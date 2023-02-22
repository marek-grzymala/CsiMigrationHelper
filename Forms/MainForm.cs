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
        private TreeNode<DbObject> tgtCurrentSchema;
        private TreeNode<DbObject> tgtCurrentTable;
        private TreeNode<DbObject> tgtStagingSchema;
        private TreeNode<DbObject> tgtStagingTable;
        private TreeNode<DbObject> tgtArchiveSchema;
        private TreeNode<DbObject> tgtArchiveTable;
        private TreeNode<DbObject> tgtColumn;
        private TreeNode<DbObject> tgtDataType;
        private TreeNode<DbObject> tgtPartitionScheme;
        private TreeNode<DbObject> tgtIndex;

        private TreeNode<DbObject> trckInstance;
        private TreeNode<DbObject> trckDatabase;
        private TreeNode<DbObject> trckSchema;
        private TreeNode<DbObject> trckProjectsTable;
        private TreeNode<DbObject> trckProjectName;
        private TreeNode<DbObject> trckProjectDescription;

        private DbUtil Src = new DbUtil();
        private DbUtil Tgt = new DbUtil();
        private DbUtil Trck = new DbUtil();

        private PartitionSetup ps = new PartitionSetup();

        private TgtTblMetaDataHandler TgtMtdHdlr_Current = new TgtTblMetaDataHandler();
        private TgtTblMetaDataHandler TgtMtdHdlr_Staging = new TgtTblMetaDataHandler();
        private TgtTblMetaDataHandler TgtMtdHdlr_Archive = new TgtTblMetaDataHandler();
        private TrackingTblHndlr TrckTblHndlr;
        private EventArgsProjectFields eaProjectFields;

        private EventLog elg;

        public MainForm()
        {
            InitializeComponent();

            #region init
            {
                Options.suffixCurrent = "_Current";
                Options.suffixStaging = "_Staging";
                Options.suffixArchive = "_Archive";
                Options.autoDropDownComboBoxes = true;
                Options.prefixCSI = "CSI_";
                Options.suffixTgtColName = "_";
                Options.translateUserDefinedDataTypes = true;
                Options.doNotCreateFKsOnCrossDbTarget = true;
                Options.makeCSIClustered = true;
                Options.renameTgtColumns = false;
                Options.projectsTableDefaultName = "CsiMigrationProjects";
                Options.newProjectDefaultName = "My New Csi Migration Project";
                Options.newProjectDefaultDescription = "Project description";
                Options.migrationTrackingTblSuffix = "_TrackingTbl";
                Options.allowCreateTgtArchiveWithNoCsiIndex = false;
                Options.partition_FG_Prefix = "FG_";
                Options.partition_FI_Prefix = "FI_";
                Options.partition_PF_Name = "pf_monthly_date";
                Options.partition_PS_Name = "ps_monthly_date";
                Options.partitionInterval = "monthly";

            }

            root = new TreeNode<DbObject>(new DbObject(DbObjectBranch.Root, DbObjectLevel.Root, "Root", "---------------------- Root Node ----------------------", null));
            srcInstance = root.AddChild(new DbObject(DbObjectBranch.Src, DbObjectLevel.Instance, "srcInstance", string.Empty, new GuiElem(tbx_InstanceSrc), Src));
            {
                srcDatabase = srcInstance.AddChild(new DbObject(DbObjectBranch.Src, DbObjectLevel.Database, "srcDatabase", string.Empty, new GuiElem(cbx_dbList_Src)));
                cbx_dbList_Src.SetParentTreeNode(srcDatabase);
                {
                    srcSchema = srcDatabase.AddChild(new DbObject(DbObjectBranch.Src, DbObjectLevel.Schema, "srcSchema", string.Empty, new GuiElem(cbx_schList_Src)));
                    cbx_schList_Src.SetParentTreeNode(srcSchema);
                    {
                        srcTable = srcSchema.AddChild(new DbObject(DbObjectBranch.Src, DbObjectLevel.Table, "srcTable", string.Empty, new GuiElem(cbx_tbList_Src)));
                        cbx_tbList_Src.SetParentTreeNode(srcTable);
                        {
                            srcColumn = srcTable.AddChild(new DbObject(DbObjectBranch.Src, DbObjectLevel.Column, "srcColumn", string.Empty, new GuiElem(cbx_colList_Src)));
                            cbx_colList_Src.SetParentTreeNode(srcColumn);
                            {
                                srcDataType = srcColumn.AddChild(new DbObject(DbObjectBranch.Src, DbObjectLevel.DataType, "srcDataType", string.Empty, new GuiElem(tbx_DataType_Src)));
                                tbx_DataType_Src.SetParentTreeNode(srcDataType, cbx_tbList_Src, srcTable, null, null);
                                {
                                    srcPartitionScheme = srcDataType.AddChild(new DbObject(DbObjectBranch.Src, DbObjectLevel.PartitionScheme, "srcPartitionScheme", string.Empty, null));
                                    srcPartitionScheme.IsDummyNode = true;
                                    {
                                        srcIndex = srcPartitionScheme.AddChild(new DbObject(DbObjectBranch.Src, DbObjectLevel.Index, "srcIndex", string.Empty, new GuiElem(cbx_idxList_Src)));
                                        cbx_idxList_Src.SetParentTreeNode(srcIndex);
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
                cbx_dbList_Tgt.SetParentTreeNode(tgtDatabase);
                {
                    tgtCurrentSchema = tgtDatabase.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Schema, "tgtSchema_Current", string.Empty, new GuiElem(cbx_schList_Tgt_Current)));
                    cbx_schList_Tgt_Current.SetParentTreeNode(tgtCurrentSchema);
                    {
                        tgtCurrentTable = tgtCurrentSchema.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Table, "tgtTable_Current", string.Empty, new GuiElem(cbx_tbList_Tgt_Current)));
                        cbx_tbList_Tgt_Current.SetParentTreeNode(tgtCurrentTable);
                        rdbtn_Current_Clone.SetParentTreeNode(tgtCurrentTable);
                        rdbtn_Current_Clone.Checked = true;

                        tgtCurrentTable.CloneableFromSrc = rdbtn_Current_Clone.Checked ? true : false;
                        tgtCurrentTable.AddCousin(srcTable, srcTable.CloneableFromSrc);
                        srcTable.AddCousin(tgtCurrentTable, tgtCurrentTable.CloneableFromSrc);
                    }

                    tgtStagingSchema = tgtDatabase.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Schema, "tgtSchema_Staging", string.Empty, new GuiElem(cbx_schList_Tgt_Staging)));
                    cbx_schList_Tgt_Staging.SetParentTreeNode(tgtStagingSchema);
                    {
                        tgtStagingTable = tgtStagingSchema.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Table, "tgtTable_Staging", string.Empty, new GuiElem(cbx_tbList_Tgt_Staging)));
                        cbx_tbList_Tgt_Staging.SetParentTreeNode(tgtStagingTable);
                        rdbtn_Staging_Clone.SetParentTreeNode(tgtStagingTable);
                        rdbtn_Staging_Clone.Checked = true;

                        tgtStagingTable.CloneableFromSrc = rdbtn_Staging_Clone.Checked ? true : false;
                        tgtStagingTable.AddCousin(srcTable, srcTable.CloneableFromSrc);
                        srcTable.AddCousin(tgtStagingTable, tgtStagingTable.CloneableFromSrc);
                    }

                    tgtArchiveSchema = tgtDatabase.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Schema, "tgtSchema_Archive", string.Empty, new GuiElem(cbx_schList_Tgt_Archive)));
                    cbx_schList_Tgt_Archive.SetParentTreeNode(tgtArchiveSchema);
                    {
                        tgtArchiveTable = tgtArchiveSchema.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Table, "tgtTable_Archive", string.Empty, new GuiElem(cbx_tbList_Tgt_Archive)));
                        cbx_tbList_Tgt_Archive.SetParentTreeNode(tgtArchiveTable);
                        rdbtn_Archive_Clone.SetParentTreeNode(tgtArchiveTable);
                        rdbtn_Archive_Clone.Checked = true;

                        tgtArchiveTable.CloneableFromSrc = rdbtn_Archive_Clone.Checked ? true : false; // if tgtColumn.CloneableFromSrc is changed to false then this flag has to be to be changed as well
                        tgtArchiveTable.AddCousin(srcTable, srcTable.CloneableFromSrc);
                        srcTable.AddCousin(tgtArchiveTable, tgtArchiveTable.CloneableFromSrc);
                        {
                            tgtColumn = tgtArchiveTable.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Column, "tgtColumn", string.Empty, new GuiElem(cbx_colList_Tgt)));
                            cbx_colList_Tgt.SetParentTreeNode(tgtColumn);
                            tgtColumn.CloneableFromSrc = rdbtn_Archive_Clone.Checked ? true : false; // if this flag gets changed then its parent flag has to be changed as well
                            tgtColumn.AddCousin(srcColumn, srcColumn.CloneableFromSrc);
                            srcColumn.AddCousin(tgtColumn, tgtColumn.CloneableFromSrc);
                            {
                                tgtDataType = tgtColumn.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.DataType, "tgtDataType", string.Empty, new GuiElem(tbx_DataType_Tgt)));
                                tbx_DataType_Tgt.SetParentTreeNode(tgtDataType, cbx_tbList_Src, srcTable, cbx_tbList_Tgt_Archive, tgtArchiveTable);
                                tgtDataType.CloneableFromSrc = rdbtn_Archive_Clone.Checked ? true : false; // if this flag gets changed then its parent flag has to be changed as well
                                tgtDataType.AddCousin(srcDataType, srcDataType.CloneableFromSrc);
                                srcDataType.AddCousin(tgtDataType, tgtDataType.CloneableFromSrc);
                                {
                                    tgtPartitionScheme = tgtDataType.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.PartitionScheme, "tgtPartitionScheme", string.Empty, new GuiElem(cbx_psList_Tgt)));
                                    cbx_psList_Tgt.SetParentTreeNode(tgtPartitionScheme);
                                    tgtPartitionScheme.CloneableFromSrc = true;
                                    //// - srcPartitionScheme.AddCousin(TreeNode<DbObject>.ConvertToDbObject(tgtPartitionScheme), tgtPartitionScheme.CloneableFromSrc); // this is redundant since srcPartitionScheme is "Dummy"
                                    {
                                        tgtIndex = tgtPartitionScheme.AddChild(new DbObject(DbObjectBranch.Tgt, DbObjectLevel.Index, "tgtIndex", string.Empty, new GuiElem(cbx_idxList_Tgt)));
                                        cbx_idxList_Tgt.SetParentTreeNode(tgtIndex);
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

            eaProjectFields = new EventArgsProjectFields(
                                      srcInstance
                                    , srcDatabase
                                    , srcSchema
                                    , srcTable
                                    , srcColumn
                                    , srcDataType
                                    , srcIndex
                                    , tgtInstance
                                    , tgtDatabase
                                    , tgtCurrentSchema
                                    , tgtCurrentTable
                                    , tgtStagingSchema
                                    , tgtStagingTable
                                    , tgtArchiveSchema
                                    , tgtArchiveTable
                                    , tgtColumn
                                    , tgtDataType
                                    , tgtPartitionScheme
                                    , tgtIndex
                                   );


            trckInstance = root.AddChild(new DbObject(DbObjectBranch.TrckTbl, DbObjectLevel.Instance, "trckInstance", string.Empty, new GuiElem(tbx_TrackTbl_Instance), Trck));
            {
                trckDatabase = trckInstance.AddChild(new DbObject(DbObjectBranch.TrckTbl, DbObjectLevel.Database, "trckDatabase", string.Empty, new GuiElem(cbxt_TrackTbl_Database), Trck));
                cbxt_TrackTbl_Database.SetParentTreeNode(trckDatabase);
                {
                    trckSchema = trckDatabase.AddChild(new DbObject(DbObjectBranch.TrckTbl, DbObjectLevel.Schema, "trckSchema", string.Empty, new GuiElem(cbxt_TrackTbl_Schema), Trck));
                    cbxt_TrackTbl_Schema.SetParentTreeNode(trckSchema);
                    {
                        trckProjectsTable = trckSchema.AddChild(new DbObject(DbObjectBranch.TrckTbl, DbObjectLevel.Table, "trckProjectsTable", string.Empty, new GuiElem(cbxt_TrackTbl_ProjectsTable), Trck));                        
                        cbxt_TrackTbl_ProjectsTable.SetParentTreeNode(
                                                                       trckProjectsTable
                                                                     , btnLoginTrackTbl
                                                                     , tbx_TrackTbl_Instance
                                                                     , cbxt_TrackTbl_Database
                                                                     , cbxt_TrackTbl_Schema
                                                                     , null
                                                                     , rdbtn_TrackTbl_ProjectsCreateNew
                                                                     , rdbtn_TrackTbl_ProjectNameUseExisting
                                                                     , grpBx_TrackTbl_ProjectsTableCreateNewUseExisting
                                                                     , btnTrackTbl_ProjectsSave
                                                                     , btnTrackTbl_ProjectsEdit
                                                                     , null);
                        rdbtn_TrackTbl_ProjectsCreateNew.SetParentTreeNode(trckProjectsTable);
                        rdbtn_TrackTbl_ProjectsCreateNew.Checked = true;
                        {
                            trckProjectName = trckProjectsTable.AddChild(new DbObject(DbObjectBranch.TrckTbl, DbObjectLevel.Column, "trckProjectName", string.Empty, new GuiElem(cbxt_TrackTbl_ProjectName), Trck));
                            cbxt_TrackTbl_ProjectName.SetParentTreeNode(
                                                                         trckProjectName
                                                                       , btnLoginTrackTbl
                                                                       , tbx_TrackTbl_Instance
                                                                       , cbxt_TrackTbl_Database
                                                                       , cbxt_TrackTbl_Schema
                                                                       , cbxt_TrackTbl_ProjectsTable
                                                                       , rdbtn_TrackTbl_ProjectNameCreateNew
                                                                       , rdbtn_TrackTbl_ProjectNameUseExisting
                                                                       , grpBx_TrackTbl_ProjectNameCreateNewUseExisting
                                                                       , btnTrackTbl_ProjectNameSave
                                                                       , btnTrackTbl_ProjectNameEdit
                                                                       , tbx_TrackTbl_ProjectDescription);
                            rdbtn_TrackTbl_ProjectNameCreateNew.SetParentTreeNode(trckProjectName);
                            rdbtn_TrackTbl_ProjectNameCreateNew.Checked = true;
                            TrckTblHndlr = new TrackingTblHndlr(cbxt_TrackTbl_ProjectsTable
                                                              , cbxt_TrackTbl_ProjectName
                                                              , tbxTrackFullSource
                                                              , tbxTrackFullTarget
                                                              , gridTrackingTable
                                                              , eaProjectFields
                                                              , imageList1
                                                              , btnTrackingLoadSrcCount
                                                              , btnTrackingRunImport
                                                              );
                            {
                                trckProjectDescription = trckProjectName.AddChild(new DbObject(DbObjectBranch.TrckTbl, DbObjectLevel.DataType, "trckProjectDescription", string.Empty, new GuiElem(tbx_TrackTbl_ProjectDescription)));
                            }
                        }
                    }
                }
            }

            gridFileGroups.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(gridFileGroups, true, null);
            gridPartitionFunction.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(gridPartitionFunction, true, null);
            gridPartitionScheme.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(gridPartitionScheme, true, null);

            gridColList_Current.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(gridColList_Current, true, null);
            gridColList_Staging.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(gridColList_Staging, true, null);
            gridColList_Archive.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(gridColList_Archive, true, null);

            gridConstraintList_Current.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(gridConstraintList_Current, true, null);
            gridConstraintList_Staging.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(gridConstraintList_Staging, true, null);
            gridConstraintList_Archive.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(gridConstraintList_Archive, true, null);

            ps = new PartitionSetup(new EventArgsPartitionSetup(
                                   tgtInstance,
                                   tgtDatabase,
                                   dtm_FileGroup_Start,
                                   dtm_FileGroup_End,
                                   dtm_PartitionFunction_Start,
                                   dtm_PartitionFunction_End,
                                   tbx_FileGroupPrefix,
                                   tbx_FileNamePrefix,
                                   tbx_PartitionFunctionName,
                                   cbx_PartitionFunctionSelect,
                                   tbx_PartitionSchemeName,
                                   rdbtn_PF_BoundaryOnRight,
                                   gridFileGroups,
                                   gridPartitionFunction,
                                   gridPartitionScheme,
                                   btn_FileGroup_Reload,
                                   btn_PartitionFunction_Reload,
                                   btn_PartitionScheme_Reload,
                                   btn_FileGroup_CheckSyntax,
                                   btn_PartitionFunction_CheckSyntax,
                                   btn_PartitionScheme_CheckSyntax,
                                   btn_FileGroup_Execute,
                                   btn_PartitionFunction_Execute,
                                   btn_PartitionScheme_Execute,
                                   imageList1
                                   ));

            TgtMtdHdlr_Current = new TgtTblMetaDataHandler(new EventArgsTgtTblMetadata(
                                                                root,
                                                                tgtCurrentTable,
                                                                tbx_TgtMetadataTableName_Current,
                                                                gridColList_Current,
                                                                gridConstraintList_Current,
                                                                btnCurrentReload,
                                                                btnCurrentSyntax,
                                                                btnCurrentExecute,
                                                                imageList1
                                                              ));
            TgtMtdHdlr_Staging = new TgtTblMetaDataHandler(new EventArgsTgtTblMetadata(
                                                                root,
                                                                tgtStagingTable,
                                                                tbx_TgtMetadataTableName_Staging,
                                                                gridColList_Staging,
                                                                gridConstraintList_Staging,
                                                                btnStagingReload,
                                                                btnStagingSyntax,
                                                                btnStagingExecute,
                                                                imageList1
                                                              ));
            TgtMtdHdlr_Archive = new TgtTblMetaDataHandler(new EventArgsTgtTblMetadata(
                                                                root,
                                                                tgtArchiveTable,
                                                                tbx_TgtMetaDataTableName_Archive,
                                                                gridColList_Archive,
                                                                gridConstraintList_Archive,
                                                                btnArchiveReload,
                                                                btnArchiveSyntax,
                                                                btnArchiveExecute,
                                                                imageList1
                                                              ));

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
        //-------------------------------------------------------------------- SOURCE/TARGET: --------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------

        #region SrcTgt
        private void buttonLoginSrc_Click(object sender, EventArgs e)
        {
            LoginForm.HandleLoginBtnClick(sender, srcInstance);
        }
        private void buttonLoginTgt_Click(object sender, EventArgs e)
        {
            LoginForm.HandleLoginBtnClick(sender, tgtInstance);
        }

        private void chkBxCurrent_CheckedChanged(object sender, EventArgs e)
        {
            tgtCurrentSchema.Enabled = chkBxCurrent.Checked ? true : false;
        }

        private void chkBxStaging_CheckedChanged(object sender, EventArgs e)
        {
            tgtStagingSchema.Enabled = chkBxStaging.Checked ? true : false;
        }

        private void chkBxArchive_CheckedChanged(object sender, EventArgs e)
        {
            tgtArchiveSchema.Enabled = chkBxArchive.Checked ? true : false;
        }
        #endregion

        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------- MIGRATION TRACKING TBL: ----------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------

        #region MigrationTrcTbl
        private void btnTrackTblLogin_Click(object sender, EventArgs e)
        {
            LoginForm.HandleLoginBtnClick(sender, trckInstance);
        }
        #endregion

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


