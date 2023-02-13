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
        public Button      EditButton;

        public ComboBoxExtTrackTbl()
        {

        }

        public void SetParentTreeNode(TreeNode<DbObject> tn
                                    , RadioButton rbtnNew
                                    , RadioButton rbtnExisting
                                    , GroupBox rdButtonsGroupBox
                                    , Button saveButton
                                    , Button renameButton)
        {
            TreeNodeOwner       = tn                    != null ? tn : null;
            RdButtonCreateNew   = rbtnNew               != null ? rbtnNew: null;
            RdButtonUseExisting = rbtnExisting          != null ? rbtnExisting : null;
            RdButtonsGroupBox   = rdButtonsGroupBox     != null ? rdButtonsGroupBox : null;
            SaveButton          = saveButton            != null ? saveButton : null;
            EditButton          = renameButton          != null ? renameButton : null;
            if (RdButtonCreateNew != null)
            {
                RdButtonCreateNew.CheckedChanged += new EventHandler(OnRdButtonCheckedChanged);
            }
            this.TextChanged += new EventHandler(OnTextChanged);
            EditButton.Click += new EventHandler(UnLockGuiControls);
        }
        protected virtual void OnTextChanged(object sender, EventArgs e)
        {
            if (RdButtonCreateNew.Checked && Text.Length > 0)
            {
                this.TreeNodeOwner.SetTreeNodeTextNoSubtreeClearing(TreeNodeOwner, Text, false);
                /* enable or disable Save Button depending on Text Length: */
                this.SaveButton.Enabled = true;
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
                if (RdButtonCreateNew.Checked)
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
                                TreeNodeOwner.SetTextOfDirectChildren(TreeNodeOwner, Options.newProjectDefaultDescription);
                                break;
                        }
                    }
                    /* enable or disable Save Button depending on RdButton State and Cbx Text Length: */
                    SaveButton.Enabled = (Text.Length > 0) ? true : false;
                }
                else
                {
                    SaveButton.Enabled = false;
                }
            }
        }

        public void LockGuiControls()
        {
            this.Enabled                = false;
            RdButtonsGroupBox.Enabled   = false;
            SaveButton.Enabled          = false;              
            EditButton.Enabled          = true;
        }

        public void UnLockGuiControls(object sender, EventArgs e)
        {
            this.Enabled                = true;
            RdButtonsGroupBox.Enabled   = true;
            SaveButton.Enabled          = true;
            EditButton.Enabled          = false;
        }
    }
}
