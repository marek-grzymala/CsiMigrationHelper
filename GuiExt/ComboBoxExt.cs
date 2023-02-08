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
        private TreeNode<DbObject> ParentTreeNode;
        private RadioButton RdButton;
        private Button SaveButton;
        private TreeNode<DbObject> instanceNode;


        public ComboBoxExt()
        {
            this.SelectedIndexChanged += new EventHandler(OnSelectedIndexChanged);
            this.TextUpdate += new EventHandler(OnTextUpdate);
            this.Resize += new EventHandler(OnResize);
        }

        public void SetParentTreeNode(TreeNode<DbObject> tn)
        {
            if (tn != null)
            {
                ParentTreeNode = tn;
            }
        }

        public void SetParentTreeNode(TreeNode<DbObject> tn, RadioButton rbtn, Button btn)
        {
            if (tn != null)
            {
                ParentTreeNode = tn;
                RdButton = rbtn;
                SaveButton = btn;
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
                ParentTreeNode.EmptySubtreeText(ParentTreeNode);
                if (ParentTreeNode.Enabled && this.SelectedIndex > 0) // populate all childNodes only if the user selects a valid ComboBox item, otherwise empty the Subtree
                {
                    if (ParentTreeNode.Data.ObjectLevel == (int)DbObjectLevel.Database)
                    {
                        instanceNode = ParentTreeNode.TraverseUpUntil(ParentTreeNode, (int)DbObjectLevel.Instance);
                    }
                    string newCbxSelection = ParentTreeNode.Data.Gui.GetCbxSelectionChangeCommited(ParamSelector.GetParamMetaByObjectLvl(ParentTreeNode.Data.ObjectLevel).DisplayMember);

                    if (newCbxSelection.Length > 0)
                    {
                        if (ParentTreeNode.Data.ObjectLevel == (int)DbObjectLevel.Database)
                        {
                            instanceNode.Data.Dbu.ChangeConnection(newCbxSelection);
                        }
                        ParentTreeNode.SetTreeNodeText(ParentTreeNode, newCbxSelection);
                        CmBxSelectHndlr.PopulateChildNodes(sender, ParentTreeNode);
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
            if (ParentTreeNode.Data.ObjectBranch == (int)DbObjectBranch.TrckTbl && RdButton.Checked)
            {
                /*enable Save Button: */
                SaveButton.Enabled = this.Text.Length > 0 ? true : false;
            }
        }
    }
}
