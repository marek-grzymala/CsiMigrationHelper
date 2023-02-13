using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms; // get rid of it and replace MessageBox by throw new Exception
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Text;

namespace CsiMigrationHelper
{
    public class DbUtil : IDisposable
    {
        private SqlConnection con;
        private string conStr;

        public DbUtil()
        {
            //this.connectionString = connectionString;
        }

        public DbUtil(string connectionString)
        {
            this.conStr = connectionString;
        }

        public ConnectionState GetConnectionState()
        {
            return con.State;
        }
        
        public string GetConnectionString()
        {
            return this.conStr;
        }
        public void SetConnectionString(string connectionString)
        {
            this.conStr = connectionString;
        }

        public string GetDataSource()
        {
            return this.con.DataSource.ToString();
        }
        public string GetDatabase()
        {
            return this.con.Database.ToString();
        }
        public string GetUserID()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(this.con.ConnectionString);
            return builder.UserID.ToString();
        }

        public bool ParseSql(TreeNode<DbObject> instanceNode, string sql)
        {
            using (instanceNode.Data.Dbu)
            {
                instanceNode.Data.Dbu.OpenConnection();
                {
                    var parser = new TSql160Parser(true); //sql server 2022 parser
                    IList<ParseError> errorList;
                    var reader = new StringReader(sql);
                    var res = parser.Parse(reader, out errorList);

                    if (errorList.Count > 0)
                    {
                        //return false;
                        var errorMsg = string.Empty;
                        foreach (var error in errorList)
                        {
                            errorMsg += error.Message + " Error Line: " + error.Line + " Position: " + error.Offset + "; ";
                        }
                        //Console.WriteLine(errorMsg);
                        throw new ExceptionSqlParseError(errorMsg);
                    }
                    else
                    {
                        //Console.WriteLine(string.Concat("Successfully parsed: ", Environment.NewLine, sql));
                        EventLog.AppendLog(string.Concat("Successfully parsed: ", Environment.NewLine, sql));
                    }
                }
                instanceNode.Data.Dbu.CloseConnection();
            }
            return true;
        }

        public bool ExecuteSql(TreeNode<DbObject> instanceNode, string sql, string customMsgOnError)
        {
            using (instanceNode.Data.Dbu)
            {
                instanceNode.Data.Dbu.OpenConnection();
                {
                    SqlCommand cmd = new SqlCommand(sql, con);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        instanceNode.Data.Dbu.CloseConnection();
                        EventLog.AppendLog(string.Concat("Successfully executed: ", Environment.NewLine, sql));
                        return true;
                    }
                    catch (Exception ex)
                    {
                        instanceNode.Data.Dbu.CloseConnection();
                        cmd.Dispose();
                        throw new ExceptionSqlExecError(ex.Message, customMsgOnError);
                    }
                    finally
                    {
                        cmd.Dispose();
                    }
                }
            }
        }

        public DataSetForGui GetDataSetForGui(TreeNode<DbObject> instanceNode, TreeNode<DbObject> childNode, string dsOptions)
        {
            DataSetForGui dataSetForGui = null;
            using (instanceNode.Data.Dbu)
            {
                instanceNode.Data.Dbu.OpenConnection();
                ParamSelector dsParams = new ParamSelector(childNode, dsOptions);
                DataSet ds = PopulateDataSet(dsParams, dsOptions);
                dataSetForGui = new DataSetForGui(ds, dsParams);
                instanceNode.Data.Dbu.CloseConnection();
            }
            return dataSetForGui;
        }

        private DataSet PopulateDataSet(ParamSelector ps, string dsOptions)
        {
            string displayMember = ps.ParamMetaData.DisplayMember;
            string selectedText = ps.ParamMetaData.SelectedText;
            string parametersUsed = string.Empty;

            if (ps.SqlParamList.Count > 0)
            {
                parametersUsed = "Matching parameter(s): " + Environment.NewLine;
                foreach (SqlParameter p in ps.SqlParamList)
                {
                    if (p != null)
                    {
                        parametersUsed += string.Concat(p.ParameterName, " = ", p.Value, Environment.NewLine);
                    }
                }
            }
            string errorMsg = string.Concat(ps.ParamMetaData.ErrorMsgIfNoneFound, Environment.NewLine, 
                "For Branch: [", ps.BranchName, "]", Environment.NewLine,
                "On SQL Instance: [", con.DataSource, "]", Environment.NewLine, 
                "In database: [",  con.Database, "]", Environment.NewLine, parametersUsed);
            
            DataSet ds = GetDataSet(ps.SqlQueryText, ps.SqlParamList);
            
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (dsOptions == null)
                {
                    DataRow dr = ds.Tables[0].NewRow();
                    dr[displayMember] = selectedText;
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                }
            }
            else
            {
                if (dsOptions == null || (dsOptions != null && !dsOptions.Equals("ConstraintDefinition")))
                {
                    throw new ExceptionEmptyResultSet(errorMsg);
                }
            }
            return ds;
        }

        public int OpenConnection()
        {
            int result = -1;

            if (con != null && (con.State == ConnectionState.Open))
            {
                result = 0;
            }
            if (con == null || (con.State != ConnectionState.Open))
            {
                this.con = new SqlConnection(this.conStr);
                try
                {
                    con.Open();
                    if (con != null && (con.State == ConnectionState.Open))
                    {
                        result = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return result;
        }

        public void ChangeConnection(string newDbName)
        {
            OpenConnection();
            try
            {
                this.con.ChangeDatabase(newDbName);
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(con.ConnectionString);
                builder.InitialCatalog = newDbName;
                this.SetConnectionString(builder.ConnectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void CloseConnection()
        {
            if (con != null && (con.State != ConnectionState.Closed))
            { 
                con.Close();
            }
        }
        public SqlConnection GetConnection()
        {
            return con;
        }

        public DataTable GetDataTable(string SQL)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(SQL, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                OpenConnection();
                da.SelectCommand = cmd;
                da.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ds.Dispose();
                da.Dispose();
            }
            finally
            {
                ds.Dispose();
                da.Dispose();
            }
            con.Dispose();
            this.Dispose();
            return dt;
        }


        public DataSet GetDataSet(string sql, List<SqlParameter> sqlParamList)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Clear();

            foreach (SqlParameter p in sqlParamList)
            {
                if (p != null)
                {
                    cmd.Parameters.Add(p);
                }
            }

            try
            {
                OpenConnection();
                adp.SelectCommand = cmd;
                adp.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                adp.Dispose();
                cmd.Dispose();
            }
            finally
            {
                adp.Dispose();
                cmd.Dispose();
            }
            con.Dispose();
            this.Dispose();
            return ds;
        }

        public Boolean ExecuteReader(string sql)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                //cmd.ExecuteNonQuery();
                cmd.ExecuteReader();
                return true;
            }
            catch
            {
                cmd.Dispose();
                return false;
            }
            finally
            {
                cmd.Dispose();
            }
        }

        // Implementing IDisposable method:
        public void Dispose()
        {
            CloseConnection();
            //this.Dispose();
        }
    }
}
