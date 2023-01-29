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
        private TreeNode<DbObject> Tn;

        public ComboBoxExt()
        {
            this.SelectedIndexChanged += new EventHandler(OnSelectedIndexChanged);
            this.Resize += new EventHandler(OnResize);
        }

        public void SetMembers(TreeNode<DbObject> tn, SrcTgtSelectionHandler srcTgtHdlr)
        {
            if (tn != null && srcTgtHdlr != null)
            {
                Tn = tn;
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
                SrcTgtHdlr.HandleGuiSelectionChange(this, Tn);
            }
            catch (ExceptionEmptyResultSet ex)
            {
                if (ex.retry)
                {
                    //SrcTgtHdlr.HandleGuiSelectionChange(Tn.Parent.Data.Gui.GetGuiObject(), Tn.Parent);
                    this.DroppedDown = true;
                }
            }
            catch (ExceptionDataTypeMismatch ex)
            {
                if (ex.retry)
                {
                    //SrcTgtHdlr.HandleGuiSelectionChange(Tn.Parent.Data.Gui.GetGuiObject(), Tn.Parent);
                    this.DroppedDown = true;
                }
            }
        }
    }
}
