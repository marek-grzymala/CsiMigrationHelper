using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsiMigrationHelper
{
    public class EventArgsProjectFields : EventArgs
    {
        public TreeNode<DbObject> SrcInstance;
        public TreeNode<DbObject> SrcDatabase;
        public TreeNode<DbObject> SrcTableSchema;
        public TreeNode<DbObject> SrcTableName;
        public TreeNode<DbObject> SrcColumn;
        public TreeNode<DbObject> SrcTableIndex;
        public string             SrcSynonym;

        public TreeNode<DbObject> TgtInstance;
        public TreeNode<DbObject> TgtDatabase;
        public TreeNode<DbObject> TgtArchiveTableSchema;
        public TreeNode<DbObject> TgtArchiveTableName;
        public TreeNode<DbObject> TgtColumn;
        public TreeNode<DbObject> TgtArchiveTableCSIndex;
        public string             TgtSynonym;

        public EventArgsProjectFields(

                                        TreeNode<DbObject> srcInstance,
                                        TreeNode<DbObject> srcDatabase,
                                        TreeNode<DbObject> srcArchiveTableSchema,
                                        TreeNode<DbObject> srcArchiveTableName,
                                        TreeNode<DbObject> srcColumn,
                                        TreeNode<DbObject> srcArchiveTableIndex,
                                        TreeNode<DbObject> tgtInstance,
                                        TreeNode<DbObject> tgtDatabase,
                                        TreeNode<DbObject> tgtArchiveTableSchema,
                                        TreeNode<DbObject> tgtArchiveTableName,
                                        TreeNode<DbObject> tgtColumn,
                                        TreeNode<DbObject> tgtArchiveTableCSIndex
                                     )
        {
            SrcInstance      = srcInstance;
            SrcDatabase      = srcDatabase;
            SrcTableSchema   = srcArchiveTableSchema;
            SrcTableName     = srcArchiveTableName;
            SrcColumn        = srcColumn;
            SrcTableIndex    = srcArchiveTableIndex;

            TgtInstance             = tgtInstance;
            TgtDatabase             = tgtDatabase;
            TgtArchiveTableSchema   = tgtArchiveTableSchema;
            TgtArchiveTableName     = tgtArchiveTableName;
            TgtColumn               = tgtColumn;
            TgtArchiveTableCSIndex  = tgtArchiveTableCSIndex;
        }
    }
}
