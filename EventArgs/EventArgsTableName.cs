using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsiMigrationHelper
{
    public class EventArgsTableName : EventArgs
    {
        public TreeNode<DbObject> InstanceNode;
        public string SchemaName;
        public string TableName;

        public EventArgsTableName(TreeNode<DbObject> instanceNode, string schemaName, string tableName)
        {
            InstanceNode = instanceNode;
            SchemaName = schemaName;
            TableName = tableName;
        }
    }
}
