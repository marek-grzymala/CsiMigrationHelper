using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CsiMigrationHelper
{
    public class TgtTblMetaDataHandler
    {
        public EventArgsTgtTblMetadata e { get; set; }
        private string CreateTable;
        private string CreateConstraints;

        public TgtTblMetaDataHandler()
        {
        }
        public TgtTblMetaDataHandler(EventArgsTgtTblMetadata _e)
        {
            e = _e;
            e.BtnReload.Click += new EventHandler(OnBtnReloadClick);
            e.BtnCheckSyntax.Click += new EventHandler(OnBtnCheckSyntaxClick);
            e.BtnExecute.Click += new EventHandler(OnBtnExecuteClick);
            e.GridColList.CellValueChanged += new DataGridViewCellEventHandler(OnGridCurrentCellValueChanged);
            e.GridConstraintList.CellValueChanged += new DataGridViewCellEventHandler(OnGridCurrentCellValueChanged);
        }

        protected virtual void OnBtnReloadClick(object sender, EventArgs ea)
        {
            if (LoadGrids())
            {
                e.BtnReload.Image = e.ImageList1.Images[0];
            }
            else
            {
                e.BtnReload.Image = e.ImageList1.Images[1];
            }
        }

        protected virtual void OnBtnCheckSyntaxClick(object sender, EventArgs ea)
        {
            if (CheckSqlSyntax())
            {
                e.BtnCheckSyntax.Image = e.ImageList1.Images[0];
            }
            else
            {
                e.BtnCheckSyntax.Image = e.ImageList1.Images[1];
            }
        }

        protected virtual void OnBtnExecuteClick(object sender, EventArgs ea)
        {
            if (ExecuteCreateTbl())
            {
                e.BtnExecute.Image = e.ImageList1.Images[0];
            }
            else
            {
                e.BtnExecute.Image = e.ImageList1.Images[1];
            }
        }

        protected virtual void OnGridCurrentCellValueChanged(object sender, DataGridViewCellEventArgs ea)
        {
            e.BtnExecute.Enabled = false;
        }

        public bool LoadGrids()
        {
            bool result = false;
            if (e.TgtTable.CloneableFromSrc && e.TgtTable.Enabled && e.TgtTable.Data.ObjectText.Length > 0)
            {
                TreeNode<DbObject> instanceNode = e.SrcColumn.TraverseUpUntil(e.SrcColumn, (int)DbObjectLevel.Instance);
                
                if (instanceNode.Data.Dbu.GetConnection() != null)
                {
                    string dsOption = string.Empty;
                    string tgtColNameSuffix = Options.suffixTgtColName;
                    DataSetForGui dsColumnList = new DataSetForGui();
                    DataSetForGui dsConstraintList = new DataSetForGui();
                    try
                    {
                        dsOption = Options.translateUserDefinedDataTypes ? "TableDefinitionTranslateUserTypes" : "TableDefinition";
                        dsColumnList = instanceNode.Data.Dbu.GetDataSetForGui(instanceNode, e.SrcColumn, dsOption);                                      
                        
                        if (dsColumnList != null)
                        {
                            e.GridColList.DataSource = dsColumnList.Ds;
                            e.GridColList.DataMember = dsColumnList.Ds.Tables["Table"].TableName;
                            e.GridColList.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            e.GridColList.Columns["ColumnName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            e.GridColList.Columns["ColumnDefinition"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            e.GridColList.Columns["Id"].ValueType = typeof(int);
                            e.GridColList.Sort(e.GridColList.Columns["Id"], System.ComponentModel.ListSortDirection.Ascending);                    
                            e.TbxTgtTableName.Text = "[" + e.TgtTable.Parent.Data.ObjectText + "].[" + e.TgtTable.Data.ObjectText + "]";
                        }
                    }
                    catch (ExceptionEmptyResultSet ex)
                    {
                        MessageBox.Show(string.Concat("Exception in method LoadGrids() when populating list of column list of table: ", e.TgtTable.Data.ObjectText, ex.Message));
                    }

                    try
                    {               
                        dsOption = "ConstraintDefinition";
                        dsConstraintList = instanceNode.Data.Dbu.GetDataSetForGui(instanceNode, e.SrcColumn, dsOption);
                        
                        if (dsConstraintList != null)
                        {
                            e.GridConstraintList.DataSource = dsConstraintList.Ds;
                            e.GridConstraintList.DataMember = dsConstraintList.Ds.Tables["Table"].TableName;

                            if (e.TgtTable.Data.ObjectName.Equals("tgtTable_Archive") && e.TgtIndex.Data.ObjectText.Length > 0)
                            {
                                if (Options.makeCSIClustered == true)
                                {
                                    this.RenameDataSetFieldValue(dsConstraintList.Ds, "ConstraintType", " CLUSTERED", "", 0, false);
                                }
                                DataRow dr = dsConstraintList.Ds.Tables[0].NewRow();
                                //CSI Index has to be before the PK (if there is a seperate one), so let's put it as the first on the list just in case:
                                dr["Id"] = 0; // dsConstraintList.Ds.Tables["Table"].Rows.Count + 1;
                                dr["ConstraintName"] = "[" + e.TgtIndex.Data.ObjectText + "]";
                                dr["Type"] = "IX";
                                dr["ConstraintType"] = string.Concat(Options.makeCSIClustered == true ? "CLUSTERED " : "", "COLUMNSTORE");
                                dr["ColumnList"] = "";
                                dr["ConstraintDefinition"] = "";
                                dsConstraintList.Ds.Tables[0].Rows.Add(dr);
                            }
                            
                            this.RenameDataSetFieldValue(dsConstraintList.Ds, "ConstraintName", e.SrcTable.Data.ObjectText, e.TgtTable.Data.ObjectText, 0, false);

                            e.GridConstraintList.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            e.GridConstraintList.Columns["ConstraintName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            e.GridConstraintList.Columns["Type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            e.GridConstraintList.Columns["ConstraintType"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            e.GridConstraintList.Columns["ColumnList"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            e.GridConstraintList.Columns["ConstraintDefinition"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;                
                            e.GridConstraintList.Columns["Id"].ValueType = typeof(int);
                            e.GridConstraintList.Sort(e.GridConstraintList.Columns["Id"], System.ComponentModel.ListSortDirection.Ascending);                    

                            if (Options.renameTgtColumns == true)
                            {
                                this.RenameDataSetFieldValue(dsColumnList.Ds, "ColumnName", e.SrcTable.Data.ObjectText, string.Concat(e.TgtTable.Data.ObjectText, Options.suffixTgtColName), 0, true);
                                this.RenameDataSetFieldValue(dsConstraintList.Ds, "ColumnList", e.SrcTable.Data.ObjectText, string.Concat(e.TgtTable.Data.ObjectText, Options.suffixTgtColName), 0, true);
                                this.RenameDataSetFieldValue(dsConstraintList.Ds, "ConstraintDefinition", e.SrcTable.Data.ObjectText, string.Concat(e.TgtTable.Data.ObjectText, Options.suffixTgtColName), 0, true, "ConstraintType = 'CHECK'");
                            }
                            e.GridColList.Update();
                            e.GridConstraintList.Update();

                            e.BtnCheckSyntax.Image = null;
                            e.BtnCheckSyntax.Enabled = true;

                            e.BtnExecute.Image = null;
                            e.BtnExecute.Enabled = false;
                            result = true;
                        }
                    }
                    catch (ExceptionEmptyResultSet ex)
                    {
                        MessageBox.Show(string.Concat("No results found when populating list of constraints of table: ", e.TgtTable.Data.ObjectText, ex.Message));
                    }
                }
                else
                {
                    MessageBox.Show(string.Concat("Connection: ", e.TgtInstance.Data.ObjectName, " not initialized"), "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                }
            }
            else
            {
                e.GridColList.DataSource = null;
                e.GridConstraintList.DataSource = null;                
                e.BtnCheckSyntax.Image = null;
                e.BtnCheckSyntax.Enabled = false;
                e.BtnExecute.Image = null;
                e.BtnExecute.Enabled = false;                
            }
            return result;
        }

        public void RenameDataSetFieldValue(DataSet ds, string fieldName, string patternToMatch, string replacement, int matchMode, bool caseSensitive)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {                
                if (dr["Type"].Equals("IX") && dr["ConstraintType"].ToString().Contains("COLUMNSTORE"))
                {
                    // do not rename the Tgt Archive CSI Index (has to be exactly as in the TreeNode object because it is being referenced later)
                }
                else
                {
                    if (dr.Field<String>(fieldName).Length > 0 && RegexUtil.FindSubstringMatchingPattern(dr.Field<String>(fieldName)
                        , patternToMatch, matchMode, caseSensitive).Length > 0)
                    {
                        dr.BeginEdit();
                        dr[fieldName] = RegexUtil.ReplaceSubstringMatchingPattern(dr.Field<String>(fieldName), patternToMatch, replacement, matchMode, caseSensitive);
                        dr.EndEdit();
                    }
                }
            }
        }

        public void RenameDataSetFieldValue(DataSet ds, string fieldName, string patternToMatch, string replacement, int matchMode, bool caseSensitive, string filter)
        {
            foreach (DataRow dr in ds.Tables[0].Select(filter))
            {
                if (dr.Field<String>(fieldName).Length > 0 && RegexUtil.FindSubstringMatchingPattern(dr.Field<String>(fieldName)
                    , patternToMatch, matchMode, caseSensitive).Length > 0)
                {
                    dr.BeginEdit();
                    dr[fieldName] = RegexUtil.ReplaceSubstringMatchingPattern(dr.Field<String>(fieldName), patternToMatch, replacement, matchMode, caseSensitive);
                    dr.EndEdit();
                }
            }
        }

        public bool CheckSqlSyntax()
        {
            bool result = false;

            StringBuilder sbCreateTbl = new StringBuilder("CREATE TABLE " + e.TbxTgtTableName.Text + Environment.NewLine + "(");
            foreach (DataGridViewRow row in e.GridColList.Rows)
            {
                sbCreateTbl.Append(string.Concat(row.Index > 0 && row.Index < e.GridColList.Rows.Count - 1 ? Environment.NewLine + ", " : " "
                    , row.Cells["ColumnName"].Value, " ", row.Cells["ColumnDefinition"].Value));
            }
            sbCreateTbl.Append(string.Concat(Environment.NewLine, ")"
                , e.TgtPartitionScheme.Data.ObjectText.Length > 0 ? " ON ["+ e.TgtPartitionScheme+ "](["+ e.TgtColumn+ "]);" :  ";"));
            CreateTable = sbCreateTbl.ToString();
            
            StringBuilder sbAddConstr = new StringBuilder();

            //e.GridConstraintList.Sort(e.GridConstraintList.Columns["Id"], System.ComponentModel.ListSortDirection.Ascending);
            foreach (DataGridViewRow row in e.GridConstraintList.Rows)
            {
                if (row.Cells["Type"].Value != null)
                {
                    StringBuilder sbColumnList = new StringBuilder();
                    StringBuilder sbConstraintDefinition = new StringBuilder();
                    switch (row.Cells["Type"].Value.ToString().Trim())
                    {
                        case "PK":
                            sbColumnList.Append(row.Cells["ColumnList"].Value);
                            //we have to add the partitioning column to the PK:
                            sbColumnList.Append(row.Cells["ColumnList"].Value.ToString().Contains(e.TgtColumn.Data.ObjectText) ? "" 
                                : string.Concat(", [", e.TgtColumn.Data.ObjectText, "] ASC"));
                            sbAddConstr.Append(string.Concat(Environment.NewLine, "ALTER TABLE ", e.TbxTgtTableName.Text
                                , " ADD CONSTRAINT ", row.Cells["ConstraintName"].Value, " ", row.Cells["ConstraintType"].Value
                                , " (", sbColumnList, ");"));
                            break;

                        case "D":
                            sbAddConstr.Append(string.Concat(Environment.NewLine, "ALTER TABLE ", e.TbxTgtTableName.Text
                                , " ADD CONSTRAINT ", row.Cells["ConstraintName"].Value, " ", row.Cells["ConstraintType"].Value, " "
                                , row.Cells["ConstraintDefinition"].Value
                                , " FOR ", row.Cells["ColumnList"].Value, ";"));
                            break;

                        case "C":
                            sbAddConstr.Append(string.Concat(Environment.NewLine, "ALTER TABLE ", e.TbxTgtTableName.Text
                                , " ADD CONSTRAINT ", row.Cells["ConstraintName"].Value, " ", row.Cells["ConstraintType"].Value, " "
                                , row.Cells["ConstraintDefinition"].Value));
                            break;

                        case "F":
                            if ((!e.SrcInstance.Data.ObjectText.Equals(e.TgtInstance.Data.ObjectText) 
                                || !e.SrcDatabase.Data.ObjectText.Equals(e.TgtDatabase.Data.ObjectText))
                               && Options.doNotCreateFKsOnCrossDbTarget == true)                               
                            {
                                e.GridConstraintList.Rows[row.Index].DefaultCellStyle.ForeColor = Color.Red;
                                e.GridConstraintList.Update();
                                break;
                            }
                            else
                            {
                                e.GridConstraintList.Rows[row.Index].DefaultCellStyle.ForeColor = Color.Black;
                                e.GridConstraintList.Update();
                                sbAddConstr.Append(string.Concat(Environment.NewLine, "ALTER TABLE ", e.TbxTgtTableName.Text
                                    , " WITH CHECK ADD CONSTRAINT ", row.Cells["ConstraintName"].Value, " ", row.Cells["ConstraintType"].Value
                                    , "(", row.Cells["ColumnList"].Value, ") ", row.Cells["ConstraintDefinition"].Value));
                                break;
                            }

                        case "IX":
                            sbColumnList.Append(row.Cells["ColumnList"].Value);
                            sbConstraintDefinition.Append(row.Cells["ConstraintDefinition"].Value);
                            if (row.Cells["ConstraintType"].Value.ToString().Contains("UNIQUE"))
                            {
                                sbColumnList.Append(row.Cells["ColumnList"].Value.ToString().Contains(e.TbxTgtTableName.Text) ? "" 
                                    : string.Concat(", [", e.TgtColumn.Data.ObjectText, "] ASC"));
                            }
                            sbAddConstr.Append(string.Concat(Environment.NewLine, "CREATE ", row.Cells["ConstraintType"].Value
                                , " INDEX ", row.Cells["ConstraintName"].Value
                                , " ON " + e.TbxTgtTableName.Text
                                // on SQL 2019 a columnstore index does not accept a list of columns, so we need to remove that list:
                                , row.Cells["ConstraintType"].Value.ToString().Contains("COLUMNSTORE") ? ";" 
                                : string.Concat("(", sbColumnList, ") ", sbConstraintDefinition, ";")));
                            break;

                        default:
                            throw new Exception("Method BuildSqlCmd() TgtTblMetaDataHandler in received an unhandled Constraint Type: " 
                                + row.Cells["Type"].Value.ToString().Trim());
                    }                                
                }
            }
            CreateConstraints = sbAddConstr.ToString();
            try
            {
                if (e.TgtInstance.Data.Dbu.ParseSql(e.TgtInstance, string.Concat(CreateTable, Environment.NewLine, CreateConstraints)))
                {
                    e.BtnExecute.Image = null;
                    e.BtnExecute.Enabled = true;
                    result = true;
                }
            }
            catch (ExceptionSqlParseError ex)
            {
                e.BtnExecute.Image = null;
                e.BtnExecute.Enabled = false;
                result = false;
            }
            return result;
        }

        public bool ExecuteCreateTbl()
        {
            try
            {
                return e.TgtInstance.Data.Dbu.ExecuteSql(e.TgtInstance
                    , string.Concat(CreateTable, Environment.NewLine, CreateConstraints)
                    , "Error Creating Table");
            }
            catch (ExceptionSqlExecError ex)
            {
                // for now do nothing
                return false;
            }
        }
    }
}
