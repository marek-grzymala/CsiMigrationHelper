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

        public TreeNode<DbObject> TreeNodeOwner;
        private TreeNode<DbObject> InstanceNode;

        public ComboBoxExt()
        {
            this.SelectedIndexChanged += new EventHandler(OnSelectedIndexChanged);
            this.Resize += new EventHandler(OnResize);                      
        }

        public void SetParentTreeNode(TreeNode<DbObject> tn)
        {
            TreeNodeOwner = tn != null ? tn : null;
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
                    string newCbxSelection = TreeNodeOwner.Data.Gui.GetCbxSelectionChangeCommited(ParamSelector.GetParamMetaByObjectLvl(TreeNodeOwner.Data.ObjectLevel, TreeNodeOwner.Data.ObjectBranch).DisplayMember);

                    if (newCbxSelection.Length > 0)
                    {
                        if (TreeNodeOwner.Data.ObjectLevel == (int)DbObjectLevel.Database)
                        {
                            InstanceNode.Data.Dbu.ChangeConnection(newCbxSelection);
                        }
                        TreeNodeOwner.SetTreeNodeText(TreeNodeOwner, newCbxSelection, true);
                        CmBxSelectHndlr.PopulateChildNodes(sender, TreeNodeOwner);
                    }
                }
            }
            catch (ExceptionEmptyResultSet ex)
            {
                if (ex.retry && TreeNodeOwner.Data.ObjectBranch != (int)DbObjectBranch.TrckTbl)
                {
                    this.DroppedDown = true;
                }
            }
            catch (ExceptionDataTypeMismatch ex)
            {
                if (ex.retry && TreeNodeOwner.Data.ObjectBranch != (int)DbObjectBranch.TrckTbl)
                {
                    this.DroppedDown = true;
                }
            }
        }
    }
}
