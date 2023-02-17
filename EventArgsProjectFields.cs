using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsiMigrationHelper
{
    public class EventArgsProjectFields : EventArgs
    {
        public TreeNode<DbObject> TgtInstance;
        public TreeNode<DbObject> TgtDatabase;
        public TreeNode<DbObject> TgtArchiveTableSchema;
        public TreeNode<DbObject> TgtArchiveTableName;
        public TreeNode<DbObject> TgtArchiveTableCSIndex;

        public EventArgsProjectFields(
                                        TreeNode<DbObject> tgtInstance,
                                        TreeNode<DbObject> tgtDatabase,
                                        TreeNode<DbObject> tgtArchiveTableSchema,
                                        TreeNode<DbObject> tgtArchiveTableName,
                                        TreeNode<DbObject> tgtArchiveTableCSIndex
                                     )
        {


            TgtInstance =             tgtInstance;
            TgtDatabase =             tgtDatabase;
            TgtArchiveTableSchema =   tgtArchiveTableSchema;
            TgtArchiveTableName =     tgtArchiveTableName;
            TgtArchiveTableCSIndex =  tgtArchiveTableCSIndex;
        }

    }
}
