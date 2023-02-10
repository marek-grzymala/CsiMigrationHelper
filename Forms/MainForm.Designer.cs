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
            this.cbx_idxList_Src = new CsiMigrationHelper.ComboBoxExt();
            this.tbx_DataType_Src = new CsiMigrationHelper.TextBoxExt();
            this.cbx_colList_Src = new CsiMigrationHelper.ComboBoxExt();
            this.cbx_tbList_Src = new CsiMigrationHelper.ComboBoxExt();
            this.cbx_schList_Src = new CsiMigrationHelper.ComboBoxExt();
            this.cbx_dbList_Src = new CsiMigrationHelper.ComboBoxExt();
            this.buttonLoginSrc = new System.Windows.Forms.Button();
            this.tbx_InstanceSrc = new System.Windows.Forms.TextBox();
            this.gpbxTgt = new System.Windows.Forms.GroupBox();
            this.tblp_TabSetupTgt = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_UseExisting = new System.Windows.Forms.Label();
            this.lbl_Clone = new System.Windows.Forms.Label();
            this.lbl_Enabled = new System.Windows.Forms.Label();
            this.lbl_TableTgt = new System.Windows.Forms.Label();
            this.lbl_SchemaTgt = new System.Windows.Forms.Label();
            this.cbx_idxList_Tgt = new CsiMigrationHelper.ComboBoxExt();
            this.cbx_psList_Tgt = new CsiMigrationHelper.ComboBoxExt();
            this.tbx_DataType_Tgt = new CsiMigrationHelper.TextBoxExt();
            this.cbx_colList_Tgt = new CsiMigrationHelper.ComboBoxExt();
            this.cbx_dbList_Tgt = new CsiMigrationHelper.ComboBoxExt();
            this.buttonLoginTgt = new System.Windows.Forms.Button();
            this.tbx_InstanceTgt = new System.Windows.Forms.TextBox();
            this.grpBx_Current = new System.Windows.Forms.GroupBox();
            this.tblp_Current = new System.Windows.Forms.TableLayoutPanel();
            this.chkBxCurrent = new System.Windows.Forms.CheckBox();
            this.cbx_tbList_Tgt_Current = new CsiMigrationHelper.ComboBoxExt();
            this.cbx_schList_Tgt_Current = new CsiMigrationHelper.ComboBoxExt();
            this.rdbtn_Current_Clone = new CsiMigrationHelper.RadioButtonExt();
            this.rdbtn_Current_UseExisting = new System.Windows.Forms.RadioButton();
            this.grpBx_Staging = new System.Windows.Forms.GroupBox();
            this.tblp_Staging = new System.Windows.Forms.TableLayoutPanel();
            this.chkBxStaging = new System.Windows.Forms.CheckBox();
            this.cbx_tbList_Tgt_Staging = new CsiMigrationHelper.ComboBoxExt();
            this.cbx_schList_Tgt_Staging = new CsiMigrationHelper.ComboBoxExt();
            this.rdbtn_Staging_Clone = new CsiMigrationHelper.RadioButtonExt();
            this.rdbtn_Staging_UseExisting = new System.Windows.Forms.RadioButton();
            this.grpBx_Archive = new System.Windows.Forms.GroupBox();
            this.tblp_Archive = new System.Windows.Forms.TableLayoutPanel();
            this.chkBxArchive = new System.Windows.Forms.CheckBox();
            this.cbx_tbList_Tgt_Archive = new CsiMigrationHelper.ComboBoxExt();
            this.cbx_schList_Tgt_Archive = new CsiMigrationHelper.ComboBoxExt();
            this.rdbtn_Archive_Clone = new CsiMigrationHelper.RadioButtonExt();
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
            this.grpbxSchema = new System.Windows.Forms.GroupBox();
            this.cbxt_TrackTbl_Schema = new CsiMigrationHelper.ComboBoxExt();
            this.grpbxDatabase = new System.Windows.Forms.GroupBox();
            this.cbxt_TrackTbl_Database = new CsiMigrationHelper.ComboBoxExt();
            this.grpbxInstance = new System.Windows.Forms.GroupBox();
            this.tblp_TabTrackTbl_Instance = new System.Windows.Forms.TableLayoutPanel();
            this.tbx_TrackTblInstance = new System.Windows.Forms.TextBox();
            this.btnTrackTblLogin = new System.Windows.Forms.Button();
            this.tblp_TrackingTbl_ProjectTables = new System.Windows.Forms.TableLayoutPanel();
            this.tblp_TrackTbl_ProjectNameSaveRunBtns = new System.Windows.Forms.TableLayoutPanel();
            this.btnTrackTbl_ProjectNameEdit = new System.Windows.Forms.Button();
            this.btnTrackTbl_ProjectNameSave = new System.Windows.Forms.Button();
            this.grpbxTrackTblProjectNameCreateNewUseExisting = new System.Windows.Forms.GroupBox();
            this.tblp_TrackingTbl_ProjectName = new System.Windows.Forms.TableLayoutPanel();
            this.rdbtn_TrackTbl_ProjectNameUseExisting = new System.Windows.Forms.RadioButton();
            this.rdbtn_TrackTbl_ProjectNameCreateNew = new CsiMigrationHelper.RadioButtonExt();
            this.grpbxTrackTblProjectName = new System.Windows.Forms.GroupBox();
            this.cbxt_TrackTbl_ProjectName = new CsiMigrationHelper.ComboBoxExt();
            this.tblp_TrackTbl_ProjectsSaveRunBtns = new System.Windows.Forms.TableLayoutPanel();
            this.btnTrackTbl_ProjectsEdit = new System.Windows.Forms.Button();
            this.btnTrackTbl_ProjectsSave = new System.Windows.Forms.Button();
            this.lblTrackTbl_ProjectsUseExisting = new System.Windows.Forms.Label();
            this.lblTrackTbl_ProjectsCreateNew = new System.Windows.Forms.Label();
            this.grpbxTrackTblProjectCreateNewUseExisting = new System.Windows.Forms.GroupBox();
            this.tblp_TrackTbl_UseExistingCreateNew = new System.Windows.Forms.TableLayoutPanel();
            this.rdbtn_TrackTbl_ProjectsUseExisting = new System.Windows.Forms.RadioButton();
            this.rdbtn_TrackTbl_ProjectsCreateNew = new CsiMigrationHelper.RadioButtonExt();
            this.grpbxTrackTblProjectsTbl = new System.Windows.Forms.GroupBox();
            this.cbxt_TrackTbl_ProjectsTable = new CsiMigrationHelper.ComboBoxExt();
            this.tabEventLog = new System.Windows.Forms.TabPage();
            this.rtbxEventLog = new System.Windows.Forms.RichTextBox();
            this.tabSandBox = new System.Windows.Forms.TabPage();
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
            this.grpbxSchema.SuspendLayout();
            this.grpbxDatabase.SuspendLayout();
            this.grpbxInstance.SuspendLayout();
            this.tblp_TabTrackTbl_Instance.SuspendLayout();
            this.tblp_TrackingTbl_ProjectTables.SuspendLayout();
            this.tblp_TrackTbl_ProjectNameSaveRunBtns.SuspendLayout();
            this.grpbxTrackTblProjectNameCreateNewUseExisting.SuspendLayout();
            this.tblp_TrackingTbl_ProjectName.SuspendLayout();
            this.grpbxTrackTblProjectName.SuspendLayout();
            this.tblp_TrackTbl_ProjectsSaveRunBtns.SuspendLayout();
            this.grpbxTrackTblProjectCreateNewUseExisting.SuspendLayout();
            this.tblp_TrackTbl_UseExistingCreateNew.SuspendLayout();
            this.grpbxTrackTblProjectsTbl.SuspendLayout();
            this.tabEventLog.SuspendLayout();
            this.tabSandBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabSrcTgtSetup);
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
            this.gridColList_Current.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridColList_Current_CellValueChanged);
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
            this.gridConstraintList_Current.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridConstraintList_Current_CellValueChanged);
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
            this.btnCurrentExecute.Click += new System.EventHandler(this.btnCurrentExecute_Click);
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
            this.btnCurrentSyntax.Click += new System.EventHandler(this.btnCurrentSyntax_Click);
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
            this.btnCurrentReload.Click += new System.EventHandler(this.btnCurrentReload_Click);
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
            this.gridColList_Staging.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridColList_Staging_CellValueChanged);
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
            this.gridConstraintList_Staging.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridConstraintList_Staging_CellValueChanged);
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
            this.btnStagingExecute.Click += new System.EventHandler(this.btnStagingExecute_Click);
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
            this.btnStagingSyntax.Click += new System.EventHandler(this.btnStagingSyntax_Click);
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
            this.btnStagingReload.Click += new System.EventHandler(this.btnStagingReload_Click);
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
            this.gridColList_Archive.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridColList_Archive_CellValueChanged);
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
            this.gridConstraintList_Archive.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridConstraintList_Archive_CellValueChanged);
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
            this.btnArchiveExecute.Click += new System.EventHandler(this.btnArchiveExecute_Click);
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
            this.btnArchiveSyntax.Click += new System.EventHandler(this.btnArchiveSyntax_Click);
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
            this.btnArchiveReload.Click += new System.EventHandler(this.btnArchiveReload_Click);
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
            this.tblp_TrackingTable.Controls.Add(this.gridTrackingTable, 0, 1);
            this.tblp_TrackingTable.Controls.Add(this.split_TrackingTable, 0, 0);
            this.tblp_TrackingTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblp_TrackingTable.Location = new System.Drawing.Point(3, 3);
            this.tblp_TrackingTable.Name = "tblp_TrackingTable";
            this.tblp_TrackingTable.RowCount = 2;
            this.tblp_TrackingTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tblp_TrackingTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TrackingTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblp_TrackingTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblp_TrackingTable.Size = new System.Drawing.Size(1470, 602);
            this.tblp_TrackingTable.TabIndex = 0;
            // 
            // gridTrackingTable
            // 
            this.gridTrackingTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTrackingTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTrackingTable.Location = new System.Drawing.Point(5, 185);
            this.gridTrackingTable.Margin = new System.Windows.Forms.Padding(5);
            this.gridTrackingTable.Name = "gridTrackingTable";
            this.gridTrackingTable.Size = new System.Drawing.Size(1460, 412);
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
            this.tblp_TrackingTbl_InstanceDbSchema.Controls.Add(this.grpbxSchema, 0, 2);
            this.tblp_TrackingTbl_InstanceDbSchema.Controls.Add(this.grpbxDatabase, 0, 1);
            this.tblp_TrackingTbl_InstanceDbSchema.Controls.Add(this.grpbxInstance, 0, 0);
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
            // grpbxSchema
            // 
            this.grpbxSchema.Controls.Add(this.cbxt_TrackTbl_Schema);
            this.grpbxSchema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpbxSchema.Location = new System.Drawing.Point(3, 119);
            this.grpbxSchema.Name = "grpbxSchema";
            this.grpbxSchema.Size = new System.Drawing.Size(511, 52);
            this.grpbxSchema.TabIndex = 3;
            this.grpbxSchema.TabStop = false;
            this.grpbxSchema.Text = "Schema:";
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
            // grpbxDatabase
            // 
            this.grpbxDatabase.Controls.Add(this.cbxt_TrackTbl_Database);
            this.grpbxDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpbxDatabase.Location = new System.Drawing.Point(3, 61);
            this.grpbxDatabase.Name = "grpbxDatabase";
            this.grpbxDatabase.Padding = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.grpbxDatabase.Size = new System.Drawing.Size(511, 52);
            this.grpbxDatabase.TabIndex = 0;
            this.grpbxDatabase.TabStop = false;
            this.grpbxDatabase.Text = "Database:";
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
            // grpbxInstance
            // 
            this.grpbxInstance.Controls.Add(this.tblp_TabTrackTbl_Instance);
            this.grpbxInstance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpbxInstance.Location = new System.Drawing.Point(3, 3);
            this.grpbxInstance.Name = "grpbxInstance";
            this.grpbxInstance.Size = new System.Drawing.Size(511, 52);
            this.grpbxInstance.TabIndex = 0;
            this.grpbxInstance.TabStop = false;
            this.grpbxInstance.Text = "Instance:";
            // 
            // tblp_TabTrackTbl_Instance
            // 
            this.tblp_TabTrackTbl_Instance.ColumnCount = 2;
            this.tblp_TabTrackTbl_Instance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_TabTrackTbl_Instance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tblp_TabTrackTbl_Instance.Controls.Add(this.tbx_TrackTblInstance, 0, 0);
            this.tblp_TabTrackTbl_Instance.Controls.Add(this.btnTrackTblLogin, 1, 0);
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
            // tbx_TrackTblInstance
            // 
            this.tbx_TrackTblInstance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_TrackTblInstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_TrackTblInstance.Location = new System.Drawing.Point(4, 6);
            this.tbx_TrackTblInstance.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tbx_TrackTblInstance.Name = "tbx_TrackTblInstance";
            this.tbx_TrackTblInstance.Size = new System.Drawing.Size(407, 22);
            this.tbx_TrackTblInstance.TabIndex = 70;
            // 
            // btnTrackTblLogin
            // 
            this.btnTrackTblLogin.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTrackTblLogin.Location = new System.Drawing.Point(418, 3);
            this.btnTrackTblLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnTrackTblLogin.Name = "btnTrackTblLogin";
            this.btnTrackTblLogin.Size = new System.Drawing.Size(84, 25);
            this.btnTrackTblLogin.TabIndex = 69;
            this.btnTrackTblLogin.Text = "Login";
            this.btnTrackTblLogin.UseVisualStyleBackColor = true;
            this.btnTrackTblLogin.Click += new System.EventHandler(this.btnTrackTblLogin_Click);
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
            this.tblp_TrackingTbl_ProjectTables.Controls.Add(this.grpbxTrackTblProjectName, 0, 1);
            this.tblp_TrackingTbl_ProjectTables.Controls.Add(this.tblp_TrackTbl_ProjectsSaveRunBtns, 1, 0);
            this.tblp_TrackingTbl_ProjectTables.Controls.Add(this.grpbxTrackTblProjectsTbl, 0, 0);
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
            this.tblp_TrackTbl_ProjectNameSaveRunBtns.Controls.Add(this.grpbxTrackTblProjectNameCreateNewUseExisting, 0, 1);
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
            this.btnTrackTbl_ProjectNameSave.Location = new System.Drawing.Point(143, 18);
            this.btnTrackTbl_ProjectNameSave.Margin = new System.Windows.Forms.Padding(5, 3, 2, 3);
            this.btnTrackTbl_ProjectNameSave.Name = "btnTrackTbl_ProjectNameSave";
            this.btnTrackTbl_ProjectNameSave.Padding = new System.Windows.Forms.Padding(1);
            this.btnTrackTbl_ProjectNameSave.Size = new System.Drawing.Size(85, 32);
            this.btnTrackTbl_ProjectNameSave.TabIndex = 70;
            this.btnTrackTbl_ProjectNameSave.Text = "Save";
            this.btnTrackTbl_ProjectNameSave.UseVisualStyleBackColor = true;
            this.btnTrackTbl_ProjectNameSave.Click += new System.EventHandler(this.btnTrackTbl_ProjectNameSave_Click);
            // 
            // grpbxTrackTblProjectNameCreateNewUseExisting
            // 
            this.tblp_TrackTbl_ProjectNameSaveRunBtns.SetColumnSpan(this.grpbxTrackTblProjectNameCreateNewUseExisting, 2);
            this.grpbxTrackTblProjectNameCreateNewUseExisting.Controls.Add(this.tblp_TrackingTbl_ProjectName);
            this.grpbxTrackTblProjectNameCreateNewUseExisting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpbxTrackTblProjectNameCreateNewUseExisting.Location = new System.Drawing.Point(0, 15);
            this.grpbxTrackTblProjectNameCreateNewUseExisting.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.grpbxTrackTblProjectNameCreateNewUseExisting.Name = "grpbxTrackTblProjectNameCreateNewUseExisting";
            this.grpbxTrackTblProjectNameCreateNewUseExisting.Padding = new System.Windows.Forms.Padding(0);
            this.grpbxTrackTblProjectNameCreateNewUseExisting.Size = new System.Drawing.Size(138, 37);
            this.grpbxTrackTblProjectNameCreateNewUseExisting.TabIndex = 2;
            this.grpbxTrackTblProjectNameCreateNewUseExisting.TabStop = false;
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
            this.rdbtn_TrackTbl_ProjectNameUseExisting.Location = new System.Drawing.Point(69, 2);
            this.rdbtn_TrackTbl_ProjectNameUseExisting.Margin = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.rdbtn_TrackTbl_ProjectNameUseExisting.Name = "rdbtn_TrackTbl_ProjectNameUseExisting";
            this.rdbtn_TrackTbl_ProjectNameUseExisting.Size = new System.Drawing.Size(69, 13);
            this.rdbtn_TrackTbl_ProjectNameUseExisting.TabIndex = 1;
            this.rdbtn_TrackTbl_ProjectNameUseExisting.TabStop = true;
            this.rdbtn_TrackTbl_ProjectNameUseExisting.UseVisualStyleBackColor = true;
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
            // grpbxTrackTblProjectName
            // 
            this.grpbxTrackTblProjectName.Controls.Add(this.cbxt_TrackTbl_ProjectName);
            this.grpbxTrackTblProjectName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpbxTrackTblProjectName.Location = new System.Drawing.Point(3, 61);
            this.grpbxTrackTblProjectName.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.grpbxTrackTblProjectName.Name = "grpbxTrackTblProjectName";
            this.grpbxTrackTblProjectName.Size = new System.Drawing.Size(611, 52);
            this.grpbxTrackTblProjectName.TabIndex = 7;
            this.grpbxTrackTblProjectName.TabStop = false;
            this.grpbxTrackTblProjectName.Text = "Project Name:";
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
            this.tblp_TrackTbl_ProjectsSaveRunBtns.Controls.Add(this.grpbxTrackTblProjectCreateNewUseExisting, 0, 1);
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
            // grpbxTrackTblProjectCreateNewUseExisting
            // 
            this.tblp_TrackTbl_ProjectsSaveRunBtns.SetColumnSpan(this.grpbxTrackTblProjectCreateNewUseExisting, 2);
            this.grpbxTrackTblProjectCreateNewUseExisting.Controls.Add(this.tblp_TrackTbl_UseExistingCreateNew);
            this.grpbxTrackTblProjectCreateNewUseExisting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpbxTrackTblProjectCreateNewUseExisting.Location = new System.Drawing.Point(0, 20);
            this.grpbxTrackTblProjectCreateNewUseExisting.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.grpbxTrackTblProjectCreateNewUseExisting.Name = "grpbxTrackTblProjectCreateNewUseExisting";
            this.grpbxTrackTblProjectCreateNewUseExisting.Padding = new System.Windows.Forms.Padding(0);
            this.grpbxTrackTblProjectCreateNewUseExisting.Size = new System.Drawing.Size(138, 37);
            this.grpbxTrackTblProjectCreateNewUseExisting.TabIndex = 2;
            this.grpbxTrackTblProjectCreateNewUseExisting.TabStop = false;
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
            // grpbxTrackTblProjectsTbl
            // 
            this.grpbxTrackTblProjectsTbl.Controls.Add(this.cbxt_TrackTbl_ProjectsTable);
            this.grpbxTrackTblProjectsTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpbxTrackTblProjectsTbl.Location = new System.Drawing.Point(3, 3);
            this.grpbxTrackTblProjectsTbl.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.grpbxTrackTblProjectsTbl.Name = "grpbxTrackTblProjectsTbl";
            this.grpbxTrackTblProjectsTbl.Size = new System.Drawing.Size(611, 52);
            this.grpbxTrackTblProjectsTbl.TabIndex = 6;
            this.grpbxTrackTblProjectsTbl.TabStop = false;
            this.grpbxTrackTblProjectsTbl.Text = "Projects Table:";
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
            this.tabSandBox.Controls.Add(this.btnPrint);
            this.tabSandBox.Controls.Add(this.btnClearConfig);
            this.tabSandBox.Location = new System.Drawing.Point(4, 25);
            this.tabSandBox.Name = "tabSandBox";
            this.tabSandBox.Size = new System.Drawing.Size(1476, 608);
            this.tabSandBox.TabIndex = 4;
            this.tabSandBox.Text = "SandoBox";
            this.tabSandBox.UseVisualStyleBackColor = true;
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
            this.grpbxSchema.ResumeLayout(false);
            this.grpbxDatabase.ResumeLayout(false);
            this.grpbxInstance.ResumeLayout(false);
            this.tblp_TabTrackTbl_Instance.ResumeLayout(false);
            this.tblp_TabTrackTbl_Instance.PerformLayout();
            this.tblp_TrackingTbl_ProjectTables.ResumeLayout(false);
            this.tblp_TrackTbl_ProjectNameSaveRunBtns.ResumeLayout(false);
            this.grpbxTrackTblProjectNameCreateNewUseExisting.ResumeLayout(false);
            this.tblp_TrackingTbl_ProjectName.ResumeLayout(false);
            this.tblp_TrackingTbl_ProjectName.PerformLayout();
            this.grpbxTrackTblProjectName.ResumeLayout(false);
            this.tblp_TrackTbl_ProjectsSaveRunBtns.ResumeLayout(false);
            this.tblp_TrackTbl_ProjectsSaveRunBtns.PerformLayout();
            this.grpbxTrackTblProjectCreateNewUseExisting.ResumeLayout(false);
            this.tblp_TrackTbl_UseExistingCreateNew.ResumeLayout(false);
            this.tblp_TrackTbl_UseExistingCreateNew.PerformLayout();
            this.grpbxTrackTblProjectsTbl.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox grpbxInstance;
        private System.Windows.Forms.TabPage tabSandBox;
        private System.Windows.Forms.Button btnTrackTblLogin;
        private System.Windows.Forms.GroupBox grpbxDatabase;
        private System.Windows.Forms.GroupBox grpbxSchema;
        private System.Windows.Forms.GroupBox grpbxTrackTblProjectsTbl;
        private System.Windows.Forms.TableLayoutPanel tblp_TabTrackTbl_Instance;
        private System.Windows.Forms.TextBox tbx_TrackTblInstance;
        private System.Windows.Forms.TableLayoutPanel tblp_TrackTbl_ProjectsSaveRunBtns;
        private System.Windows.Forms.GroupBox grpbxTrackTblProjectCreateNewUseExisting;
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
        private ComboBoxExt cbxt_TrackTbl_ProjectsTable;
        private TextBoxExt tbx_DataType_Src;
        private TextBoxExt tbx_DataType_Tgt;
        private System.Windows.Forms.GroupBox grpbxTrackTblProjectName;
        private ComboBoxExt cbxt_TrackTbl_ProjectName;
        private System.Windows.Forms.TableLayoutPanel tblp_TrackTbl_ProjectNameSaveRunBtns;
        private System.Windows.Forms.Button btnTrackTbl_ProjectNameEdit;
        private System.Windows.Forms.Button btnTrackTbl_ProjectNameSave;
        private System.Windows.Forms.GroupBox grpbxTrackTblProjectNameCreateNewUseExisting;
        private System.Windows.Forms.TableLayoutPanel tblp_TrackingTbl_ProjectName;
        private System.Windows.Forms.RadioButton rdbtn_TrackTbl_ProjectNameUseExisting;
        private RadioButtonExt rdbtn_TrackTbl_ProjectNameCreateNew;
        private System.Windows.Forms.SplitContainer split_TrackingTable;
        private System.Windows.Forms.TableLayoutPanel tblp_TrackingTbl_InstanceDbSchema;
        private System.Windows.Forms.TableLayoutPanel tblp_TrackingTbl_ProjectTables;
    }
}

