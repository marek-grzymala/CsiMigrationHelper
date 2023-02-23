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
        public TreeNode<DbObject> SrcSchema;
        public TreeNode<DbObject> SrcTable;
        public TreeNode<DbObject> SrcColumn;
        public TreeNode<DbObject> SrcDataType;
        public TreeNode<DbObject> SrcIndex;
        public string             SrcSynonym;

        public TreeNode<DbObject> TgtInstance;
        public TreeNode<DbObject> TgtDatabase;
        public TreeNode<DbObject> TgtCurrentSchema;
        public TreeNode<DbObject> TgtCurrentTable;
        public TreeNode<DbObject> TgtStagingSchema;
        public TreeNode<DbObject> TgtStagingTable;
        public TreeNode<DbObject> TgtArchiveSchema;
        public TreeNode<DbObject> TgtArchiveTable;
        public TreeNode<DbObject> TgtColumn;
        public TreeNode<DbObject> TgtDataType;
        public TreeNode<DbObject> TgtPartitionScheme;
        public TreeNode<DbObject> TgtIndex;
        public string             TgtSynonym;
        public string             TrackSynonymProjects;
        public string             TrackSynonymMigrationTrck;


        public EventArgsProjectFields(

                                        TreeNode<DbObject> srcInstance,
                                        TreeNode<DbObject> srcDatabase,
                                        TreeNode<DbObject> srcSchema,
                                        TreeNode<DbObject> srcTable,
                                        TreeNode<DbObject> srcColumn,
                                        TreeNode<DbObject> srcDataType,
                                        TreeNode<DbObject> srcIndex,
                                        TreeNode<DbObject> tgtInstance,
                                        TreeNode<DbObject> tgtDatabase,
                                        TreeNode<DbObject> tgtCurrentSchema,
                                        TreeNode<DbObject> tgtCurrentTable,
                                        TreeNode<DbObject> tgtStagingSchema,
                                        TreeNode<DbObject> tgtStagingTable,
                                        TreeNode<DbObject> tgtArchiveSchema,
                                        TreeNode<DbObject> tgtArchiveTable,
                                        TreeNode<DbObject> tgtColumn,
                                        TreeNode<DbObject> tgtDataType,
                                        TreeNode<DbObject> tgtPartitionScheme,
                                        TreeNode<DbObject> tgtArchiveTableCSIndex
                                     )
        {
            SrcInstance             = srcInstance;
            SrcDatabase             = srcDatabase;
            SrcSchema               = srcSchema;
            SrcTable                = srcTable;
            SrcColumn               = srcColumn;
            SrcDataType             = srcDataType;
            SrcIndex                = srcIndex;
            TgtInstance             = tgtInstance;
            TgtDatabase             = tgtDatabase;
            TgtCurrentSchema        = tgtCurrentSchema;
            TgtCurrentTable         = tgtCurrentTable;
            TgtStagingSchema        = tgtStagingSchema;
            TgtStagingTable         = tgtStagingTable;
            TgtArchiveSchema        = tgtArchiveSchema;
            TgtArchiveTable         = tgtArchiveTable;
            TgtColumn               = tgtColumn;
            TgtDataType             = tgtDataType;
            TgtPartitionScheme      = tgtPartitionScheme;
            TgtIndex                = tgtArchiveTableCSIndex;
        }
    }
}
