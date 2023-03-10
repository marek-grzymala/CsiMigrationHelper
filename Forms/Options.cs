using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
//using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsiMigrationHelper
{
    public partial class Options : Form
    {
        public static bool autoDropDownComboBoxes;
        public static string suffixCurrent;
        public static string suffixStaging;
        public static string suffixArchive;
        public static string prefixCSI;

        public static string partition_FG_Prefix;
        public static string partition_FI_Prefix;
        public static string partition_PF_Name;
        public static string partition_PS_Name;
        public static string partitionInterval;

        public static bool translateUserDefinedDataTypes;
        public static bool doNotCreateFKsOnCrossDbTarget;
        public static bool makeCSIClustered;
        public static bool renameTgtColumns;
        public static string suffixTgtColName;
        public static bool allowCreateTgtArchiveWithNoCsiIndex;

        public static string projectsTableDefaultName;
        public static string newProjectDefaultName;
        public static string newProjectDefaultDescription;
        public static string migrationTrackingTblSuffix;

        public Options()
        {
            InitializeComponent();
            tbx_CurrentSuffix.Text = suffixCurrent;
            tbx_StagingSuffix.Text = suffixStaging;
            tbx_ArchiveSuffix.Text = suffixArchive;
            tbx_CSIprefix.Text = prefixCSI;

            tbx_Partition_FG_Prefix.Text        = partition_FG_Prefix;
            tbx_Partition_FI_Prefix.Text        = partition_FI_Prefix;
            tbx_Partition_PF.Text               = partition_PF_Name;
            tbx_Partition_PS.Text               = partition_PS_Name;
            cmbx_PartitionInterval.SelectedItem = partitionInterval;

            chkbxAutoDropDownComboBoxes.Checked = autoDropDownComboBoxes;
            rdbtnTranslateUserDefinedDataTypes.Checked = translateUserDefinedDataTypes;
            chbxDoNotCreateFKsOnCrossDbTarget.Checked = doNotCreateFKsOnCrossDbTarget;
            chkbxMakeCSIClustered.Checked = makeCSIClustered;
            chkbxRenameTgtColumns.Checked = renameTgtColumns;
            tbx_TgtColumnNameSuffix.Text = suffixTgtColName;
            chbxAllowCreateTgtArchiveWithNoCsiIndex.Checked = allowCreateTgtArchiveWithNoCsiIndex;

            tbx_ProjectsTableDefaultName.Text = projectsTableDefaultName;
            tbx_NewProjectDefaultName.Text = newProjectDefaultName;
            tbx_NewProjectDefaultDescription.Text = newProjectDefaultDescription;
            tbx_MIgrationTrackingTblSuffix.Text = migrationTrackingTblSuffix;
        }

        public static bool HandleOptionsMenuClick()
        {
            DialogResult diagResult;
            using (Options options = new Options())
            {
                diagResult = options.ShowDialog();
                if (diagResult == DialogResult.OK)
                {
                    suffixCurrent = options.tbx_CurrentSuffix.Text;
                    suffixStaging = options.tbx_StagingSuffix.Text;
                    suffixArchive = options.tbx_ArchiveSuffix.Text;
                    prefixCSI = options.tbx_CSIprefix.Text;

                    partition_FG_Prefix = options.tbx_Partition_FG_Prefix.Text;
                    partition_FI_Prefix = options.tbx_Partition_FI_Prefix.Text;       
                    partition_PF_Name   = options.tbx_Partition_PF.Text;
                    partition_PS_Name   = options.tbx_Partition_PS.Text;
                    partitionInterval   = options.cmbx_PartitionInterval.SelectedText;

                    autoDropDownComboBoxes = options.chkbxAutoDropDownComboBoxes.Checked ? true : false;
                    translateUserDefinedDataTypes = options.rdbtnTranslateUserDefinedDataTypes.Checked ? true : false;
                    doNotCreateFKsOnCrossDbTarget = options.chbxDoNotCreateFKsOnCrossDbTarget.Checked ? true : false;
                    makeCSIClustered = options.chkbxMakeCSIClustered.Checked ? true : false;
                    renameTgtColumns = options.chkbxRenameTgtColumns.Checked ? true : false;
                    suffixTgtColName = options.tbx_TgtColumnNameSuffix.Text;
                    allowCreateTgtArchiveWithNoCsiIndex = options.chbxAllowCreateTgtArchiveWithNoCsiIndex.Checked ? true : false;

                    projectsTableDefaultName = options.tbx_ProjectsTableDefaultName.Text;
                    newProjectDefaultName = options.tbx_NewProjectDefaultName.Text;
                    newProjectDefaultDescription = options.tbx_NewProjectDefaultDescription.Text;
                    migrationTrackingTblSuffix = options.tbx_MIgrationTrackingTblSuffix.Text;
                }
            }
            return diagResult == DialogResult.OK;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.DialogResult = DialogResult.OK;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.DialogResult = DialogResult.OK;
        }

        public static string GetTableSuffixPerNode(TreeNode<DbObject> t)
        {
            string suffix = string.Empty;
            if ((t.Data.ObjectBranch == (int)DbObjectBranch.Tgt || t.Data.ObjectBranch == (int)DbObjectBranch.TrckTbl)
                && t.Data.ObjectLevel == (int)DbObjectLevel.Table)
            {
                if (t.Data.ObjectName.Contains("Current"))
                {
                    suffix = suffixCurrent;
                }
                else if (t.Data.ObjectName.Contains("Staging"))
                {
                    suffix = suffixStaging;
                }
                else if (t.Data.ObjectName.Contains("Archive"))
                {
                    suffix = suffixArchive;
                }
            }
            else
            {
                throw new Exception(string.Concat("Method GetTableSuffixPerNode() got input object with either wrong ObjectBranch: [",
                                                   t.Data.ObjectBranch,
                                                   "] or wrong ObjectLevel: [", t.Data.ObjectLevel, "]",
                                                   "Correct ObjectBranch is: [", (int)DbObjectBranch.Tgt,
                                                   "] and correct ObjectLevel is: [", (int)DbObjectLevel.Table, "]"));
            }
            return suffix;
        }

        private void chkbxRenameTgtColumns_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbxRenameTgtColumns.Checked)
            {
                lblTgtColumnNameSuffix.Enabled = true;
                tbx_TgtColumnNameSuffix.Enabled = true;
            }
            else
            {
                lblTgtColumnNameSuffix.Enabled = false;
                tbx_TgtColumnNameSuffix.Enabled = false;
            }
        }
    }
}
