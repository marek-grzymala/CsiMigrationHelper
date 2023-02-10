using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsiMigrationHelper
{
    public class ComboBoxExt : ComboBox
    {
        private TreeNode<DbObject> TreeNodeOwner;
        private RadioButton RdButton;
        private Button SaveButton;
        private TreeNode<DbObject> InstanceNode;


        public ComboBoxExt()
        {
            //this.TextChanged += new EventHandler(OnTextUpdate);
            this.SelectedIndexChanged += new EventHandler(OnSelectedIndexChanged);
            this.Resize += new EventHandler(OnResize);                      
        }

        public void SetParentTreeNode(TreeNode<DbObject> tn)
        {
            if (tn != null)
            {
                TreeNodeOwner = tn;
            }
        }

        public void SetParentTreeNode(TreeNode<DbObject> tn, RadioButton rbtn, Button btn)
        {
            if (tn != null && rbtn != null && btn != null)
            {
                TreeNodeOwner = tn;
                RdButton = rbtn;
                SaveButton = btn;
                RdButton.CheckedChanged += new EventHandler(OnRdButtonCheckedChanged);
            }
        }

        protected virtual void OnResize(object sender, EventArgs e)  // this is to prevent "highlighting" of ComboBox selection when Form is resized
        {
            this.SelectionLength = 0;
        }

        public void RunOnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.OnSelectedIndexChanged(sender, e);            
        }
        
        protected virtual void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TreeNodeOwner.EmptySubtreeText(TreeNodeOwner);
                if (TreeNodeOwner.Enabled && this.SelectedIndex > 0) // populate all childNodes only if the user selects a valid ComboBox item, otherwise empty the Subtree
                {
                    if (TreeNodeOwner.Data.ObjectLevel == (int)DbObjectLevel.Database)
                    {
                        InstanceNode = TreeNodeOwner.TraverseUpUntil(TreeNodeOwner, (int)DbObjectLevel.Instance);
                    }
                    string newCbxSelection = TreeNodeOwner.Data.Gui.GetCbxSelectionChangeCommited(ParamSelector.GetParamMetaByObjectLvl(TreeNodeOwner.Data.ObjectLevel).DisplayMember);

                    if (newCbxSelection.Length > 0)
                    {
                        if (TreeNodeOwner.Data.ObjectLevel == (int)DbObjectLevel.Database)
                        {
                            InstanceNode.Data.Dbu.ChangeConnection(newCbxSelection);
                        }
                        TreeNodeOwner.SetTreeNodeText(TreeNodeOwner, newCbxSelection);
                        CmBxSelectHndlr.PopulateChildNodes(sender, TreeNodeOwner);
                    }
                }
            }
            catch (ExceptionEmptyResultSet ex)
            {
                if (ex.retry)
                {
                    this.DroppedDown = true;
                }
            }
            catch (ExceptionDataTypeMismatch ex)
            {
                if (ex.retry)
                {
                    this.DroppedDown = true;
                }
            }
        }

        protected virtual void OnTextUpdate(object sender, EventArgs e)
        {
            if (TreeNodeOwner.Data.ObjectBranch == (int)DbObjectBranch.TrckTbl && RdButton != null && SaveButton != null)
            {
                if (RdButton.Checked)
                {
                    /*enable or disable Save Button depending on Text Length: */
                    SaveButton.Enabled = this.Text.Length > 0 ? true : false;
                }
            }
        }

        protected virtual void OnRdButtonCheckedChanged(object sender, EventArgs e)
        {
            if (TreeNodeOwner.Data.ObjectBranch == (int)DbObjectBranch.TrckTbl && RdButton != null && SaveButton != null)
            {
               /*enable or disable Save Button depending on RdButton State: */ 
               if (RdButton.Checked && TreeNodeOwner != null)
               {
                    if (TreeNodeOwner.Parent.IsTextSet())
                    {
                        int objectLevel = TreeNodeOwner.Data.ObjectLevel;
                        switch (objectLevel)
                        {
                            case (int)DbObjectLevel.Table:
                                TreeNodeOwner.SetTreeNodeText(TreeNodeOwner, Options.projectsTableDefaultName);
                                break;

                            case (int)DbObjectLevel.Column:
                                TreeNodeOwner.SetTreeNodeText(TreeNodeOwner, Options.newProjectDefaultName);
                                break;
                        }
                    }
               }
               SaveButton.Enabled = (RdButton.Checked && this.Text.Length > 0) ? true : false;
            }
        }
    }
}
