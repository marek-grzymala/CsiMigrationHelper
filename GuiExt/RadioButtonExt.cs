using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsiMigrationHelper
{
    public class RadioButtonExt : RadioButton
    {
        private TreeNode<DbObject> TreeNodeOwner;        

        public RadioButtonExt()
        {
            this.CheckedChanged += new EventHandler(OnCheckedChanged);
        }

        public void SetParentTreeNode(TreeNode<DbObject> parentNode)
        {
            TreeNodeOwner = parentNode != null ? parentNode : null;
        }

        protected virtual void OnCheckedChanged(object sender, EventArgs e)
        {
            TreeNodeOwner.CloneableFromSrc = this.Checked ? true : false;
            int branch = TreeNodeOwner.Data.ObjectBranch;
            try
            {
            switch (branch)
                {
                case (int)DbObjectBranch.Tgt:                        
                     if (TreeNodeOwner.Parent.IsTextSet())
                     {
                             CmBxSelectHndlr.PopulateChildNodes(sender, TreeNodeOwner.Parent);
                     }
                     break;

                case (int)DbObjectBranch.TrckTbl:
                    if (TreeNodeOwner.CloneableFromSrc)
                    {
                        TreeNodeOwner.Data.Gui.Cbxtr.RunOnRdButtonCheckedChanged(sender, EventArgs.Empty);
                    }
                    else
                    {    
                        if (TreeNodeOwner.Parent.IsTextSet())
                        {
                            CmBxSelectHndlr.PopulateChildNodes(sender, TreeNodeOwner.Parent);
                        }
                    }
                    break;
                }
            }
            catch (ExceptionEmptyResultSet ex)
            {
                if (ex.retry)
                {
                    ComboBox cb = TreeNodeOwner.Parent.Data.Gui.GetGuiObject() as ComboBox;
                    if (cb != null)
                    {
                        cb.DroppedDown = true;
                    }
                }
            }
        }
    }
}
