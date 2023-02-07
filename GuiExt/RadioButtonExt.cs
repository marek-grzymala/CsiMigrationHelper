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
        private TreeNode<DbObject> ParentTreeNode;

        public RadioButtonExt()
        {
            this.CheckedChanged += new EventHandler(OnCheckedChanged);
        }

        public void SetParentTreeNode(TreeNode<DbObject> parentNode)
        {
            ParentTreeNode = parentNode != null ? parentNode : null;
        }

        protected virtual void OnCheckedChanged(object sender, EventArgs e)
        {
            if (ParentTreeNode.Data.ObjectLevel == (int)DbObjectLevel.Table)
            {
                ParentTreeNode.CloneableFromSrc = this.Checked ? true : false;
                ComboBoxExt cbxSch = ParentTreeNode.TraverseUpUntil(ParentTreeNode, (int)DbObjectLevel.Schema).Data.Gui.Cbxt;
                if (cbxSch.SelectedIndex > 0)
                {
                    try
                    {                        
                        cbxSch.RunOnSelectedIndexChanged(cbxSch, EventArgs.Empty);
                    }
                    catch (ExceptionEmptyResultSet ex)
                    {
                        if (ex.retry)
                        {                            
                            ComboBoxExt cbxDb = ParentTreeNode.TraverseUpUntil(ParentTreeNode, (int)DbObjectLevel.Database).Data.Gui.Cbxt;
                            cbxDb.RunOnSelectedIndexChanged(cbxDb, EventArgs.Empty);
                        }
                    }
                }
            }
        }
    }
}
