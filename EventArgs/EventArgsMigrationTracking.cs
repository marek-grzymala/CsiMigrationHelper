using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsiMigrationHelper
{
    public class EventArgsMigrationTracking : EventArgs
    {
        public TreeNode<DbObject> InstanceNode;
        public TreeNode<DbObject> TreeNodeOwner;
        public string SchemaName;
        public string TableName;

        public EventArgsMigrationTracking(TreeNode<DbObject> instanceNode, TreeNode<DbObject> treeNodeOwner, string schemaName, string tableName)
        {
            InstanceNode = instanceNode;
            TreeNodeOwner = treeNodeOwner;
            SchemaName = schemaName;
            TableName = tableName;
        }
    }
}