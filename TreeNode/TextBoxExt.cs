using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsiMigrationHelper
{
    public class TextBoxExt : TextBox
    {
        private ComboBoxSelectionHandler SrcTgtHdlr;
        private TreeNode<DbObject> ParentTreeNode;
        private ComboBoxExt Cbx_tbList_Src;
        private TreeNode<DbObject> SrcTable;
        private ComboBoxExt Cbx_tbList_Tgt;
        private TreeNode<DbObject> TgtTable;

        public TextBoxExt()
        {
            this.TextChanged += new EventHandler(OnTextChanged);
        }

        public void SetParentTreeNode   (
                                          TreeNode<DbObject> parentNode
                                        , ComboBoxSelectionHandler srcTgtHdlr
                                        , ComboBoxExt cbx_tbList_Src
                                        , TreeNode<DbObject> srcTable
                                        , ComboBoxExt cbx_tbList_Tgt
                                        , TreeNode<DbObject> tgtTable
                                        )
        {
            ParentTreeNode = parentNode     != null ? parentNode     : null;
            SrcTgtHdlr     = srcTgtHdlr     != null ? srcTgtHdlr     : null;
            Cbx_tbList_Src = cbx_tbList_Src != null ? cbx_tbList_Src : null;
            SrcTable       = srcTable       != null ? srcTable       : null;
            Cbx_tbList_Tgt = cbx_tbList_Tgt != null ? cbx_tbList_Tgt : null;
            TgtTable       = tgtTable       != null ? tgtTable       : null;
        }

        protected virtual void OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                SrcTgtHdlr.HandleGuiSelectionChange(sender, ParentTreeNode);
            }
            catch (ExceptionEmptyResultSet ex)
            {
                if (ex.retry)
                {
                    switch (ParentTreeNode.Data.ObjectBranch)
                    {
                        case (int)DbObjectBranch.Src:
                            
                            if (Cbx_tbList_Src != null && SrcTable != null)
                            {
                                SrcTgtHdlr.HandleGuiSelectionChange(Cbx_tbList_Src, SrcTable);
                            }
                            break;

                        case (int)DbObjectBranch.Tgt:
                            
                            if (ParentTreeNode.CloneableFromSrc)
                            {
                                if (Cbx_tbList_Src != null && SrcTable != null)
                                {
                                    SrcTgtHdlr.HandleGuiSelectionChange(Cbx_tbList_Src, SrcTable);
                                }
                            }
                            else
                            {
                                if (Cbx_tbList_Tgt != null && TgtTable != null)
                                {
                                    SrcTgtHdlr.HandleGuiSelectionChange(Cbx_tbList_Tgt, TgtTable);
                                }
                            }
                            break;
                    }
                }
            }
            catch (ExceptionDataTypeMismatch ex)
            {
                if (ex.retry)
                {
                    switch (ParentTreeNode.Data.ObjectBranch)
                    {
                        case (int)DbObjectBranch.Src:
                            
                            if (Cbx_tbList_Src != null && SrcTable != null)
                            {
                                SrcTgtHdlr.HandleGuiSelectionChange(Cbx_tbList_Src, SrcTable);
                            }
                            break;

                        case (int)DbObjectBranch.Tgt:
                            
                            if (ParentTreeNode.CloneableFromSrc)
                            {
                                if (Cbx_tbList_Tgt != null && TgtTable != null)
                                {
                                    SrcTgtHdlr.HandleGuiSelectionChange(Cbx_tbList_Tgt, TgtTable);
                                }
                            }
                            else
                            {
                                if (Cbx_tbList_Src != null && SrcTable != null)
                                {
                                    SrcTgtHdlr.HandleGuiSelectionChange(Cbx_tbList_Src, SrcTable);
                                }
                            }
                            break;
                    }
                }
            }
        }
    }
}
