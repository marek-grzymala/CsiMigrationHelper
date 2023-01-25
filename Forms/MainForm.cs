using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace CsiMigrationHelper
{
    public partial class MainForm : Form
    {

        private TreeNode<DbObject> root;
        private TreeNode<DbObject> srcInstance;
        private TreeNode<DbObject> srcDatabase;
        private TreeNode<DbObject> srcSchema;
        private TreeNode<DbObject> srcTable;
        private TreeNode<DbObject> srcColumn;
        private TreeNode<DbObject> srcDataType;
        private TreeNode<DbObject> srcPartitionScheme;
        private TreeNode<DbObject> srcIndex;

        private TreeNode<DbObject> tgtInstance;
        private TreeNode<DbObject> tgtDatabase;
        private TreeNode<DbObject> tgtSchema_Current;
        private TreeNode<DbObject> tgtSchema_Staging;
        private TreeNode<DbObject> tgtSchema_Archive;
        private TreeNode<DbObject> tgtTable_Current;
        private TreeNode<DbObject> tgtTable_Staging;
        private TreeNode<DbObject> tgtTable_Archive;
        private TreeNode<DbObject> tgtColumn;
        private TreeNode<DbObject> tgtDataType;
        private TreeNode<DbObject> tgtPartitionScheme;
        private TreeNode<DbObject> tgtIndex;

        private DbUtil Src = new DbUtil();
        private DbUtil Tgt = new DbUtil();
        private SrcTgtSelectionHandler SrcTgtHdlr = new SrcTgtSelectionHandler();
        private TgtTblMetaDataHandler TgtMtdHdlr_Current = new TgtTblMetaDataHandler();
        private TgtTblMetaDataHandler TgtMtdHdlr_Staging = new TgtTblMetaDataHandler();
        private TgtTblMetaDataHandler TgtMtdHdlr_Archive = new TgtTblMetaDataHandler();
        private EventLog elg;



        public MainForm()
        {
            InitializeComponent();

            #region init            

            root = new TreeNode<DbObject>(new DbObject(DbObjectBranch.Root, DbObjectLevel.Root, "Root", "---------------------- Root Node ----------------------", null));

            srcInstance = root.AddChild(new DbObject(DbObjectBranch.Src, DbObjectLevel.Instance, "srcInstance", string.Empty, new GuiElem(tbxInstanceSrc), Src));
            {
                srcDatabase = srcInstance.AddChild(new DbObject(DbObjectBranch.Src, DbObjectLevel.Database, "srcDatabase", string.Empty, new GuiElem(cbx_dbList_Src)));
                {
                    srcSchema = srcDatabase.AddChild(new DbObject(DbObjectBranch.Src, DbObjectLevel.Schema, "srcSchema", string.Empty, new GuiElem(cbx_schList_Src)));
                    {
                        srcTable = srcSchema.AddChild(new DbObject(DbObjectBranch.Src, DbObjectLevel.Table, "srcTable", string.Empty, new GuiElem(cbx_tbList_Src)));
                        {
                            srcColumn = srcTable.AddChild(new DbObject(DbObjectBranch.Src, DbObjectLevel.Column, "srcColumn", string.Empty, new GuiElem(cbx_colList_Src)));
                            {
                                srcDataType = srcColumn.AddChild(new DbObject(DbObjectBranch.Src, DbObjectLevel.DataType, "srcDataType", string.Empty, new GuiElem(tbx_DataType_Src)));
                                {
                                    srcPartitionScheme = srcDataType.AddChild(new DbObject(DbObjectBranch.Src, DbObjectLevel.PartitionScheme, "srcPartitionScheme", string.Empty, null));
                                    srcPartitionScheme.IsDummyNode = true;
                                    {
                                        srcIndex = srcPartitionScheme.AddChild(new DbObject(DbObjectBranch.Src, DbObjectLevel.Index, "srcIndex", string.Empty, new GuiElem(cbx_idxList_Src)));
                                    }
                                }
                            }
                        }
                    }
                }
            }

            tgtInstance = root.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Instance, "tgtInstance", string.Empty, new GuiElem(tbxInstanceTgt), Tgt));
            {
                tgtDatabase = tgtInstance.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Database, "tgtDatabase", string.Empty, new GuiElem(cbx_dbList_Tgt)));
                {
                    tgtSchema_Current = tgtDatabase.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Schema, "tgtSchema_Current", string.Empty, new GuiElem(cbx_schList_Tgt_Current)));
                    {
                        tgtTable_Current = tgtSchema_Current.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Table, "tgtTable_Current", string.Empty, new GuiElem(cbx_tbList_Tgt_Current)));
                        tgtTable_Current.CloneableFromSrc = rdbtn_Current_Clone.Checked ? true : false;
                        tgtTable_Current.AddCousin(srcTable, srcTable.CloneableFromSrc);
                        srcTable.AddCousin(tgtTable_Current, tgtTable_Current.CloneableFromSrc);
                    }

                    tgtSchema_Staging = tgtDatabase.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Schema, "tgtSchema_Staging", string.Empty, new GuiElem(cbx_schList_Tgt_Staging)));
                    {
                        tgtTable_Staging = tgtSchema_Staging.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Table, "tgtTable_Staging", string.Empty, new GuiElem(cbx_tbList_Tgt_Staging)));
                        tgtTable_Staging.CloneableFromSrc = rdbtn_Staging_Clone.Checked ? true : false;
                        tgtTable_Staging.AddCousin(srcTable, srcTable.CloneableFromSrc);
                        srcTable.AddCousin(tgtTable_Staging, tgtTable_Staging.CloneableFromSrc);
                    }

                    tgtSchema_Archive = tgtDatabase.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Schema, "tgtSchema_Archive", string.Empty, new GuiElem(cbx_schList_Tgt_Archive)));
                    {
                        tgtTable_Archive = tgtSchema_Archive.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Table, "tgtTable_Archive", string.Empty, new GuiElem(cbx_tbList_Tgt_Archive)));
                        tgtTable_Archive.CloneableFromSrc = rdbtn_Archive_Clone.Checked ? true : false; // if tgtColumn.CloneableFromSrc is changed to false then this flag has to be to be changed as well
                        tgtTable_Archive.AddCousin(srcTable, srcTable.CloneableFromSrc);
                        srcTable.AddCousin(tgtTable_Archive, tgtTable_Archive.CloneableFromSrc);
                        {
                            tgtColumn = tgtTable_Archive.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Column, "tgtColumn", string.Empty, new GuiElem(cbx_colList_Tgt)));
                            tgtColumn.CloneableFromSrc = rdbtn_Archive_Clone.Checked ? true : false; // if this flag gets changed then its parent flag has to be changed as well
                            tgtColumn.AddCousin(srcColumn, srcColumn.CloneableFromSrc);
                            srcColumn.AddCousin(tgtColumn, tgtColumn.CloneableFromSrc);
                            {
                                tgtDataType = tgtColumn.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.DataType, "tgtDataType", string.Empty, new GuiElem(tbx_DataType_Tgt)));
                                tgtDataType.CloneableFromSrc = rdbtn_Archive_Clone.Checked ? true : false; // if this flag gets changed then its parent flag has to be changed as well
                                tgtDataType.AddCousin(srcDataType, srcDataType.CloneableFromSrc);
                                srcDataType.AddCousin(tgtDataType, tgtDataType.CloneableFromSrc);
                                {
                                    tgtPartitionScheme = tgtDataType.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.PartitionScheme, "tgtPartitionScheme", string.Empty, new GuiElem(cbx_psList_Tgt)));
                                    tgtPartitionScheme.CloneableFromSrc = true;
                                    //// - srcPartitionScheme.AddCousin(TreeNode<DbObject>.ConvertToDbObject(tgtPartitionScheme), tgtPartitionScheme.CloneableFromSrc); // this is redundant since srcPartitionScheme is "Dummy"
                                    {
                                        tgtIndex = tgtPartitionScheme.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Index, "tgtIndex", string.Empty, new GuiElem(cbx_idxList_Tgt)));
                                        tgtIndex.CloneableFromSrc = rdbtn_Archive_Clone.Checked ? true : false; // if this flag gets changed then its parent flag has to be changed as well
                                        tgtIndex.AddCousin(srcIndex, srcIndex.CloneableFromSrc);
                                        srcIndex.AddCousin(tgtIndex, tgtIndex.CloneableFromSrc);
                                    }
                                }
                            }
                        }
                    }
                }
            }



            {
                Options.suffixCurrent = "_Current";
                Options.suffixStaging = "_Staging";
                Options.suffixArchive = "_Archive";
                Options.prefixCSI = "CSI_";
                Options.suffixTgtColName = "_";
                Options.translateUserDefinedDataTypes = true;
                Options.doNotCreateFKsOnCrossDbTarget = true;
                Options.makeCSIClustered = true;
                Options.renameTgtColumns = false;
            }

            gridColList_Current.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(gridColList_Current, true, null);
            gridColList_Staging.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(gridColList_Staging, true, null);
            gridColList_Archive.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(gridColList_Archive, true, null);

            gridConstraintList_Current.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(gridConstraintList_Current, true, null);
            gridConstraintList_Staging.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(gridConstraintList_Staging, true, null);
            gridConstraintList_Archive.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(gridConstraintList_Archive, true, null);

            elg = new EventLog(rtbxEventLog);
            #endregion

        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------- SOURCE: --------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------


        private void buttonLoginSrc_Click(object sender, EventArgs e)
        {
            LoginForm.HandleLoginBtnClick(sender, srcInstance, SrcTgtHdlr);
        }

        private void cbx_dbList_Src_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SrcTgtHdlr.HandleGuiSelectionChange(sender, srcDatabase);
            }
            catch (ExceptionEmptyResultSet ex)
            {
                if (ex.retry)
                {
                    LoginForm.HandleLoginBtnClick(sender, srcInstance, SrcTgtHdlr);
                }
            }
        }

        private void cbx_schList_Src_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SrcTgtHdlr.HandleGuiSelectionChange(sender, srcSchema);
            }
            catch (ExceptionEmptyResultSet ex)
            {
                if (ex.retry)
                {
                    SrcTgtHdlr.HandleGuiSelectionChange(cbx_dbList_Src, srcDatabase);
                }
            }
        }

        private void cbx_tbList_Src_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SrcTgtHdlr.HandleGuiSelectionChange(sender, srcTable);
            }
            catch (ExceptionEmptyResultSet ex)
            {
                if (ex.retry)
                {
                    SrcTgtHdlr.HandleGuiSelectionChange(cbx_schList_Src, srcSchema);
                }
            }
        }

        private void cbx_colList_Src_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SrcTgtHdlr.HandleGuiSelectionChange(sender, srcColumn);
            }
            catch (ExceptionEmptyResultSet ex)
            {
                if (ex.retry)
                {
                    SrcTgtHdlr.HandleGuiSelectionChange(cbx_tbList_Src, srcTable);
                }
            }
            catch (ExceptionDataTypeMismatch ex)
            {
                if (ex.retry)
                {
                    SrcTgtHdlr.HandleGuiSelectionChange(cbx_tbList_Src, srcTable);
                }
            }
        }

        private void tbx_DataType_Src_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SrcTgtHdlr.HandleGuiSelectionChange(sender, srcDataType);
            }
            catch (ExceptionEmptyResultSet ex)
            {
                if (ex.retry)
                {
                    SrcTgtHdlr.HandleGuiSelectionChange(cbx_tbList_Src, srcTable);
                }
            }
            catch (ExceptionDataTypeMismatch ex)
            {
                if (ex.retry)
                {
                    SrcTgtHdlr.HandleGuiSelectionChange(cbx_tbList_Src, srcTable);
                }
            }
        }

        private void cbx_idxList_Src_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SrcTgtHdlr.HandleGuiSelectionChange(sender, srcIndex);
            }
            catch (ExceptionEmptyResultSet ex)
            {
                if (ex.retry)
                {
                    SrcTgtHdlr.HandleGuiSelectionChange(cbx_tbList_Src, srcTable);
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------- TARGET: --------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------

        private void buttonLoginTgt_Click(object sender, EventArgs e)
        {
            LoginForm.HandleLoginBtnClick(sender, tgtInstance, SrcTgtHdlr);
        }

        private void cbx_dbList_Tgt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SrcTgtHdlr.HandleGuiSelectionChange(sender, tgtDatabase);
            }
            catch (ExceptionEmptyResultSet ex)
            {
                if (ex.retry)
                {
                    LoginForm.HandleLoginBtnClick(sender, tgtInstance, SrcTgtHdlr);
                }
            }
        }

        private void cbx_schList_Tgt_Current_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SrcTgtHdlr.HandleGuiSelectionChange(sender, tgtSchema_Current);
            }
            catch (ExceptionEmptyResultSet ex)
            {
                if (ex.retry)
                {
                    SrcTgtHdlr.HandleGuiSelectionChange(cbx_dbList_Tgt, tgtDatabase);
                }
            }
        }

        private void cbx_schList_Tgt_Staging_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SrcTgtHdlr.HandleGuiSelectionChange(sender, tgtSchema_Staging);
            }
            catch (ExceptionEmptyResultSet ex)
            {
                if (ex.retry)
                {
                    SrcTgtHdlr.HandleGuiSelectionChange(cbx_dbList_Tgt, tgtDatabase);
                }
            }
        }

        private void cbx_schList_Tgt_Archive_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SrcTgtHdlr.HandleGuiSelectionChange(sender, tgtSchema_Archive);
            }
            catch (ExceptionEmptyResultSet ex)
            {
                if (ex.retry)
                {
                    SrcTgtHdlr.HandleGuiSelectionChange(cbx_dbList_Tgt, tgtDatabase);
                }
            }
        }

        private void cbx_tbList_Tgt_Current_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SrcTgtHdlr.HandleGuiSelectionChange(sender, tgtTable_Current);
            }
            catch (ExceptionEmptyResultSet ex)
            {
                if (ex.retry)
                {
                    SrcTgtHdlr.HandleGuiSelectionChange(cbx_schList_Tgt_Current, tgtSchema_Current);
                }
            }
        }

        private void cbx_tbList_Tgt_Staging_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SrcTgtHdlr.HandleGuiSelectionChange(sender, tgtTable_Staging);
            }
            catch (ExceptionEmptyResultSet ex)
            {
                if (ex.retry)
                {
                    SrcTgtHdlr.HandleGuiSelectionChange(cbx_schList_Tgt_Staging, tgtSchema_Staging);
                }
            }
        }

        private void cbx_tbList_Tgt_Archive_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SrcTgtHdlr.HandleGuiSelectionChange(sender, tgtTable_Archive);
            }
            catch (ExceptionEmptyResultSet ex)
            {
                if (ex.retry)
                {
                    SrcTgtHdlr.HandleGuiSelectionChange(cbx_schList_Tgt_Archive, tgtSchema_Archive);
                }
            }
        }

        private void cbx_colList_Tgt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SrcTgtHdlr.HandleGuiSelectionChange(sender, tgtColumn);
            }
            catch (ExceptionEmptyResultSet ex)
            {
                if (ex.retry)
                {
                    SrcTgtHdlr.HandleGuiSelectionChange(cbx_tbList_Tgt_Archive, tgtTable_Archive);
                }
            }
            catch (ExceptionDataTypeMismatch ex)
            {
                if (ex.retry)
                {
                    SrcTgtHdlr.HandleGuiSelectionChange(cbx_tbList_Tgt_Archive, tgtTable_Archive);
                    //SrcTgtHdlr.HandleGuiSelectionChange(cbx_tbList_Src, srcTable);
                }
            }
        }

        private void tbx_DataType_Tgt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SrcTgtHdlr.HandleGuiSelectionChange(sender, tgtDataType);
            }
            catch (ExceptionEmptyResultSet ex)
            {
                if (ex.retry)
                {
                    if (tgtDataType.CloneableFromSrc)
                    {
                        SrcTgtHdlr.HandleGuiSelectionChange(cbx_tbList_Src, srcTable);
                    }
                    else
                    {
                        SrcTgtHdlr.HandleGuiSelectionChange(cbx_tbList_Tgt_Archive, tgtTable_Archive);
                    }
                }
            }
            catch (ExceptionDataTypeMismatch ex)
            {
                if (tgtDataType.CloneableFromSrc)
                {
                    SrcTgtHdlr.HandleGuiSelectionChange(cbx_tbList_Tgt_Archive, tgtTable_Archive);
                }
                else
                {
                    SrcTgtHdlr.HandleGuiSelectionChange(cbx_tbList_Src, srcTable);
                }
            }
        }

        private void cbx_psList_Tgt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SrcTgtHdlr.HandleGuiSelectionChange(sender, tgtPartitionScheme);
            }
            catch (ExceptionEmptyResultSet ex)
            {
                if (ex.retry)
                {
                    SrcTgtHdlr.HandleGuiSelectionChange(cbx_tbList_Tgt_Archive, tgtTable_Archive);
                }
            }
        }

        private void cbx_idxList_Tgt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SrcTgtHdlr.HandleGuiSelectionChange(sender, tgtIndex);
            }
            catch (ExceptionEmptyResultSet ex)
            {
                if (ex.retry)
                {
                    SrcTgtHdlr.HandleGuiSelectionChange(cbx_psList_Tgt, tgtPartitionScheme);
                }
            }
        }

        private void chkBxCurrent_CheckedChanged(object sender, EventArgs e)
        {
            //SrcTgtHdlr.HandleGuiSelectionChange(sender, tgtSchema_Current);//
            tgtSchema_Current.Enabled = chkBxCurrent.Checked ? true : false;
        }

        private void chkBxStaging_CheckedChanged(object sender, EventArgs e)
        {
            //SrcTgtHdlr.HandleGuiSelectionChange(sender, tgtSchema_Staging);
            tgtSchema_Staging.Enabled = chkBxStaging.Checked ? true : false;
        }

        private void chkBxArchive_CheckedChanged(object sender, EventArgs e)
        {
            //SrcTgtHdlr.HandleGuiSelectionChange(sender, tgtSchema_Archive);
            tgtSchema_Archive.Enabled = chkBxArchive.Checked ? true : false;
        }

        private void rdbtn_Current_Clone_CheckedChanged(object sender, EventArgs e)
        {
            tgtTable_Current.CloneableFromSrc = rdbtn_Current_Clone.Checked ? true : false;
            if (cbx_schList_Tgt_Current.SelectedIndex > 0)
            {
                SrcTgtHdlr.HandleGuiSelectionChange(cbx_schList_Tgt_Current, tgtSchema_Current);
            }
        }

        private void rdbtn_Staging_Clone_CheckedChanged(object sender, EventArgs e)
        {
            tgtTable_Staging.CloneableFromSrc = rdbtn_Staging_Clone.Checked ? true : false;
            if (cbx_schList_Tgt_Staging.SelectedIndex > 0)
            {
                SrcTgtHdlr.HandleGuiSelectionChange(cbx_schList_Tgt_Staging, tgtSchema_Staging);
            }
        }

        private void rdbtn_Archive_Clone_CheckedChanged(object sender, EventArgs e)
        {
            tgtTable_Archive.CloneableFromSrc = rdbtn_Archive_Clone.Checked ? true : false;
            if (cbx_schList_Tgt_Archive.SelectedIndex > 0)
            {
                SrcTgtHdlr.HandleGuiSelectionChange(cbx_schList_Tgt_Archive, tgtSchema_Archive);
            }
        }

        private void optionsStripMenuItem_Click(object sender, EventArgs e)
        {
            Options.HandleOptionsMenuClick();
        }

        private void btnCurrentReload_Click(object sender, EventArgs e)
        {
            TgtMtdHdlr_Current.e = new EventArgsTgtTblMetadata(
                root,
                tgtTable_Current,
                tbxTgtTableName_Current,
                gridColList_Current,
                gridConstraintList_Current,
                btnCurrentSyntax,
                btnCurrentExecute
                );
            if (TgtMtdHdlr_Current.LoadGrids())            
            {
                btnCurrentReload.Image = imageList1.Images[0];
            }
            else 
            {
                btnCurrentReload.Image = imageList1.Images[1];
            }
        }

        private void btnCurrentSyntax_Click(object sender, EventArgs e)
        {
            if (TgtMtdHdlr_Current.CheckSqlSyntax())
            {
                btnCurrentSyntax.Image = imageList1.Images[0];
            }
            else
            {
                btnCurrentSyntax.Image = imageList1.Images[1];
            }
        }
        private void btnStagingReload_Click(object sender, EventArgs e)
        {
            TgtMtdHdlr_Staging.e = new EventArgsTgtTblMetadata(
                root,
                tgtTable_Staging,
                tbxTgtTableName_Staging,
                gridColList_Staging,
                gridConstraintList_Staging,
                btnStagingSyntax,
                btnStagingExecute
                );
            
            if (TgtMtdHdlr_Staging.LoadGrids())
            {
                btnStagingReload.Image = imageList1.Images[0];
            }
            else
            {
                btnStagingReload.Image = imageList1.Images[1];
            }
        }

        private void btnStagingSyntax_Click(object sender, EventArgs e)
        {
            if (TgtMtdHdlr_Staging.CheckSqlSyntax())
            {
                btnStagingSyntax.Image = imageList1.Images[0];
            }
            else
            {
                btnStagingSyntax.Image = imageList1.Images[1];
            }
        }

        private void btnArchiveReload_Click(object sender, EventArgs e)
        {
            TgtMtdHdlr_Archive.e = new EventArgsTgtTblMetadata(
                root,
                tgtTable_Archive,
                tbxTgtTableName_Archive,
                gridColList_Archive,
                gridConstraintList_Archive,
                btnArchiveSyntax,
                btnArchiveExecute
                );
            
            if (TgtMtdHdlr_Archive.LoadGrids())
            {
                btnArchiveReload.Image = imageList1.Images[0];
            }
            else
            {
                btnArchiveReload.Image = imageList1.Images[1];
            }
        }

        private void btnArchiveSyntax_Click(object sender, EventArgs e)
        {
            if (TgtMtdHdlr_Archive.CheckSqlSyntax())
            {
                btnArchiveSyntax.Image = imageList1.Images[0];
            }
            else
            {
                btnArchiveSyntax.Image = imageList1.Images[1];
            }
        }
        private void btnPrintTree_Click(object sender, EventArgs e)
        {
            TreeNode<DbObject>.PrintNodeTree(root);
        }

        private void gridColList_Current_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            btnCurrentExecute.Enabled = false;
        }

        private void gridConstraintList_Current_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            btnCurrentExecute.Enabled = false;
        }

        private void gridColList_Staging_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            btnStagingExecute.Enabled = false;
        }

        private void gridConstraintList_Staging_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            btnStagingExecute.Enabled = false;
        }

        private void gridColList_Archive_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            btnArchiveExecute.Enabled = false;
        }

        private void gridConstraintList_Archive_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            btnArchiveExecute.Enabled = false;
        }

        private void btnCurrentExecute_Click(object sender, EventArgs e)
        {
            if (TgtMtdHdlr_Current.ExecuteCreateTbl())
            {
                btnCurrentExecute.Image = imageList1.Images[0];
            }
            else
            {
                btnCurrentExecute.Image = imageList1.Images[1];
            }
        }

        private void btnStagingExecute_Click(object sender, EventArgs e)
        {
            if (TgtMtdHdlr_Staging.ExecuteCreateTbl())
            {
                btnStagingExecute.Image = imageList1.Images[0];
            }
            else
            {
                btnStagingExecute.Image = imageList1.Images[1];
            }
        }

        private void btnArchiveExecute_Click(object sender, EventArgs e)
        {
            if (TgtMtdHdlr_Archive.ExecuteCreateTbl())
            {
                btnArchiveExecute.Image = imageList1.Images[0];
            }
            else
            {
                btnArchiveExecute.Image = imageList1.Images[1];
            }
        }
    }
}


