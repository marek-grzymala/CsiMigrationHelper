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
        private ComboBoxSelectionHandler CbxHdlr;
        private TreeNode<DbObject> ParentTreeNode;
        private RadioButton RdButton;
        private Button SaveButton;


        public ComboBoxExt()
        {
            this.SelectedIndexChanged += new EventHandler(OnSelectedIndexChanged);
            this.TextUpdate += new EventHandler(OnTextUpdate);
            this.Resize += new EventHandler(OnResize);
        }

        public void SetParentTreeNode(TreeNode<DbObject> tn, ComboBoxSelectionHandler cbxHdlr)
        {
            if (tn != null && cbxHdlr != null)
            {
                ParentTreeNode = tn;
                CbxHdlr = cbxHdlr;
            }
        }

        public void SetParentTreeNode(TreeNode<DbObject> tn, ComboBoxSelectionHandler cbxHdlr, RadioButton rbtn, Button btn)
        {
            if (tn != null && cbxHdlr != null)
            {
                ParentTreeNode = tn;
                CbxHdlr = cbxHdlr;
                RdButton = rbtn;
                SaveButton = btn;
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
                CbxHdlr.HandleGuiSelectionChange(this, ParentTreeNode);
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
            if (ParentTreeNode.Data.ObjectBranch == (int)DbObjectBranch.TrckTbl
                && this.Name.Equals("cbxt_TrackTbl_Table")
                && RdButton.Checked)
            {
                /*enable Save Button: */
                SaveButton.Enabled = this.Text.Length > 0 ? true : false;
            }
        }
    }
}
