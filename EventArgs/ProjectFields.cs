using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsiMigrationHelper
{
    public class ProjectFields
    {

        public string SrcInstance;
        public string SrcDatabase;
        public string SrcSchema;
        public string SrcTable;
        public string SrcColumn;
        public string SrcDataType;
        public string SrcIndex;
        public string SrcSynonym;

        public string TgtInstance;
        public string TgtDatabase;
        public string TgtCurrentSchema;
        public string TgtCurrentTable;
        public string TgtStagingSchema;
        public string TgtStagingTable;
        public string TgtArchiveSchema;
        public string TgtArchiveTable;
        public string TgtColumn;
        public string TgtDataType;
        public string TgtPartitionScheme;
        public string TgtIndex;
        public string TgtSynonym;
        public string TrackSynonymProjects;
        public string TrackSynonymMigrationTrck;

        
        public ProjectFields()
        {

        }
        
        
        public ProjectFields(

                                string srcInstance,
                                string srcDatabase,
                                string srcSchema,
                                string srcTable,
                                string srcColumn,
                                string srcDataType,
                                string srcIndex,
                                string tgtInstance,
                                string tgtDatabase,
                                string tgtCurrentSchema,
                                string tgtCurrentTable,
                                string tgtStagingSchema,
                                string tgtStagingTable,
                                string tgtArchiveSchema,
                                string tgtArchiveTable,
                                string tgtColumn,
                                string tgtDataType,
                                string tgtPartitionScheme,
                                string tgtArchiveTableCSIndex
                             )
        {
            SrcInstance = srcInstance;
            SrcDatabase = srcDatabase;
            SrcSchema = srcSchema;
            SrcTable = srcTable;
            SrcColumn = srcColumn;
            SrcDataType = srcDataType;
            SrcIndex = srcIndex;
            TgtInstance = tgtInstance;
            TgtDatabase = tgtDatabase;
            TgtCurrentSchema = tgtCurrentSchema;
            TgtCurrentTable = tgtCurrentTable;
            TgtStagingSchema = tgtStagingSchema;
            TgtStagingTable = tgtStagingTable;
            TgtArchiveSchema = tgtArchiveSchema;
            TgtArchiveTable = tgtArchiveTable;
            TgtColumn = tgtColumn;
            TgtDataType = tgtDataType;
            TgtPartitionScheme = tgtPartitionScheme;
            TgtIndex = tgtArchiveTableCSIndex;
        }

        public bool SetProjectFileds(

                                string srcInstance,
                                string srcDatabase,
                                string srcSchema,
                                string srcTable,
                                string srcColumn,
                                string srcDataType,
                                string srcIndex,
                                string tgtInstance,
                                string tgtDatabase,
                                string tgtCurrentSchema,
                                string tgtCurrentTable,
                                string tgtStagingSchema,
                                string tgtStagingTable,
                                string tgtArchiveSchema,
                                string tgtArchiveTable,
                                string tgtColumn,
                                string tgtDataType,
                                string tgtPartitionScheme,
                                string tgtArchiveTableCSIndex)
        {
            bool result = false;

            SrcInstance = srcInstance;
            SrcDatabase = srcDatabase;
            SrcSchema = srcSchema;
            SrcTable = srcTable;
            SrcColumn = srcColumn;
            SrcDataType = srcDataType;
            SrcIndex = srcIndex;
            TgtInstance = tgtInstance;
            TgtDatabase = tgtDatabase;
            TgtCurrentSchema = tgtCurrentSchema;
            TgtCurrentTable = tgtCurrentTable;
            TgtStagingSchema = tgtStagingSchema;
            TgtStagingTable = tgtStagingTable;
            TgtArchiveSchema = tgtArchiveSchema;
            TgtArchiveTable = tgtArchiveTable;
            TgtColumn = tgtColumn;
            TgtDataType = tgtDataType;
            TgtPartitionScheme = tgtPartitionScheme;
            TgtIndex = tgtArchiveTableCSIndex;

            return result;
        }

        
        
        public int RunUspGetProjectSettingsByProjectName(string projectName, EventArgsMigrationTracking e)
        {
            try
            {
                List<SqlParameter> sqlParamList = new List<SqlParameter>();
                SqlParameter p_ProjectName = new SqlParameter()
                {
                    ParameterName = "@ProjectName",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000,
                    Value = projectName
                };
                sqlParamList.Add(p_ProjectName);

                SqlParameter p_SrcInstance = new SqlParameter()
                {
                    ParameterName = "@SrcInstance",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_SrcInstance.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_SrcInstance);

                SqlParameter p_SrcDatabase = new SqlParameter()
                {
                    ParameterName = "@SrcDatabase",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_SrcDatabase.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_SrcDatabase);

                SqlParameter p_SrcSchema = new SqlParameter()
                {
                    ParameterName = "@SrcSchema",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_SrcSchema.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_SrcSchema);

                SqlParameter p_SrcTable = new SqlParameter()
                {
                    ParameterName = "@SrcTable",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_SrcTable.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_SrcTable);

                SqlParameter p_SrcColumn = new SqlParameter()
                {
                    ParameterName = "@SrcColumn",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_SrcColumn.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_SrcColumn);

                SqlParameter p_SrcDataType = new SqlParameter()
                {
                    ParameterName = "@SrcDataType",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_SrcDataType.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_SrcDataType);

                SqlParameter p_SrcIndex = new SqlParameter()
                {
                    ParameterName = "@SrcIndex",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_SrcIndex.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_SrcIndex);


                SqlParameter p_SrcSynonym = new SqlParameter()
                {
                    ParameterName = "@SrcSynonym",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_SrcSynonym.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_SrcSynonym);

                SqlParameter p_TgtInstance = new SqlParameter()
                {
                    ParameterName = "@TgtInstance",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TgtInstance.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TgtInstance);

                SqlParameter p_TgtDatabase = new SqlParameter()
                {
                    ParameterName = "@TgtDatabase",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TgtDatabase.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TgtDatabase);

                SqlParameter p_TgtCurrentSchema = new SqlParameter()
                {
                    ParameterName = "@TgtCurrentSchema",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TgtCurrentSchema.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TgtCurrentSchema);

                SqlParameter p_TgtCurrentTable = new SqlParameter()
                {
                    ParameterName = "@TgtCurrentTable",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TgtCurrentTable.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TgtCurrentTable);

                SqlParameter p_TgtStagingSchema = new SqlParameter()
                {
                    ParameterName = "@TgtStagingSchema",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TgtStagingSchema.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TgtStagingSchema);

                SqlParameter p_TgtStagingTable = new SqlParameter()
                {
                    ParameterName = "@TgtStagingTable",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TgtStagingTable.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TgtStagingTable);

                SqlParameter p_TgtArchiveSchema = new SqlParameter()
                {
                    ParameterName = "@TgtArchiveSchema",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TgtArchiveSchema.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TgtArchiveSchema);

                SqlParameter p_TgtArchiveTable = new SqlParameter()
                {
                    ParameterName = "@TgtArchiveTable",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TgtArchiveTable.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TgtArchiveTable);

                SqlParameter p_TgtColumn = new SqlParameter()
                {
                    ParameterName = "@TgtColumn",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TgtColumn.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TgtColumn);

                SqlParameter p_TgtDataType = new SqlParameter()
                {
                    ParameterName = "@TgtDataType",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TgtDataType.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TgtDataType);

                SqlParameter p_TgtPartitionScheme = new SqlParameter()
                {
                    ParameterName = "@TgtPartitionScheme",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TgtPartitionScheme.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TgtPartitionScheme);

                SqlParameter p_TgtIndex = new SqlParameter()
                {
                    ParameterName = "@TgtIndex",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TgtIndex.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TgtIndex);

                SqlParameter p_TgtSynonym = new SqlParameter()
                {
                    ParameterName = "@TgtSynonym",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TgtSynonym.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TgtSynonym);

                SqlParameter p_TrackSynonymProjects = new SqlParameter()
                {
                    ParameterName = "@TrackSynonymProjects",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TrackSynonymProjects.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TrackSynonymProjects);

                SqlParameter p_TrackSynonymMigrationTrck = new SqlParameter()
                {
                    ParameterName = "@TrackSynonymMigrationTrck",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000
                };
                p_TrackSynonymMigrationTrck.Direction = ParameterDirection.Output;
                sqlParamList.Add(p_TrackSynonymMigrationTrck);

                e.InstanceNode.Data.Dbu.ExecuteSqlUspOutParams(e.InstanceNode, string.Concat(e.SchemaName, ".", "[usp_GetProjectSettingsFrom_", e.SchemaName, "_", e.TableName, "]")
                                                              , string.Concat("Error Executing: ", e.SchemaName, ".", "[usp_GetProjectSettingsFrom_", e.SchemaName, "_", e.TableName, "]")
                                                              , sqlParamList);

                SrcInstance = p_SrcInstance.Value.ToString();
                SrcDatabase = p_SrcDatabase.Value.ToString();
                SrcSchema = p_SrcSchema.Value.ToString();
                SrcTable = p_SrcTable.Value.ToString();
                SrcColumn = p_SrcColumn.Value.ToString();
                SrcDataType = p_SrcDataType.Value.ToString();
                SrcIndex = p_SrcIndex.Value.ToString();
                SrcSynonym = p_SrcSynonym.Value.ToString();
                TgtInstance = p_TgtInstance.Value.ToString();
                TgtDatabase = p_TgtDatabase.Value.ToString();
                TgtCurrentSchema = p_TgtCurrentSchema.Value.ToString();
                TgtCurrentTable = p_TgtCurrentTable.Value.ToString();
                TgtStagingSchema = p_TgtStagingSchema.Value.ToString();
                TgtStagingTable = p_TgtStagingTable.Value.ToString();
                TgtArchiveSchema = p_TgtArchiveSchema.Value.ToString();
                TgtArchiveTable = p_TgtArchiveTable.Value.ToString();
                TgtColumn = p_TgtColumn.Value.ToString();
                TgtDataType = p_TgtDataType.Value.ToString();
                TgtPartitionScheme = p_TgtPartitionScheme.Value.ToString();
                TgtIndex = p_TgtIndex.Value.ToString();
                TgtSynonym = p_TgtSynonym.Value.ToString();
                TrackSynonymProjects = p_TrackSynonymProjects.Value.ToString();
                TrackSynonymMigrationTrck = p_TrackSynonymMigrationTrck.Value.ToString();

                return 1;
            }
            catch (ExceptionSqlExecError ex)
            {
                // for now do nothing
                return 0;
            }
        }
    }
}
