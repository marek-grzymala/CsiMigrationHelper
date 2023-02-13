﻿
namespace CsiMigrationHelper
{
    partial class Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.tbx_CurrentSuffix = new System.Windows.Forms.TextBox();
            this.tbx_StagingSuffix = new System.Windows.Forms.TextBox();
            this.lblStaging = new System.Windows.Forms.Label();
            this.tbx_ArchiveSuffix = new System.Windows.Forms.TextBox();
            this.lblArchive = new System.Windows.Forms.Label();
            this.tbx_CSIprefix = new System.Windows.Forms.TextBox();
            this.lblCSI_Prefix = new System.Windows.Forms.Label();
            this.tbx_TgtColumnNameSuffix = new System.Windows.Forms.TextBox();
            this.lblTgtColumnNameSuffix = new System.Windows.Forms.Label();
            this.tabControlOptions = new System.Windows.Forms.TabControl();
            this.Tab_SrcTgtSetup = new System.Windows.Forms.TabPage();
            this.chkbxAutoDropDownComboBoxes = new System.Windows.Forms.CheckBox();
            this.lblAutoDropComboBoxes = new System.Windows.Forms.Label();
            this.Tab_TgtMetaDataSetup = new System.Windows.Forms.TabPage();
            this.chkbxRenameTgtColumns = new System.Windows.Forms.CheckBox();
            this.chkbxMakeCSIClustered = new System.Windows.Forms.CheckBox();
            this.chbxDoNotCreateFKsOnCrossDbTarget = new System.Windows.Forms.CheckBox();
            this.gpbxUserDefDataTypeHndling = new System.Windows.Forms.GroupBox();
            this.rdbtnTranslateUserDefinedDataTypes = new System.Windows.Forms.RadioButton();
            this.rdbtnUseDataTypesAsDefinedInSrc = new System.Windows.Forms.RadioButton();
            this.Tab_TrackingTable = new System.Windows.Forms.TabPage();
            this.lblNewProjectsDefaultName = new System.Windows.Forms.Label();
            this.tbx_NewProjectDefaultName = new System.Windows.Forms.TextBox();
            this.lblTrackingTableDefaultName = new System.Windows.Forms.Label();
            this.tbx_ProjectsTableDefaultName = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.lblNewProjectsDefaultDescription = new System.Windows.Forms.Label();
            this.tbx_NewProjectDefaultDescription = new System.Windows.Forms.TextBox();
            this.tabControlOptions.SuspendLayout();
            this.Tab_SrcTgtSetup.SuspendLayout();
            this.Tab_TgtMetaDataSetup.SuspendLayout();
            this.gpbxUserDefDataTypeHndling.SuspendLayout();
            this.Tab_TrackingTable.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(167, 13);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(85, 26);
            this.OK.TabIndex = 0;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(286, 13);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(85, 26);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrent.Location = new System.Drawing.Point(28, 53);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(141, 18);
            this.lblCurrent.TabIndex = 2;
            this.lblCurrent.Text = "Current Table Suffix:";
            // 
            // tbx_CurrentSuffix
            // 
            this.tbx_CurrentSuffix.Location = new System.Drawing.Point(267, 51);
            this.tbx_CurrentSuffix.Name = "tbx_CurrentSuffix";
            this.tbx_CurrentSuffix.Size = new System.Drawing.Size(204, 24);
            this.tbx_CurrentSuffix.TabIndex = 3;
            this.tbx_CurrentSuffix.Text = "_Current";
            // 
            // tbx_StagingSuffix
            // 
            this.tbx_StagingSuffix.Location = new System.Drawing.Point(267, 90);
            this.tbx_StagingSuffix.Name = "tbx_StagingSuffix";
            this.tbx_StagingSuffix.Size = new System.Drawing.Size(204, 24);
            this.tbx_StagingSuffix.TabIndex = 5;
            this.tbx_StagingSuffix.Text = "_Staging";
            // 
            // lblStaging
            // 
            this.lblStaging.AutoSize = true;
            this.lblStaging.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaging.Location = new System.Drawing.Point(28, 92);
            this.lblStaging.Name = "lblStaging";
            this.lblStaging.Size = new System.Drawing.Size(141, 18);
            this.lblStaging.TabIndex = 4;
            this.lblStaging.Text = "Staging Table Suffix:";
            // 
            // tbx_ArchiveSuffix
            // 
            this.tbx_ArchiveSuffix.Location = new System.Drawing.Point(267, 134);
            this.tbx_ArchiveSuffix.Name = "tbx_ArchiveSuffix";
            this.tbx_ArchiveSuffix.Size = new System.Drawing.Size(204, 24);
            this.tbx_ArchiveSuffix.TabIndex = 7;
            this.tbx_ArchiveSuffix.Text = "_Archive";
            // 
            // lblArchive
            // 
            this.lblArchive.AutoSize = true;
            this.lblArchive.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArchive.Location = new System.Drawing.Point(28, 136);
            this.lblArchive.Name = "lblArchive";
            this.lblArchive.Size = new System.Drawing.Size(140, 18);
            this.lblArchive.TabIndex = 6;
            this.lblArchive.Text = "Archive Table Suffix:";
            // 
            // tbx_CSIprefix
            // 
            this.tbx_CSIprefix.Location = new System.Drawing.Point(267, 178);
            this.tbx_CSIprefix.Name = "tbx_CSIprefix";
            this.tbx_CSIprefix.Size = new System.Drawing.Size(204, 24);
            this.tbx_CSIprefix.TabIndex = 9;
            this.tbx_CSIprefix.Text = "CSI_";
            // 
            // lblCSI_Prefix
            // 
            this.lblCSI_Prefix.AutoSize = true;
            this.lblCSI_Prefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCSI_Prefix.Location = new System.Drawing.Point(28, 180);
            this.lblCSI_Prefix.Name = "lblCSI_Prefix";
            this.lblCSI_Prefix.Size = new System.Drawing.Size(156, 18);
            this.lblCSI_Prefix.TabIndex = 8;
            this.lblCSI_Prefix.Text = "CS Index Name Prefix:";
            // 
            // tbx_TgtColumnNameSuffix
            // 
            this.tbx_TgtColumnNameSuffix.Enabled = false;
            this.tbx_TgtColumnNameSuffix.Location = new System.Drawing.Point(380, 251);
            this.tbx_TgtColumnNameSuffix.Name = "tbx_TgtColumnNameSuffix";
            this.tbx_TgtColumnNameSuffix.Size = new System.Drawing.Size(91, 24);
            this.tbx_TgtColumnNameSuffix.TabIndex = 11;
            this.tbx_TgtColumnNameSuffix.Text = "_";
            // 
            // lblTgtColumnNameSuffix
            // 
            this.lblTgtColumnNameSuffix.AutoSize = true;
            this.lblTgtColumnNameSuffix.Enabled = false;
            this.lblTgtColumnNameSuffix.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTgtColumnNameSuffix.Location = new System.Drawing.Point(41, 253);
            this.lblTgtColumnNameSuffix.Name = "lblTgtColumnNameSuffix";
            this.lblTgtColumnNameSuffix.Size = new System.Drawing.Size(333, 18);
            this.lblTgtColumnNameSuffix.TabIndex = 10;
            this.lblTgtColumnNameSuffix.Text = "Append an additional Target Column Name Suffix:";
            // 
            // tabControlOptions
            // 
            this.tabControlOptions.Controls.Add(this.Tab_SrcTgtSetup);
            this.tabControlOptions.Controls.Add(this.Tab_TgtMetaDataSetup);
            this.tabControlOptions.Controls.Add(this.Tab_TrackingTable);
            this.tabControlOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlOptions.Location = new System.Drawing.Point(0, 0);
            this.tabControlOptions.Name = "tabControlOptions";
            this.tabControlOptions.SelectedIndex = 0;
            this.tabControlOptions.Size = new System.Drawing.Size(539, 322);
            this.tabControlOptions.TabIndex = 12;
            // 
            // Tab_SrcTgtSetup
            // 
            this.Tab_SrcTgtSetup.Controls.Add(this.chkbxAutoDropDownComboBoxes);
            this.Tab_SrcTgtSetup.Controls.Add(this.lblAutoDropComboBoxes);
            this.Tab_SrcTgtSetup.Controls.Add(this.lblCurrent);
            this.Tab_SrcTgtSetup.Controls.Add(this.tbx_CurrentSuffix);
            this.Tab_SrcTgtSetup.Controls.Add(this.lblStaging);
            this.Tab_SrcTgtSetup.Controls.Add(this.tbx_StagingSuffix);
            this.Tab_SrcTgtSetup.Controls.Add(this.lblArchive);
            this.Tab_SrcTgtSetup.Controls.Add(this.tbx_ArchiveSuffix);
            this.Tab_SrcTgtSetup.Controls.Add(this.lblCSI_Prefix);
            this.Tab_SrcTgtSetup.Controls.Add(this.tbx_CSIprefix);
            this.Tab_SrcTgtSetup.Location = new System.Drawing.Point(4, 27);
            this.Tab_SrcTgtSetup.Name = "Tab_SrcTgtSetup";
            this.Tab_SrcTgtSetup.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_SrcTgtSetup.Size = new System.Drawing.Size(531, 291);
            this.Tab_SrcTgtSetup.TabIndex = 0;
            this.Tab_SrcTgtSetup.Text = "Source/Target Setup:";
            this.Tab_SrcTgtSetup.UseVisualStyleBackColor = true;
            // 
            // chkbxAutoDropDownComboBoxes
            // 
            this.chkbxAutoDropDownComboBoxes.AutoSize = true;
            this.chkbxAutoDropDownComboBoxes.Checked = true;
            this.chkbxAutoDropDownComboBoxes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbxAutoDropDownComboBoxes.Location = new System.Drawing.Point(271, 223);
            this.chkbxAutoDropDownComboBoxes.Name = "chkbxAutoDropDownComboBoxes";
            this.chkbxAutoDropDownComboBoxes.Size = new System.Drawing.Size(15, 14);
            this.chkbxAutoDropDownComboBoxes.TabIndex = 11;
            this.chkbxAutoDropDownComboBoxes.UseVisualStyleBackColor = true;
            // 
            // lblAutoDropComboBoxes
            // 
            this.lblAutoDropComboBoxes.AutoSize = true;
            this.lblAutoDropComboBoxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoDropComboBoxes.Location = new System.Drawing.Point(27, 223);
            this.lblAutoDropComboBoxes.Name = "lblAutoDropComboBoxes";
            this.lblAutoDropComboBoxes.Size = new System.Drawing.Size(223, 18);
            this.lblAutoDropComboBoxes.TabIndex = 10;
            this.lblAutoDropComboBoxes.Text = "Auto Drop-Down Combo Boxes:";
            // 
            // Tab_TgtMetaDataSetup
            // 
            this.Tab_TgtMetaDataSetup.Controls.Add(this.chkbxRenameTgtColumns);
            this.Tab_TgtMetaDataSetup.Controls.Add(this.chkbxMakeCSIClustered);
            this.Tab_TgtMetaDataSetup.Controls.Add(this.chbxDoNotCreateFKsOnCrossDbTarget);
            this.Tab_TgtMetaDataSetup.Controls.Add(this.gpbxUserDefDataTypeHndling);
            this.Tab_TgtMetaDataSetup.Controls.Add(this.tbx_TgtColumnNameSuffix);
            this.Tab_TgtMetaDataSetup.Controls.Add(this.lblTgtColumnNameSuffix);
            this.Tab_TgtMetaDataSetup.Location = new System.Drawing.Point(4, 27);
            this.Tab_TgtMetaDataSetup.Name = "Tab_TgtMetaDataSetup";
            this.Tab_TgtMetaDataSetup.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_TgtMetaDataSetup.Size = new System.Drawing.Size(531, 291);
            this.Tab_TgtMetaDataSetup.TabIndex = 1;
            this.Tab_TgtMetaDataSetup.Text = "Target Metadata:";
            this.Tab_TgtMetaDataSetup.UseVisualStyleBackColor = true;
            // 
            // chkbxRenameTgtColumns
            // 
            this.chkbxRenameTgtColumns.AutoSize = true;
            this.chkbxRenameTgtColumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbxRenameTgtColumns.Location = new System.Drawing.Point(41, 212);
            this.chkbxRenameTgtColumns.Name = "chkbxRenameTgtColumns";
            this.chkbxRenameTgtColumns.Size = new System.Drawing.Size(340, 22);
            this.chkbxRenameTgtColumns.TabIndex = 15;
            this.chkbxRenameTgtColumns.Text = "Rename Tgt Columns using TableName pattern";
            this.chkbxRenameTgtColumns.UseVisualStyleBackColor = true;
            this.chkbxRenameTgtColumns.CheckedChanged += new System.EventHandler(this.chkbxRenameTgtColumns_CheckedChanged);
            // 
            // chkbxMakeCSIClustered
            // 
            this.chkbxMakeCSIClustered.AutoSize = true;
            this.chkbxMakeCSIClustered.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbxMakeCSIClustered.Location = new System.Drawing.Point(41, 174);
            this.chkbxMakeCSIClustered.Name = "chkbxMakeCSIClustered";
            this.chkbxMakeCSIClustered.Size = new System.Drawing.Size(283, 22);
            this.chkbxMakeCSIClustered.TabIndex = 14;
            this.chkbxMakeCSIClustered.Text = "Make the Columnstore Index Clustered";
            this.chkbxMakeCSIClustered.UseVisualStyleBackColor = true;
            // 
            // chbxDoNotCreateFKsOnCrossDbTarget
            // 
            this.chbxDoNotCreateFKsOnCrossDbTarget.AutoSize = true;
            this.chbxDoNotCreateFKsOnCrossDbTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxDoNotCreateFKsOnCrossDbTarget.Location = new System.Drawing.Point(41, 140);
            this.chbxDoNotCreateFKsOnCrossDbTarget.Name = "chbxDoNotCreateFKsOnCrossDbTarget";
            this.chbxDoNotCreateFKsOnCrossDbTarget.Size = new System.Drawing.Size(352, 22);
            this.chbxDoNotCreateFKsOnCrossDbTarget.TabIndex = 13;
            this.chbxDoNotCreateFKsOnCrossDbTarget.Text = "Do not create ForeignKeys on a Cross-Db Target";
            this.chbxDoNotCreateFKsOnCrossDbTarget.UseVisualStyleBackColor = true;
            // 
            // gpbxUserDefDataTypeHndling
            // 
            this.gpbxUserDefDataTypeHndling.Controls.Add(this.rdbtnTranslateUserDefinedDataTypes);
            this.gpbxUserDefDataTypeHndling.Controls.Add(this.rdbtnUseDataTypesAsDefinedInSrc);
            this.gpbxUserDefDataTypeHndling.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbxUserDefDataTypeHndling.Location = new System.Drawing.Point(41, 17);
            this.gpbxUserDefDataTypeHndling.Name = "gpbxUserDefDataTypeHndling";
            this.gpbxUserDefDataTypeHndling.Size = new System.Drawing.Size(430, 114);
            this.gpbxUserDefDataTypeHndling.TabIndex = 12;
            this.gpbxUserDefDataTypeHndling.TabStop = false;
            this.gpbxUserDefDataTypeHndling.Text = "User-Defined DataType Handling:";
            // 
            // rdbtnTranslateUserDefinedDataTypes
            // 
            this.rdbtnTranslateUserDefinedDataTypes.AutoSize = true;
            this.rdbtnTranslateUserDefinedDataTypes.Location = new System.Drawing.Point(23, 71);
            this.rdbtnTranslateUserDefinedDataTypes.Name = "rdbtnTranslateUserDefinedDataTypes";
            this.rdbtnTranslateUserDefinedDataTypes.Size = new System.Drawing.Size(374, 22);
            this.rdbtnTranslateUserDefinedDataTypes.TabIndex = 1;
            this.rdbtnTranslateUserDefinedDataTypes.Text = "Translate User-Defined Data-Types to System-Types";
            this.rdbtnTranslateUserDefinedDataTypes.UseVisualStyleBackColor = true;
            // 
            // rdbtnUseDataTypesAsDefinedInSrc
            // 
            this.rdbtnUseDataTypesAsDefinedInSrc.AutoSize = true;
            this.rdbtnUseDataTypesAsDefinedInSrc.Checked = true;
            this.rdbtnUseDataTypesAsDefinedInSrc.Location = new System.Drawing.Point(24, 35);
            this.rdbtnUseDataTypesAsDefinedInSrc.Name = "rdbtnUseDataTypesAsDefinedInSrc";
            this.rdbtnUseDataTypesAsDefinedInSrc.Size = new System.Drawing.Size(271, 22);
            this.rdbtnUseDataTypesAsDefinedInSrc.TabIndex = 0;
            this.rdbtnUseDataTypesAsDefinedInSrc.TabStop = true;
            this.rdbtnUseDataTypesAsDefinedInSrc.Text = "Use Data-Types as defined in Source";
            this.rdbtnUseDataTypesAsDefinedInSrc.UseVisualStyleBackColor = true;
            // 
            // Tab_TrackingTable
            // 
            this.Tab_TrackingTable.Controls.Add(this.lblNewProjectsDefaultDescription);
            this.Tab_TrackingTable.Controls.Add(this.tbx_NewProjectDefaultDescription);
            this.Tab_TrackingTable.Controls.Add(this.lblNewProjectsDefaultName);
            this.Tab_TrackingTable.Controls.Add(this.tbx_NewProjectDefaultName);
            this.Tab_TrackingTable.Controls.Add(this.lblTrackingTableDefaultName);
            this.Tab_TrackingTable.Controls.Add(this.tbx_ProjectsTableDefaultName);
            this.Tab_TrackingTable.Location = new System.Drawing.Point(4, 27);
            this.Tab_TrackingTable.Name = "Tab_TrackingTable";
            this.Tab_TrackingTable.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_TrackingTable.Size = new System.Drawing.Size(531, 291);
            this.Tab_TrackingTable.TabIndex = 2;
            this.Tab_TrackingTable.Text = "TrackingTable";
            this.Tab_TrackingTable.UseVisualStyleBackColor = true;
            // 
            // lblNewProjectsDefaultName
            // 
            this.lblNewProjectsDefaultName.AutoSize = true;
            this.lblNewProjectsDefaultName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewProjectsDefaultName.Location = new System.Drawing.Point(19, 107);
            this.lblNewProjectsDefaultName.Name = "lblNewProjectsDefaultName";
            this.lblNewProjectsDefaultName.Size = new System.Drawing.Size(223, 18);
            this.lblNewProjectsDefaultName.TabIndex = 6;
            this.lblNewProjectsDefaultName.Text = "Default Name for Projects Table:";
            // 
            // tbx_NewProjectDefaultName
            // 
            this.tbx_NewProjectDefaultName.Location = new System.Drawing.Point(258, 105);
            this.tbx_NewProjectDefaultName.Name = "tbx_NewProjectDefaultName";
            this.tbx_NewProjectDefaultName.Size = new System.Drawing.Size(204, 24);
            this.tbx_NewProjectDefaultName.TabIndex = 7;
            this.tbx_NewProjectDefaultName.Text = "Csix Migration Project";
            // 
            // lblTrackingTableDefaultName
            // 
            this.lblTrackingTableDefaultName.AutoSize = true;
            this.lblTrackingTableDefaultName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrackingTableDefaultName.Location = new System.Drawing.Point(19, 57);
            this.lblTrackingTableDefaultName.Name = "lblTrackingTableDefaultName";
            this.lblTrackingTableDefaultName.Size = new System.Drawing.Size(223, 18);
            this.lblTrackingTableDefaultName.TabIndex = 4;
            this.lblTrackingTableDefaultName.Text = "Default Name for Projects Table:";
            // 
            // tbx_ProjectsTableDefaultName
            // 
            this.tbx_ProjectsTableDefaultName.Location = new System.Drawing.Point(258, 55);
            this.tbx_ProjectsTableDefaultName.Name = "tbx_ProjectsTableDefaultName";
            this.tbx_ProjectsTableDefaultName.Size = new System.Drawing.Size(204, 24);
            this.tbx_ProjectsTableDefaultName.TabIndex = 5;
            this.tbx_ProjectsTableDefaultName.Text = "CsixMigrationProjects";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.Cancel);
            this.pnlButtons.Controls.Add(this.OK);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 328);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(539, 53);
            this.pnlButtons.TabIndex = 13;
            // 
            // lblNewProjectsDefaultDescription
            // 
            this.lblNewProjectsDefaultDescription.AutoSize = true;
            this.lblNewProjectsDefaultDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewProjectsDefaultDescription.Location = new System.Drawing.Point(19, 162);
            this.lblNewProjectsDefaultDescription.Name = "lblNewProjectsDefaultDescription";
            this.lblNewProjectsDefaultDescription.Size = new System.Drawing.Size(223, 18);
            this.lblNewProjectsDefaultDescription.TabIndex = 8;
            this.lblNewProjectsDefaultDescription.Text = "Default Name for Projects Table:";
            // 
            // tbx_NewProjectDefaultDescription
            // 
            this.tbx_NewProjectDefaultDescription.Location = new System.Drawing.Point(258, 160);
            this.tbx_NewProjectDefaultDescription.Name = "tbx_NewProjectDefaultDescription";
            this.tbx_NewProjectDefaultDescription.Size = new System.Drawing.Size(204, 24);
            this.tbx_NewProjectDefaultDescription.TabIndex = 9;
            this.tbx_NewProjectDefaultDescription.Text = "Csix Migration Project Description";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 381);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.tabControlOptions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(555, 420);
            this.MinimumSize = new System.Drawing.Size(555, 420);
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.tabControlOptions.ResumeLayout(false);
            this.Tab_SrcTgtSetup.ResumeLayout(false);
            this.Tab_SrcTgtSetup.PerformLayout();
            this.Tab_TgtMetaDataSetup.ResumeLayout(false);
            this.Tab_TgtMetaDataSetup.PerformLayout();
            this.gpbxUserDefDataTypeHndling.ResumeLayout(false);
            this.gpbxUserDefDataTypeHndling.PerformLayout();
            this.Tab_TrackingTable.ResumeLayout(false);
            this.Tab_TrackingTable.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.TextBox tbx_CurrentSuffix;
        private System.Windows.Forms.TextBox tbx_StagingSuffix;
        private System.Windows.Forms.Label lblStaging;
        private System.Windows.Forms.TextBox tbx_ArchiveSuffix;
        private System.Windows.Forms.Label lblArchive;
        private System.Windows.Forms.TextBox tbx_CSIprefix;
        private System.Windows.Forms.Label lblCSI_Prefix;
        private System.Windows.Forms.TextBox tbx_TgtColumnNameSuffix;
        private System.Windows.Forms.Label lblTgtColumnNameSuffix;
        private System.Windows.Forms.TabControl tabControlOptions;
        private System.Windows.Forms.TabPage Tab_SrcTgtSetup;
        private System.Windows.Forms.TabPage Tab_TgtMetaDataSetup;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.GroupBox gpbxUserDefDataTypeHndling;
        private System.Windows.Forms.RadioButton rdbtnTranslateUserDefinedDataTypes;
        private System.Windows.Forms.RadioButton rdbtnUseDataTypesAsDefinedInSrc;
        private System.Windows.Forms.CheckBox chbxDoNotCreateFKsOnCrossDbTarget;
        private System.Windows.Forms.CheckBox chkbxMakeCSIClustered;
        private System.Windows.Forms.CheckBox chkbxRenameTgtColumns;
        private System.Windows.Forms.CheckBox chkbxAutoDropDownComboBoxes;
        private System.Windows.Forms.Label lblAutoDropComboBoxes;
        private System.Windows.Forms.TabPage Tab_TrackingTable;
        private System.Windows.Forms.Label lblTrackingTableDefaultName;
        private System.Windows.Forms.TextBox tbx_ProjectsTableDefaultName;
        private System.Windows.Forms.Label lblNewProjectsDefaultName;
        private System.Windows.Forms.TextBox tbx_NewProjectDefaultName;
        private System.Windows.Forms.Label lblNewProjectsDefaultDescription;
        private System.Windows.Forms.TextBox tbx_NewProjectDefaultDescription;
    }
}