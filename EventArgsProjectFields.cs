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
        //private TreeNode<DbObject>[] AllFields;

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

            //AllFields[0] = TgtInstance;
            //AllFields[1] = TgtDatabase;
            //AllFields[2] = TgtArchiveTableSchema;
            //AllFields[3] = TgtArchiveTableName;
            //AllFields[4] = TgtArchiveTableCSIndex;
        }

        //public bool AreAllFiledsSet()
        //{
        //    bool result = true;
        //    for (int i = 0; i <= AllFields.Length; i++)
        //    {
        //        if (!AllFields[i].IsTextSet())
        //        {
        //            result = false;
        //        }
        //    }            
        //    return result;
        //}
    }
}
