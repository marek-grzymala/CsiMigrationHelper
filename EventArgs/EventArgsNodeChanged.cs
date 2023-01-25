using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsiMigrationHelper
{
    public class EventArgsNodeChanged : EventArgs
    {
        public TreeNode<DbObject> TreeNode;
        public bool NewEnabledState { get; set; }

        //public EventArgsNodeCreated(TreeNode<DbObject> treeNode);
        public EventArgsNodeChanged(TreeNode<DbObject> treeNode, bool newEnabledState)
        {
            TreeNode = treeNode;
            NewEnabledState = newEnabledState;            
        }
    }
}
