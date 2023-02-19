namespace CsiMigrationHelper
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSrcTgtSetup = new System.Windows.Forms.TabPage();
            this.tblp_TabSetupOuter = new System.Windows.Forms.TableLayoutPanel();
            this.split_SrcTgtSetup = new System.Windows.Forms.SplitContainer();
            this.gpbxSrc = new System.Windows.Forms.GroupBox();
            this.tblp_TabSetupSrc = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLoginSrc = new System.Windows.Forms.Button();
            this.tbx_InstanceSrc = new System.Windows.Forms.TextBox();
            this.gpbxTgt = new System.Windows.Forms.GroupBox();
            this.tblp_TabSetupTgt = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_UseExisting = new System.Windows.Forms.Label();
            this.lbl_Clone = new System.Windows.Forms.Label();
            this.lbl_Enabled = new System.Windows.Forms.Label();
            this.lbl_TableTgt = new System.Windows.Forms.Label();
            this.lbl_SchemaTgt = new System.Windows.Forms.Label();
            this.buttonLoginTgt = new System.Windows.Forms.Button();
            this.tbx_InstanceTgt = new System.Windows.Forms.TextBox();
            this.grpBx_Current = new System.Windows.Forms.GroupBox();
            this.tblp_Current = new System.Windows.Forms.TableLayoutPanel();
            this.chkBxCurrent = new System.Windows.Forms.CheckBox();
            this.rdbtn_Current_UseExisting = new System.Windows.Forms.RadioButton();
            this.grpBx_Staging = new System.Windows.Forms.GroupBox();
            this.tblp_Staging = new System.Windows.Forms.TableLayoutPanel();
            this.chkBxStaging = new System.Windows.Forms.CheckBox();
            this.rdbtn_Staging_UseExisting = new System.Windows.Forms.RadioButton();
            this.grpBx_Archive = new System.Windows.Forms.GroupBox();
            this.tblp_Archive = new System.Windows.Forms.TableLayoutPanel();
            this.chkBxArchive = new System.Windows.Forms.CheckBox();
            this.rdbtn_Archive_UseExisting = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tblp_ObjectLablels = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Index = new System.Windows.Forms.Label();
            this.lbl_PartitionScheme = new System.Windows.Forms.Label();
            this.lbl_DataType = new System.Windows.Forms.Label();
            this.lbl_Column = new System.Windows.Forms.Label();
            this.lbl_Table = new System.Windows.Forms.Label();
            this.lbl_Schema = new System.Windows.Forms.Label();
            this.lbl_Database = new System.Windows.Forms.Label();
            this.lbl_Instance = new System.Windows.Forms.Label();
            this.tabPartition = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tblp_Partition_FileGroups = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbx_FileGroupPrefix = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbx_FileNamePrefix = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtm_FileGroup_End = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtm_FileGroup_Start = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gridFileGroups = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_FileGroup_Execute = new System.Windows.Forms.Button();
            this.btn_FileGroup_CheckSyntax = new System.Windows.Forms.Button();
            this.btn_FileGroup_Reload = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpBx_PartitionFunctionName = new System.Windows.Forms.GroupBox();
            this.tbx_PartitionFunctionName = new System.Windows.Forms.TextBox();
            this.grpBx_PartitionFunction_Boundary = new System.Windows.Forms.GroupBox();
            this.rdbtn_PF_BoundaryOnRight = new System.Windows.Forms.RadioButton();
            this.rdbtn_PF_BoundaryOnLeft = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dtm_PartitionFunction_End = new System.Windows.Forms.DateTimePicker();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.dtm_PartitionFunction_Start = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.gridPartitionFunction = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_PartitionFunction_Execute = new System.Windows.Forms.Button();
            this.btn_PartitionFunction_CheckSyntax = new System.Windows.Forms.Button();
            this.btn_PartitionFunction_Reload = new System.Windows.Forms.Button();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.grpBx_PartitionSchemeName = new System.Windows.Forms.GroupBox();
            this.tbx_PartitionSchemeName = new System.Windows.Forms.TextBox();
            this.grpBx_PartitionFunctionSelect = new System.Windows.Forms.GroupBox();
            this.cbx_PartitionFunctionSelect = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.gridPartitionScheme = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_PartitionScheme_Execute = new System.Windows.Forms.Button();
            this.btn_PartitionScheme_CheckSyntax = new System.Windows.Forms.Button();
            this.btn_PartitionScheme_Reload = new System.Windows.Forms.Button();
            this.tabTgtMetadata = new System.Windows.Forms.TabPage();
            this.split_TgtMetadata = new System.Windows.Forms.SplitContainer();
            this.split_TgtMeta_Current = new System.Windows.Forms.SplitContainer();
            this.tblp_TgtMeta_ColumnList_Current = new System.Windows.Forms.TableLayoutPanel();
            this.gridColList_Current = new System.Windows.Forms.DataGridView();
            this.pnlTgtTableName_Current = new System.Windows.Forms.Panel();
            this.tbx_TgtMetadataTableName_Current = new System.Windows.Forms.TextBox();
            this.tblp_TgtMeta_ConstraintList_Current = new System.Windows.Forms.TableLayoutPanel();
            this.gridConstraintList_Current = new System.Windows.Forms.DataGridView();
            this.tblp_TgtMeta_Btns_Current = new System.Windows.Forms.TableLayoutPanel();
            this.btnCurrentExecute = new System.Windows.Forms.Button();
            this.btnCurrentSyntax = new System.Windows.Forms.Button();
            this.btnCurrentReload = new System.Windows.Forms.Button();
            this.split_TgtMeta_StagingArchive = new System.Windows.Forms.SplitContainer();
            this.splitStaging = new System.Windows.Forms.SplitContainer();
            this.tblp_TgtMeta_ColumnList_Staging = new System.Windows.Forms.TableLayoutPanel();
            this.gridColList_Staging = new System.Windows.Forms.DataGridView();
            this.pnlTgtTableName_Staging = new System.Windows.Forms.Panel();
            this.tbx_TgtMetadataTableName_Staging = new System.Windows.Forms.TextBox();
            this.tblp_TgtMeta_ConstraintList_Staging = new System.Windows.Forms.TableLayoutPanel();
            this.gridConstraintList_Staging = new System.Windows.Forms.DataGridView();
            this.tblp_TgtMeta_Btns_Staging = new System.Windows.Forms.TableLayoutPanel();
            this.btnStagingExecute = new System.Windows.Forms.Button();
            this.btnStagingSyntax = new System.Windows.Forms.Button();
            this.btnStagingReload = new System.Windows.Forms.Button();
            this.split_TgtMeta_Archive = new System.Windows.Forms.SplitContainer();
            this.tblp_TgtMeta_ColumnList_Archive = new System.Windows.Forms.TableLayoutPanel();
            this.gridColList_Archive = new System.Windows.Forms.DataGridView();
            this.pnlTgtTableName_Archive = new System.Windows.Forms.Panel();
            this.tbx_TgtMetaDataTableName_Archive = new System.Windows.Forms.TextBox();
            this.tblp_TgtMeta_ConstraintList_Archive = new System.Windows.Forms.TableLayoutPanel();
            this.gridConstraintList_Archive = new System.Windows.Forms.DataGridView();
            this.tblp_TgtMeta_Btns_Archive = new System.Windows.Forms.TableLayoutPanel();
            this.btnArchiveExecute = new System.Windows.Forms.Button();
            this.btnArchiveSyntax = new System.Windows.Forms.Button();
            this.btnArchiveReload = new System.Windows.Forms.Button();
            this.tabTrackingTbl = new System.Windows.Forms.TabPage();
            this.tblp_TrackingTable = new System.Windows.Forms.TableLayoutPanel();
            this.gridTrackingTable = new System.Windows.Forms.DataGridView();
            this.split_TrackingTable = new System.Windows.Forms.SplitContainer();
            this.tblp_TrackingTbl_InstanceDbSchema = new System.Windows.Forms.TableLayoutPanel();
            this.grpBx_TrackTbl_Schema = new System.Windows.Forms.GroupBox();
            this.grpBx_TrackTbl_Database = new System.Windows.Forms.GroupBox();
            this.grpBx_TrackTbl_Instance = new System.Windows.Forms.GroupBox();
            this.tblp_TabTrackTbl_Instance = new System.Windows.Forms.TableLayoutPanel();
            this.tbx_TrackTbl_Instance = new System.Windows.Forms.TextBox();
            this.btnLoginTrackTbl = new System.Windows.Forms.Button();
            this.tblp_TrackingTbl_ProjectTables = new System.Windows.Forms.TableLayoutPanel();
            this.tblp_TrackTbl_ProjectNameSaveRunBtns = new System.Windows.Forms.TableLayoutPanel();
            this.btnTrackTbl_ProjectNameEdit = new System.Windows.Forms.Button();
            this.btnTrackTbl_ProjectNameSave = new System.Windows.Forms.Button();
            this.grpBx_TrackTbl_ProjectNameCreateNewUseExisting = new System.Windows.Forms.GroupBox();
            this.tblp_TrackingTbl_ProjectName = new System.Windows.Forms.TableLayoutPanel();
            this.rdbtn_TrackTbl_ProjectNameUseExisting = new System.Windows.Forms.RadioButton();
            this.grpBx_TrackTbl_ProjectName = new System.Windows.Forms.GroupBox();
            this.tblp_TrackTbl_ProjectsSaveRunBtns = new System.Windows.Forms.TableLayoutPanel();
            this.btnTrackTbl_ProjectsEdit = new System.Windows.Forms.Button();
            this.btnTrackTbl_ProjectsSave = new System.Windows.Forms.Button();
            this.lblTrackTbl_ProjectsUseExisting = new System.Windows.Forms.Label();
            this.lblTrackTbl_ProjectsCreateNew = new System.Windows.Forms.Label();
            this.grpBx_TrackTbl_ProjectsTableCreateNewUseExisting = new System.Windows.Forms.GroupBox();
            this.tblp_TrackTbl_UseExistingCreateNew = new System.Windows.Forms.TableLayoutPanel();
            this.rdbtn_TrackTbl_ProjectsUseExisting = new System.Windows.Forms.RadioButton();
            this.grpBx_TrackTbl_ProjectsTbl = new System.Windows.Forms.GroupBox();
            this.grpBx_TrackTbl_ProjectDescription = new System.Windows.Forms.GroupBox();
            this.tbx_TrackTbl_ProjectDescription = new System.Windows.Forms.TextBox();
            this.split_TrackingTable_SrcTgt = new System.Windows.Forms.SplitContainer();
            this.grpbx_TrackingTbl_Src = new System.Windows.Forms.GroupBox();
            this.grpbx_TrackingTbl_Tgt = new System.Windows.Forms.GroupBox();
            this.tabEventLog = new System.Windows.Forms.TabPage();
            this.rtbxEventLog = new System.Windows.Forms.RichTextBox();
            this.tabSandBox = new System.Windows.Forms.TabPage();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClearConfig = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnTrackingLoadSrcCount = new System.Windows.Forms.Button();
            this.cbx_idxList_Src = new CsiMigrationHelper.ComboBoxExt();
            this.tbx_DataType_Src = new CsiMigrationHelper.TextBoxExt();
            this.cbx_colList_Src = new CsiMigrationHelper.ComboBoxExt();
            this.cbx_tbList_Src = new CsiMigrationHelper.ComboBoxExt();
            this.cbx_schList_Src = new CsiMigrationHelper.ComboBoxExt();
            this.cbx_dbList_Src = new CsiMigrationHelper.ComboBoxExt();
            this.cbx_idxList_Tgt = new CsiMigrationHelper.ComboBoxExt();
            this.cbx_psList_Tgt = new CsiMigrationHelper.ComboBoxExt();
            this.tbx_DataType_Tgt = new CsiMigrationHelper.TextBoxExt();
            this.cbx_colList_Tgt = new CsiMigrationHelper.ComboBoxExt();
            this.cbx_dbList_Tgt = new CsiMigrationHelper.ComboBoxExt();
            this.cbx_tbList_Tgt_Current = new CsiMigrationHelper.ComboBoxExt();
            this.cbx_schList_Tgt_Current = new CsiMigrationHelper.ComboBoxExt();
            this.rdbtn_Current_Clone = new CsiMigrationHelper.RadioButtonExt();
            this.cbx_tbList_Tgt_Staging = new CsiMigrationHelper.ComboBoxExt();
            this.cbx_schList_Tgt_Staging = new CsiMigrationHelper.ComboBoxExt();
            this.rdbtn_Staging_Clone = new CsiMigrationHelper.RadioButtonExt();
            this.cbx_tbList_Tgt_Archive = new CsiMigrationHelper.ComboBoxExt();
            this.cbx_schList_Tgt_Archive = new CsiMigrationHelper.ComboBoxExt();
            this.rdbtn_Archive_Clone = new CsiMigrationHelper.RadioButtonExt();
            this.cbxt_TrackTbl_Schema = new CsiMigrationHelper.ComboBoxExt();
            this.cbxt_TrackTbl_Database = new CsiMigrationHelper.ComboBoxExt();
            this.rdbtn_TrackTbl_ProjectNameCreateNew = new CsiMigrationHelper.RadioButtonExt();
            this.cbxt_TrackTbl_ProjectName = new CsiMigrationHelper.ComboBoxExtTrackTbl();
            this.rdbtn_TrackTbl_ProjectsCreateNew = new CsiMigrationHelper.RadioButtonExt();
            this.cbxt_TrackTbl_ProjectsTable = new CsiMigrationHelper.ComboBoxExtTrackTbl();
            this.tbxTrackFullSource = new System.Windows.Forms.TextBox();
            this.tbxTrackFullTarget = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabSrcTgtSetup.SuspendLayout();
            this.tblp_TabSetupOuter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_SrcTgtSetup)).BeginInit();
            this.split_SrcTgtSetup.Panel1.SuspendLayout();
            this.split_SrcTgtSetup.Panel2.SuspendLayout();
            this.split_SrcTgtSetup.SuspendLayout();
            this.gpbxSrc.SuspendLayout();
            this.tblp_TabSetupSrc.SuspendLayout();
            this.gpbxTgt.SuspendLayout();
            this.tblp_TabSetupTgt.SuspendLayout();
            this.grpBx_Current.SuspendLayout();
            this.tblp_Current.SuspendLayout();
            this.grpBx_Staging.SuspendLayout();
            this.tblp_Staging.SuspendLayout();
            this.grpBx_Archive.SuspendLayout();
            this.tblp_Archive.SuspendLayout();
            this.tblp_ObjectLablels.SuspendLayout();
            this.tabPartition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tblp_Partition_FileGroups.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFileGroups)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpBx_PartitionFunctionName.SuspendLayout();
            this.grpBx_PartitionFunction_Boundary.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPartitionFunction)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.grpBx_PartitionSchemeName.SuspendLayout();
            this.grpBx_PartitionFunctionSelect.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPartitionScheme)).BeginInit();
            this.tableLayoutPanel9.SuspendLayout();
            this.tabTgtMetadata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_TgtMetadata)).BeginInit();
            this.split_TgtMetadata.Panel1.SuspendLayout();
            this.split_TgtMetadata.Panel2.SuspendLayout();
            this.split_TgtMetadata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_TgtMeta_Current)).BeginInit();
            this.split_TgtMeta_Current.Panel1.SuspendLayout();
            this.split_TgtMeta_Current.Panel2.SuspendLayout();
            this.split_TgtMeta_Current.SuspendLayout();
            this.tblp_TgtMeta_ColumnList_Current.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridColList_Current)).BeginInit();
            this.pnlTgtTableName_Current.SuspendLayout();
            this.tblp_TgtMeta_ConstraintList_Current.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridConstraintList_Current)).BeginInit();
            this.tblp_TgtMeta_Btns_Current.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_TgtMeta_StagingArchive)).BeginInit();
            this.split_TgtMeta_StagingArchive.Panel1.SuspendLayout();
            this.split_TgtMeta_StagingArchive.Panel2.SuspendLayout();
            this.split_TgtMeta_StagingArchive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitStaging)).BeginInit();
            this.splitStaging.Panel1.SuspendLayout();
            this.splitStaging.Panel2.SuspendLayout();
            this.splitStaging.SuspendLayout();
            this.tblp_TgtMeta_ColumnList_Staging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridColList_Staging)).BeginInit();
            this.pnlTgtTableName_Staging.SuspendLayout();
            this.tblp_TgtMeta_ConstraintList_Staging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridConstraintList_Staging)).BeginInit();
            this.tblp_TgtMeta_Btns_Staging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_TgtMeta_Archive)).BeginInit();
            this.split_TgtMeta_Archive.Panel1.SuspendLayout();
            this.split_TgtMeta_Archive.Panel2.SuspendLayout();
            this.split_TgtMeta_Archive.SuspendLayout();
            this.tblp_TgtMeta_ColumnList_Archive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridColList_Archive)).BeginInit();
            this.pnlTgtTableName_Archive.SuspendLayout();
            this.tblp_TgtMeta_ConstraintList_Archive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridConstraintList_Archive)).BeginInit();
            this.tblp_TgtMeta_Btns_Archive.SuspendLayout();
            this.tabTrackingTbl.SuspendLayout();
            this.tblp_TrackingTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTrackingTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.split_TrackingTable)).BeginInit();
            this.split_TrackingTable.Panel1.SuspendLayout();
            this.split_TrackingTable.Panel2.SuspendLayout();
            this.split_TrackingTable.SuspendLayout();
            this.tblp_TrackingTbl_InstanceDbSchema.SuspendLayout();
            this.grpBx_TrackTbl_Schema.SuspendLayout();
            this.grpBx_TrackTbl_Database.SuspendLayout();
            this.grpBx_TrackTbl_Instance.SuspendLayout();
            this.tblp_TabTrackTbl_Instance.SuspendLayout();
            this.tblp_TrackingTbl_ProjectTables.SuspendLayout();
            this.tblp_TrackTbl_ProjectNameSaveRunBtns.SuspendLayout();
            this.grpBx_TrackTbl_ProjectNameCreateNewUseExisting.SuspendLayout();
            this.tblp_TrackingTbl_ProjectName.SuspendLayout();
            this.grpBx_TrackTbl_ProjectName.SuspendLayout();
            this.tblp_TrackTbl_ProjectsSaveRunBtns.SuspendLayout();
            this.grpBx_TrackTbl_ProjectsTableCreateNewUseExisting.SuspendLayout();
            this.tblp_TrackTbl_UseExistingCreateNew.SuspendLayout();
            this.grpBx_TrackTbl_ProjectsTbl.SuspendLayout();
            this.grpBx_TrackTbl_ProjectDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_TrackingTable_SrcTgt)).BeginInit();
            this.split_TrackingTable_SrcTgt.Panel1.SuspendLayout();
            this.split_TrackingTable_SrcTgt.Panel2.SuspendLayout();
            this.split_TrackingTable_SrcTgt.SuspendLayout();
            this.grpbx_TrackingTbl_Src.SuspendLayout();
            this.grpbx_TrackingTbl_Tgt.SuspendLayout();
            this.tabEventLog.SuspendLayout();
            this.tabSandBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabSrcTgtSetup);
            this.tabControl.Controls.Add(this.tabPartition);
            this.tabControl.Controls.Add(this.tabTgtMetadata);
            this.tabControl.Controls.Add(this.tabTrackingTbl);
            this.tabControl.Controls.Add(this.tabEventLog);
            this.tabControl.Controls.Add(this.tabSandBox);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1484, 637);
            this.tabControl.TabIndex = 47;
            // 
            // tabSrcTgtSetup
            // 
            this.tabSrcTgtSetup.Controls.Add(this.tblp_TabSetupOuter);
            this.tabSrcTgtSetup.Location = new System.Drawing.Point(4, 25);
            this.tabSrcTgtSetup.Name = "tabSrcTgtSetup";
            this.tabSrcTgtSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tabSrcTgtSetup.Size = new System.Drawing.Size(1476, 608);
            this.tabSrcTgtSetup.TabIndex = 0;
            this.tabSrcTgtSetup.Text = "Src/Tgt Setup";
            this.tabSrcTgtSetup.UseVisualStyleBackColor = true;
            // 
            // tblp_TabSetupOuter
            // 
            this.tblp_TabSetupOuter.ColumnCount = 2;
            this.tblp_TabSetupOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tblp_TabSetupOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TabSetupOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblp_TabSetupOuter.Controls.Add(this.split_SrcTgtSetup, 1, 0);
            this.tblp_TabSetupOuter.Controls.Add(this.statusStrip1, 0, 1);
            this.tblp_TabSetupOuter.Controls.Add(this.tblp_ObjectLablels, 0, 0);
            this.tblp_TabSetupOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblp_TabSetupOuter.Location = new System.Drawing.Point(3, 3);
            this.tblp_TabSetupOuter.Name = "tblp_TabSetupOuter";
            this.tblp_TabSetupOuter.RowCount = 1;
            this.tblp_TabSetupOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TabSetupOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblp_TabSetupOuter.Size = new System.Drawing.Size(1470, 602);
            this.tblp_TabSetupOuter.TabIndex = 0;
            // 
            // split_SrcTgtSetup
            // 
            this.split_SrcTgtSetup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_SrcTgtSetup.Location = new System.Drawing.Point(153, 3);
            this.split_SrcTgtSetup.Name = "split_SrcTgtSetup";
            // 
            // split_SrcTgtSetup.Panel1
            // 
            this.split_SrcTgtSetup.Panel1.Controls.Add(this.gpbxSrc);
            // 
            // split_SrcTgtSetup.Panel2
            // 
            this.split_SrcTgtSetup.Panel2.Controls.Add(this.gpbxTgt);
            this.split_SrcTgtSetup.Size = new System.Drawing.Size(1314, 576);
            this.split_SrcTgtSetup.SplitterDistance = 407;
            this.split_SrcTgtSetup.TabIndex = 0;
            // 
            // gpbxSrc
            // 
            this.gpbxSrc.Controls.Add(this.tblp_TabSetupSrc);
            this.gpbxSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbxSrc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbxSrc.Location = new System.Drawing.Point(0, 0);
            this.gpbxSrc.Name = "gpbxSrc";
            this.gpbxSrc.Size = new System.Drawing.Size(407, 576);
            this.gpbxSrc.TabIndex = 0;
            this.gpbxSrc.TabStop = false;
            this.gpbxSrc.Text = "Source:";
            // 
            // tblp_TabSetupSrc
            // 
            this.tblp_TabSetupSrc.ColumnCount = 2;
            this.tblp_TabSetupSrc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TabSetupSrc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tblp_TabSetupSrc.Controls.Add(this.cbx_idxList_Src, 0, 10);
            this.tblp_TabSetupSrc.Controls.Add(this.tbx_DataType_Src, 0, 8);
            this.tblp_TabSetupSrc.Controls.Add(this.cbx_colList_Src, 0, 7);
            this.tblp_TabSetupSrc.Controls.Add(this.cbx_tbList_Src, 0, 3);
            this.tblp_TabSetupSrc.Controls.Add(this.cbx_schList_Src, 0, 2);
            this.tblp_TabSetupSrc.Controls.Add(this.cbx_dbList_Src, 0, 1);
            this.tblp_TabSetupSrc.Controls.Add(this.buttonLoginSrc, 1, 0);
            this.tblp_TabSetupSrc.Controls.Add(this.tbx_InstanceSrc, 0, 0);
            this.tblp_TabSetupSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblp_TabSetupSrc.Location = new System.Drawing.Point(3, 18);
            this.tblp_TabSetupSrc.Name = "tblp_TabSetupSrc";
            this.tblp_TabSetupSrc.RowCount = 12;
            this.tblp_TabSetupSrc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_TabSetupSrc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_TabSetupSrc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_TabSetupSrc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_TabSetupSrc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tblp_TabSetupSrc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tblp_TabSetupSrc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tblp_TabSetupSrc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_TabSetupSrc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_TabSetupSrc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_TabSetupSrc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_TabSetupSrc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TabSetupSrc.Size = new System.Drawing.Size(401, 555);
            this.tblp_TabSetupSrc.TabIndex = 0;
            // 
            // buttonLoginSrc
            // 
            this.buttonLoginSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLoginSrc.Location = new System.Drawing.Point(314, 3);
            this.buttonLoginSrc.Name = "buttonLoginSrc";
            this.buttonLoginSrc.Size = new System.Drawing.Size(84, 24);
            this.buttonLoginSrc.TabIndex = 68;
            this.buttonLoginSrc.Text = "Login";
            this.buttonLoginSrc.UseVisualStyleBackColor = true;
            this.buttonLoginSrc.Click += new System.EventHandler(this.buttonLoginSrc_Click);
            // 
            // tbx_InstanceSrc
            // 
            this.tbx_InstanceSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_InstanceSrc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_InstanceSrc.Location = new System.Drawing.Point(3, 3);
            this.tbx_InstanceSrc.Name = "tbx_InstanceSrc";
            this.tbx_InstanceSrc.Size = new System.Drawing.Size(305, 22);
            this.tbx_InstanceSrc.TabIndex = 67;
            // 
            // gpbxTgt
            // 
            this.gpbxTgt.Controls.Add(this.tblp_TabSetupTgt);
            this.gpbxTgt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbxTgt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbxTgt.Location = new System.Drawing.Point(0, 0);
            this.gpbxTgt.Name = "gpbxTgt";
            this.gpbxTgt.Size = new System.Drawing.Size(903, 576);
            this.gpbxTgt.TabIndex = 0;
            this.gpbxTgt.TabStop = false;
            this.gpbxTgt.Text = "Target:";
            // 
            // tblp_TabSetupTgt
            // 
            this.tblp_TabSetupTgt.ColumnCount = 5;
            this.tblp_TabSetupTgt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tblp_TabSetupTgt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TabSetupTgt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tblp_TabSetupTgt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tblp_TabSetupTgt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tblp_TabSetupTgt.Controls.Add(this.lbl_UseExisting, 4, 2);
            this.tblp_TabSetupTgt.Controls.Add(this.lbl_Clone, 3, 2);
            this.tblp_TabSetupTgt.Controls.Add(this.lbl_Enabled, 2, 2);
            this.tblp_TabSetupTgt.Controls.Add(this.lbl_TableTgt, 1, 2);
            this.tblp_TabSetupTgt.Controls.Add(this.lbl_SchemaTgt, 0, 2);
            this.tblp_TabSetupTgt.Controls.Add(this.cbx_idxList_Tgt, 0, 10);
            this.tblp_TabSetupTgt.Controls.Add(this.cbx_psList_Tgt, 0, 9);
            this.tblp_TabSetupTgt.Controls.Add(this.tbx_DataType_Tgt, 0, 8);
            this.tblp_TabSetupTgt.Controls.Add(this.cbx_colList_Tgt, 0, 7);
            this.tblp_TabSetupTgt.Controls.Add(this.cbx_dbList_Tgt, 0, 1);
            this.tblp_TabSetupTgt.Controls.Add(this.buttonLoginTgt, 2, 0);
            this.tblp_TabSetupTgt.Controls.Add(this.tbx_InstanceTgt, 0, 0);
            this.tblp_TabSetupTgt.Controls.Add(this.grpBx_Current, 0, 4);
            this.tblp_TabSetupTgt.Controls.Add(this.grpBx_Staging, 0, 5);
            this.tblp_TabSetupTgt.Controls.Add(this.grpBx_Archive, 0, 6);
            this.tblp_TabSetupTgt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblp_TabSetupTgt.Location = new System.Drawing.Point(3, 18);
            this.tblp_TabSetupTgt.Name = "tblp_TabSetupTgt";
            this.tblp_TabSetupTgt.RowCount = 12;
            this.tblp_TabSetupTgt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_TabSetupTgt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_TabSetupTgt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_TabSetupTgt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_TabSetupTgt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tblp_TabSetupTgt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tblp_TabSetupTgt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tblp_TabSetupTgt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_TabSetupTgt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_TabSetupTgt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_TabSetupTgt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_TabSetupTgt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TabSetupTgt.Size = new System.Drawing.Size(897, 555);
            this.tblp_TabSetupTgt.TabIndex = 0;
            // 
            // lbl_UseExisting
            // 
            this.lbl_UseExisting.AutoSize = true;
            this.lbl_UseExisting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_UseExisting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_UseExisting.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UseExisting.Location = new System.Drawing.Point(818, 63);
            this.lbl_UseExisting.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_UseExisting.Name = "lbl_UseExisting";
            this.lbl_UseExisting.Padding = new System.Windows.Forms.Padding(3);
            this.tblp_TabSetupTgt.SetRowSpan(this.lbl_UseExisting, 2);
            this.lbl_UseExisting.Size = new System.Drawing.Size(76, 54);
            this.lbl_UseExisting.TabIndex = 78;
            this.lbl_UseExisting.Text = "Use Existing:";
            this.lbl_UseExisting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Clone
            // 
            this.lbl_Clone.AutoSize = true;
            this.lbl_Clone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Clone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Clone.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Clone.Location = new System.Drawing.Point(740, 63);
            this.lbl_Clone.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_Clone.Name = "lbl_Clone";
            this.lbl_Clone.Padding = new System.Windows.Forms.Padding(3);
            this.tblp_TabSetupTgt.SetRowSpan(this.lbl_Clone, 2);
            this.lbl_Clone.Size = new System.Drawing.Size(72, 54);
            this.lbl_Clone.TabIndex = 77;
            this.lbl_Clone.Text = "Clone Src:";
            this.lbl_Clone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Enabled
            // 
            this.lbl_Enabled.AutoSize = true;
            this.lbl_Enabled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Enabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Enabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Enabled.Location = new System.Drawing.Point(650, 63);
            this.lbl_Enabled.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_Enabled.Name = "lbl_Enabled";
            this.lbl_Enabled.Padding = new System.Windows.Forms.Padding(3);
            this.tblp_TabSetupTgt.SetRowSpan(this.lbl_Enabled, 2);
            this.lbl_Enabled.Size = new System.Drawing.Size(84, 54);
            this.lbl_Enabled.TabIndex = 76;
            this.lbl_Enabled.Text = "Enabled:";
            this.lbl_Enabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_TableTgt
            // 
            this.lbl_TableTgt.AutoSize = true;
            this.lbl_TableTgt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_TableTgt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_TableTgt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TableTgt.Location = new System.Drawing.Point(163, 63);
            this.lbl_TableTgt.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_TableTgt.Name = "lbl_TableTgt";
            this.lbl_TableTgt.Padding = new System.Windows.Forms.Padding(3);
            this.tblp_TabSetupTgt.SetRowSpan(this.lbl_TableTgt, 2);
            this.lbl_TableTgt.Size = new System.Drawing.Size(481, 54);
            this.lbl_TableTgt.TabIndex = 75;
            this.lbl_TableTgt.Text = "Target Table:";
            this.lbl_TableTgt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_SchemaTgt
            // 
            this.lbl_SchemaTgt.AutoSize = true;
            this.lbl_SchemaTgt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_SchemaTgt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_SchemaTgt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SchemaTgt.Location = new System.Drawing.Point(5, 63);
            this.lbl_SchemaTgt.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.lbl_SchemaTgt.Name = "lbl_SchemaTgt";
            this.lbl_SchemaTgt.Padding = new System.Windows.Forms.Padding(3);
            this.tblp_TabSetupTgt.SetRowSpan(this.lbl_SchemaTgt, 2);
            this.lbl_SchemaTgt.Size = new System.Drawing.Size(152, 54);
            this.lbl_SchemaTgt.TabIndex = 74;
            this.lbl_SchemaTgt.Text = "Target Schema:";
            this.lbl_SchemaTgt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonLoginTgt
            // 
            this.buttonLoginTgt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLoginTgt.Location = new System.Drawing.Point(650, 3);
            this.buttonLoginTgt.Name = "buttonLoginTgt";
            this.buttonLoginTgt.Size = new System.Drawing.Size(84, 24);
            this.buttonLoginTgt.TabIndex = 56;
            this.buttonLoginTgt.Text = "Login";
            this.buttonLoginTgt.UseVisualStyleBackColor = true;
            this.buttonLoginTgt.Click += new System.EventHandler(this.buttonLoginTgt_Click);
            // 
            // tbx_InstanceTgt
            // 
            this.tblp_TabSetupTgt.SetColumnSpan(this.tbx_InstanceTgt, 2);
            this.tbx_InstanceTgt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_InstanceTgt.Location = new System.Drawing.Point(5, 3);
            this.tbx_InstanceTgt.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.tbx_InstanceTgt.Name = "tbx_InstanceTgt";
            this.tbx_InstanceTgt.Size = new System.Drawing.Size(639, 22);
            this.tbx_InstanceTgt.TabIndex = 44;
            // 
            // grpBx_Current
            // 
            this.tblp_TabSetupTgt.SetColumnSpan(this.grpBx_Current, 5);
            this.grpBx_Current.Controls.Add(this.tblp_Current);
            this.grpBx_Current.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBx_Current.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBx_Current.Location = new System.Drawing.Point(3, 123);
            this.grpBx_Current.Name = "grpBx_Current";
            this.grpBx_Current.Size = new System.Drawing.Size(891, 50);
            this.grpBx_Current.TabIndex = 71;
            this.grpBx_Current.TabStop = false;
            this.grpBx_Current.Text = "Current:";
            // 
            // tblp_Current
            // 
            this.tblp_Current.ColumnCount = 5;
            this.tblp_Current.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tblp_Current.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_Current.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tblp_Current.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tblp_Current.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tblp_Current.Controls.Add(this.chkBxCurrent, 0, 0);
            this.tblp_Current.Controls.Add(this.cbx_tbList_Tgt_Current, 0, 0);
            this.tblp_Current.Controls.Add(this.cbx_schList_Tgt_Current, 0, 0);
            this.tblp_Current.Controls.Add(this.rdbtn_Current_Clone, 3, 0);
            this.tblp_Current.Controls.Add(this.rdbtn_Current_UseExisting, 4, 0);
            this.tblp_Current.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblp_Current.Location = new System.Drawing.Point(3, 18);
            this.tblp_Current.Name = "tblp_Current";
            this.tblp_Current.RowCount = 1;
            this.tblp_Current.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_Current.Size = new System.Drawing.Size(885, 29);
            this.tblp_Current.TabIndex = 0;
            // 
            // chkBxCurrent
            // 
            this.chkBxCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.chkBxCurrent.AutoSize = true;
            this.chkBxCurrent.Checked = true;
            this.chkBxCurrent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBxCurrent.Location = new System.Drawing.Point(678, 3);
            this.chkBxCurrent.Name = "chkBxCurrent";
            this.chkBxCurrent.Size = new System.Drawing.Size(15, 23);
            this.chkBxCurrent.TabIndex = 68;
            this.chkBxCurrent.UseVisualStyleBackColor = true;
            this.chkBxCurrent.CheckedChanged += new System.EventHandler(this.chkBxCurrent_CheckedChanged);
            // 
            // rdbtn_Current_UseExisting
            // 
            this.rdbtn_Current_UseExisting.AutoSize = true;
            this.rdbtn_Current_UseExisting.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbtn_Current_UseExisting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdbtn_Current_UseExisting.Location = new System.Drawing.Point(812, 3);
            this.rdbtn_Current_UseExisting.Name = "rdbtn_Current_UseExisting";
            this.rdbtn_Current_UseExisting.Size = new System.Drawing.Size(70, 23);
            this.rdbtn_Current_UseExisting.TabIndex = 70;
            this.rdbtn_Current_UseExisting.TabStop = true;
            this.rdbtn_Current_UseExisting.UseVisualStyleBackColor = true;
            // 
            // grpBx_Staging
            // 
            this.tblp_TabSetupTgt.SetColumnSpan(this.grpBx_Staging, 5);
            this.grpBx_Staging.Controls.Add(this.tblp_Staging);
            this.grpBx_Staging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBx_Staging.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBx_Staging.Location = new System.Drawing.Point(3, 179);
            this.grpBx_Staging.Name = "grpBx_Staging";
            this.grpBx_Staging.Size = new System.Drawing.Size(891, 50);
            this.grpBx_Staging.TabIndex = 72;
            this.grpBx_Staging.TabStop = false;
            this.grpBx_Staging.Text = "Staging:";
            // 
            // tblp_Staging
            // 
            this.tblp_Staging.ColumnCount = 5;
            this.tblp_Staging.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tblp_Staging.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_Staging.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tblp_Staging.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tblp_Staging.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tblp_Staging.Controls.Add(this.chkBxStaging, 0, 0);
            this.tblp_Staging.Controls.Add(this.cbx_tbList_Tgt_Staging, 0, 0);
            this.tblp_Staging.Controls.Add(this.cbx_schList_Tgt_Staging, 0, 0);
            this.tblp_Staging.Controls.Add(this.rdbtn_Staging_Clone, 3, 0);
            this.tblp_Staging.Controls.Add(this.rdbtn_Staging_UseExisting, 4, 0);
            this.tblp_Staging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblp_Staging.Location = new System.Drawing.Point(3, 18);
            this.tblp_Staging.Name = "tblp_Staging";
            this.tblp_Staging.RowCount = 1;
            this.tblp_Staging.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_Staging.Size = new System.Drawing.Size(885, 29);
            this.tblp_Staging.TabIndex = 0;
            // 
            // chkBxStaging
            // 
            this.chkBxStaging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.chkBxStaging.AutoSize = true;
            this.chkBxStaging.Checked = true;
            this.chkBxStaging.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBxStaging.Location = new System.Drawing.Point(678, 3);
            this.chkBxStaging.Name = "chkBxStaging";
            this.chkBxStaging.Size = new System.Drawing.Size(15, 23);
            this.chkBxStaging.TabIndex = 69;
            this.chkBxStaging.UseVisualStyleBackColor = true;
            this.chkBxStaging.CheckedChanged += new System.EventHandler(this.chkBxStaging_CheckedChanged);
            // 
            // rdbtn_Staging_UseExisting
            // 
            this.rdbtn_Staging_UseExisting.AutoSize = true;
            this.rdbtn_Staging_UseExisting.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbtn_Staging_UseExisting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdbtn_Staging_UseExisting.Location = new System.Drawing.Point(812, 3);
            this.rdbtn_Staging_UseExisting.Name = "rdbtn_Staging_UseExisting";
            this.rdbtn_Staging_UseExisting.Size = new System.Drawing.Size(70, 23);
            this.rdbtn_Staging_UseExisting.TabIndex = 71;
            this.rdbtn_Staging_UseExisting.TabStop = true;
            this.rdbtn_Staging_UseExisting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbtn_Staging_UseExisting.UseVisualStyleBackColor = true;
            // 
            // grpBx_Archive
            // 
            this.tblp_TabSetupTgt.SetColumnSpan(this.grpBx_Archive, 5);
            this.grpBx_Archive.Controls.Add(this.tblp_Archive);
            this.grpBx_Archive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBx_Archive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBx_Archive.Location = new System.Drawing.Point(3, 235);
            this.grpBx_Archive.Name = "grpBx_Archive";
            this.grpBx_Archive.Size = new System.Drawing.Size(891, 50);
            this.grpBx_Archive.TabIndex = 73;
            this.grpBx_Archive.TabStop = false;
            this.grpBx_Archive.Text = "Archive:";
            // 
            // tblp_Archive
            // 
            this.tblp_Archive.ColumnCount = 5;
            this.tblp_Archive.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tblp_Archive.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_Archive.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tblp_Archive.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tblp_Archive.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tblp_Archive.Controls.Add(this.chkBxArchive, 0, 0);
            this.tblp_Archive.Controls.Add(this.cbx_tbList_Tgt_Archive, 0, 0);
            this.tblp_Archive.Controls.Add(this.cbx_schList_Tgt_Archive, 0, 0);
            this.tblp_Archive.Controls.Add(this.rdbtn_Archive_Clone, 3, 0);
            this.tblp_Archive.Controls.Add(this.rdbtn_Archive_UseExisting, 4, 0);
            this.tblp_Archive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblp_Archive.Location = new System.Drawing.Point(3, 18);
            this.tblp_Archive.Name = "tblp_Archive";
            this.tblp_Archive.RowCount = 1;
            this.tblp_Archive.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_Archive.Size = new System.Drawing.Size(885, 29);
            this.tblp_Archive.TabIndex = 0;
            // 
            // chkBxArchive
            // 
            this.chkBxArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.chkBxArchive.AutoSize = true;
            this.chkBxArchive.Checked = true;
            this.chkBxArchive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBxArchive.Location = new System.Drawing.Point(678, 3);
            this.chkBxArchive.Name = "chkBxArchive";
            this.chkBxArchive.Size = new System.Drawing.Size(15, 23);
            this.chkBxArchive.TabIndex = 70;
            this.chkBxArchive.UseVisualStyleBackColor = true;
            this.chkBxArchive.CheckedChanged += new System.EventHandler(this.chkBxArchive_CheckedChanged);
            // 
            // rdbtn_Archive_UseExisting
            // 
            this.rdbtn_Archive_UseExisting.AutoSize = true;
            this.rdbtn_Archive_UseExisting.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbtn_Archive_UseExisting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdbtn_Archive_UseExisting.Location = new System.Drawing.Point(812, 3);
            this.rdbtn_Archive_UseExisting.Name = "rdbtn_Archive_UseExisting";
            this.rdbtn_Archive_UseExisting.Size = new System.Drawing.Size(70, 23);
            this.rdbtn_Archive_UseExisting.TabIndex = 72;
            this.rdbtn_Archive_UseExisting.TabStop = true;
            this.rdbtn_Archive_UseExisting.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.tblp_TabSetupOuter.SetColumnSpan(this.statusStrip1, 2);
            this.statusStrip1.Location = new System.Drawing.Point(0, 582);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1470, 20);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tblp_ObjectLablels
            // 
            this.tblp_ObjectLablels.ColumnCount = 1;
            this.tblp_ObjectLablels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_ObjectLablels.Controls.Add(this.lbl_Index, 0, 10);
            this.tblp_ObjectLablels.Controls.Add(this.lbl_PartitionScheme, 0, 9);
            this.tblp_ObjectLablels.Controls.Add(this.lbl_DataType, 0, 8);
            this.tblp_ObjectLablels.Controls.Add(this.lbl_Column, 0, 7);
            this.tblp_ObjectLablels.Controls.Add(this.lbl_Table, 0, 3);
            this.tblp_ObjectLablels.Controls.Add(this.lbl_Schema, 0, 2);
            this.tblp_ObjectLablels.Controls.Add(this.lbl_Database, 0, 1);
            this.tblp_ObjectLablels.Controls.Add(this.lbl_Instance, 0, 0);
            this.tblp_ObjectLablels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblp_ObjectLablels.Location = new System.Drawing.Point(3, 3);
            this.tblp_ObjectLablels.Name = "tblp_ObjectLablels";
            this.tblp_ObjectLablels.RowCount = 12;
            this.tblp_ObjectLablels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tblp_ObjectLablels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_ObjectLablels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_ObjectLablels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_ObjectLablels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tblp_ObjectLablels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tblp_ObjectLablels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tblp_ObjectLablels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_ObjectLablels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_ObjectLablels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_ObjectLablels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_ObjectLablels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_ObjectLablels.Size = new System.Drawing.Size(144, 576);
            this.tblp_ObjectLablels.TabIndex = 2;
            // 
            // lbl_Index
            // 
            this.lbl_Index.AutoSize = true;
            this.lbl_Index.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Index.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Index.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Index.Location = new System.Drawing.Point(3, 399);
            this.lbl_Index.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.lbl_Index.Name = "lbl_Index";
            this.lbl_Index.Padding = new System.Windows.Forms.Padding(3);
            this.lbl_Index.Size = new System.Drawing.Size(138, 26);
            this.lbl_Index.TabIndex = 7;
            this.lbl_Index.Text = "Index:";
            this.lbl_Index.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_PartitionScheme
            // 
            this.lbl_PartitionScheme.AutoSize = true;
            this.lbl_PartitionScheme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_PartitionScheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_PartitionScheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PartitionScheme.Location = new System.Drawing.Point(3, 369);
            this.lbl_PartitionScheme.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.lbl_PartitionScheme.Name = "lbl_PartitionScheme";
            this.lbl_PartitionScheme.Padding = new System.Windows.Forms.Padding(3);
            this.lbl_PartitionScheme.Size = new System.Drawing.Size(138, 26);
            this.lbl_PartitionScheme.TabIndex = 6;
            this.lbl_PartitionScheme.Text = "Partition Scheme:";
            this.lbl_PartitionScheme.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_DataType
            // 
            this.lbl_DataType.AutoSize = true;
            this.lbl_DataType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_DataType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_DataType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DataType.Location = new System.Drawing.Point(3, 339);
            this.lbl_DataType.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.lbl_DataType.Name = "lbl_DataType";
            this.lbl_DataType.Padding = new System.Windows.Forms.Padding(3);
            this.lbl_DataType.Size = new System.Drawing.Size(138, 26);
            this.lbl_DataType.TabIndex = 5;
            this.lbl_DataType.Text = "Data Type:";
            this.lbl_DataType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Column
            // 
            this.lbl_Column.AutoSize = true;
            this.lbl_Column.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Column.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Column.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Column.Location = new System.Drawing.Point(3, 309);
            this.lbl_Column.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_Column.Name = "lbl_Column";
            this.lbl_Column.Padding = new System.Windows.Forms.Padding(3);
            this.lbl_Column.Size = new System.Drawing.Size(138, 24);
            this.lbl_Column.TabIndex = 4;
            this.lbl_Column.Text = "Column:";
            this.lbl_Column.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Table
            // 
            this.lbl_Table.AutoSize = true;
            this.lbl_Table.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Table.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Table.Location = new System.Drawing.Point(3, 111);
            this.lbl_Table.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_Table.Name = "lbl_Table";
            this.lbl_Table.Padding = new System.Windows.Forms.Padding(3);
            this.tblp_ObjectLablels.SetRowSpan(this.lbl_Table, 4);
            this.lbl_Table.Size = new System.Drawing.Size(138, 192);
            this.lbl_Table.TabIndex = 3;
            this.lbl_Table.Text = "Table:";
            this.lbl_Table.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Schema
            // 
            this.lbl_Schema.AutoSize = true;
            this.lbl_Schema.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Schema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Schema.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Schema.Location = new System.Drawing.Point(3, 81);
            this.lbl_Schema.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_Schema.Name = "lbl_Schema";
            this.lbl_Schema.Padding = new System.Windows.Forms.Padding(3);
            this.lbl_Schema.Size = new System.Drawing.Size(138, 24);
            this.lbl_Schema.TabIndex = 2;
            this.lbl_Schema.Text = "Schema:";
            this.lbl_Schema.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Database
            // 
            this.lbl_Database.AutoSize = true;
            this.lbl_Database.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Database.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Database.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Database.Location = new System.Drawing.Point(3, 51);
            this.lbl_Database.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_Database.Name = "lbl_Database";
            this.lbl_Database.Padding = new System.Windows.Forms.Padding(3);
            this.lbl_Database.Size = new System.Drawing.Size(138, 24);
            this.lbl_Database.TabIndex = 1;
            this.lbl_Database.Text = "Database:";
            this.lbl_Database.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Instance
            // 
            this.lbl_Instance.AutoSize = true;
            this.lbl_Instance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Instance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Instance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Instance.Location = new System.Drawing.Point(3, 3);
            this.lbl_Instance.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_Instance.Name = "lbl_Instance";
            this.lbl_Instance.Padding = new System.Windows.Forms.Padding(3);
            this.lbl_Instance.Size = new System.Drawing.Size(138, 42);
            this.lbl_Instance.TabIndex = 0;
            this.lbl_Instance.Text = "Instance:";
            this.lbl_Instance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPartition
            // 
            this.tabPartition.Controls.Add(this.splitContainer1);
            this.tabPartition.Location = new System.Drawing.Point(4, 25);
            this.tabPartition.Name = "tabPartition";
            this.tabPartition.Size = new System.Drawing.Size(1476, 608);
            this.tabPartition.TabIndex = 5;
            this.tabPartition.Text = "Partition Setup";
            this.tabPartition.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1476, 608);
            this.splitContainer1.SplitterDistance = 671;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(5);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tblp_Partition_FileGroups);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer2.Size = new System.Drawing.Size(669, 606);
            this.splitContainer2.SplitterDistance = 129;
            this.splitContainer2.TabIndex = 1;
            // 
            // tblp_Partition_FileGroups
            // 
            this.tblp_Partition_FileGroups.ColumnCount = 2;
            this.tblp_Partition_FileGroups.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblp_Partition_FileGroups.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblp_Partition_FileGroups.Controls.Add(this.groupBox4, 0, 1);
            this.tblp_Partition_FileGroups.Controls.Add(this.groupBox3, 0, 1);
            this.tblp_Partition_FileGroups.Controls.Add(this.groupBox2, 1, 0);
            this.tblp_Partition_FileGroups.Controls.Add(this.groupBox1, 0, 0);
            this.tblp_Partition_FileGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblp_Partition_FileGroups.Location = new System.Drawing.Point(3, 3);
            this.tblp_Partition_FileGroups.Name = "tblp_Partition_FileGroups";
            this.tblp_Partition_FileGroups.RowCount = 2;
            this.tblp_Partition_FileGroups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblp_Partition_FileGroups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblp_Partition_FileGroups.Size = new System.Drawing.Size(663, 123);
            this.tblp_Partition_FileGroups.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbx_FileGroupPrefix);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 64);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox4.Size = new System.Drawing.Size(325, 56);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "File Group Prefix:";
            // 
            // tbx_FileGroupPrefix
            // 
            this.tbx_FileGroupPrefix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_FileGroupPrefix.Location = new System.Drawing.Point(3, 25);
            this.tbx_FileGroupPrefix.Name = "tbx_FileGroupPrefix";
            this.tbx_FileGroupPrefix.Size = new System.Drawing.Size(319, 22);
            this.tbx_FileGroupPrefix.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbx_FileNamePrefix);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(334, 64);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox3.Size = new System.Drawing.Size(326, 56);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "File Name Prefix:";
            // 
            // tbx_FileNamePrefix
            // 
            this.tbx_FileNamePrefix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_FileNamePrefix.Location = new System.Drawing.Point(3, 25);
            this.tbx_FileNamePrefix.Name = "tbx_FileNamePrefix";
            this.tbx_FileNamePrefix.Size = new System.Drawing.Size(320, 22);
            this.tbx_FileNamePrefix.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtm_FileGroup_End);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(334, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox2.Size = new System.Drawing.Size(326, 55);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "End Date:";
            // 
            // dtm_FileGroup_End
            // 
            this.dtm_FileGroup_End.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtm_FileGroup_End.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtm_FileGroup_End.Location = new System.Drawing.Point(3, 25);
            this.dtm_FileGroup_End.Name = "dtm_FileGroup_End";
            this.dtm_FileGroup_End.Size = new System.Drawing.Size(320, 22);
            this.dtm_FileGroup_End.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtm_FileGroup_Start);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox1.Size = new System.Drawing.Size(325, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Start Date:";
            // 
            // dtm_FileGroup_Start
            // 
            this.dtm_FileGroup_Start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtm_FileGroup_Start.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtm_FileGroup_Start.Location = new System.Drawing.Point(3, 25);
            this.dtm_FileGroup_Start.Name = "dtm_FileGroup_Start";
            this.dtm_FileGroup_Start.Size = new System.Drawing.Size(319, 22);
            this.dtm_FileGroup_Start.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.gridFileGroups, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(663, 467);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // gridFileGroups
            // 
            this.gridFileGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFileGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFileGroups.Location = new System.Drawing.Point(3, 3);
            this.gridFileGroups.Name = "gridFileGroups";
            this.gridFileGroups.Size = new System.Drawing.Size(657, 421);
            this.gridFileGroups.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.btn_FileGroup_Execute, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn_FileGroup_CheckSyntax, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn_FileGroup_Reload, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 430);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(657, 34);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // btn_FileGroup_Execute
            // 
            this.btn_FileGroup_Execute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_FileGroup_Execute.Enabled = false;
            this.btn_FileGroup_Execute.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_FileGroup_Execute.Location = new System.Drawing.Point(441, 3);
            this.btn_FileGroup_Execute.Name = "btn_FileGroup_Execute";
            this.btn_FileGroup_Execute.Size = new System.Drawing.Size(213, 28);
            this.btn_FileGroup_Execute.TabIndex = 1;
            this.btn_FileGroup_Execute.Text = "Execute";
            this.btn_FileGroup_Execute.UseVisualStyleBackColor = true;
            // 
            // btn_FileGroup_CheckSyntax
            // 
            this.btn_FileGroup_CheckSyntax.AutoSize = true;
            this.btn_FileGroup_CheckSyntax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_FileGroup_CheckSyntax.Enabled = false;
            this.btn_FileGroup_CheckSyntax.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_FileGroup_CheckSyntax.Location = new System.Drawing.Point(222, 3);
            this.btn_FileGroup_CheckSyntax.Name = "btn_FileGroup_CheckSyntax";
            this.btn_FileGroup_CheckSyntax.Size = new System.Drawing.Size(213, 28);
            this.btn_FileGroup_CheckSyntax.TabIndex = 2;
            this.btn_FileGroup_CheckSyntax.Text = "Check Syntax";
            this.btn_FileGroup_CheckSyntax.UseVisualStyleBackColor = true;
            // 
            // btn_FileGroup_Reload
            // 
            this.btn_FileGroup_Reload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_FileGroup_Reload.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_FileGroup_Reload.Location = new System.Drawing.Point(3, 3);
            this.btn_FileGroup_Reload.Name = "btn_FileGroup_Reload";
            this.btn_FileGroup_Reload.Size = new System.Drawing.Size(213, 28);
            this.btn_FileGroup_Reload.TabIndex = 0;
            this.btn_FileGroup_Reload.Text = "Reload";
            this.btn_FileGroup_Reload.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            this.splitContainer3.Panel1.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.splitContainer3.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer3.Panel2.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.splitContainer3.Panel2.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.splitContainer3.Size = new System.Drawing.Size(801, 608);
            this.splitContainer3.SplitterDistance = 411;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Margin = new System.Windows.Forms.Padding(5);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer4.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.tableLayoutPanel5);
            this.splitContainer4.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer4.Size = new System.Drawing.Size(408, 606);
            this.splitContainer4.SplitterDistance = 126;
            this.splitContainer4.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.grpBx_PartitionFunctionName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grpBx_PartitionFunction_Boundary, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox7, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox8, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.16667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.83333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(402, 120);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // grpBx_PartitionFunctionName
            // 
            this.grpBx_PartitionFunctionName.Controls.Add(this.tbx_PartitionFunctionName);
            this.grpBx_PartitionFunctionName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBx_PartitionFunctionName.Location = new System.Drawing.Point(3, 62);
            this.grpBx_PartitionFunctionName.Name = "grpBx_PartitionFunctionName";
            this.grpBx_PartitionFunctionName.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.grpBx_PartitionFunctionName.Size = new System.Drawing.Size(195, 55);
            this.grpBx_PartitionFunctionName.TabIndex = 3;
            this.grpBx_PartitionFunctionName.TabStop = false;
            this.grpBx_PartitionFunctionName.Text = "Partition Function Name:";
            // 
            // tbx_PartitionFunctionName
            // 
            this.tbx_PartitionFunctionName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_PartitionFunctionName.Location = new System.Drawing.Point(3, 25);
            this.tbx_PartitionFunctionName.Name = "tbx_PartitionFunctionName";
            this.tbx_PartitionFunctionName.Size = new System.Drawing.Size(189, 22);
            this.tbx_PartitionFunctionName.TabIndex = 0;
            // 
            // grpBx_PartitionFunction_Boundary
            // 
            this.grpBx_PartitionFunction_Boundary.Controls.Add(this.rdbtn_PF_BoundaryOnRight);
            this.grpBx_PartitionFunction_Boundary.Controls.Add(this.rdbtn_PF_BoundaryOnLeft);
            this.grpBx_PartitionFunction_Boundary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBx_PartitionFunction_Boundary.Location = new System.Drawing.Point(204, 62);
            this.grpBx_PartitionFunction_Boundary.Name = "grpBx_PartitionFunction_Boundary";
            this.grpBx_PartitionFunction_Boundary.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.grpBx_PartitionFunction_Boundary.Size = new System.Drawing.Size(195, 55);
            this.grpBx_PartitionFunction_Boundary.TabIndex = 2;
            this.grpBx_PartitionFunction_Boundary.TabStop = false;
            this.grpBx_PartitionFunction_Boundary.Text = "Boundary on :";
            // 
            // rdbtn_PF_BoundaryOnRight
            // 
            this.rdbtn_PF_BoundaryOnRight.AutoSize = true;
            this.rdbtn_PF_BoundaryOnRight.Location = new System.Drawing.Point(141, 25);
            this.rdbtn_PF_BoundaryOnRight.Name = "rdbtn_PF_BoundaryOnRight";
            this.rdbtn_PF_BoundaryOnRight.Size = new System.Drawing.Size(57, 20);
            this.rdbtn_PF_BoundaryOnRight.TabIndex = 1;
            this.rdbtn_PF_BoundaryOnRight.TabStop = true;
            this.rdbtn_PF_BoundaryOnRight.Text = "Right";
            this.rdbtn_PF_BoundaryOnRight.UseVisualStyleBackColor = true;
            // 
            // rdbtn_PF_BoundaryOnLeft
            // 
            this.rdbtn_PF_BoundaryOnLeft.AutoSize = true;
            this.rdbtn_PF_BoundaryOnLeft.Location = new System.Drawing.Point(33, 25);
            this.rdbtn_PF_BoundaryOnLeft.Name = "rdbtn_PF_BoundaryOnLeft";
            this.rdbtn_PF_BoundaryOnLeft.Size = new System.Drawing.Size(47, 20);
            this.rdbtn_PF_BoundaryOnLeft.TabIndex = 0;
            this.rdbtn_PF_BoundaryOnLeft.TabStop = true;
            this.rdbtn_PF_BoundaryOnLeft.Text = "Left";
            this.rdbtn_PF_BoundaryOnLeft.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.dtm_PartitionFunction_End);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(204, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox7.Size = new System.Drawing.Size(195, 53);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "End Date:";
            // 
            // dtm_PartitionFunction_End
            // 
            this.dtm_PartitionFunction_End.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtm_PartitionFunction_End.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtm_PartitionFunction_End.Location = new System.Drawing.Point(3, 25);
            this.dtm_PartitionFunction_End.Name = "dtm_PartitionFunction_End";
            this.dtm_PartitionFunction_End.Size = new System.Drawing.Size(189, 22);
            this.dtm_PartitionFunction_End.TabIndex = 3;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.dtm_PartitionFunction_Start);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(3, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox8.Size = new System.Drawing.Size(195, 53);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Start Date:";
            // 
            // dtm_PartitionFunction_Start
            // 
            this.dtm_PartitionFunction_Start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtm_PartitionFunction_Start.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtm_PartitionFunction_Start.Location = new System.Drawing.Point(3, 25);
            this.dtm_PartitionFunction_Start.Name = "dtm_PartitionFunction_Start";
            this.dtm_PartitionFunction_Start.Size = new System.Drawing.Size(189, 22);
            this.dtm_PartitionFunction_Start.TabIndex = 3;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.gridPartitionFunction, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(402, 470);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // gridPartitionFunction
            // 
            this.gridPartitionFunction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPartitionFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPartitionFunction.Location = new System.Drawing.Point(3, 3);
            this.gridPartitionFunction.Name = "gridPartitionFunction";
            this.gridPartitionFunction.Size = new System.Drawing.Size(396, 424);
            this.gridPartitionFunction.TabIndex = 5;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.Controls.Add(this.btn_PartitionFunction_Execute, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btn_PartitionFunction_CheckSyntax, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btn_PartitionFunction_Reload, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 433);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(396, 34);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // btn_PartitionFunction_Execute
            // 
            this.btn_PartitionFunction_Execute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_PartitionFunction_Execute.Enabled = false;
            this.btn_PartitionFunction_Execute.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_PartitionFunction_Execute.Location = new System.Drawing.Point(267, 3);
            this.btn_PartitionFunction_Execute.Name = "btn_PartitionFunction_Execute";
            this.btn_PartitionFunction_Execute.Size = new System.Drawing.Size(126, 28);
            this.btn_PartitionFunction_Execute.TabIndex = 1;
            this.btn_PartitionFunction_Execute.Text = "Execute";
            this.btn_PartitionFunction_Execute.UseVisualStyleBackColor = true;
            // 
            // btn_PartitionFunction_CheckSyntax
            // 
            this.btn_PartitionFunction_CheckSyntax.AutoSize = true;
            this.btn_PartitionFunction_CheckSyntax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_PartitionFunction_CheckSyntax.Enabled = false;
            this.btn_PartitionFunction_CheckSyntax.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_PartitionFunction_CheckSyntax.Location = new System.Drawing.Point(135, 3);
            this.btn_PartitionFunction_CheckSyntax.Name = "btn_PartitionFunction_CheckSyntax";
            this.btn_PartitionFunction_CheckSyntax.Size = new System.Drawing.Size(126, 28);
            this.btn_PartitionFunction_CheckSyntax.TabIndex = 2;
            this.btn_PartitionFunction_CheckSyntax.Text = "Check Syntax";
            this.btn_PartitionFunction_CheckSyntax.UseVisualStyleBackColor = true;
            // 
            // btn_PartitionFunction_Reload
            // 
            this.btn_PartitionFunction_Reload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_PartitionFunction_Reload.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_PartitionFunction_Reload.Location = new System.Drawing.Point(3, 3);
            this.btn_PartitionFunction_Reload.Name = "btn_PartitionFunction_Reload";
            this.btn_PartitionFunction_Reload.Size = new System.Drawing.Size(126, 28);
            this.btn_PartitionFunction_Reload.TabIndex = 0;
            this.btn_PartitionFunction_Reload.Text = "Reload";
            this.btn_PartitionFunction_Reload.UseVisualStyleBackColor = true;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(1, 0);
            this.splitContainer5.Margin = new System.Windows.Forms.Padding(5);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.tableLayoutPanel4);
            this.splitContainer5.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.tableLayoutPanel8);
            this.splitContainer5.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer5.Size = new System.Drawing.Size(383, 606);
            this.splitContainer5.SplitterDistance = 125;
            this.splitContainer5.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.grpBx_PartitionSchemeName, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.grpBx_PartitionFunctionSelect, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.16667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.83333F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(377, 119);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // grpBx_PartitionSchemeName
            // 
            this.grpBx_PartitionSchemeName.Controls.Add(this.tbx_PartitionSchemeName);
            this.grpBx_PartitionSchemeName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBx_PartitionSchemeName.Location = new System.Drawing.Point(3, 3);
            this.grpBx_PartitionSchemeName.Name = "grpBx_PartitionSchemeName";
            this.grpBx_PartitionSchemeName.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.grpBx_PartitionSchemeName.Size = new System.Drawing.Size(371, 52);
            this.grpBx_PartitionSchemeName.TabIndex = 3;
            this.grpBx_PartitionSchemeName.TabStop = false;
            this.grpBx_PartitionSchemeName.Text = "Partition Scheme Name:";
            // 
            // tbx_PartitionSchemeName
            // 
            this.tbx_PartitionSchemeName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_PartitionSchemeName.Location = new System.Drawing.Point(3, 25);
            this.tbx_PartitionSchemeName.Name = "tbx_PartitionSchemeName";
            this.tbx_PartitionSchemeName.Size = new System.Drawing.Size(365, 22);
            this.tbx_PartitionSchemeName.TabIndex = 0;
            // 
            // grpBx_PartitionFunctionSelect
            // 
            this.grpBx_PartitionFunctionSelect.Controls.Add(this.cbx_PartitionFunctionSelect);
            this.grpBx_PartitionFunctionSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBx_PartitionFunctionSelect.Location = new System.Drawing.Point(3, 61);
            this.grpBx_PartitionFunctionSelect.Name = "grpBx_PartitionFunctionSelect";
            this.grpBx_PartitionFunctionSelect.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.grpBx_PartitionFunctionSelect.Size = new System.Drawing.Size(371, 55);
            this.grpBx_PartitionFunctionSelect.TabIndex = 4;
            this.grpBx_PartitionFunctionSelect.TabStop = false;
            this.grpBx_PartitionFunctionSelect.Text = "Select Partition Function:";
            // 
            // cbx_PartitionFunctionSelect
            // 
            this.cbx_PartitionFunctionSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_PartitionFunctionSelect.FormattingEnabled = true;
            this.cbx_PartitionFunctionSelect.Location = new System.Drawing.Point(3, 25);
            this.cbx_PartitionFunctionSelect.Name = "cbx_PartitionFunctionSelect";
            this.cbx_PartitionFunctionSelect.Size = new System.Drawing.Size(365, 24);
            this.cbx_PartitionFunctionSelect.TabIndex = 0;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.gridPartitionScheme, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel9, 0, 1);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(377, 471);
            this.tableLayoutPanel8.TabIndex = 3;
            // 
            // gridPartitionScheme
            // 
            this.gridPartitionScheme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPartitionScheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPartitionScheme.Location = new System.Drawing.Point(3, 3);
            this.gridPartitionScheme.Name = "gridPartitionScheme";
            this.gridPartitionScheme.Size = new System.Drawing.Size(371, 425);
            this.gridPartitionScheme.TabIndex = 5;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 3;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel9.Controls.Add(this.btn_PartitionScheme_Execute, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.btn_PartitionScheme_CheckSyntax, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.btn_PartitionScheme_Reload, 0, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 434);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(371, 34);
            this.tableLayoutPanel9.TabIndex = 0;
            // 
            // btn_PartitionScheme_Execute
            // 
            this.btn_PartitionScheme_Execute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_PartitionScheme_Execute.Enabled = false;
            this.btn_PartitionScheme_Execute.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_PartitionScheme_Execute.Location = new System.Drawing.Point(249, 3);
            this.btn_PartitionScheme_Execute.Name = "btn_PartitionScheme_Execute";
            this.btn_PartitionScheme_Execute.Size = new System.Drawing.Size(119, 28);
            this.btn_PartitionScheme_Execute.TabIndex = 1;
            this.btn_PartitionScheme_Execute.Text = "Execute";
            this.btn_PartitionScheme_Execute.UseVisualStyleBackColor = true;
            // 
            // btn_PartitionScheme_CheckSyntax
            // 
            this.btn_PartitionScheme_CheckSyntax.AutoSize = true;
            this.btn_PartitionScheme_CheckSyntax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_PartitionScheme_CheckSyntax.Enabled = false;
            this.btn_PartitionScheme_CheckSyntax.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_PartitionScheme_CheckSyntax.Location = new System.Drawing.Point(126, 3);
            this.btn_PartitionScheme_CheckSyntax.Name = "btn_PartitionScheme_CheckSyntax";
            this.btn_PartitionScheme_CheckSyntax.Size = new System.Drawing.Size(117, 28);
            this.btn_PartitionScheme_CheckSyntax.TabIndex = 2;
            this.btn_PartitionScheme_CheckSyntax.Text = "Check Syntax";
            this.btn_PartitionScheme_CheckSyntax.UseVisualStyleBackColor = true;
            // 
            // btn_PartitionScheme_Reload
            // 
            this.btn_PartitionScheme_Reload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_PartitionScheme_Reload.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_PartitionScheme_Reload.Location = new System.Drawing.Point(3, 3);
            this.btn_PartitionScheme_Reload.Name = "btn_PartitionScheme_Reload";
            this.btn_PartitionScheme_Reload.Size = new System.Drawing.Size(117, 28);
            this.btn_PartitionScheme_Reload.TabIndex = 0;
            this.btn_PartitionScheme_Reload.Text = "Reload";
            this.btn_PartitionScheme_Reload.UseVisualStyleBackColor = true;
            // 
            // tabTgtMetadata
            // 
            this.tabTgtMetadata.Controls.Add(this.split_TgtMetadata);
            this.tabTgtMetadata.Location = new System.Drawing.Point(4, 25);
            this.tabTgtMetadata.Name = "tabTgtMetadata";
            this.tabTgtMetadata.Padding = new System.Windows.Forms.Padding(3);
            this.tabTgtMetadata.Size = new System.Drawing.Size(1476, 608);
            this.tabTgtMetadata.TabIndex = 2;
            this.tabTgtMetadata.Text = "Tgt Metadata";
            this.tabTgtMetadata.UseVisualStyleBackColor = true;
            // 
            // split_TgtMetadata
            // 
            this.split_TgtMetadata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.split_TgtMetadata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_TgtMetadata.Location = new System.Drawing.Point(3, 3);
            this.split_TgtMetadata.Name = "split_TgtMetadata";
            // 
            // split_TgtMetadata.Panel1
            // 
            this.split_TgtMetadata.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.split_TgtMetadata.Panel1.Controls.Add(this.split_TgtMeta_Current);
            // 
            // split_TgtMetadata.Panel2
            // 
            this.split_TgtMetadata.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.split_TgtMetadata.Panel2.Controls.Add(this.split_TgtMeta_StagingArchive);
            this.split_TgtMetadata.Size = new System.Drawing.Size(1470, 602);
            this.split_TgtMetadata.SplitterDistance = 457;
            this.split_TgtMetadata.TabIndex = 1;
            // 
            // split_TgtMeta_Current
            // 
            this.split_TgtMeta_Current.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_TgtMeta_Current.Location = new System.Drawing.Point(0, 0);
            this.split_TgtMeta_Current.Margin = new System.Windows.Forms.Padding(5);
            this.split_TgtMeta_Current.Name = "split_TgtMeta_Current";
            this.split_TgtMeta_Current.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split_TgtMeta_Current.Panel1
            // 
            this.split_TgtMeta_Current.Panel1.Controls.Add(this.tblp_TgtMeta_ColumnList_Current);
            this.split_TgtMeta_Current.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // split_TgtMeta_Current.Panel2
            // 
            this.split_TgtMeta_Current.Panel2.Controls.Add(this.tblp_TgtMeta_ConstraintList_Current);
            this.split_TgtMeta_Current.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.split_TgtMeta_Current.Size = new System.Drawing.Size(455, 600);
            this.split_TgtMeta_Current.SplitterDistance = 362;
            this.split_TgtMeta_Current.TabIndex = 1;
            // 
            // tblp_TgtMeta_ColumnList_Current
            // 
            this.tblp_TgtMeta_ColumnList_Current.ColumnCount = 1;
            this.tblp_TgtMeta_ColumnList_Current.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TgtMeta_ColumnList_Current.Controls.Add(this.gridColList_Current, 0, 1);
            this.tblp_TgtMeta_ColumnList_Current.Controls.Add(this.pnlTgtTableName_Current, 0, 0);
            this.tblp_TgtMeta_ColumnList_Current.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblp_TgtMeta_ColumnList_Current.Location = new System.Drawing.Point(3, 3);
            this.tblp_TgtMeta_ColumnList_Current.Name = "tblp_TgtMeta_ColumnList_Current";
            this.tblp_TgtMeta_ColumnList_Current.RowCount = 2;
            this.tblp_TgtMeta_ColumnList_Current.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_TgtMeta_ColumnList_Current.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TgtMeta_ColumnList_Current.Size = new System.Drawing.Size(449, 356);
            this.tblp_TgtMeta_ColumnList_Current.TabIndex = 0;
            // 
            // gridColList_Current
            // 
            this.gridColList_Current.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridColList_Current.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridColList_Current.Location = new System.Drawing.Point(3, 33);
            this.gridColList_Current.Name = "gridColList_Current";
            this.gridColList_Current.Size = new System.Drawing.Size(443, 320);
            this.gridColList_Current.TabIndex = 4;
            // 
            // pnlTgtTableName_Current
            // 
            this.pnlTgtTableName_Current.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTgtTableName_Current.Controls.Add(this.tbx_TgtMetadataTableName_Current);
            this.pnlTgtTableName_Current.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTgtTableName_Current.Location = new System.Drawing.Point(3, 3);
            this.pnlTgtTableName_Current.Name = "pnlTgtTableName_Current";
            this.pnlTgtTableName_Current.Size = new System.Drawing.Size(443, 24);
            this.pnlTgtTableName_Current.TabIndex = 3;
            // 
            // tbx_TgtMetadataTableName_Current
            // 
            this.tbx_TgtMetadataTableName_Current.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_TgtMetadataTableName_Current.Location = new System.Drawing.Point(0, 0);
            this.tbx_TgtMetadataTableName_Current.Name = "tbx_TgtMetadataTableName_Current";
            this.tbx_TgtMetadataTableName_Current.Size = new System.Drawing.Size(441, 22);
            this.tbx_TgtMetadataTableName_Current.TabIndex = 0;
            // 
            // tblp_TgtMeta_ConstraintList_Current
            // 
            this.tblp_TgtMeta_ConstraintList_Current.ColumnCount = 1;
            this.tblp_TgtMeta_ConstraintList_Current.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TgtMeta_ConstraintList_Current.Controls.Add(this.gridConstraintList_Current, 0, 0);
            this.tblp_TgtMeta_ConstraintList_Current.Controls.Add(this.tblp_TgtMeta_Btns_Current, 0, 1);
            this.tblp_TgtMeta_ConstraintList_Current.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblp_TgtMeta_ConstraintList_Current.Location = new System.Drawing.Point(3, 3);
            this.tblp_TgtMeta_ConstraintList_Current.Name = "tblp_TgtMeta_ConstraintList_Current";
            this.tblp_TgtMeta_ConstraintList_Current.RowCount = 2;
            this.tblp_TgtMeta_ConstraintList_Current.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TgtMeta_ConstraintList_Current.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblp_TgtMeta_ConstraintList_Current.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblp_TgtMeta_ConstraintList_Current.Size = new System.Drawing.Size(449, 228);
            this.tblp_TgtMeta_ConstraintList_Current.TabIndex = 1;
            // 
            // gridConstraintList_Current
            // 
            this.gridConstraintList_Current.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridConstraintList_Current.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridConstraintList_Current.Location = new System.Drawing.Point(3, 3);
            this.gridConstraintList_Current.Name = "gridConstraintList_Current";
            this.gridConstraintList_Current.Size = new System.Drawing.Size(443, 182);
            this.gridConstraintList_Current.TabIndex = 5;
            // 
            // tblp_TgtMeta_Btns_Current
            // 
            this.tblp_TgtMeta_Btns_Current.ColumnCount = 3;
            this.tblp_TgtMeta_Btns_Current.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblp_TgtMeta_Btns_Current.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblp_TgtMeta_Btns_Current.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblp_TgtMeta_Btns_Current.Controls.Add(this.btnCurrentExecute, 0, 0);
            this.tblp_TgtMeta_Btns_Current.Controls.Add(this.btnCurrentSyntax, 0, 0);
            this.tblp_TgtMeta_Btns_Current.Controls.Add(this.btnCurrentReload, 0, 0);
            this.tblp_TgtMeta_Btns_Current.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tblp_TgtMeta_Btns_Current.Location = new System.Drawing.Point(3, 191);
            this.tblp_TgtMeta_Btns_Current.Name = "tblp_TgtMeta_Btns_Current";
            this.tblp_TgtMeta_Btns_Current.RowCount = 1;
            this.tblp_TgtMeta_Btns_Current.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TgtMeta_Btns_Current.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tblp_TgtMeta_Btns_Current.Size = new System.Drawing.Size(443, 34);
            this.tblp_TgtMeta_Btns_Current.TabIndex = 0;
            // 
            // btnCurrentExecute
            // 
            this.btnCurrentExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCurrentExecute.Enabled = false;
            this.btnCurrentExecute.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCurrentExecute.Location = new System.Drawing.Point(297, 3);
            this.btnCurrentExecute.Name = "btnCurrentExecute";
            this.btnCurrentExecute.Size = new System.Drawing.Size(143, 28);
            this.btnCurrentExecute.TabIndex = 1;
            this.btnCurrentExecute.Text = "Execute";
            this.btnCurrentExecute.UseVisualStyleBackColor = true;
            // 
            // btnCurrentSyntax
            // 
            this.btnCurrentSyntax.AutoSize = true;
            this.btnCurrentSyntax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCurrentSyntax.Enabled = false;
            this.btnCurrentSyntax.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCurrentSyntax.Location = new System.Drawing.Point(150, 3);
            this.btnCurrentSyntax.Name = "btnCurrentSyntax";
            this.btnCurrentSyntax.Size = new System.Drawing.Size(141, 28);
            this.btnCurrentSyntax.TabIndex = 2;
            this.btnCurrentSyntax.Text = "Check Syntax";
            this.btnCurrentSyntax.UseVisualStyleBackColor = true;
            // 
            // btnCurrentReload
            // 
            this.btnCurrentReload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCurrentReload.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCurrentReload.Location = new System.Drawing.Point(3, 3);
            this.btnCurrentReload.Name = "btnCurrentReload";
            this.btnCurrentReload.Size = new System.Drawing.Size(141, 28);
            this.btnCurrentReload.TabIndex = 0;
            this.btnCurrentReload.Text = "Reload";
            this.btnCurrentReload.UseVisualStyleBackColor = true;
            // 
            // split_TgtMeta_StagingArchive
            // 
            this.split_TgtMeta_StagingArchive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.split_TgtMeta_StagingArchive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_TgtMeta_StagingArchive.Location = new System.Drawing.Point(0, 0);
            this.split_TgtMeta_StagingArchive.Name = "split_TgtMeta_StagingArchive";
            // 
            // split_TgtMeta_StagingArchive.Panel1
            // 
            this.split_TgtMeta_StagingArchive.Panel1.Controls.Add(this.splitStaging);
            this.split_TgtMeta_StagingArchive.Panel1.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.split_TgtMeta_StagingArchive.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            // 
            // split_TgtMeta_StagingArchive.Panel2
            // 
            this.split_TgtMeta_StagingArchive.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.split_TgtMeta_StagingArchive.Panel2.Controls.Add(this.split_TgtMeta_Archive);
            this.split_TgtMeta_StagingArchive.Panel2.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.split_TgtMeta_StagingArchive.Panel2.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.split_TgtMeta_StagingArchive.Size = new System.Drawing.Size(1009, 602);
            this.split_TgtMeta_StagingArchive.SplitterDistance = 480;
            this.split_TgtMeta_StagingArchive.TabIndex = 0;
            // 
            // splitStaging
            // 
            this.splitStaging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitStaging.Location = new System.Drawing.Point(0, 0);
            this.splitStaging.Margin = new System.Windows.Forms.Padding(5);
            this.splitStaging.Name = "splitStaging";
            this.splitStaging.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitStaging.Panel1
            // 
            this.splitStaging.Panel1.Controls.Add(this.tblp_TgtMeta_ColumnList_Staging);
            this.splitStaging.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitStaging.Panel2
            // 
            this.splitStaging.Panel2.Controls.Add(this.tblp_TgtMeta_ConstraintList_Staging);
            this.splitStaging.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitStaging.Size = new System.Drawing.Size(477, 600);
            this.splitStaging.SplitterDistance = 362;
            this.splitStaging.TabIndex = 2;
            // 
            // tblp_TgtMeta_ColumnList_Staging
            // 
            this.tblp_TgtMeta_ColumnList_Staging.ColumnCount = 1;
            this.tblp_TgtMeta_ColumnList_Staging.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TgtMeta_ColumnList_Staging.Controls.Add(this.gridColList_Staging, 0, 1);
            this.tblp_TgtMeta_ColumnList_Staging.Controls.Add(this.pnlTgtTableName_Staging, 0, 0);
            this.tblp_TgtMeta_ColumnList_Staging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblp_TgtMeta_ColumnList_Staging.Location = new System.Drawing.Point(3, 3);
            this.tblp_TgtMeta_ColumnList_Staging.Name = "tblp_TgtMeta_ColumnList_Staging";
            this.tblp_TgtMeta_ColumnList_Staging.RowCount = 2;
            this.tblp_TgtMeta_ColumnList_Staging.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_TgtMeta_ColumnList_Staging.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TgtMeta_ColumnList_Staging.Size = new System.Drawing.Size(471, 356);
            this.tblp_TgtMeta_ColumnList_Staging.TabIndex = 1;
            // 
            // gridColList_Staging
            // 
            this.gridColList_Staging.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridColList_Staging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridColList_Staging.Location = new System.Drawing.Point(3, 33);
            this.gridColList_Staging.Name = "gridColList_Staging";
            this.gridColList_Staging.Size = new System.Drawing.Size(465, 320);
            this.gridColList_Staging.TabIndex = 4;
            // 
            // pnlTgtTableName_Staging
            // 
            this.pnlTgtTableName_Staging.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTgtTableName_Staging.Controls.Add(this.tbx_TgtMetadataTableName_Staging);
            this.pnlTgtTableName_Staging.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTgtTableName_Staging.Location = new System.Drawing.Point(3, 3);
            this.pnlTgtTableName_Staging.Name = "pnlTgtTableName_Staging";
            this.pnlTgtTableName_Staging.Size = new System.Drawing.Size(465, 24);
            this.pnlTgtTableName_Staging.TabIndex = 3;
            // 
            // tbx_TgtMetadataTableName_Staging
            // 
            this.tbx_TgtMetadataTableName_Staging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_TgtMetadataTableName_Staging.Location = new System.Drawing.Point(0, 0);
            this.tbx_TgtMetadataTableName_Staging.Name = "tbx_TgtMetadataTableName_Staging";
            this.tbx_TgtMetadataTableName_Staging.Size = new System.Drawing.Size(463, 22);
            this.tbx_TgtMetadataTableName_Staging.TabIndex = 0;
            // 
            // tblp_TgtMeta_ConstraintList_Staging
            // 
            this.tblp_TgtMeta_ConstraintList_Staging.ColumnCount = 1;
            this.tblp_TgtMeta_ConstraintList_Staging.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TgtMeta_ConstraintList_Staging.Controls.Add(this.gridConstraintList_Staging, 0, 0);
            this.tblp_TgtMeta_ConstraintList_Staging.Controls.Add(this.tblp_TgtMeta_Btns_Staging, 0, 1);
            this.tblp_TgtMeta_ConstraintList_Staging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblp_TgtMeta_ConstraintList_Staging.Location = new System.Drawing.Point(3, 3);
            this.tblp_TgtMeta_ConstraintList_Staging.Name = "tblp_TgtMeta_ConstraintList_Staging";
            this.tblp_TgtMeta_ConstraintList_Staging.RowCount = 2;
            this.tblp_TgtMeta_ConstraintList_Staging.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TgtMeta_ConstraintList_Staging.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblp_TgtMeta_ConstraintList_Staging.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblp_TgtMeta_ConstraintList_Staging.Size = new System.Drawing.Size(471, 228);
            this.tblp_TgtMeta_ConstraintList_Staging.TabIndex = 2;
            // 
            // gridConstraintList_Staging
            // 
            this.gridConstraintList_Staging.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridConstraintList_Staging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridConstraintList_Staging.Location = new System.Drawing.Point(3, 3);
            this.gridConstraintList_Staging.Name = "gridConstraintList_Staging";
            this.gridConstraintList_Staging.Size = new System.Drawing.Size(465, 182);
            this.gridConstraintList_Staging.TabIndex = 5;
            // 
            // tblp_TgtMeta_Btns_Staging
            // 
            this.tblp_TgtMeta_Btns_Staging.ColumnCount = 3;
            this.tblp_TgtMeta_Btns_Staging.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblp_TgtMeta_Btns_Staging.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblp_TgtMeta_Btns_Staging.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblp_TgtMeta_Btns_Staging.Controls.Add(this.btnStagingExecute, 0, 0);
            this.tblp_TgtMeta_Btns_Staging.Controls.Add(this.btnStagingSyntax, 0, 0);
            this.tblp_TgtMeta_Btns_Staging.Controls.Add(this.btnStagingReload, 0, 0);
            this.tblp_TgtMeta_Btns_Staging.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tblp_TgtMeta_Btns_Staging.Location = new System.Drawing.Point(3, 191);
            this.tblp_TgtMeta_Btns_Staging.Name = "tblp_TgtMeta_Btns_Staging";
            this.tblp_TgtMeta_Btns_Staging.RowCount = 1;
            this.tblp_TgtMeta_Btns_Staging.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TgtMeta_Btns_Staging.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tblp_TgtMeta_Btns_Staging.Size = new System.Drawing.Size(465, 34);
            this.tblp_TgtMeta_Btns_Staging.TabIndex = 0;
            // 
            // btnStagingExecute
            // 
            this.btnStagingExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStagingExecute.Enabled = false;
            this.btnStagingExecute.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStagingExecute.Location = new System.Drawing.Point(313, 3);
            this.btnStagingExecute.Name = "btnStagingExecute";
            this.btnStagingExecute.Size = new System.Drawing.Size(149, 28);
            this.btnStagingExecute.TabIndex = 1;
            this.btnStagingExecute.Text = "Execute";
            this.btnStagingExecute.UseVisualStyleBackColor = true;
            // 
            // btnStagingSyntax
            // 
            this.btnStagingSyntax.AutoSize = true;
            this.btnStagingSyntax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStagingSyntax.Enabled = false;
            this.btnStagingSyntax.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStagingSyntax.Location = new System.Drawing.Point(158, 3);
            this.btnStagingSyntax.Name = "btnStagingSyntax";
            this.btnStagingSyntax.Size = new System.Drawing.Size(149, 28);
            this.btnStagingSyntax.TabIndex = 2;
            this.btnStagingSyntax.Text = "Check Syntax";
            this.btnStagingSyntax.UseVisualStyleBackColor = true;
            // 
            // btnStagingReload
            // 
            this.btnStagingReload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStagingReload.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStagingReload.Location = new System.Drawing.Point(3, 3);
            this.btnStagingReload.Name = "btnStagingReload";
            this.btnStagingReload.Size = new System.Drawing.Size(149, 28);
            this.btnStagingReload.TabIndex = 0;
            this.btnStagingReload.Text = "Reload";
            this.btnStagingReload.UseVisualStyleBackColor = true;
            // 
            // split_TgtMeta_Archive
            // 
            this.split_TgtMeta_Archive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_TgtMeta_Archive.Location = new System.Drawing.Point(1, 0);
            this.split_TgtMeta_Archive.Margin = new System.Windows.Forms.Padding(5);
            this.split_TgtMeta_Archive.Name = "split_TgtMeta_Archive";
            this.split_TgtMeta_Archive.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split_TgtMeta_Archive.Panel1
            // 
            this.split_TgtMeta_Archive.Panel1.Controls.Add(this.tblp_TgtMeta_ColumnList_Archive);
            this.split_TgtMeta_Archive.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // split_TgtMeta_Archive.Panel2
            // 
            this.split_TgtMeta_Archive.Panel2.Controls.Add(this.tblp_TgtMeta_ConstraintList_Archive);
            this.split_TgtMeta_Archive.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.split_TgtMeta_Archive.Size = new System.Drawing.Size(522, 600);
            this.split_TgtMeta_Archive.SplitterDistance = 362;
            this.split_TgtMeta_Archive.TabIndex = 2;
            // 
            // tblp_TgtMeta_ColumnList_Archive
            // 
            this.tblp_TgtMeta_ColumnList_Archive.ColumnCount = 1;
            this.tblp_TgtMeta_ColumnList_Archive.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TgtMeta_ColumnList_Archive.Controls.Add(this.gridColList_Archive, 0, 1);
            this.tblp_TgtMeta_ColumnList_Archive.Controls.Add(this.pnlTgtTableName_Archive, 0, 0);
            this.tblp_TgtMeta_ColumnList_Archive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblp_TgtMeta_ColumnList_Archive.Location = new System.Drawing.Point(3, 3);
            this.tblp_TgtMeta_ColumnList_Archive.Name = "tblp_TgtMeta_ColumnList_Archive";
            this.tblp_TgtMeta_ColumnList_Archive.RowCount = 2;
            this.tblp_TgtMeta_ColumnList_Archive.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_TgtMeta_ColumnList_Archive.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TgtMeta_ColumnList_Archive.Size = new System.Drawing.Size(516, 356);
            this.tblp_TgtMeta_ColumnList_Archive.TabIndex = 2;
            // 
            // gridColList_Archive
            // 
            this.gridColList_Archive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridColList_Archive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridColList_Archive.Location = new System.Drawing.Point(3, 33);
            this.gridColList_Archive.Name = "gridColList_Archive";
            this.gridColList_Archive.Size = new System.Drawing.Size(510, 320);
            this.gridColList_Archive.TabIndex = 4;
            // 
            // pnlTgtTableName_Archive
            // 
            this.pnlTgtTableName_Archive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTgtTableName_Archive.Controls.Add(this.tbx_TgtMetaDataTableName_Archive);
            this.pnlTgtTableName_Archive.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTgtTableName_Archive.Location = new System.Drawing.Point(3, 3);
            this.pnlTgtTableName_Archive.Name = "pnlTgtTableName_Archive";
            this.pnlTgtTableName_Archive.Size = new System.Drawing.Size(510, 24);
            this.pnlTgtTableName_Archive.TabIndex = 3;
            // 
            // tbx_TgtMetaDataTableName_Archive
            // 
            this.tbx_TgtMetaDataTableName_Archive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_TgtMetaDataTableName_Archive.Location = new System.Drawing.Point(0, 0);
            this.tbx_TgtMetaDataTableName_Archive.Name = "tbx_TgtMetaDataTableName_Archive";
            this.tbx_TgtMetaDataTableName_Archive.Size = new System.Drawing.Size(508, 22);
            this.tbx_TgtMetaDataTableName_Archive.TabIndex = 0;
            // 
            // tblp_TgtMeta_ConstraintList_Archive
            // 
            this.tblp_TgtMeta_ConstraintList_Archive.ColumnCount = 1;
            this.tblp_TgtMeta_ConstraintList_Archive.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TgtMeta_ConstraintList_Archive.Controls.Add(this.gridConstraintList_Archive, 0, 0);
            this.tblp_TgtMeta_ConstraintList_Archive.Controls.Add(this.tblp_TgtMeta_Btns_Archive, 0, 1);
            this.tblp_TgtMeta_ConstraintList_Archive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblp_TgtMeta_ConstraintList_Archive.Location = new System.Drawing.Point(3, 3);
            this.tblp_TgtMeta_ConstraintList_Archive.Name = "tblp_TgtMeta_ConstraintList_Archive";
            this.tblp_TgtMeta_ConstraintList_Archive.RowCount = 2;
            this.tblp_TgtMeta_ConstraintList_Archive.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TgtMeta_ConstraintList_Archive.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblp_TgtMeta_ConstraintList_Archive.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblp_TgtMeta_ConstraintList_Archive.Size = new System.Drawing.Size(516, 228);
            this.tblp_TgtMeta_ConstraintList_Archive.TabIndex = 3;
            // 
            // gridConstraintList_Archive
            // 
            this.gridConstraintList_Archive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridConstraintList_Archive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridConstraintList_Archive.Location = new System.Drawing.Point(3, 3);
            this.gridConstraintList_Archive.Name = "gridConstraintList_Archive";
            this.gridConstraintList_Archive.Size = new System.Drawing.Size(510, 182);
            this.gridConstraintList_Archive.TabIndex = 5;
            // 
            // tblp_TgtMeta_Btns_Archive
            // 
            this.tblp_TgtMeta_Btns_Archive.ColumnCount = 3;
            this.tblp_TgtMeta_Btns_Archive.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblp_TgtMeta_Btns_Archive.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblp_TgtMeta_Btns_Archive.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblp_TgtMeta_Btns_Archive.Controls.Add(this.btnArchiveExecute, 0, 0);
            this.tblp_TgtMeta_Btns_Archive.Controls.Add(this.btnArchiveSyntax, 0, 0);
            this.tblp_TgtMeta_Btns_Archive.Controls.Add(this.btnArchiveReload, 0, 0);
            this.tblp_TgtMeta_Btns_Archive.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tblp_TgtMeta_Btns_Archive.Location = new System.Drawing.Point(3, 191);
            this.tblp_TgtMeta_Btns_Archive.Name = "tblp_TgtMeta_Btns_Archive";
            this.tblp_TgtMeta_Btns_Archive.RowCount = 1;
            this.tblp_TgtMeta_Btns_Archive.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TgtMeta_Btns_Archive.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tblp_TgtMeta_Btns_Archive.Size = new System.Drawing.Size(510, 34);
            this.tblp_TgtMeta_Btns_Archive.TabIndex = 0;
            // 
            // btnArchiveExecute
            // 
            this.btnArchiveExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnArchiveExecute.Enabled = false;
            this.btnArchiveExecute.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnArchiveExecute.Location = new System.Drawing.Point(343, 3);
            this.btnArchiveExecute.Name = "btnArchiveExecute";
            this.btnArchiveExecute.Size = new System.Drawing.Size(164, 28);
            this.btnArchiveExecute.TabIndex = 1;
            this.btnArchiveExecute.Text = "Execute";
            this.btnArchiveExecute.UseVisualStyleBackColor = true;
            // 
            // btnArchiveSyntax
            // 
            this.btnArchiveSyntax.AutoSize = true;
            this.btnArchiveSyntax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnArchiveSyntax.Enabled = false;
            this.btnArchiveSyntax.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnArchiveSyntax.Location = new System.Drawing.Point(173, 3);
            this.btnArchiveSyntax.Name = "btnArchiveSyntax";
            this.btnArchiveSyntax.Size = new System.Drawing.Size(164, 28);
            this.btnArchiveSyntax.TabIndex = 2;
            this.btnArchiveSyntax.Text = "Check Syntax";
            this.btnArchiveSyntax.UseVisualStyleBackColor = true;
            // 
            // btnArchiveReload
            // 
            this.btnArchiveReload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnArchiveReload.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnArchiveReload.Location = new System.Drawing.Point(3, 3);
            this.btnArchiveReload.Name = "btnArchiveReload";
            this.btnArchiveReload.Size = new System.Drawing.Size(164, 28);
            this.btnArchiveReload.TabIndex = 0;
            this.btnArchiveReload.Text = "Reload";
            this.btnArchiveReload.UseVisualStyleBackColor = true;
            // 
            // tabTrackingTbl
            // 
            this.tabTrackingTbl.Controls.Add(this.tblp_TrackingTable);
            this.tabTrackingTbl.Location = new System.Drawing.Point(4, 25);
            this.tabTrackingTbl.Name = "tabTrackingTbl";
            this.tabTrackingTbl.Padding = new System.Windows.Forms.Padding(3);
            this.tabTrackingTbl.Size = new System.Drawing.Size(1476, 608);
            this.tabTrackingTbl.TabIndex = 1;
            this.tabTrackingTbl.Text = "Tracking Tbl";
            this.tabTrackingTbl.UseVisualStyleBackColor = true;
            // 
            // tblp_TrackingTable
            // 
            this.tblp_TrackingTable.ColumnCount = 1;
            this.tblp_TrackingTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TrackingTable.Controls.Add(this.gridTrackingTable, 0, 2);
            this.tblp_TrackingTable.Controls.Add(this.split_TrackingTable, 0, 0);
            this.tblp_TrackingTable.Controls.Add(this.split_TrackingTable_SrcTgt, 0, 1);
            this.tblp_TrackingTable.Controls.Add(this.btnTrackingLoadSrcCount, 0, 3);
            this.tblp_TrackingTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblp_TrackingTable.Location = new System.Drawing.Point(3, 3);
            this.tblp_TrackingTable.Name = "tblp_TrackingTable";
            this.tblp_TrackingTable.RowCount = 4;
            this.tblp_TrackingTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tblp_TrackingTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tblp_TrackingTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TrackingTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblp_TrackingTable.Size = new System.Drawing.Size(1470, 602);
            this.tblp_TrackingTable.TabIndex = 0;
            // 
            // gridTrackingTable
            // 
            this.gridTrackingTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTrackingTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTrackingTable.Location = new System.Drawing.Point(5, 235);
            this.gridTrackingTable.Margin = new System.Windows.Forms.Padding(5);
            this.gridTrackingTable.Name = "gridTrackingTable";
            this.gridTrackingTable.Size = new System.Drawing.Size(1460, 322);
            this.gridTrackingTable.TabIndex = 2;
            // 
            // split_TrackingTable
            // 
            this.split_TrackingTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_TrackingTable.Location = new System.Drawing.Point(3, 3);
            this.split_TrackingTable.Name = "split_TrackingTable";
            // 
            // split_TrackingTable.Panel1
            // 
            this.split_TrackingTable.Panel1.Controls.Add(this.tblp_TrackingTbl_InstanceDbSchema);
            // 
            // split_TrackingTable.Panel2
            // 
            this.split_TrackingTable.Panel2.Controls.Add(this.tblp_TrackingTbl_ProjectTables);
            this.split_TrackingTable.Size = new System.Drawing.Size(1464, 174);
            this.split_TrackingTable.SplitterDistance = 517;
            this.split_TrackingTable.TabIndex = 4;
            // 
            // tblp_TrackingTbl_InstanceDbSchema
            // 
            this.tblp_TrackingTbl_InstanceDbSchema.ColumnCount = 1;
            this.tblp_TrackingTbl_InstanceDbSchema.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TrackingTbl_InstanceDbSchema.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblp_TrackingTbl_InstanceDbSchema.Controls.Add(this.grpBx_TrackTbl_Schema, 0, 2);
            this.tblp_TrackingTbl_InstanceDbSchema.Controls.Add(this.grpBx_TrackTbl_Database, 0, 1);
            this.tblp_TrackingTbl_InstanceDbSchema.Controls.Add(this.grpBx_TrackTbl_Instance, 0, 0);
            this.tblp_TrackingTbl_InstanceDbSchema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblp_TrackingTbl_InstanceDbSchema.Location = new System.Drawing.Point(0, 0);
            this.tblp_TrackingTbl_InstanceDbSchema.Name = "tblp_TrackingTbl_InstanceDbSchema";
            this.tblp_TrackingTbl_InstanceDbSchema.RowCount = 3;
            this.tblp_TrackingTbl_InstanceDbSchema.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblp_TrackingTbl_InstanceDbSchema.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblp_TrackingTbl_InstanceDbSchema.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblp_TrackingTbl_InstanceDbSchema.Size = new System.Drawing.Size(517, 174);
            this.tblp_TrackingTbl_InstanceDbSchema.TabIndex = 0;
            // 
            // grpBx_TrackTbl_Schema
            // 
            this.grpBx_TrackTbl_Schema.Controls.Add(this.cbxt_TrackTbl_Schema);
            this.grpBx_TrackTbl_Schema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBx_TrackTbl_Schema.Location = new System.Drawing.Point(3, 119);
            this.grpBx_TrackTbl_Schema.Name = "grpBx_TrackTbl_Schema";
            this.grpBx_TrackTbl_Schema.Size = new System.Drawing.Size(511, 52);
            this.grpBx_TrackTbl_Schema.TabIndex = 3;
            this.grpBx_TrackTbl_Schema.TabStop = false;
            this.grpBx_TrackTbl_Schema.Text = "Schema:";
            // 
            // grpBx_TrackTbl_Database
            // 
            this.grpBx_TrackTbl_Database.Controls.Add(this.cbxt_TrackTbl_Database);
            this.grpBx_TrackTbl_Database.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBx_TrackTbl_Database.Location = new System.Drawing.Point(3, 61);
            this.grpBx_TrackTbl_Database.Name = "grpBx_TrackTbl_Database";
            this.grpBx_TrackTbl_Database.Padding = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.grpBx_TrackTbl_Database.Size = new System.Drawing.Size(511, 52);
            this.grpBx_TrackTbl_Database.TabIndex = 0;
            this.grpBx_TrackTbl_Database.TabStop = false;
            this.grpBx_TrackTbl_Database.Text = "Database:";
            // 
            // grpBx_TrackTbl_Instance
            // 
            this.grpBx_TrackTbl_Instance.Controls.Add(this.tblp_TabTrackTbl_Instance);
            this.grpBx_TrackTbl_Instance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBx_TrackTbl_Instance.Location = new System.Drawing.Point(3, 3);
            this.grpBx_TrackTbl_Instance.Name = "grpBx_TrackTbl_Instance";
            this.grpBx_TrackTbl_Instance.Size = new System.Drawing.Size(511, 52);
            this.grpBx_TrackTbl_Instance.TabIndex = 0;
            this.grpBx_TrackTbl_Instance.TabStop = false;
            this.grpBx_TrackTbl_Instance.Text = "Instance:";
            // 
            // tblp_TabTrackTbl_Instance
            // 
            this.tblp_TabTrackTbl_Instance.ColumnCount = 2;
            this.tblp_TabTrackTbl_Instance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TabTrackTbl_Instance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tblp_TabTrackTbl_Instance.Controls.Add(this.tbx_TrackTbl_Instance, 0, 0);
            this.tblp_TabTrackTbl_Instance.Controls.Add(this.btnLoginTrackTbl, 1, 0);
            this.tblp_TabTrackTbl_Instance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblp_TabTrackTbl_Instance.Location = new System.Drawing.Point(3, 18);
            this.tblp_TabTrackTbl_Instance.Margin = new System.Windows.Forms.Padding(1);
            this.tblp_TabTrackTbl_Instance.Name = "tblp_TabTrackTbl_Instance";
            this.tblp_TabTrackTbl_Instance.Padding = new System.Windows.Forms.Padding(1);
            this.tblp_TabTrackTbl_Instance.RowCount = 1;
            this.tblp_TabTrackTbl_Instance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TabTrackTbl_Instance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tblp_TabTrackTbl_Instance.Size = new System.Drawing.Size(505, 31);
            this.tblp_TabTrackTbl_Instance.TabIndex = 72;
            // 
            // tbx_TrackTbl_Instance
            // 
            this.tbx_TrackTbl_Instance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_TrackTbl_Instance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_TrackTbl_Instance.Location = new System.Drawing.Point(4, 6);
            this.tbx_TrackTbl_Instance.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tbx_TrackTbl_Instance.Name = "tbx_TrackTbl_Instance";
            this.tbx_TrackTbl_Instance.Size = new System.Drawing.Size(407, 22);
            this.tbx_TrackTbl_Instance.TabIndex = 70;
            // 
            // btnLoginTrackTbl
            // 
            this.btnLoginTrackTbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLoginTrackTbl.Location = new System.Drawing.Point(418, 3);
            this.btnLoginTrackTbl.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoginTrackTbl.Name = "btnLoginTrackTbl";
            this.btnLoginTrackTbl.Size = new System.Drawing.Size(84, 25);
            this.btnLoginTrackTbl.TabIndex = 69;
            this.btnLoginTrackTbl.Text = "Login";
            this.btnLoginTrackTbl.UseVisualStyleBackColor = true;
            this.btnLoginTrackTbl.Click += new System.EventHandler(this.btnTrackTblLogin_Click);
            // 
            // tblp_TrackingTbl_ProjectTables
            // 
            this.tblp_TrackingTbl_ProjectTables.ColumnCount = 5;
            this.tblp_TrackingTbl_ProjectTables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TrackingTbl_ProjectTables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tblp_TrackingTbl_ProjectTables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tblp_TrackingTbl_ProjectTables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tblp_TrackingTbl_ProjectTables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tblp_TrackingTbl_ProjectTables.Controls.Add(this.tblp_TrackTbl_ProjectNameSaveRunBtns, 1, 1);
            this.tblp_TrackingTbl_ProjectTables.Controls.Add(this.grpBx_TrackTbl_ProjectName, 0, 1);
            this.tblp_TrackingTbl_ProjectTables.Controls.Add(this.tblp_TrackTbl_ProjectsSaveRunBtns, 1, 0);
            this.tblp_TrackingTbl_ProjectTables.Controls.Add(this.grpBx_TrackTbl_ProjectsTbl, 0, 0);
            this.tblp_TrackingTbl_ProjectTables.Controls.Add(this.grpBx_TrackTbl_ProjectDescription, 0, 2);
            this.tblp_TrackingTbl_ProjectTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblp_TrackingTbl_ProjectTables.Location = new System.Drawing.Point(0, 0);
            this.tblp_TrackingTbl_ProjectTables.Name = "tblp_TrackingTbl_ProjectTables";
            this.tblp_TrackingTbl_ProjectTables.RowCount = 3;
            this.tblp_TrackingTbl_ProjectTables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblp_TrackingTbl_ProjectTables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblp_TrackingTbl_ProjectTables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblp_TrackingTbl_ProjectTables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblp_TrackingTbl_ProjectTables.Size = new System.Drawing.Size(943, 174);
            this.tblp_TrackingTbl_ProjectTables.TabIndex = 0;
            // 
            // tblp_TrackTbl_ProjectNameSaveRunBtns
            // 
            this.tblp_TrackTbl_ProjectNameSaveRunBtns.ColumnCount = 4;
            this.tblp_TrackingTbl_ProjectTables.SetColumnSpan(this.tblp_TrackTbl_ProjectNameSaveRunBtns, 4);
            this.tblp_TrackTbl_ProjectNameSaveRunBtns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblp_TrackTbl_ProjectNameSaveRunBtns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblp_TrackTbl_ProjectNameSaveRunBtns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tblp_TrackTbl_ProjectNameSaveRunBtns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tblp_TrackTbl_ProjectNameSaveRunBtns.Controls.Add(this.btnTrackTbl_ProjectNameEdit, 0, 1);
            this.tblp_TrackTbl_ProjectNameSaveRunBtns.Controls.Add(this.btnTrackTbl_ProjectNameSave, 0, 1);
            this.tblp_TrackTbl_ProjectNameSaveRunBtns.Controls.Add(this.grpBx_TrackTbl_ProjectNameCreateNewUseExisting, 0, 1);
            this.tblp_TrackTbl_ProjectNameSaveRunBtns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblp_TrackTbl_ProjectNameSaveRunBtns.Location = new System.Drawing.Point(619, 58);
            this.tblp_TrackTbl_ProjectNameSaveRunBtns.Margin = new System.Windows.Forms.Padding(0);
            this.tblp_TrackTbl_ProjectNameSaveRunBtns.Name = "tblp_TrackTbl_ProjectNameSaveRunBtns";
            this.tblp_TrackTbl_ProjectNameSaveRunBtns.RowCount = 3;
            this.tblp_TrackTbl_ProjectNameSaveRunBtns.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblp_TrackTbl_ProjectNameSaveRunBtns.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TrackTbl_ProjectNameSaveRunBtns.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tblp_TrackTbl_ProjectNameSaveRunBtns.Size = new System.Drawing.Size(324, 58);
            this.tblp_TrackTbl_ProjectNameSaveRunBtns.TabIndex = 73;
            // 
            // btnTrackTbl_ProjectNameEdit
            // 
            this.btnTrackTbl_ProjectNameEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTrackTbl_ProjectNameEdit.Enabled = false;
            this.btnTrackTbl_ProjectNameEdit.Location = new System.Drawing.Point(232, 18);
            this.btnTrackTbl_ProjectNameEdit.Margin = new System.Windows.Forms.Padding(2, 3, 5, 3);
            this.btnTrackTbl_ProjectNameEdit.Name = "btnTrackTbl_ProjectNameEdit";
            this.btnTrackTbl_ProjectNameEdit.Padding = new System.Windows.Forms.Padding(1);
            this.btnTrackTbl_ProjectNameEdit.Size = new System.Drawing.Size(87, 32);
            this.btnTrackTbl_ProjectNameEdit.TabIndex = 71;
            this.btnTrackTbl_ProjectNameEdit.Text = "Edit";
            this.btnTrackTbl_ProjectNameEdit.UseVisualStyleBackColor = true;
            // 
            // btnTrackTbl_ProjectNameSave
            // 
            this.btnTrackTbl_ProjectNameSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTrackTbl_ProjectNameSave.Enabled = false;
            this.btnTrackTbl_ProjectNameSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTrackTbl_ProjectNameSave.Location = new System.Drawing.Point(143, 18);
            this.btnTrackTbl_ProjectNameSave.Margin = new System.Windows.Forms.Padding(5, 3, 2, 3);
            this.btnTrackTbl_ProjectNameSave.Name = "btnTrackTbl_ProjectNameSave";
            this.btnTrackTbl_ProjectNameSave.Padding = new System.Windows.Forms.Padding(1);
            this.btnTrackTbl_ProjectNameSave.Size = new System.Drawing.Size(85, 32);
            this.btnTrackTbl_ProjectNameSave.TabIndex = 70;
            this.btnTrackTbl_ProjectNameSave.Text = "Save";
            this.btnTrackTbl_ProjectNameSave.UseVisualStyleBackColor = true;
            // 
            // grpBx_TrackTbl_ProjectNameCreateNewUseExisting
            // 
            this.tblp_TrackTbl_ProjectNameSaveRunBtns.SetColumnSpan(this.grpBx_TrackTbl_ProjectNameCreateNewUseExisting, 2);
            this.grpBx_TrackTbl_ProjectNameCreateNewUseExisting.Controls.Add(this.tblp_TrackingTbl_ProjectName);
            this.grpBx_TrackTbl_ProjectNameCreateNewUseExisting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBx_TrackTbl_ProjectNameCreateNewUseExisting.Location = new System.Drawing.Point(0, 15);
            this.grpBx_TrackTbl_ProjectNameCreateNewUseExisting.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.grpBx_TrackTbl_ProjectNameCreateNewUseExisting.Name = "grpBx_TrackTbl_ProjectNameCreateNewUseExisting";
            this.grpBx_TrackTbl_ProjectNameCreateNewUseExisting.Padding = new System.Windows.Forms.Padding(0);
            this.grpBx_TrackTbl_ProjectNameCreateNewUseExisting.Size = new System.Drawing.Size(138, 37);
            this.grpBx_TrackTbl_ProjectNameCreateNewUseExisting.TabIndex = 2;
            this.grpBx_TrackTbl_ProjectNameCreateNewUseExisting.TabStop = false;
            // 
            // tblp_TrackingTbl_ProjectName
            // 
            this.tblp_TrackingTbl_ProjectName.ColumnCount = 2;
            this.tblp_TrackingTbl_ProjectName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblp_TrackingTbl_ProjectName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblp_TrackingTbl_ProjectName.Controls.Add(this.rdbtn_TrackTbl_ProjectNameUseExisting, 1, 1);
            this.tblp_TrackingTbl_ProjectName.Controls.Add(this.rdbtn_TrackTbl_ProjectNameCreateNew, 0, 1);
            this.tblp_TrackingTbl_ProjectName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblp_TrackingTbl_ProjectName.Location = new System.Drawing.Point(0, 15);
            this.tblp_TrackingTbl_ProjectName.Margin = new System.Windows.Forms.Padding(0);
            this.tblp_TrackingTbl_ProjectName.Name = "tblp_TrackingTbl_ProjectName";
            this.tblp_TrackingTbl_ProjectName.RowCount = 2;
            this.tblp_TrackingTbl_ProjectName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TrackingTbl_ProjectName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblp_TrackingTbl_ProjectName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblp_TrackingTbl_ProjectName.Size = new System.Drawing.Size(138, 22);
            this.tblp_TrackingTbl_ProjectName.TabIndex = 0;
            // 
            // rdbtn_TrackTbl_ProjectNameUseExisting
            // 
            this.rdbtn_TrackTbl_ProjectNameUseExisting.AutoSize = true;
            this.rdbtn_TrackTbl_ProjectNameUseExisting.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbtn_TrackTbl_ProjectNameUseExisting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdbtn_TrackTbl_ProjectNameUseExisting.Enabled = false;
            this.rdbtn_TrackTbl_ProjectNameUseExisting.Location = new System.Drawing.Point(69, 2);
            this.rdbtn_TrackTbl_ProjectNameUseExisting.Margin = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.rdbtn_TrackTbl_ProjectNameUseExisting.Name = "rdbtn_TrackTbl_ProjectNameUseExisting";
            this.rdbtn_TrackTbl_ProjectNameUseExisting.Size = new System.Drawing.Size(69, 13);
            this.rdbtn_TrackTbl_ProjectNameUseExisting.TabIndex = 1;
            this.rdbtn_TrackTbl_ProjectNameUseExisting.TabStop = true;
            this.rdbtn_TrackTbl_ProjectNameUseExisting.UseVisualStyleBackColor = true;
            // 
            // grpBx_TrackTbl_ProjectName
            // 
            this.grpBx_TrackTbl_ProjectName.Controls.Add(this.cbxt_TrackTbl_ProjectName);
            this.grpBx_TrackTbl_ProjectName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBx_TrackTbl_ProjectName.Location = new System.Drawing.Point(3, 61);
            this.grpBx_TrackTbl_ProjectName.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.grpBx_TrackTbl_ProjectName.Name = "grpBx_TrackTbl_ProjectName";
            this.grpBx_TrackTbl_ProjectName.Size = new System.Drawing.Size(611, 52);
            this.grpBx_TrackTbl_ProjectName.TabIndex = 7;
            this.grpBx_TrackTbl_ProjectName.TabStop = false;
            this.grpBx_TrackTbl_ProjectName.Text = "Project Name:";
            // 
            // tblp_TrackTbl_ProjectsSaveRunBtns
            // 
            this.tblp_TrackTbl_ProjectsSaveRunBtns.ColumnCount = 4;
            this.tblp_TrackingTbl_ProjectTables.SetColumnSpan(this.tblp_TrackTbl_ProjectsSaveRunBtns, 4);
            this.tblp_TrackTbl_ProjectsSaveRunBtns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblp_TrackTbl_ProjectsSaveRunBtns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblp_TrackTbl_ProjectsSaveRunBtns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tblp_TrackTbl_ProjectsSaveRunBtns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tblp_TrackTbl_ProjectsSaveRunBtns.Controls.Add(this.btnTrackTbl_ProjectsEdit, 0, 1);
            this.tblp_TrackTbl_ProjectsSaveRunBtns.Controls.Add(this.btnTrackTbl_ProjectsSave, 0, 1);
            this.tblp_TrackTbl_ProjectsSaveRunBtns.Controls.Add(this.lblTrackTbl_ProjectsUseExisting, 1, 0);
            this.tblp_TrackTbl_ProjectsSaveRunBtns.Controls.Add(this.lblTrackTbl_ProjectsCreateNew, 0, 0);
            this.tblp_TrackTbl_ProjectsSaveRunBtns.Controls.Add(this.grpBx_TrackTbl_ProjectsTableCreateNewUseExisting, 0, 1);
            this.tblp_TrackTbl_ProjectsSaveRunBtns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblp_TrackTbl_ProjectsSaveRunBtns.Location = new System.Drawing.Point(619, 0);
            this.tblp_TrackTbl_ProjectsSaveRunBtns.Margin = new System.Windows.Forms.Padding(0);
            this.tblp_TrackTbl_ProjectsSaveRunBtns.Name = "tblp_TrackTbl_ProjectsSaveRunBtns";
            this.tblp_TrackTbl_ProjectsSaveRunBtns.RowCount = 2;
            this.tblp_TrackTbl_ProjectsSaveRunBtns.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblp_TrackTbl_ProjectsSaveRunBtns.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TrackTbl_ProjectsSaveRunBtns.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblp_TrackTbl_ProjectsSaveRunBtns.Size = new System.Drawing.Size(324, 58);
            this.tblp_TrackTbl_ProjectsSaveRunBtns.TabIndex = 72;
            // 
            // btnTrackTbl_ProjectsEdit
            // 
            this.btnTrackTbl_ProjectsEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTrackTbl_ProjectsEdit.Enabled = false;
            this.btnTrackTbl_ProjectsEdit.Location = new System.Drawing.Point(232, 23);
            this.btnTrackTbl_ProjectsEdit.Margin = new System.Windows.Forms.Padding(2, 3, 5, 3);
            this.btnTrackTbl_ProjectsEdit.Name = "btnTrackTbl_ProjectsEdit";
            this.btnTrackTbl_ProjectsEdit.Padding = new System.Windows.Forms.Padding(1);
            this.btnTrackTbl_ProjectsEdit.Size = new System.Drawing.Size(87, 32);
            this.btnTrackTbl_ProjectsEdit.TabIndex = 71;
            this.btnTrackTbl_ProjectsEdit.Text = "Edit";
            this.btnTrackTbl_ProjectsEdit.UseVisualStyleBackColor = true;
            // 
            // btnTrackTbl_ProjectsSave
            // 
            this.btnTrackTbl_ProjectsSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTrackTbl_ProjectsSave.Enabled = false;
            this.btnTrackTbl_ProjectsSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTrackTbl_ProjectsSave.Location = new System.Drawing.Point(143, 23);
            this.btnTrackTbl_ProjectsSave.Margin = new System.Windows.Forms.Padding(5, 3, 2, 3);
            this.btnTrackTbl_ProjectsSave.Name = "btnTrackTbl_ProjectsSave";
            this.btnTrackTbl_ProjectsSave.Padding = new System.Windows.Forms.Padding(1);
            this.btnTrackTbl_ProjectsSave.Size = new System.Drawing.Size(85, 32);
            this.btnTrackTbl_ProjectsSave.TabIndex = 70;
            this.btnTrackTbl_ProjectsSave.Text = "Save";
            this.btnTrackTbl_ProjectsSave.UseVisualStyleBackColor = true;
            // 
            // lblTrackTbl_ProjectsUseExisting
            // 
            this.lblTrackTbl_ProjectsUseExisting.AutoSize = true;
            this.lblTrackTbl_ProjectsUseExisting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrackTbl_ProjectsUseExisting.Location = new System.Drawing.Point(72, 0);
            this.lblTrackTbl_ProjectsUseExisting.Name = "lblTrackTbl_ProjectsUseExisting";
            this.lblTrackTbl_ProjectsUseExisting.Size = new System.Drawing.Size(63, 20);
            this.lblTrackTbl_ProjectsUseExisting.TabIndex = 4;
            this.lblTrackTbl_ProjectsUseExisting.Text = "Existing:";
            this.lblTrackTbl_ProjectsUseExisting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTrackTbl_ProjectsCreateNew
            // 
            this.lblTrackTbl_ProjectsCreateNew.AutoSize = true;
            this.lblTrackTbl_ProjectsCreateNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrackTbl_ProjectsCreateNew.Location = new System.Drawing.Point(3, 0);
            this.lblTrackTbl_ProjectsCreateNew.Name = "lblTrackTbl_ProjectsCreateNew";
            this.lblTrackTbl_ProjectsCreateNew.Size = new System.Drawing.Size(63, 20);
            this.lblTrackTbl_ProjectsCreateNew.TabIndex = 3;
            this.lblTrackTbl_ProjectsCreateNew.Text = "New:";
            this.lblTrackTbl_ProjectsCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpBx_TrackTbl_ProjectsTableCreateNewUseExisting
            // 
            this.tblp_TrackTbl_ProjectsSaveRunBtns.SetColumnSpan(this.grpBx_TrackTbl_ProjectsTableCreateNewUseExisting, 2);
            this.grpBx_TrackTbl_ProjectsTableCreateNewUseExisting.Controls.Add(this.tblp_TrackTbl_UseExistingCreateNew);
            this.grpBx_TrackTbl_ProjectsTableCreateNewUseExisting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBx_TrackTbl_ProjectsTableCreateNewUseExisting.Location = new System.Drawing.Point(0, 20);
            this.grpBx_TrackTbl_ProjectsTableCreateNewUseExisting.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.grpBx_TrackTbl_ProjectsTableCreateNewUseExisting.Name = "grpBx_TrackTbl_ProjectsTableCreateNewUseExisting";
            this.grpBx_TrackTbl_ProjectsTableCreateNewUseExisting.Padding = new System.Windows.Forms.Padding(0);
            this.grpBx_TrackTbl_ProjectsTableCreateNewUseExisting.Size = new System.Drawing.Size(138, 37);
            this.grpBx_TrackTbl_ProjectsTableCreateNewUseExisting.TabIndex = 2;
            this.grpBx_TrackTbl_ProjectsTableCreateNewUseExisting.TabStop = false;
            // 
            // tblp_TrackTbl_UseExistingCreateNew
            // 
            this.tblp_TrackTbl_UseExistingCreateNew.ColumnCount = 2;
            this.tblp_TrackTbl_UseExistingCreateNew.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblp_TrackTbl_UseExistingCreateNew.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblp_TrackTbl_UseExistingCreateNew.Controls.Add(this.rdbtn_TrackTbl_ProjectsUseExisting, 1, 1);
            this.tblp_TrackTbl_UseExistingCreateNew.Controls.Add(this.rdbtn_TrackTbl_ProjectsCreateNew, 0, 1);
            this.tblp_TrackTbl_UseExistingCreateNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblp_TrackTbl_UseExistingCreateNew.Location = new System.Drawing.Point(0, 15);
            this.tblp_TrackTbl_UseExistingCreateNew.Margin = new System.Windows.Forms.Padding(0);
            this.tblp_TrackTbl_UseExistingCreateNew.Name = "tblp_TrackTbl_UseExistingCreateNew";
            this.tblp_TrackTbl_UseExistingCreateNew.RowCount = 2;
            this.tblp_TrackTbl_UseExistingCreateNew.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TrackTbl_UseExistingCreateNew.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblp_TrackTbl_UseExistingCreateNew.Size = new System.Drawing.Size(138, 22);
            this.tblp_TrackTbl_UseExistingCreateNew.TabIndex = 0;
            // 
            // rdbtn_TrackTbl_ProjectsUseExisting
            // 
            this.rdbtn_TrackTbl_ProjectsUseExisting.AutoSize = true;
            this.rdbtn_TrackTbl_ProjectsUseExisting.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbtn_TrackTbl_ProjectsUseExisting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdbtn_TrackTbl_ProjectsUseExisting.Location = new System.Drawing.Point(69, -8);
            this.rdbtn_TrackTbl_ProjectsUseExisting.Margin = new System.Windows.Forms.Padding(0);
            this.rdbtn_TrackTbl_ProjectsUseExisting.Name = "rdbtn_TrackTbl_ProjectsUseExisting";
            this.rdbtn_TrackTbl_ProjectsUseExisting.Size = new System.Drawing.Size(69, 30);
            this.rdbtn_TrackTbl_ProjectsUseExisting.TabIndex = 1;
            this.rdbtn_TrackTbl_ProjectsUseExisting.TabStop = true;
            this.rdbtn_TrackTbl_ProjectsUseExisting.UseVisualStyleBackColor = true;
            // 
            // grpBx_TrackTbl_ProjectsTbl
            // 
            this.grpBx_TrackTbl_ProjectsTbl.Controls.Add(this.cbxt_TrackTbl_ProjectsTable);
            this.grpBx_TrackTbl_ProjectsTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBx_TrackTbl_ProjectsTbl.Location = new System.Drawing.Point(3, 3);
            this.grpBx_TrackTbl_ProjectsTbl.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.grpBx_TrackTbl_ProjectsTbl.Name = "grpBx_TrackTbl_ProjectsTbl";
            this.grpBx_TrackTbl_ProjectsTbl.Size = new System.Drawing.Size(611, 52);
            this.grpBx_TrackTbl_ProjectsTbl.TabIndex = 6;
            this.grpBx_TrackTbl_ProjectsTbl.TabStop = false;
            this.grpBx_TrackTbl_ProjectsTbl.Text = "Projects Table:";
            // 
            // grpBx_TrackTbl_ProjectDescription
            // 
            this.grpBx_TrackTbl_ProjectDescription.Controls.Add(this.tbx_TrackTbl_ProjectDescription);
            this.grpBx_TrackTbl_ProjectDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBx_TrackTbl_ProjectDescription.Location = new System.Drawing.Point(3, 119);
            this.grpBx_TrackTbl_ProjectDescription.Name = "grpBx_TrackTbl_ProjectDescription";
            this.grpBx_TrackTbl_ProjectDescription.Size = new System.Drawing.Size(613, 52);
            this.grpBx_TrackTbl_ProjectDescription.TabIndex = 74;
            this.grpBx_TrackTbl_ProjectDescription.TabStop = false;
            this.grpBx_TrackTbl_ProjectDescription.Text = "Project Description:";
            // 
            // tbx_TrackTbl_ProjectDescription
            // 
            this.tbx_TrackTbl_ProjectDescription.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbx_TrackTbl_ProjectDescription.Enabled = false;
            this.tbx_TrackTbl_ProjectDescription.Location = new System.Drawing.Point(3, 27);
            this.tbx_TrackTbl_ProjectDescription.Name = "tbx_TrackTbl_ProjectDescription";
            this.tbx_TrackTbl_ProjectDescription.Size = new System.Drawing.Size(607, 22);
            this.tbx_TrackTbl_ProjectDescription.TabIndex = 0;
            // 
            // split_TrackingTable_SrcTgt
            // 
            this.split_TrackingTable_SrcTgt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_TrackingTable_SrcTgt.Location = new System.Drawing.Point(3, 183);
            this.split_TrackingTable_SrcTgt.Name = "split_TrackingTable_SrcTgt";
            // 
            // split_TrackingTable_SrcTgt.Panel1
            // 
            this.split_TrackingTable_SrcTgt.Panel1.Controls.Add(this.grpbx_TrackingTbl_Src);
            // 
            // split_TrackingTable_SrcTgt.Panel2
            // 
            this.split_TrackingTable_SrcTgt.Panel2.Controls.Add(this.grpbx_TrackingTbl_Tgt);
            this.split_TrackingTable_SrcTgt.Size = new System.Drawing.Size(1464, 44);
            this.split_TrackingTable_SrcTgt.SplitterDistance = 723;
            this.split_TrackingTable_SrcTgt.TabIndex = 5;
            // 
            // grpbx_TrackingTbl_Src
            // 
            this.grpbx_TrackingTbl_Src.Controls.Add(this.tbxTrackFullSource);
            this.grpbx_TrackingTbl_Src.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpbx_TrackingTbl_Src.Location = new System.Drawing.Point(0, 0);
            this.grpbx_TrackingTbl_Src.Name = "grpbx_TrackingTbl_Src";
            this.grpbx_TrackingTbl_Src.Size = new System.Drawing.Size(723, 44);
            this.grpbx_TrackingTbl_Src.TabIndex = 0;
            this.grpbx_TrackingTbl_Src.TabStop = false;
            this.grpbx_TrackingTbl_Src.Text = "Source Table:";
            // 
            // grpbx_TrackingTbl_Tgt
            // 
            this.grpbx_TrackingTbl_Tgt.Controls.Add(this.tbxTrackFullTarget);
            this.grpbx_TrackingTbl_Tgt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpbx_TrackingTbl_Tgt.Location = new System.Drawing.Point(0, 0);
            this.grpbx_TrackingTbl_Tgt.Name = "grpbx_TrackingTbl_Tgt";
            this.grpbx_TrackingTbl_Tgt.Size = new System.Drawing.Size(737, 44);
            this.grpbx_TrackingTbl_Tgt.TabIndex = 0;
            this.grpbx_TrackingTbl_Tgt.TabStop = false;
            this.grpbx_TrackingTbl_Tgt.Text = "Target Table:";
            // 
            // tabEventLog
            // 
            this.tabEventLog.Controls.Add(this.rtbxEventLog);
            this.tabEventLog.Location = new System.Drawing.Point(4, 25);
            this.tabEventLog.Name = "tabEventLog";
            this.tabEventLog.Size = new System.Drawing.Size(1476, 608);
            this.tabEventLog.TabIndex = 3;
            this.tabEventLog.Text = "EventLog";
            this.tabEventLog.UseVisualStyleBackColor = true;
            // 
            // rtbxEventLog
            // 
            this.rtbxEventLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbxEventLog.Location = new System.Drawing.Point(0, 0);
            this.rtbxEventLog.Margin = new System.Windows.Forms.Padding(5);
            this.rtbxEventLog.Name = "rtbxEventLog";
            this.rtbxEventLog.Size = new System.Drawing.Size(1476, 608);
            this.rtbxEventLog.TabIndex = 0;
            this.rtbxEventLog.Text = "";
            // 
            // tabSandBox
            // 
            this.tabSandBox.Controls.Add(this.dateTimePicker2);
            this.tabSandBox.Controls.Add(this.dateTimePicker1);
            this.tabSandBox.Controls.Add(this.btnPrint);
            this.tabSandBox.Controls.Add(this.btnClearConfig);
            this.tabSandBox.Location = new System.Drawing.Point(4, 25);
            this.tabSandBox.Name = "tabSandBox";
            this.tabSandBox.Size = new System.Drawing.Size(1476, 608);
            this.tabSandBox.TabIndex = 4;
            this.tabSandBox.Text = "SandoBox";
            this.tabSandBox.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(270, 216);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(110, 22);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(270, 136);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(110, 22);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(1046, 292);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(106, 42);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print Tree";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrintTree_Click);
            // 
            // btnClearConfig
            // 
            this.btnClearConfig.Location = new System.Drawing.Point(1049, 378);
            this.btnClearConfig.Name = "btnClearConfig";
            this.btnClearConfig.Size = new System.Drawing.Size(102, 41);
            this.btnClearConfig.TabIndex = 1;
            this.btnClearConfig.Text = "Clear Config";
            this.btnClearConfig.UseVisualStyleBackColor = true;
            this.btnClearConfig.Click += new System.EventHandler(this.btnClearConfig_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1484, 24);
            this.menuStrip1.TabIndex = 48;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // optionsStripMenuItem
            // 
            this.optionsStripMenuItem.Name = "optionsStripMenuItem";
            this.optionsStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.optionsStripMenuItem.Text = "Options";
            this.optionsStripMenuItem.Click += new System.EventHandler(this.optionsStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "GreenChkMrk.png");
            this.imageList1.Images.SetKeyName(1, "FailIcon.png");
            // 
            // btnTrackingLoadSrcCount
            // 
            this.btnTrackingLoadSrcCount.Enabled = false;
            this.btnTrackingLoadSrcCount.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTrackingLoadSrcCount.Location = new System.Drawing.Point(3, 565);
            this.btnTrackingLoadSrcCount.Name = "btnTrackingLoadSrcCount";
            this.btnTrackingLoadSrcCount.Size = new System.Drawing.Size(153, 32);
            this.btnTrackingLoadSrcCount.TabIndex = 6;
            this.btnTrackingLoadSrcCount.Text = "Get Count From Src";
            this.btnTrackingLoadSrcCount.UseVisualStyleBackColor = true;
            // 
            // cbx_idxList_Src
            // 
            this.cbx_idxList_Src.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_idxList_Src.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_idxList_Src.FormattingEnabled = true;
            this.cbx_idxList_Src.Location = new System.Drawing.Point(3, 381);
            this.cbx_idxList_Src.Name = "cbx_idxList_Src";
            this.cbx_idxList_Src.Size = new System.Drawing.Size(305, 24);
            this.cbx_idxList_Src.TabIndex = 74;
            // 
            // tbx_DataType_Src
            // 
            this.tbx_DataType_Src.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_DataType_Src.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_DataType_Src.Location = new System.Drawing.Point(3, 321);
            this.tbx_DataType_Src.Name = "tbx_DataType_Src";
            this.tbx_DataType_Src.Size = new System.Drawing.Size(305, 22);
            this.tbx_DataType_Src.TabIndex = 73;
            // 
            // cbx_colList_Src
            // 
            this.cbx_colList_Src.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_colList_Src.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_colList_Src.FormattingEnabled = true;
            this.cbx_colList_Src.Location = new System.Drawing.Point(3, 291);
            this.cbx_colList_Src.Name = "cbx_colList_Src";
            this.cbx_colList_Src.Size = new System.Drawing.Size(305, 24);
            this.cbx_colList_Src.TabIndex = 72;
            // 
            // cbx_tbList_Src
            // 
            this.cbx_tbList_Src.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_tbList_Src.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_tbList_Src.FormattingEnabled = true;
            this.cbx_tbList_Src.Location = new System.Drawing.Point(3, 93);
            this.cbx_tbList_Src.Name = "cbx_tbList_Src";
            this.cbx_tbList_Src.Size = new System.Drawing.Size(305, 24);
            this.cbx_tbList_Src.TabIndex = 71;
            // 
            // cbx_schList_Src
            // 
            this.cbx_schList_Src.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_schList_Src.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_schList_Src.FormattingEnabled = true;
            this.cbx_schList_Src.Location = new System.Drawing.Point(3, 63);
            this.cbx_schList_Src.Name = "cbx_schList_Src";
            this.cbx_schList_Src.Size = new System.Drawing.Size(305, 24);
            this.cbx_schList_Src.TabIndex = 70;
            // 
            // cbx_dbList_Src
            // 
            this.cbx_dbList_Src.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_dbList_Src.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_dbList_Src.FormattingEnabled = true;
            this.cbx_dbList_Src.Location = new System.Drawing.Point(3, 33);
            this.cbx_dbList_Src.Name = "cbx_dbList_Src";
            this.cbx_dbList_Src.Size = new System.Drawing.Size(305, 24);
            this.cbx_dbList_Src.TabIndex = 69;
            // 
            // cbx_idxList_Tgt
            // 
            this.tblp_TabSetupTgt.SetColumnSpan(this.cbx_idxList_Tgt, 2);
            this.cbx_idxList_Tgt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_idxList_Tgt.FormattingEnabled = true;
            this.cbx_idxList_Tgt.Location = new System.Drawing.Point(5, 381);
            this.cbx_idxList_Tgt.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.cbx_idxList_Tgt.Name = "cbx_idxList_Tgt";
            this.cbx_idxList_Tgt.Size = new System.Drawing.Size(639, 24);
            this.cbx_idxList_Tgt.TabIndex = 67;
            // 
            // cbx_psList_Tgt
            // 
            this.cbx_psList_Tgt.AccessibleDescription = "PartitionScheme List matching the Column selected in cbx_colList_Tgt";
            this.tblp_TabSetupTgt.SetColumnSpan(this.cbx_psList_Tgt, 2);
            this.cbx_psList_Tgt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_psList_Tgt.FormattingEnabled = true;
            this.cbx_psList_Tgt.Location = new System.Drawing.Point(5, 351);
            this.cbx_psList_Tgt.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.cbx_psList_Tgt.Name = "cbx_psList_Tgt";
            this.cbx_psList_Tgt.Size = new System.Drawing.Size(639, 24);
            this.cbx_psList_Tgt.TabIndex = 66;
            // 
            // tbx_DataType_Tgt
            // 
            this.tblp_TabSetupTgt.SetColumnSpan(this.tbx_DataType_Tgt, 2);
            this.tbx_DataType_Tgt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_DataType_Tgt.Location = new System.Drawing.Point(5, 321);
            this.tbx_DataType_Tgt.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.tbx_DataType_Tgt.Name = "tbx_DataType_Tgt";
            this.tbx_DataType_Tgt.Size = new System.Drawing.Size(639, 22);
            this.tbx_DataType_Tgt.TabIndex = 65;
            // 
            // cbx_colList_Tgt
            // 
            this.cbx_colList_Tgt.AccessibleDescription = "";
            this.tblp_TabSetupTgt.SetColumnSpan(this.cbx_colList_Tgt, 2);
            this.cbx_colList_Tgt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_colList_Tgt.FormattingEnabled = true;
            this.cbx_colList_Tgt.Location = new System.Drawing.Point(5, 291);
            this.cbx_colList_Tgt.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.cbx_colList_Tgt.Name = "cbx_colList_Tgt";
            this.cbx_colList_Tgt.Size = new System.Drawing.Size(639, 24);
            this.cbx_colList_Tgt.TabIndex = 64;
            // 
            // cbx_dbList_Tgt
            // 
            this.tblp_TabSetupTgt.SetColumnSpan(this.cbx_dbList_Tgt, 2);
            this.cbx_dbList_Tgt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_dbList_Tgt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_dbList_Tgt.FormattingEnabled = true;
            this.cbx_dbList_Tgt.Location = new System.Drawing.Point(5, 33);
            this.cbx_dbList_Tgt.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.cbx_dbList_Tgt.Name = "cbx_dbList_Tgt";
            this.cbx_dbList_Tgt.Size = new System.Drawing.Size(639, 24);
            this.cbx_dbList_Tgt.TabIndex = 57;
            // 
            // cbx_tbList_Tgt_Current
            // 
            this.cbx_tbList_Tgt_Current.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_tbList_Tgt_Current.FormattingEnabled = true;
            this.cbx_tbList_Tgt_Current.Location = new System.Drawing.Point(157, 3);
            this.cbx_tbList_Tgt_Current.Name = "cbx_tbList_Tgt_Current";
            this.cbx_tbList_Tgt_Current.Size = new System.Drawing.Size(481, 24);
            this.cbx_tbList_Tgt_Current.TabIndex = 61;
            // 
            // cbx_schList_Tgt_Current
            // 
            this.cbx_schList_Tgt_Current.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_schList_Tgt_Current.FormattingEnabled = true;
            this.cbx_schList_Tgt_Current.Location = new System.Drawing.Point(3, 3);
            this.cbx_schList_Tgt_Current.Name = "cbx_schList_Tgt_Current";
            this.cbx_schList_Tgt_Current.Size = new System.Drawing.Size(148, 24);
            this.cbx_schList_Tgt_Current.TabIndex = 58;
            // 
            // rdbtn_Current_Clone
            // 
            this.rdbtn_Current_Clone.AutoSize = true;
            this.rdbtn_Current_Clone.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbtn_Current_Clone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdbtn_Current_Clone.Location = new System.Drawing.Point(734, 3);
            this.rdbtn_Current_Clone.Name = "rdbtn_Current_Clone";
            this.rdbtn_Current_Clone.Size = new System.Drawing.Size(72, 23);
            this.rdbtn_Current_Clone.TabIndex = 69;
            this.rdbtn_Current_Clone.TabStop = true;
            this.rdbtn_Current_Clone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbtn_Current_Clone.UseVisualStyleBackColor = true;
            // 
            // cbx_tbList_Tgt_Staging
            // 
            this.cbx_tbList_Tgt_Staging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_tbList_Tgt_Staging.FormattingEnabled = true;
            this.cbx_tbList_Tgt_Staging.Location = new System.Drawing.Point(157, 3);
            this.cbx_tbList_Tgt_Staging.Name = "cbx_tbList_Tgt_Staging";
            this.cbx_tbList_Tgt_Staging.Size = new System.Drawing.Size(481, 24);
            this.cbx_tbList_Tgt_Staging.TabIndex = 62;
            // 
            // cbx_schList_Tgt_Staging
            // 
            this.cbx_schList_Tgt_Staging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_schList_Tgt_Staging.FormattingEnabled = true;
            this.cbx_schList_Tgt_Staging.Location = new System.Drawing.Point(3, 3);
            this.cbx_schList_Tgt_Staging.Name = "cbx_schList_Tgt_Staging";
            this.cbx_schList_Tgt_Staging.Size = new System.Drawing.Size(148, 24);
            this.cbx_schList_Tgt_Staging.TabIndex = 59;
            // 
            // rdbtn_Staging_Clone
            // 
            this.rdbtn_Staging_Clone.AutoSize = true;
            this.rdbtn_Staging_Clone.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbtn_Staging_Clone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdbtn_Staging_Clone.Location = new System.Drawing.Point(734, 3);
            this.rdbtn_Staging_Clone.Name = "rdbtn_Staging_Clone";
            this.rdbtn_Staging_Clone.Size = new System.Drawing.Size(72, 23);
            this.rdbtn_Staging_Clone.TabIndex = 70;
            this.rdbtn_Staging_Clone.TabStop = true;
            this.rdbtn_Staging_Clone.UseVisualStyleBackColor = true;
            // 
            // cbx_tbList_Tgt_Archive
            // 
            this.cbx_tbList_Tgt_Archive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_tbList_Tgt_Archive.FormattingEnabled = true;
            this.cbx_tbList_Tgt_Archive.Location = new System.Drawing.Point(157, 3);
            this.cbx_tbList_Tgt_Archive.Name = "cbx_tbList_Tgt_Archive";
            this.cbx_tbList_Tgt_Archive.Size = new System.Drawing.Size(481, 24);
            this.cbx_tbList_Tgt_Archive.TabIndex = 63;
            // 
            // cbx_schList_Tgt_Archive
            // 
            this.cbx_schList_Tgt_Archive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_schList_Tgt_Archive.FormattingEnabled = true;
            this.cbx_schList_Tgt_Archive.Location = new System.Drawing.Point(3, 3);
            this.cbx_schList_Tgt_Archive.Name = "cbx_schList_Tgt_Archive";
            this.cbx_schList_Tgt_Archive.Size = new System.Drawing.Size(148, 24);
            this.cbx_schList_Tgt_Archive.TabIndex = 60;
            // 
            // rdbtn_Archive_Clone
            // 
            this.rdbtn_Archive_Clone.AutoSize = true;
            this.rdbtn_Archive_Clone.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbtn_Archive_Clone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdbtn_Archive_Clone.Location = new System.Drawing.Point(734, 3);
            this.rdbtn_Archive_Clone.Name = "rdbtn_Archive_Clone";
            this.rdbtn_Archive_Clone.Size = new System.Drawing.Size(72, 23);
            this.rdbtn_Archive_Clone.TabIndex = 71;
            this.rdbtn_Archive_Clone.TabStop = true;
            this.rdbtn_Archive_Clone.UseVisualStyleBackColor = true;
            // 
            // cbxt_TrackTbl_Schema
            // 
            this.cbxt_TrackTbl_Schema.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cbxt_TrackTbl_Schema.FormattingEnabled = true;
            this.cbxt_TrackTbl_Schema.Location = new System.Drawing.Point(3, 25);
            this.cbxt_TrackTbl_Schema.Name = "cbxt_TrackTbl_Schema";
            this.cbxt_TrackTbl_Schema.Size = new System.Drawing.Size(505, 24);
            this.cbxt_TrackTbl_Schema.TabIndex = 1;
            // 
            // cbxt_TrackTbl_Database
            // 
            this.cbxt_TrackTbl_Database.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cbxt_TrackTbl_Database.FormattingEnabled = true;
            this.cbxt_TrackTbl_Database.Location = new System.Drawing.Point(3, 23);
            this.cbxt_TrackTbl_Database.Name = "cbxt_TrackTbl_Database";
            this.cbxt_TrackTbl_Database.Size = new System.Drawing.Size(505, 24);
            this.cbxt_TrackTbl_Database.TabIndex = 0;
            // 
            // rdbtn_TrackTbl_ProjectNameCreateNew
            // 
            this.rdbtn_TrackTbl_ProjectNameCreateNew.AutoSize = true;
            this.rdbtn_TrackTbl_ProjectNameCreateNew.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbtn_TrackTbl_ProjectNameCreateNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdbtn_TrackTbl_ProjectNameCreateNew.Location = new System.Drawing.Point(0, 2);
            this.rdbtn_TrackTbl_ProjectNameCreateNew.Margin = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.rdbtn_TrackTbl_ProjectNameCreateNew.Name = "rdbtn_TrackTbl_ProjectNameCreateNew";
            this.rdbtn_TrackTbl_ProjectNameCreateNew.Size = new System.Drawing.Size(69, 13);
            this.rdbtn_TrackTbl_ProjectNameCreateNew.TabIndex = 0;
            this.rdbtn_TrackTbl_ProjectNameCreateNew.UseVisualStyleBackColor = true;
            // 
            // cbxt_TrackTbl_ProjectName
            // 
            this.cbxt_TrackTbl_ProjectName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cbxt_TrackTbl_ProjectName.FormattingEnabled = true;
            this.cbxt_TrackTbl_ProjectName.Location = new System.Drawing.Point(3, 25);
            this.cbxt_TrackTbl_ProjectName.Name = "cbxt_TrackTbl_ProjectName";
            this.cbxt_TrackTbl_ProjectName.Size = new System.Drawing.Size(605, 24);
            this.cbxt_TrackTbl_ProjectName.TabIndex = 2;
            // 
            // rdbtn_TrackTbl_ProjectsCreateNew
            // 
            this.rdbtn_TrackTbl_ProjectsCreateNew.AutoSize = true;
            this.rdbtn_TrackTbl_ProjectsCreateNew.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbtn_TrackTbl_ProjectsCreateNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdbtn_TrackTbl_ProjectsCreateNew.Location = new System.Drawing.Point(0, -8);
            this.rdbtn_TrackTbl_ProjectsCreateNew.Margin = new System.Windows.Forms.Padding(0);
            this.rdbtn_TrackTbl_ProjectsCreateNew.Name = "rdbtn_TrackTbl_ProjectsCreateNew";
            this.rdbtn_TrackTbl_ProjectsCreateNew.Size = new System.Drawing.Size(69, 30);
            this.rdbtn_TrackTbl_ProjectsCreateNew.TabIndex = 0;
            this.rdbtn_TrackTbl_ProjectsCreateNew.UseVisualStyleBackColor = true;
            // 
            // cbxt_TrackTbl_ProjectsTable
            // 
            this.cbxt_TrackTbl_ProjectsTable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cbxt_TrackTbl_ProjectsTable.FormattingEnabled = true;
            this.cbxt_TrackTbl_ProjectsTable.Location = new System.Drawing.Point(3, 25);
            this.cbxt_TrackTbl_ProjectsTable.Name = "cbxt_TrackTbl_ProjectsTable";
            this.cbxt_TrackTbl_ProjectsTable.Size = new System.Drawing.Size(605, 24);
            this.cbxt_TrackTbl_ProjectsTable.TabIndex = 2;
            // 
            // tbxTrackFullSource
            // 
            this.tbxTrackFullSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxTrackFullSource.Location = new System.Drawing.Point(3, 18);
            this.tbxTrackFullSource.Name = "tbxTrackFullSource";
            this.tbxTrackFullSource.Size = new System.Drawing.Size(717, 22);
            this.tbxTrackFullSource.TabIndex = 0;
            // 
            // tbxTrackFullTarget
            // 
            this.tbxTrackFullTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxTrackFullTarget.Location = new System.Drawing.Point(3, 18);
            this.tbxTrackFullTarget.Name = "tbxTrackFullTarget";
            this.tbxTrackFullTarget.Size = new System.Drawing.Size(731, 22);
            this.tbxTrackFullTarget.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 661);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1500, 700);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CsiMigrationHelper";
            this.tabControl.ResumeLayout(false);
            this.tabSrcTgtSetup.ResumeLayout(false);
            this.tblp_TabSetupOuter.ResumeLayout(false);
            this.tblp_TabSetupOuter.PerformLayout();
            this.split_SrcTgtSetup.Panel1.ResumeLayout(false);
            this.split_SrcTgtSetup.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_SrcTgtSetup)).EndInit();
            this.split_SrcTgtSetup.ResumeLayout(false);
            this.gpbxSrc.ResumeLayout(false);
            this.tblp_TabSetupSrc.ResumeLayout(false);
            this.tblp_TabSetupSrc.PerformLayout();
            this.gpbxTgt.ResumeLayout(false);
            this.tblp_TabSetupTgt.ResumeLayout(false);
            this.tblp_TabSetupTgt.PerformLayout();
            this.grpBx_Current.ResumeLayout(false);
            this.tblp_Current.ResumeLayout(false);
            this.tblp_Current.PerformLayout();
            this.grpBx_Staging.ResumeLayout(false);
            this.tblp_Staging.ResumeLayout(false);
            this.tblp_Staging.PerformLayout();
            this.grpBx_Archive.ResumeLayout(false);
            this.tblp_Archive.ResumeLayout(false);
            this.tblp_Archive.PerformLayout();
            this.tblp_ObjectLablels.ResumeLayout(false);
            this.tblp_ObjectLablels.PerformLayout();
            this.tabPartition.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tblp_Partition_FileGroups.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridFileGroups)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grpBx_PartitionFunctionName.ResumeLayout(false);
            this.grpBx_PartitionFunctionName.PerformLayout();
            this.grpBx_PartitionFunction_Boundary.ResumeLayout(false);
            this.grpBx_PartitionFunction_Boundary.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPartitionFunction)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.grpBx_PartitionSchemeName.ResumeLayout(false);
            this.grpBx_PartitionSchemeName.PerformLayout();
            this.grpBx_PartitionFunctionSelect.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPartitionScheme)).EndInit();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tabTgtMetadata.ResumeLayout(false);
            this.split_TgtMetadata.Panel1.ResumeLayout(false);
            this.split_TgtMetadata.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_TgtMetadata)).EndInit();
            this.split_TgtMetadata.ResumeLayout(false);
            this.split_TgtMeta_Current.Panel1.ResumeLayout(false);
            this.split_TgtMeta_Current.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_TgtMeta_Current)).EndInit();
            this.split_TgtMeta_Current.ResumeLayout(false);
            this.tblp_TgtMeta_ColumnList_Current.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridColList_Current)).EndInit();
            this.pnlTgtTableName_Current.ResumeLayout(false);
            this.pnlTgtTableName_Current.PerformLayout();
            this.tblp_TgtMeta_ConstraintList_Current.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridConstraintList_Current)).EndInit();
            this.tblp_TgtMeta_Btns_Current.ResumeLayout(false);
            this.tblp_TgtMeta_Btns_Current.PerformLayout();
            this.split_TgtMeta_StagingArchive.Panel1.ResumeLayout(false);
            this.split_TgtMeta_StagingArchive.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_TgtMeta_StagingArchive)).EndInit();
            this.split_TgtMeta_StagingArchive.ResumeLayout(false);
            this.splitStaging.Panel1.ResumeLayout(false);
            this.splitStaging.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitStaging)).EndInit();
            this.splitStaging.ResumeLayout(false);
            this.tblp_TgtMeta_ColumnList_Staging.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridColList_Staging)).EndInit();
            this.pnlTgtTableName_Staging.ResumeLayout(false);
            this.pnlTgtTableName_Staging.PerformLayout();
            this.tblp_TgtMeta_ConstraintList_Staging.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridConstraintList_Staging)).EndInit();
            this.tblp_TgtMeta_Btns_Staging.ResumeLayout(false);
            this.tblp_TgtMeta_Btns_Staging.PerformLayout();
            this.split_TgtMeta_Archive.Panel1.ResumeLayout(false);
            this.split_TgtMeta_Archive.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_TgtMeta_Archive)).EndInit();
            this.split_TgtMeta_Archive.ResumeLayout(false);
            this.tblp_TgtMeta_ColumnList_Archive.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridColList_Archive)).EndInit();
            this.pnlTgtTableName_Archive.ResumeLayout(false);
            this.pnlTgtTableName_Archive.PerformLayout();
            this.tblp_TgtMeta_ConstraintList_Archive.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridConstraintList_Archive)).EndInit();
            this.tblp_TgtMeta_Btns_Archive.ResumeLayout(false);
            this.tblp_TgtMeta_Btns_Archive.PerformLayout();
            this.tabTrackingTbl.ResumeLayout(false);
            this.tblp_TrackingTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTrackingTable)).EndInit();
            this.split_TrackingTable.Panel1.ResumeLayout(false);
            this.split_TrackingTable.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_TrackingTable)).EndInit();
            this.split_TrackingTable.ResumeLayout(false);
            this.tblp_TrackingTbl_InstanceDbSchema.ResumeLayout(false);
            this.grpBx_TrackTbl_Schema.ResumeLayout(false);
            this.grpBx_TrackTbl_Database.ResumeLayout(false);
            this.grpBx_TrackTbl_Instance.ResumeLayout(false);
            this.tblp_TabTrackTbl_Instance.ResumeLayout(false);
            this.tblp_TabTrackTbl_Instance.PerformLayout();
            this.tblp_TrackingTbl_ProjectTables.ResumeLayout(false);
            this.tblp_TrackTbl_ProjectNameSaveRunBtns.ResumeLayout(false);
            this.grpBx_TrackTbl_ProjectNameCreateNewUseExisting.ResumeLayout(false);
            this.tblp_TrackingTbl_ProjectName.ResumeLayout(false);
            this.tblp_TrackingTbl_ProjectName.PerformLayout();
            this.grpBx_TrackTbl_ProjectName.ResumeLayout(false);
            this.tblp_TrackTbl_ProjectsSaveRunBtns.ResumeLayout(false);
            this.tblp_TrackTbl_ProjectsSaveRunBtns.PerformLayout();
            this.grpBx_TrackTbl_ProjectsTableCreateNewUseExisting.ResumeLayout(false);
            this.tblp_TrackTbl_UseExistingCreateNew.ResumeLayout(false);
            this.tblp_TrackTbl_UseExistingCreateNew.PerformLayout();
            this.grpBx_TrackTbl_ProjectsTbl.ResumeLayout(false);
            this.grpBx_TrackTbl_ProjectDescription.ResumeLayout(false);
            this.grpBx_TrackTbl_ProjectDescription.PerformLayout();
            this.split_TrackingTable_SrcTgt.Panel1.ResumeLayout(false);
            this.split_TrackingTable_SrcTgt.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_TrackingTable_SrcTgt)).EndInit();
            this.split_TrackingTable_SrcTgt.ResumeLayout(false);
            this.grpbx_TrackingTbl_Src.ResumeLayout(false);
            this.grpbx_TrackingTbl_Src.PerformLayout();
            this.grpbx_TrackingTbl_Tgt.ResumeLayout(false);
            this.grpbx_TrackingTbl_Tgt.PerformLayout();
            this.tabEventLog.ResumeLayout(false);
            this.tabSandBox.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabSrcTgtSetup;
        private System.Windows.Forms.TabPage tabTrackingTbl;
        private System.Windows.Forms.TableLayoutPanel tblp_TabSetupOuter;
        private System.Windows.Forms.SplitContainer split_SrcTgtSetup;
        private System.Windows.Forms.GroupBox gpbxSrc;
        private System.Windows.Forms.GroupBox gpbxTgt;
        private System.Windows.Forms.TableLayoutPanel tblp_TabSetupSrc;
        private System.Windows.Forms.Button buttonLoginSrc;
        private System.Windows.Forms.TextBox tbx_InstanceSrc;
        private ComboBoxExt cbx_dbList_Src;
        private ComboBoxExt cbx_schList_Src;
        private ComboBoxExt cbx_tbList_Src;
        private ComboBoxExt cbx_colList_Src;
        private ComboBoxExt cbx_idxList_Src;
        private System.Windows.Forms.TableLayoutPanel tblp_TabSetupTgt;
        private System.Windows.Forms.Button buttonLoginTgt;
        private System.Windows.Forms.TextBox tbx_InstanceTgt;
        private ComboBoxExt cbx_dbList_Tgt;
        private ComboBoxExt cbx_tbList_Tgt_Archive;
        private ComboBoxExt cbx_tbList_Tgt_Staging;
        private ComboBoxExt cbx_tbList_Tgt_Current;
        private ComboBoxExt cbx_schList_Tgt_Archive;
        private ComboBoxExt cbx_schList_Tgt_Staging;
        private ComboBoxExt cbx_schList_Tgt_Current;
        private ComboBoxExt cbx_idxList_Tgt;
        private ComboBoxExt cbx_psList_Tgt;
        private ComboBoxExt cbx_colList_Tgt;
        private System.Windows.Forms.CheckBox chkBxArchive;
        private System.Windows.Forms.CheckBox chkBxStaging;
        private System.Windows.Forms.CheckBox chkBxCurrent;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpBx_Current;
        private System.Windows.Forms.TableLayoutPanel tblp_Current;
        private System.Windows.Forms.GroupBox grpBx_Staging;
        private System.Windows.Forms.TableLayoutPanel tblp_Staging;
        private System.Windows.Forms.GroupBox grpBx_Archive;
        private System.Windows.Forms.TableLayoutPanel tblp_Archive;
        private System.Windows.Forms.TableLayoutPanel tblp_ObjectLablels;
        private System.Windows.Forms.Label lbl_Database;
        private System.Windows.Forms.Label lbl_Instance;
        private System.Windows.Forms.Label lbl_Table;
        private System.Windows.Forms.Label lbl_Schema;
        private System.Windows.Forms.Label lbl_DataType;
        private System.Windows.Forms.Label lbl_Column;
        private System.Windows.Forms.Label lbl_PartitionScheme;
        private System.Windows.Forms.Label lbl_Index;
        private System.Windows.Forms.Label lbl_TableTgt;
        private System.Windows.Forms.Label lbl_SchemaTgt;
        private System.Windows.Forms.Label lbl_Enabled;
        private System.Windows.Forms.Label lbl_UseExisting;
        private System.Windows.Forms.Label lbl_Clone;
        //private System.Windows.Forms.RadioButton rdbtn_Current_Clone;
        private RadioButtonExt rdbtn_Current_Clone;
        private System.Windows.Forms.RadioButton rdbtn_Current_UseExisting;
        //private System.Windows.Forms.RadioButton rdbtn_Staging_Clone;
        private RadioButtonExt rdbtn_Staging_Clone;
        private System.Windows.Forms.RadioButton rdbtn_Staging_UseExisting;
        //private System.Windows.Forms.RadioButton rdbtn_Archive_Clone;
        private RadioButtonExt rdbtn_Archive_Clone;
        private System.Windows.Forms.RadioButton rdbtn_Archive_UseExisting;
        private System.Windows.Forms.ToolStripMenuItem optionsStripMenuItem;
        private System.Windows.Forms.TabPage tabTgtMetadata;
        private System.Windows.Forms.SplitContainer split_TgtMetadata;
        private System.Windows.Forms.SplitContainer split_TgtMeta_Current;
        private System.Windows.Forms.TableLayoutPanel tblp_TgtMeta_Btns_Current;
        private System.Windows.Forms.Button btnCurrentExecute;
        private System.Windows.Forms.Button btnCurrentSyntax;
        private System.Windows.Forms.Button btnCurrentReload;
        private System.Windows.Forms.SplitContainer split_TgtMeta_StagingArchive;
        private System.Windows.Forms.SplitContainer splitStaging;
        private System.Windows.Forms.SplitContainer split_TgtMeta_Archive;
        private System.Windows.Forms.TableLayoutPanel tblp_TgtMeta_ColumnList_Current;
        private System.Windows.Forms.DataGridView gridColList_Current;
        private System.Windows.Forms.Panel pnlTgtTableName_Current;
        private System.Windows.Forms.TextBox tbx_TgtMetadataTableName_Current;
        private System.Windows.Forms.TableLayoutPanel tblp_TgtMeta_ConstraintList_Current;
        private System.Windows.Forms.DataGridView gridConstraintList_Current;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TableLayoutPanel tblp_TgtMeta_ColumnList_Staging;
        private System.Windows.Forms.DataGridView gridColList_Staging;
        private System.Windows.Forms.Panel pnlTgtTableName_Staging;
        private System.Windows.Forms.TextBox tbx_TgtMetadataTableName_Staging;
        private System.Windows.Forms.TableLayoutPanel tblp_TgtMeta_ConstraintList_Staging;
        private System.Windows.Forms.DataGridView gridConstraintList_Staging;
        private System.Windows.Forms.TableLayoutPanel tblp_TgtMeta_Btns_Staging;
        private System.Windows.Forms.Button btnStagingExecute;
        private System.Windows.Forms.Button btnStagingSyntax;
        private System.Windows.Forms.Button btnStagingReload;
        private System.Windows.Forms.TableLayoutPanel tblp_TgtMeta_ColumnList_Archive;
        private System.Windows.Forms.DataGridView gridColList_Archive;
        private System.Windows.Forms.Panel pnlTgtTableName_Archive;
        private System.Windows.Forms.TextBox tbx_TgtMetaDataTableName_Archive;
        private System.Windows.Forms.TableLayoutPanel tblp_TgtMeta_ConstraintList_Archive;
        private System.Windows.Forms.DataGridView gridConstraintList_Archive;
        private System.Windows.Forms.TableLayoutPanel tblp_TgtMeta_Btns_Archive;
        private System.Windows.Forms.Button btnArchiveExecute;
        private System.Windows.Forms.Button btnArchiveSyntax;
        private System.Windows.Forms.Button btnArchiveReload;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tabEventLog;
        private System.Windows.Forms.RichTextBox rtbxEventLog;
        private System.Windows.Forms.Button btnClearConfig;
        private System.Windows.Forms.TableLayoutPanel tblp_TrackingTable;
        private System.Windows.Forms.GroupBox grpBx_TrackTbl_Instance;
        private System.Windows.Forms.TabPage tabSandBox;
        private System.Windows.Forms.Button btnLoginTrackTbl;
        private System.Windows.Forms.GroupBox grpBx_TrackTbl_Database;
        private System.Windows.Forms.GroupBox grpBx_TrackTbl_Schema;
        private System.Windows.Forms.GroupBox grpBx_TrackTbl_ProjectsTbl;
        private System.Windows.Forms.TableLayoutPanel tblp_TabTrackTbl_Instance;
        private System.Windows.Forms.TextBox tbx_TrackTbl_Instance;
        private System.Windows.Forms.TableLayoutPanel tblp_TrackTbl_ProjectsSaveRunBtns;
        private System.Windows.Forms.GroupBox grpBx_TrackTbl_ProjectsTableCreateNewUseExisting;
        private System.Windows.Forms.TableLayoutPanel tblp_TrackTbl_UseExistingCreateNew;
        private System.Windows.Forms.RadioButton rdbtn_TrackTbl_ProjectsUseExisting;
        private RadioButtonExt rdbtn_TrackTbl_ProjectsCreateNew;
        private System.Windows.Forms.Label lblTrackTbl_ProjectsUseExisting;
        private System.Windows.Forms.Label lblTrackTbl_ProjectsCreateNew;
        private System.Windows.Forms.Button btnTrackTbl_ProjectsEdit;
        private System.Windows.Forms.Button btnTrackTbl_ProjectsSave;
        private System.Windows.Forms.DataGridView gridTrackingTable;
        private ComboBoxExt cbxt_TrackTbl_Database;
        private ComboBoxExt cbxt_TrackTbl_Schema;
        private TextBoxExt tbx_DataType_Src;
        private TextBoxExt tbx_DataType_Tgt;
        private System.Windows.Forms.GroupBox grpBx_TrackTbl_ProjectName;
        private System.Windows.Forms.TableLayoutPanel tblp_TrackTbl_ProjectNameSaveRunBtns;
        private System.Windows.Forms.Button btnTrackTbl_ProjectNameEdit;
        private System.Windows.Forms.Button btnTrackTbl_ProjectNameSave;
        private System.Windows.Forms.GroupBox grpBx_TrackTbl_ProjectNameCreateNewUseExisting;
        private System.Windows.Forms.TableLayoutPanel tblp_TrackingTbl_ProjectName;
        private System.Windows.Forms.RadioButton rdbtn_TrackTbl_ProjectNameUseExisting;
        private RadioButtonExt rdbtn_TrackTbl_ProjectNameCreateNew;
        private System.Windows.Forms.SplitContainer split_TrackingTable;
        private System.Windows.Forms.TableLayoutPanel tblp_TrackingTbl_InstanceDbSchema;
        private System.Windows.Forms.TableLayoutPanel tblp_TrackingTbl_ProjectTables;
        private ComboBoxExtTrackTbl cbxt_TrackTbl_ProjectsTable;
        private ComboBoxExtTrackTbl cbxt_TrackTbl_ProjectName;
        private System.Windows.Forms.GroupBox grpBx_TrackTbl_ProjectDescription;
        private System.Windows.Forms.TextBox tbx_TrackTbl_ProjectDescription;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TabPage tabPartition;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tblp_Partition_FileGroups;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtm_FileGroup_Start;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView gridFileGroups;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btn_FileGroup_Execute;
        private System.Windows.Forms.Button btn_FileGroup_CheckSyntax;
        private System.Windows.Forms.Button btn_FileGroup_Reload;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.DataGridView gridPartitionFunction;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button btn_PartitionFunction_Execute;
        private System.Windows.Forms.Button btn_PartitionFunction_CheckSyntax;
        private System.Windows.Forms.Button btn_PartitionFunction_Reload;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.DataGridView gridPartitionScheme;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Button btn_PartitionScheme_Execute;
        private System.Windows.Forms.Button btn_PartitionScheme_CheckSyntax;
        private System.Windows.Forms.Button btn_PartitionScheme_Reload;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtm_FileGroup_End;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbx_FileGroupPrefix;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbx_FileNamePrefix;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grpBx_PartitionFunctionName;
        private System.Windows.Forms.TextBox tbx_PartitionFunctionName;
        private System.Windows.Forms.GroupBox grpBx_PartitionFunction_Boundary;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DateTimePicker dtm_PartitionFunction_End;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DateTimePicker dtm_PartitionFunction_Start;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.GroupBox grpBx_PartitionSchemeName;
        private System.Windows.Forms.TextBox tbx_PartitionSchemeName;
        private System.Windows.Forms.RadioButton rdbtn_PF_BoundaryOnRight;
        private System.Windows.Forms.RadioButton rdbtn_PF_BoundaryOnLeft;
        private System.Windows.Forms.GroupBox grpBx_PartitionFunctionSelect;
        private System.Windows.Forms.ComboBox cbx_PartitionFunctionSelect;
        private System.Windows.Forms.SplitContainer split_TrackingTable_SrcTgt;
        private System.Windows.Forms.GroupBox grpbx_TrackingTbl_Src;
        private System.Windows.Forms.GroupBox grpbx_TrackingTbl_Tgt;
        private System.Windows.Forms.Button btnTrackingLoadSrcCount;
        private System.Windows.Forms.TextBox tbxTrackFullSource;
        private System.Windows.Forms.TextBox tbxTrackFullTarget;
    }
}

