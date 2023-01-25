using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsiMigrationHelper
{
    public class EventArgsNodeCreated : EventArgs
    {
        //public TreeNode<DbObject> TreeNode; 
        public DbObject DbObject { get; set; }
        public int TreeNodeLevel { get; set; }

        //public EventArgsNodeCreated(TreeNode<DbObject> treeNode);
        public EventArgsNodeCreated(DbObject dbObject, int treeNodeLevel)
        {
            //TreeNode = treeNode;
            DbObject = dbObject;
            TreeNodeLevel = treeNodeLevel;
        }
    }
}
