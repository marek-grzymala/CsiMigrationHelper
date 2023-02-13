using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsiMigrationHelper
{
    public class ComboBoxExtTrackTbl : ComboBoxExt
    {
        public RadioButton RdButtonCreateNew;
        public RadioButton RdButtonUseExisting;
        public GroupBox    RdButtonsGroupBox;
        public Button      SaveButton;
        public Button      RenameButton;

        public ComboBoxExtTrackTbl()
        {

        }

        public void SetParentTreeNode(TreeNode<DbObject> tn, RadioButton rbtnNew, RadioButton rbtnExisting, GroupBox rdButtonsGroupBox, Button saveButton, Button renameButton)
        {
            TreeNodeOwner       = tn                != null ? tn : null;
            RdButtonCreateNew   = rbtnNew           != null ? rbtnNew: null;
            RdButtonUseExisting = rbtnExisting      != null ? rbtnExisting : null;
            RdButtonsGroupBox   = rdButtonsGroupBox != null ? rdButtonsGroupBox : null;
            SaveButton          = saveButton        != null ? saveButton : null;
            RenameButton        = renameButton      != null ? renameButton : null;
            if (RdButtonCreateNew != null)
            {
                RdButtonCreateNew.CheckedChanged += new EventHandler(OnRdButtonCheckedChanged);
            }
            this.TextChanged += new EventHandler(OnTextChanged);
            SaveButton.EnabledChanged += new EventHandler(OnSaveButtonEnabledChanged);
            RenameButton.EnabledChanged += new EventHandler(OnRenameButtonEnabledChanged);
            RenameButton.Click += new EventHandler(UnLockGuiControls);
        }
        protected virtual void OnTextChanged(object sender, EventArgs e)
        {
            if (this.Text.Length > 0 && this.RdButtonCreateNew.Checked)
            {
                this.TreeNodeOwner.SetTreeNodeTextNoSubtreeClearing(TreeNodeOwner, Text, false);
                /*enable or disable Save Button depending on Text Length: */
                this.SaveButton.Enabled = this.Text.Length > 0 ? true : false;
                this.SaveButton.Image = null;
            }
            else
            {
                this.SaveButton.Enabled = false;
                this.SaveButton.Image = null;
            }
        }

        public void RunOnRdButtonCheckedChanged(object sender, EventArgs e)
        {
            this.OnRdButtonCheckedChanged(sender, e);
        }

        protected virtual void OnRdButtonCheckedChanged(object sender, EventArgs e)
        {
            if (TreeNodeOwner.Data.ObjectBranch == (int)DbObjectBranch.TrckTbl && RdButtonCreateNew != null && SaveButton != null)
            {
                if (RdButtonCreateNew.Checked && TreeNodeOwner != null)
                {
                    if (TreeNodeOwner.Parent.IsTextSet())
                    {
                        int objectLevel = TreeNodeOwner.Data.ObjectLevel;
                        switch (objectLevel)
                        {
                            case (int)DbObjectLevel.Table:
                                TreeNodeOwner.Data.Gui.ClearGui();
                                TreeNodeOwner.SetTreeNodeText(TreeNodeOwner, Options.projectsTableDefaultName, false);
                                break;

                            case (int)DbObjectLevel.Column:
                                TreeNodeOwner.Data.Gui.ClearGui();
                                TreeNodeOwner.SetTreeNodeText(TreeNodeOwner, Options.newProjectDefaultName, false);
                                break;
                        }
                    }
                }
                /*enable or disable Save Button depending on RdButton State and Cbx Text Length: */
                SaveButton.Enabled = (RdButtonCreateNew.Checked && this.Text.Length > 0) ? true : false;
            }
        }

        protected virtual void OnSaveButtonEnabledChanged(object sender, EventArgs e)
        {
            if (SaveButton.Enabled)
            {
                RenameButton.Enabled = false;
                RenameButton.Image = null;
            }
            else
            {
                RenameButton.Enabled = true;
                RenameButton.Image = null;
            }
        }

        protected virtual void OnRenameButtonEnabledChanged(object sender, EventArgs e)
        {
            if (RenameButton.Enabled)
            {
                SaveButton.Enabled = false;
                SaveButton.Image = null;
            }
            else
            {
                SaveButton.Enabled = true;
                SaveButton.Image = null;
            }
        }

        public void LockGuiControls()
        {
            this.Enabled                = false;
            RdButtonsGroupBox.Enabled   = false;
            SaveButton.Enabled          = false;
        }

        public void UnLockGuiControls(object sender, EventArgs e)
        {
            this.Enabled                = true;
            RdButtonsGroupBox.Enabled   = true;
            SaveButton.Enabled          = true;
        }
    }
}
