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
        private SrcTgtSelectionHandler SrcTgtHdlr;
        public TreeNode<DbObject> ParentTreeNode;

        public ComboBoxExt()
        {
            this.SelectedIndexChanged += new EventHandler(OnSelectedIndexChanged);
            this.Resize += new EventHandler(OnResize);
        }

        public void SetParentTreeNode(TreeNode<DbObject> tn, SrcTgtSelectionHandler srcTgtHdlr)
        {
            if (tn != null && srcTgtHdlr != null)
            {
                ParentTreeNode = tn;
                SrcTgtHdlr = srcTgtHdlr;
            }
        }

        protected virtual void OnResize(object sender, EventArgs e)  // this is to prevent "highlighting" of ComboBox selection when Form is resized
        {
            this.SelectionLength = 0;
        }

        protected virtual void OnSelectedIndexChanged(object sender, EventArgs e)
        {            
            try
            {
                SrcTgtHdlr.HandleGuiSelectionChange(this, ParentTreeNode);
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
    }
}
