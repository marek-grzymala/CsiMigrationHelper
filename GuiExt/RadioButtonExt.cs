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
            if (TreeNodeOwner.Data.ObjectLevel == (int)DbObjectLevel.Table)
            {
                TreeNodeOwner.CloneableFromSrc = this.Checked ? true : false;
                ComboBoxExt cbxSch = TreeNodeOwner.TraverseUpUntil(TreeNodeOwner, (int)DbObjectLevel.Schema).Data.Gui.Cbxt;
                if (cbxSch.SelectedIndex > 0 && !TreeNodeOwner.CloneableFromSrc)
                {
                    try
                    {                        
                        cbxSch.RunOnSelectedIndexChanged(cbxSch, EventArgs.Empty);
                    }
                    catch (ExceptionEmptyResultSet ex)
                    {
                        if (ex.retry)
                        {                            
                            ComboBoxExt cbxDb = TreeNodeOwner.TraverseUpUntil(TreeNodeOwner, (int)DbObjectLevel.Database).Data.Gui.Cbxt;
                            cbxDb.RunOnSelectedIndexChanged(cbxDb, EventArgs.Empty);
                        }
                    }
                }
            }

            if (TreeNodeOwner.Data.ObjectLevel == (int)DbObjectLevel.Column)
            {
                TreeNodeOwner.CloneableFromSrc = this.Checked ? true : false;
                ComboBoxExt cbxTbl = TreeNodeOwner.TraverseUpUntil(TreeNodeOwner, (int)DbObjectLevel.Table).Data.Gui.Cbxt;
                if (cbxTbl.SelectedIndex > 0 && !TreeNodeOwner.CloneableFromSrc)
                {
                    try
                    {
                        cbxTbl.RunOnSelectedIndexChanged(cbxTbl, EventArgs.Empty);
                    }
                    catch (ExceptionEmptyResultSet ex)
                    {
                        if (ex.retry)
                        {
                            ComboBoxExt cbxSch = TreeNodeOwner.TraverseUpUntil(TreeNodeOwner, (int)DbObjectLevel.Schema).Data.Gui.Cbxt;
                            cbxSch.RunOnSelectedIndexChanged(cbxSch, EventArgs.Empty);
                        }
                    }
                }
            }
        }
    }
}
