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
        public Button SaveButton;
        public Button RenameButton;

        public ComboBoxExtTrackTbl()
        {

        }

        public void SetParentTreeNode(TreeNode<DbObject> tn, RadioButton rbtnNew, RadioButton rbtnExisting, Button saveButton, Button renameButton)
        {
            TreeNodeOwner       = tn            != null ? tn : null;
            RdButtonCreateNew   = rbtnNew       != null ? rbtnNew: null;
            RdButtonUseExisting = rbtnExisting  != null ? rbtnExisting : null;
            SaveButton          = saveButton    != null ? saveButton : null;
            RenameButton        = renameButton  != null ? renameButton : null;
            if (RdButtonCreateNew != null)
            {
                RdButtonCreateNew.CheckedChanged += new EventHandler(OnRdButtonCheckedChanged);
            }
            this.TextChanged += new EventHandler(OnTextChanged);
        }
        protected virtual void OnTextChanged(object sender, EventArgs e)
        {
            if (this.Text.Length > 0 && this.RdButtonCreateNew.Checked)
            {
                this.TreeNodeOwner.SetTreeNodeTextNoSubtreeClearing(TreeNodeOwner, Text, false);
                /*enable or disable Save Button depending on Text Length: */
                this.SaveButton.Enabled = this.Text.Length > 0 ? true : false;
            }
            else
            {
                this.SaveButton.Enabled = false;
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
                                TreeNodeOwner.SetTreeNodeText(TreeNodeOwner, Options.projectsTableDefaultName, false);
                                break;

                            case (int)DbObjectLevel.Column:                                
                                TreeNodeOwner.SetTreeNodeText(TreeNodeOwner, Options.newProjectDefaultName, false);
                                break;
                        }
                    }
                }
                /*enable or disable Save Button depending on RdButton State and Cbx Text Length: */
                SaveButton.Enabled = (RdButtonCreateNew.Checked && this.Text.Length > 0) ? true : false;
            }
        }
    }
}
