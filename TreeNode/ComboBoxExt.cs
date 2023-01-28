using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsiMigrationHelper
{
    //public delegate void HandlerSelectedIndexChanged(object sender, EventArgs e);
    public class ComboBoxExt : ComboBox
    {
        //public event HandlerSelectedIndexChanged eventSelectedIndexChanged;
        public SrcTgtSelectionHandler SrcTgtHdlr { get; set; }
        public TreeNode<DbObject> Tn { get; set; }

        private GuiElem ParentObject;

        public ComboBoxExt()
        {
            //eventSelectedIndexChanged += new HandlerSelectedIndexChanged(OnSelectedIndexChanged);
            this.SelectedIndexChanged += new EventHandler(OnSelectedIndexChanged);
        }

        public GuiElem GetParentObject()
        {
            return ParentObject;
        }

        public void SetParentObject(GuiElem parentObject, SrcTgtSelectionHandler srcTgtHdlr)
        {
            if (parentObject != null && srcTgtHdlr != null)
            {
                Console.WriteLine("Setting ParentObject of ComboBoxExt: "+this.Name);
                ParentObject = parentObject;
                Tn = parentObject.GetParentObject().GetParentObject();
                SrcTgtHdlr = srcTgtHdlr;
            }
        }

        public void OnSelectedIndexChanged(object sender, EventArgs e)
        {            
            try
            {
                SrcTgtHdlr.HandleGuiSelectionChange(this, Tn);
            }
            catch (ExceptionEmptyResultSet ex)
            {
                if (ex.retry)
                {
                    SrcTgtHdlr.HandleGuiSelectionChange(Tn.Parent.Data.Gui, Tn.Parent);
                }
            }
        }
    }
}
