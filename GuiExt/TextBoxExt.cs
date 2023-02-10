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
        private TreeNode<DbObject> TreeNodeOwner;
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
                                        , ComboBoxExt cbx_tbList_Src
                                        , TreeNode<DbObject> srcTable
                                        , ComboBoxExt cbx_tbList_Tgt
                                        , TreeNode<DbObject> tgtTable
                                        )
        {
            TreeNodeOwner = parentNode     != null ? parentNode     : null;
            Cbx_tbList_Src = cbx_tbList_Src != null ? cbx_tbList_Src : null;
            SrcTable       = srcTable       != null ? srcTable       : null;
            Cbx_tbList_Tgt = cbx_tbList_Tgt != null ? cbx_tbList_Tgt : null;
            TgtTable       = tgtTable       != null ? tgtTable       : null;
        }

        protected virtual void OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                //SrcTgtHdlr.HandleGuiSelectionChange(sender, ParentTreeNode);
                if (this.Text.Length > 0)
                {
                    TreeNodeOwner.SetTreeNodeText(TreeNodeOwner, this.Text);
                    CmBxSelectHndlr.PopulateChildNodes(sender, TreeNodeOwner);
                }
            }
            catch (ExceptionEmptyResultSet ex)
            {
                if (ex.retry)
                {
                    switch (TreeNodeOwner.Data.ObjectBranch)
                    {
                        case (int)DbObjectBranch.Src:
                            
                            if (Cbx_tbList_Src != null && SrcTable != null)
                            {
                                //CbxHdlr.HandleGuiSelectionChange(Cbx_tbList_Src, SrcTable);
                                Cbx_tbList_Src.RunOnSelectedIndexChanged(Cbx_tbList_Src, EventArgs.Empty);
                            }
                            break;

                        case (int)DbObjectBranch.Tgt:
                            
                            if (TreeNodeOwner.CloneableFromSrc)
                            {
                                if (Cbx_tbList_Src != null && SrcTable != null)
                                {
                                    //CbxHdlr.HandleGuiSelectionChange(Cbx_tbList_Src, SrcTable);
                                    Cbx_tbList_Src.RunOnSelectedIndexChanged(Cbx_tbList_Src, EventArgs.Empty);
                                }
                            }
                            else
                            {
                                if (Cbx_tbList_Tgt != null && TgtTable != null)
                                {
                                    //CbxHdlr.HandleGuiSelectionChange(Cbx_tbList_Tgt, TgtTable);
                                    Cbx_tbList_Tgt.RunOnSelectedIndexChanged(Cbx_tbList_Tgt, EventArgs.Empty);
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
                    switch (TreeNodeOwner.Data.ObjectBranch)
                    {
                        case (int)DbObjectBranch.Src:
                            
                            if (Cbx_tbList_Src != null && SrcTable != null)
                            {
                                //CbxHdlr.HandleGuiSelectionChange(Cbx_tbList_Src, SrcTable);
                                Cbx_tbList_Src.RunOnSelectedIndexChanged(Cbx_tbList_Src, EventArgs.Empty);
                            }
                            break;

                        case (int)DbObjectBranch.Tgt:
                            
                            if (TreeNodeOwner.CloneableFromSrc)
                            {
                                if (Cbx_tbList_Tgt != null && TgtTable != null)
                                {
                                    //CbxHdlr.HandleGuiSelectionChange(Cbx_tbList_Tgt, TgtTable);
                                    Cbx_tbList_Tgt.RunOnSelectedIndexChanged(Cbx_tbList_Tgt, EventArgs.Empty);
                                }
                            }
                            else
                            {
                                if (Cbx_tbList_Src != null && SrcTable != null)
                                {
                                    //CbxHdlr.HandleGuiSelectionChange(Cbx_tbList_Src, SrcTable);
                                    Cbx_tbList_Src.RunOnSelectedIndexChanged(Cbx_tbList_Src, EventArgs.Empty);
                                }
                            }
                            break;
                    }
                }
            }
        }
    }
}
