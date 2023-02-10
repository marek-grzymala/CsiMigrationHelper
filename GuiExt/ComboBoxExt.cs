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
        private TreeNode<DbObject> TreeNodeOwnerParent;
        public RadioButton RdButtonCreateNew { get; set; }
        private RadioButton RdButtonUseExisting;
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
            TreeNodeOwner = tn != null ? tn : null;
        }

        public void SetParentTreeNode(TreeNode<DbObject> tn, RadioButton rbtnNew, RadioButton rbtnExisting, Button btn)
        {
            if (tn != null && rbtnNew != null && btn != null)
            {
                TreeNodeOwner = tn;
                RdButtonCreateNew = rbtnNew;
                RdButtonUseExisting = rbtnExisting;
                SaveButton = btn;
                RdButtonCreateNew.CheckedChanged += new EventHandler(OnRdButtonCheckedChanged);
            }
            if (TreeNodeOwner != null)
            {
                if (TreeNodeOwner.Data.ObjectLevel == (int)DbObjectLevel.Column)
                {
                    TreeNodeOwnerParent = TreeNodeOwner.Parent;
                    if (TreeNodeOwnerParent != null)
                    {
                        TreeNodeOwnerParent.Data.Gui.Cbxt.RdButtonCreateNew.CheckedChanged += new EventHandler(OnTreeNodeOwnerParentRdButtonCheckedChanged);
                    }
                }
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
        public void RunOnRdButtonCheckedChanged(object sender, EventArgs e)
        {
            this.OnRdButtonCheckedChanged(sender, e);
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
                        if (TreeNodeOwner.Data.ObjectLevel == (int)DbObjectLevel.Table && TreeNodeOwner.Data.ObjectBranch == (int)DbObjectBranch.TrckTbl)
                        {
                            //Check if this is a valid ProjectsTable!
                            Console.WriteLine(string.Concat("Checking if ", newCbxSelection, " is a valid ProjectsTable"));
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
            if (TreeNodeOwner.Data.ObjectBranch == (int)DbObjectBranch.TrckTbl && RdButtonCreateNew != null && SaveButton != null)
            {
                if (RdButtonCreateNew.Checked)
                {
                    /*enable or disable Save Button depending on Text Length: */
                    SaveButton.Enabled = this.Text.Length > 0 ? true : false;
                }
            }
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
                                TreeNodeOwner.SetTreeNodeText(TreeNodeOwner, Options.projectsTableDefaultName);
                                break;
                
                            case (int)DbObjectLevel.Column:
                                TreeNodeOwner.SetTreeNodeText(TreeNodeOwner, Options.newProjectDefaultName);
                                break;
                        }
                    }
                }
                /*enable or disable Save Button depending on RdButton State and Cbx Text Length: */ 
                SaveButton.Enabled = (RdButtonCreateNew.Checked && this.Text.Length > 0) ? true : false;
            }
        }

        protected virtual void OnTreeNodeOwnerParentRdButtonCheckedChanged(object sender, EventArgs e)
        {
            if (TreeNodeOwnerParent.Data.Gui.Cbxt.RdButtonCreateNew.Checked)
            {
                RdButtonCreateNew.Checked = true;
                RdButtonUseExisting.Enabled = false;
            }
            else
            {
                RdButtonUseExisting.Enabled = true;
            }
        }
    }
}
