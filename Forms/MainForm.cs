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

        private TreeNode<DbObject> trckInstance;
        private TreeNode<DbObject> trckDatabase;
        private TreeNode<DbObject> trckSchema;
        private TreeNode<DbObject> trckTable;

        private DbUtil Src = new DbUtil();
        private DbUtil Tgt = new DbUtil();
        private DbUtil Trck = new DbUtil();

        private ComboBoxSelectionHandler CbxHdlr = new ComboBoxSelectionHandler();
        private TgtTblMetaDataHandler TgtMtdHdlr_Current = new TgtTblMetaDataHandler();
        private TgtTblMetaDataHandler TgtMtdHdlr_Staging = new TgtTblMetaDataHandler();
        private TgtTblMetaDataHandler TgtMtdHdlr_Archive = new TgtTblMetaDataHandler();

        private EventLog elg;

        public MainForm()
        {
            InitializeComponent();

            #region init            

            root = new TreeNode<DbObject>(new DbObject(DbObjectBranch.Root, DbObjectLevel.Root, "Root", "---------------------- Root Node ----------------------", null));

            srcInstance = root.AddChild(new DbObject(DbObjectBranch.Src, DbObjectLevel.Instance, "srcInstance", string.Empty, new GuiElem(tbx_InstanceSrc), Src));
            {
                srcDatabase = srcInstance.AddChild(new DbObject(DbObjectBranch.Src, DbObjectLevel.Database, "srcDatabase", string.Empty, new GuiElem(cbx_dbList_Src)));
                cbx_dbList_Src.SetParentTreeNode(srcDatabase, CbxHdlr);
                {
                    srcSchema = srcDatabase.AddChild(new DbObject(DbObjectBranch.Src, DbObjectLevel.Schema, "srcSchema", string.Empty, new GuiElem(cbx_schList_Src)));
                    cbx_schList_Src.SetParentTreeNode(srcSchema, CbxHdlr);
                    {
                        srcTable = srcSchema.AddChild(new DbObject(DbObjectBranch.Src, DbObjectLevel.Table, "srcTable", string.Empty, new GuiElem(cbx_tbList_Src)));
                        cbx_tbList_Src.SetParentTreeNode(srcTable, CbxHdlr);
                        {
                            srcColumn = srcTable.AddChild(new DbObject(DbObjectBranch.Src, DbObjectLevel.Column, "srcColumn", string.Empty, new GuiElem(cbx_colList_Src)));
                            cbx_colList_Src.SetParentTreeNode(srcColumn, CbxHdlr);
                            {
                                srcDataType = srcColumn.AddChild(new DbObject(DbObjectBranch.Src, DbObjectLevel.DataType, "srcDataType", string.Empty, new GuiElem(tbx_DataType_Src)));
                                tbx_DataType_Src.SetParentTreeNode(srcDataType, CbxHdlr, cbx_tbList_Src, srcTable, null, null);
                                {
                                    srcPartitionScheme = srcDataType.AddChild(new DbObject(DbObjectBranch.Src, DbObjectLevel.PartitionScheme, "srcPartitionScheme", string.Empty, null));
                                    srcPartitionScheme.IsDummyNode = true;
                                    {
                                        srcIndex = srcPartitionScheme.AddChild(new DbObject(DbObjectBranch.Src, DbObjectLevel.Index, "srcIndex", string.Empty, new GuiElem(cbx_idxList_Src)));
                                        cbx_idxList_Src.SetParentTreeNode(srcIndex, CbxHdlr);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            tgtInstance = root.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Instance, "tgtInstance", string.Empty, new GuiElem(tbx_InstanceTgt), Tgt));
            {
                tgtDatabase = tgtInstance.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Database, "tgtDatabase", string.Empty, new GuiElem(cbx_dbList_Tgt)));
                cbx_dbList_Tgt.SetParentTreeNode(tgtDatabase, CbxHdlr);
                {
                    tgtSchema_Current = tgtDatabase.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Schema, "tgtSchema_Current", string.Empty, new GuiElem(cbx_schList_Tgt_Current)));
                    cbx_schList_Tgt_Current.SetParentTreeNode(tgtSchema_Current, CbxHdlr);
                    {
                        tgtTable_Current = tgtSchema_Current.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Table, "tgtTable_Current", string.Empty, new GuiElem(cbx_tbList_Tgt_Current)));
                        cbx_tbList_Tgt_Current.SetParentTreeNode(tgtTable_Current, CbxHdlr);
                        tgtTable_Current.CloneableFromSrc = rdbtn_Current_Clone.Checked ? true : false;
                        tgtTable_Current.AddCousin(srcTable, srcTable.CloneableFromSrc);
                        srcTable.AddCousin(tgtTable_Current, tgtTable_Current.CloneableFromSrc);
                    }

                    tgtSchema_Staging = tgtDatabase.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Schema, "tgtSchema_Staging", string.Empty, new GuiElem(cbx_schList_Tgt_Staging)));
                    cbx_schList_Tgt_Staging.SetParentTreeNode(tgtSchema_Staging, CbxHdlr);
                    {
                        tgtTable_Staging = tgtSchema_Staging.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Table, "tgtTable_Staging", string.Empty, new GuiElem(cbx_tbList_Tgt_Staging)));
                        cbx_tbList_Tgt_Staging.SetParentTreeNode(tgtTable_Staging, CbxHdlr);
                        tgtTable_Staging.CloneableFromSrc = rdbtn_Staging_Clone.Checked ? true : false;
                        tgtTable_Staging.AddCousin(srcTable, srcTable.CloneableFromSrc);
                        srcTable.AddCousin(tgtTable_Staging, tgtTable_Staging.CloneableFromSrc);
                    }

                    tgtSchema_Archive = tgtDatabase.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Schema, "tgtSchema_Archive", string.Empty, new GuiElem(cbx_schList_Tgt_Archive)));
                    cbx_schList_Tgt_Archive.SetParentTreeNode(tgtSchema_Archive, CbxHdlr);
                    {
                        tgtTable_Archive = tgtSchema_Archive.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Table, "tgtTable_Archive", string.Empty, new GuiElem(cbx_tbList_Tgt_Archive)));
                        cbx_tbList_Tgt_Archive.SetParentTreeNode(tgtTable_Archive, CbxHdlr);
                        tgtTable_Archive.CloneableFromSrc = rdbtn_Archive_Clone.Checked ? true : false; // if tgtColumn.CloneableFromSrc is changed to false then this flag has to be to be changed as well
                        tgtTable_Archive.AddCousin(srcTable, srcTable.CloneableFromSrc);
                        srcTable.AddCousin(tgtTable_Archive, tgtTable_Archive.CloneableFromSrc);
                        {
                            tgtColumn = tgtTable_Archive.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Column, "tgtColumn", string.Empty, new GuiElem(cbx_colList_Tgt)));
                            cbx_colList_Tgt.SetParentTreeNode(tgtColumn, CbxHdlr);
                            tgtColumn.CloneableFromSrc = rdbtn_Archive_Clone.Checked ? true : false; // if this flag gets changed then its parent flag has to be changed as well
                            tgtColumn.AddCousin(srcColumn, srcColumn.CloneableFromSrc);
                            srcColumn.AddCousin(tgtColumn, tgtColumn.CloneableFromSrc);
                            {
                                tgtDataType = tgtColumn.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.DataType, "tgtDataType", string.Empty, new GuiElem(tbx_DataType_Tgt)));
                                tbx_DataType_Tgt.SetParentTreeNode(tgtDataType, CbxHdlr, cbx_tbList_Src, srcTable, cbx_tbList_Tgt_Archive, tgtTable_Archive);
                                tgtDataType.CloneableFromSrc = rdbtn_Archive_Clone.Checked ? true : false; // if this flag gets changed then its parent flag has to be changed as well
                                tgtDataType.AddCousin(srcDataType, srcDataType.CloneableFromSrc);
                                srcDataType.AddCousin(tgtDataType, tgtDataType.CloneableFromSrc);
                                {
                                    tgtPartitionScheme = tgtDataType.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.PartitionScheme, "tgtPartitionScheme", string.Empty, new GuiElem(cbx_psList_Tgt)));
                                    cbx_psList_Tgt.SetParentTreeNode(tgtPartitionScheme, CbxHdlr);
                                    tgtPartitionScheme.CloneableFromSrc = true;
                                    //// - srcPartitionScheme.AddCousin(TreeNode<DbObject>.ConvertToDbObject(tgtPartitionScheme), tgtPartitionScheme.CloneableFromSrc); // this is redundant since srcPartitionScheme is "Dummy"
                                    {
                                        tgtIndex = tgtPartitionScheme.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Index, "tgtIndex", string.Empty, new GuiElem(cbx_idxList_Tgt)));
                                        cbx_idxList_Tgt.SetParentTreeNode(tgtIndex, CbxHdlr);
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


            trckInstance = root.AddChild(new DbObject(DbObjectBranch.TrckTbl, DbObjectLevel.Instance, "trckInstance", string.Empty, new GuiElem(tbx_TrackTblInstance), Trck));
            {
                trckDatabase = trckInstance.AddChild(new DbObject(DbObjectBranch.TrckTbl, DbObjectLevel.Database, "trckDatabase", string.Empty, new GuiElem(cbxt_TrackTbl_Database), Trck));
                cbxt_TrackTbl_Database.SetParentTreeNode(trckDatabase, CbxHdlr);
                {
                    trckSchema = trckDatabase.AddChild(new DbObject(DbObjectBranch.TrckTbl, DbObjectLevel.Schema, "trckSchema", string.Empty, new GuiElem(cbxt_TrackTbl_Schema), Trck));
                    cbxt_TrackTbl_Schema.SetParentTreeNode(trckSchema, CbxHdlr);
                    {
                        trckTable = trckSchema.AddChild(new DbObject(DbObjectBranch.TrckTbl, DbObjectLevel.Table, "trckTable", string.Empty, new GuiElem(cbxt_TrackTbl_Table), Trck));
                        cbxt_TrackTbl_Table.SetParentTreeNode(trckTable, CbxHdlr, rdbtn_TrackTbl_CreateNew, btnTrackTblSave);
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
                Options.autoDropDownComboBoxes = true;
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
        //-------------------------------------------------------------------- MENU BAR: ------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------

        private void optionsStripMenuItem_Click(object sender, EventArgs e)
        {
            Options.HandleOptionsMenuClick();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------- SOURCE: --------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------


        private void buttonLoginSrc_Click(object sender, EventArgs e)
        {
            LoginForm.HandleLoginBtnClick(sender, srcInstance, CbxHdlr);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------- TARGET: --------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------

        private void buttonLoginTgt_Click(object sender, EventArgs e)
        {
            LoginForm.HandleLoginBtnClick(sender, tgtInstance, CbxHdlr);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------- CHCKBX & RDBTNS: -----------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------

        private void chkBxCurrent_CheckedChanged(object sender, EventArgs e)
        {
            tgtSchema_Current.Enabled = chkBxCurrent.Checked ? true : false;
        }

        private void chkBxStaging_CheckedChanged(object sender, EventArgs e)
        {
            tgtSchema_Staging.Enabled = chkBxStaging.Checked ? true : false;
        }

        private void chkBxArchive_CheckedChanged(object sender, EventArgs e)
        {
            tgtSchema_Archive.Enabled = chkBxArchive.Checked ? true : false;
        }

        private void rdbtn_Current_Clone_CheckedChanged(object sender, EventArgs e)
        {
            tgtTable_Current.CloneableFromSrc = rdbtn_Current_Clone.Checked ? true : false;
            if (cbx_schList_Tgt_Current.SelectedIndex > 0)
            {
                try
                {
                    CbxHdlr.HandleGuiSelectionChange(cbx_schList_Tgt_Current, tgtSchema_Current);
                }
                catch (ExceptionEmptyResultSet ex)
                {
                    if (ex.retry)
                    {
                        CbxHdlr.HandleGuiSelectionChange(cbx_dbList_Tgt, tgtDatabase);
                    }
                }
            }
        }

        private void rdbtn_Staging_Clone_CheckedChanged(object sender, EventArgs e)
        {
            tgtTable_Staging.CloneableFromSrc = rdbtn_Staging_Clone.Checked ? true : false;
            if (cbx_schList_Tgt_Staging.SelectedIndex > 0)
            {
                try
                {
                    CbxHdlr.HandleGuiSelectionChange(cbx_schList_Tgt_Staging, tgtSchema_Staging);
                }
                catch (ExceptionEmptyResultSet ex)
                {
                    if (ex.retry)
                    {
                        CbxHdlr.HandleGuiSelectionChange(cbx_dbList_Tgt, tgtDatabase);
                    }
                }
            }
        }

        private void rdbtn_Archive_Clone_CheckedChanged(object sender, EventArgs e)
        {
            tgtTable_Archive.CloneableFromSrc = rdbtn_Archive_Clone.Checked ? true : false;
            if (cbx_schList_Tgt_Archive.SelectedIndex > 0)
            {
                try
                {
                    CbxHdlr.HandleGuiSelectionChange(cbx_schList_Tgt_Archive, tgtSchema_Archive);
                }
                catch (ExceptionEmptyResultSet ex)
                {
                    if (ex.retry)
                    {
                        CbxHdlr.HandleGuiSelectionChange(cbx_dbList_Tgt, tgtDatabase);
                    }
                }
            }
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------- TGT METADATA: --------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------

        private void btnCurrentReload_Click(object sender, EventArgs e)
        {
            TgtMtdHdlr_Current.e = new EventArgsTgtTblMetadata(
                root,
                tgtTable_Current,
                tbx_TgtMetadataTableName_Current,
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
                tbx_TgtMetadataTableName_Staging,
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
                tbx_TgtMetaDataTableName_Archive,
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


        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------- MIGRATION TRACKING TBL: ----------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------

        private void btnTrackTblLogin_Click(object sender, EventArgs e)
        {
            LoginForm.HandleLoginBtnClick(sender, trckInstance, CbxHdlr);
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------- SANDBOX: -------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------

        private void btnClearConfig_Click(object sender, EventArgs e)
        {
            root.EmptySubtreeText(root);
        }
        private void btnPrintTree_Click(object sender, EventArgs e)
        {
            TreeNode<DbObject>.PrintNodeTree(root);
        }
    }
}


