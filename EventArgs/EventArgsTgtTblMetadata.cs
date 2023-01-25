using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsiMigrationHelper
{
    public class EventArgsTgtTblMetadata : EventArgs
    {
        public TreeNode<DbObject> SrcInstance;
        public TreeNode<DbObject> SrcDatabase;
        public TreeNode<DbObject> SrcColumn;
        public TreeNode<DbObject> SrcTable;
        public TreeNode<DbObject> TgtInstance;
        public TreeNode<DbObject> TgtDatabase;
        public TreeNode<DbObject> TgtTable;
        public TreeNode<DbObject> TgtColumn;
        public TreeNode<DbObject> TgtPartitionScheme;
        public TreeNode<DbObject> TgtIndex;
        public TextBox TbxTgtTableName;
        public DataGridView GridColList;
        public DataGridView GridConstraintList;
        public Button CheckSyntaxButton;
        public Button ExecButton;

        public EventArgsTgtTblMetadata(TreeNode<DbObject> root, TreeNode<DbObject> tgtTable, TextBox tbxTgtTableName, DataGridView gridColList, DataGridView gridConstraintList, Button checkSyntaxButton, Button execButton)
        {
            SrcInstance = root.FindTreeNode(node => node.Data != null && node.Data.ObjectName.Equals("srcInstance"));
            SrcDatabase = root.FindTreeNode(node => node.Data != null && node.Data.ObjectName.Equals("srcDatabase"));
            SrcColumn = root.FindTreeNode(node => node.Data != null && node.Data.ObjectName.Equals("srcColumn"));
            SrcTable = root.FindTreeNode(node => node.Data != null && node.Data.ObjectName.Equals("srcTable"));
            TgtInstance = root.FindTreeNode(node => node.Data != null && node.Data.ObjectName.Equals("tgtInstance"));
            TgtDatabase = root.FindTreeNode(node => node.Data != null && node.Data.ObjectName.Equals("tgtDatabase"));
            TgtTable = root.FindTreeNode(node => node.Data != null && node.Data.ObjectName.Equals(tgtTable.Data.ObjectName));
            TgtColumn = root.FindTreeNode(node => node.Data != null && node.Data.ObjectName.Equals("tgtColumn"));
            TgtPartitionScheme = root.FindTreeNode(node => node.Data != null && node.Data.ObjectName.Equals("tgtPartitionScheme"));
            TgtIndex = root.FindTreeNode(node => node.Data != null && node.Data.ObjectName.Equals("tgtIndex"));
            TbxTgtTableName = tbxTgtTableName;
            GridColList = gridColList;
            GridConstraintList = gridConstraintList;
            CheckSyntaxButton = checkSyntaxButton;
            ExecButton = execButton;
        }
    }
}
