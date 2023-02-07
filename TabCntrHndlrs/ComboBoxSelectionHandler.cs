using System;
using System.Windows.Forms;

namespace CsiMigrationHelper
{
    public class ComboBoxSelectionHandler
    {
        private TreeNode<DbObject> instanceNode;
        public void HandleGuiSelectionChange(object sender, TreeNode<DbObject> senderNode)
        {
            senderNode.EmptySubtreeText(senderNode);
            if (senderNode.Enabled)
            {
                if (sender is ComboBox)
                {
                    ComboBox cb = (ComboBox)sender;
                    if (cb.SelectedIndex > 0) // populate all childNodes only if the user selects a valid ComboBox item, otherwise empty the Subtree
                    {
                        if (senderNode.Data.ObjectLevel == (int)DbObjectLevel.Database)
                        {
                            instanceNode = senderNode.TraverseUpUntil(senderNode, (int)DbObjectLevel.Instance);
                        }
                        string newCbxSelection = senderNode.Data.Gui.GetCbxSelectionChangeCommited(ParamSelector.GetParamMetaByObjectLvl(senderNode.Data.ObjectLevel).DisplayMember);

                        if (newCbxSelection.Length > 0)
                        {
                            if (senderNode.Data.ObjectLevel == (int)DbObjectLevel.Database)
                            {
                                instanceNode.Data.Dbu.ChangeConnection(newCbxSelection);
                            }
                            senderNode.SetTreeNodeText(senderNode, newCbxSelection);
                            PopulateChildNodes(sender, senderNode, newCbxSelection);
                        }
                    }
                }
                else if (sender is TextBox)
                {
                    TextBox tb = (TextBox)sender;
                    if (tb.Text.Length > 0)
                    {
                        senderNode.SetTreeNodeText(senderNode, tb.Text);
                        PopulateChildNodes(sender, senderNode, tb.Text);
                    }
                }
                else if (sender is CheckBox)
                {
                    CheckBox cb = (CheckBox)sender;
                    if (!cb.Checked)
                    {                        
                        senderNode.Enabled = false;                        
                    }
                }
            }
            else
            {
                if (sender is CheckBox)
                {
                    CheckBox cb = (CheckBox)sender;
                    if (cb.Checked)
                    {
                        senderNode.Enabled = true;
                        if (senderNode.Enabled && senderNode.Data.Gui.IsTextSet())
                        {
                            PopulateChildNodes(sender, senderNode, senderNode.Data.ObjectText);
                        }
                    }
                }
            }
        }

        public void PopulateChildNodes(object sender, TreeNode<DbObject> parentNode, string newTxtSelection)
        {
            foreach (TreeNode<DbObject> childNode in parentNode.Children)
            {
                if (childNode.Enabled)
                {
                    if (   !childNode.CloneableFromSrc 
                        && !childNode.IsDummyNode 
                        &&  childNode.TreeNodeLevel == parentNode.TreeNodeLevel + 1) //normally we populate only direct childNodes of the currentNode
                    {
                        DbObject childNodeDbo = (DbObject)Convert.ChangeType(childNode.Data, typeof(DbObject));
                        TreeNode<DbObject> instanceNode = parentNode.TraverseUpUntil(parentNode, (int)DbObjectLevel.Instance);

                        DataSetForGui dsfg = new DataSetForGui();
                        try
                        {
                            dsfg = instanceNode.Data.Dbu.GetDataSetForGui(instanceNode, childNode, null);                            
                        }
                        catch (ExceptionEmptyResultSet ex)
                        {
                            throw; // needed to re-populate combo-box after user retry decision (in the exception )
                        }
                        catch (ExceptionDataTypeMismatch ex)
                        {
                            throw; // needed to re-populate combo-box after user retry decision (in the exception )
                        }

                        if (childNodeDbo.Gui != null)
                        {
                            if (childNodeDbo.Gui.GetGuiType() == typeof(ComboBox) || childNodeDbo.Gui.GetGuiType() == typeof(ComboBoxExt))
                            {
                                childNodeDbo.Gui.PopulateGuiElem(childNodeDbo.Gui, dsfg);
                            }
                            else if (childNodeDbo.Gui.GetGuiType() == typeof(TextBox) || (childNodeDbo.Gui.GetGuiType() == typeof(TextBoxExt)))
                            {
                                if (dsfg.Ds.Tables[0].Rows.Count > 0)
                                {
                                    childNode.SetTreeNodeText(childNode, dsfg.Ds.Tables[0].Rows[1][dsfg.ParamSelect.ParamMetaData.DisplayMember].ToString());                                   
                                }
                            }
                        }
                    }
                    /*
                    dummy populate; normally we populate only direct childNodes of the currentNode
                    unless the currentNode is a [Column] lvl 5 in Branch Src:

                    Root             = 0,
                    Instance         = 1,
                    Database         = 2,
                    Schema           = 3,
                    Table            = 4,
                    Column           = 5,
                    DataType         = 6,
                    PartitionScheme  = 7,
                    Index            = 8,

                    if so: in addition to populating its direct child: [DataType] lvl 6 in regular way (above),
                    we also (below) recursively populate its "dummy" Inactive childNode: [PartitionScheme] lvl 7 
                    in order to be able to finally populate its Grandchild: [Index] lvl 8
                    */
                    else if (childNode.IsDummyNode == true)
                    {
                        PopulateChildNodes(sender, childNode, null);
                    }

                    else if (     childNode.CloneableFromSrc
                            &&    childNode.HasCousins
                            && (( childNode.TreeNodeLevel == (int)DbObjectLevel.Table)
                               ||(childNode.TreeNodeLevel == (int)DbObjectLevel.Column)
                               ||(childNode.TreeNodeLevel == (int)DbObjectLevel.DataType)
                               ||(childNode.TreeNodeLevel == (int)DbObjectLevel.Index)
                               ))
                    {
                        if (childNode.TraverseUpUntil(childNode, (int)DbObjectLevel.Schema).Enabled
                            && childNode.TraverseUpUntil(childNode, (int)DbObjectLevel.Schema).Data.Gui.IsTextSet())
                        {
                            foreach (TreeNode<DbObject> cousin in childNode.Cousins)
                            {
                                if (cousin.Data.ObjectText.Length > 0) // && !childNode.Data.ObjectText.Equals(cousin.Data.ObjectText))
                                {
                                    /*
                                    Console.WriteLine(string.Concat("CLONING FROM Src Branch Cousin: [", cousin.Data.ObjectName,
                                                                    "] detected Text: [", cousin.Data.ObjectText,
                                                                    "] onto: [", childNode.Data.ObjectName,
                                                                    "] with TreeNodeLevel: [", childNode.TreeNodeLevel,
                                                                    "] whith current Text: [", childNode.Data.ObjectText, "]"));
                                    */

                                    string indexNameTgt = string.Empty;
                                    string tableNameSuffix = string.Empty;
                                    
                                    switch (childNode.Data.ObjectLevel)
                                    {
                                        case (int)DbObjectLevel.Table:
                                            tableNameSuffix = Options.GetTableSuffixPerNode(childNode);
                                            // clone cousin's table name from Src into Tgt appending the suffix:
                                            childNode.SetTreeNodeText(childNode, string.Concat(cousin.Data.ObjectText, tableNameSuffix));
                                            break;

                                        case (int)DbObjectLevel.Index:
                                            // clone cousin's table name from Src with CSI Prefix:
                                            childNode.SetTreeNodeText(childNode, string.Concat(Options.prefixCSI, cousin.Data.ObjectText));
                                            break;

                                        default:
                                            // clone cousin's object name from Src into Tgt without any change:
                                            childNode.SetTreeNodeText(childNode, cousin.Data.ObjectText);
                                            break;
                                    }
                                                                       
                                    try
                                    {
                                        PopulateChildNodes(sender, childNode, cousin.Data.ObjectText);
                                    }
                                    catch(ExceptionEmptyResultSet ex)
                                    {
                                        throw;
                                    }
                                }
                            }
                        }
                    }

                    else if (childNode.CloneableFromSrc && childNode.TreeNodeLevel == (int)DbObjectLevel.PartitionScheme)
                    {
                        if (sender is TextBox) // needed to avoid double error message when no PS found:
                                               // (without this condition 1st error gets triggered by Cbx TgtColumn 2nd by Tbx TgtDataType)
                        {
                            /*
                            TextBox tb = (TextBox)sender;
                            Console.WriteLine(string.Concat("RUNNING PopulateGuiElem() of TARGET : [", childNode.Data.ObjectName,
                                                            "] with TreeNodeLevel: [", childNode.TreeNodeLevel,
                                                            "] whith current Text: [", childNode.Data.ObjectText,
                                                            "] SENDER TextBox: [", tb.Name,
                                                            "] whith current Text: [", tb.Text, "]"));
                            */
                            DbObject childNodeDbo = (DbObject)Convert.ChangeType(childNode.Data, typeof(DbObject));
                            TreeNode<DbObject> instanceNode = parentNode.TraverseUpUntil(parentNode, (int)DbObjectLevel.Instance);

                            DataSetForGui dsfg = new DataSetForGui();
                            try
                            {
                                dsfg = instanceNode.Data.Dbu.GetDataSetForGui(instanceNode, childNode, null);
                            }
                            catch (ExceptionEmptyResultSet ex)
                            {
                                throw;
                            }
                            childNodeDbo.Gui.PopulateGuiElem(childNodeDbo.Gui, dsfg);
                        }
                    }
                }
            }
        } // end of PopulateChildNodes()
    }
}
