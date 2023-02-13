using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CsiMigrationHelper
{
    public class ParamSelector : EventArgs
    {
        public string SqlQueryText { get; set; }
        public string BranchName { get; set; }
        public StrctParMetaData ParamMetaData { get; set; }
        public List<SqlParameter> SqlParamList { get; set; }
        public string DsOptions { get; set; }

        public ParamSelector(TreeNode<DbObject> tn, string dsOptions)
        {
            DsOptions = dsOptions;
            if (DsOptions != null)
            {
                switch (DsOptions)
                {
                    case "TableDefinition":
                        SqlQueryText = SqlText.GetSqlTableDefinitionByTableName();
                        break;
                    case "TableDefinitionTranslateUserTypes":
                        SqlQueryText = SqlText.GetSqlTableDefTranslatedUserTypesByTableName();
                        break;
                    case "ConstraintDefinition":
                        SqlQueryText = SqlText.GetSqlConstraintDefinitionByTableName();
                        break;
                }
            }
            else
            {
                SqlQueryText = SqlText.GetSqlObjectListByNodeLevel(tn);
            }
            
            switch (tn.Data.ObjectBranch)
            {
                case (int)DbObjectBranch.Root:
                    BranchName = "Root";
                    break;
             
                case (int)DbObjectBranch.Src:
                    BranchName = "Source";
                    break;

                case (int)DbObjectBranch.Tgt:
                    BranchName = "Target";
                    break;

                case (int)DbObjectBranch.TrckTbl:
                    BranchName = "Tracking Table";
                    break;
            }
               
            ParamMetaData = GetParamMetaByObjectLvl(tn.TreeNodeLevel, tn.Data.ObjectBranch);
            SqlParamList = new List<SqlParameter>();
            SqlParameter p_schName;
            SqlParameter p_tblName;
            SqlParameter p_colName;
            SqlParameter p_dataTypeName;
            //SqlParameter p_projName;

            // collect SQL Query parameters based on ObjectLevel:
            switch (tn.Data.ObjectLevel)
            {
                case (int)DbObjectLevel.Database:
                    break;

                case (int)DbObjectLevel.Schema:
                    break;

                case (int)DbObjectLevel.Table:
                    // to do: instead of instantiating a new SqlParameter at each case, figure out a way
                    // to make the SqlParam in DbObject cloneable and clone it to each local member here:
                    p_schName = new SqlParameter()
                    {
                        ParameterName = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Schema).Data.GetSqlParam().ParameterName,
                        SqlDbType = SqlDbType.VarChar,
                        Size = 4000,
                        Value = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Schema).Data.GetSqlParam().Value
                    };
                    SqlParamList.Add(p_schName);
                    break;

                case (int)DbObjectLevel.Column:                    
                    
                    if (tn.Data.ObjectBranch == (int)DbObjectBranch.TrckTbl)
                    {

                    }
                    else
                    {
                        p_schName = new SqlParameter()
                        {
                            ParameterName = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Schema).Data.GetSqlParam().ParameterName,
                            SqlDbType = SqlDbType.VarChar,
                            Size = 4000,
                            Value = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Schema).Data.GetSqlParam().Value
                        };
                        SqlParamList.Add(p_schName);
                    
                        p_tblName = new SqlParameter()
                        {
                            ParameterName = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Table).Data.GetSqlParam().ParameterName,
                            SqlDbType = SqlDbType.VarChar,
                            Size = 4000,
                            Value = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Table).Data.GetSqlParam().Value
                        };
                        SqlParamList.Add(p_tblName);
                    }
                    break;

                case (int)DbObjectLevel.DataType:
                    if (tn.Data.ObjectBranch == (int)DbObjectBranch.TrckTbl)
                    {

                    }
                    else
                    {
                        p_schName = new SqlParameter()
                        {
                            ParameterName = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Schema).Data.GetSqlParam().ParameterName,
                            SqlDbType = SqlDbType.VarChar,
                            Size = 4000,
                            Value = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Schema).Data.GetSqlParam().Value
                        };
                        SqlParamList.Add(p_schName);
                    
                        p_tblName = new SqlParameter()
                        {
                            ParameterName = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Table).Data.GetSqlParam().ParameterName,
                            SqlDbType = SqlDbType.VarChar,
                            Size = 4000,
                            Value = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Table).Data.GetSqlParam().Value
                        };
                        SqlParamList.Add(p_tblName);
                    
                        p_colName = new SqlParameter()
                        {
                            ParameterName = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Column).Data.GetSqlParam().ParameterName,
                            SqlDbType = SqlDbType.VarChar,
                            Size = 4000,
                            Value = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Column).Data.GetSqlParam().Value
                        };
                        SqlParamList.Add(p_colName);
                    }
                    
                    break;

                case (int)DbObjectLevel.PartitionScheme:
                    
                    if (!tn.CloneableFromSrc)
                    {
                        p_schName = new SqlParameter()
                        {
                            ParameterName = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Schema).Data.GetSqlParam().ParameterName,
                            SqlDbType = SqlDbType.VarChar,
                            Size = 4000,
                            Value = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Schema).Data.GetSqlParam().Value
                        };
                        SqlParamList.Add(p_schName);
                    
                        p_tblName = new SqlParameter()
                        {
                            ParameterName = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Table).Data.GetSqlParam().ParameterName,
                            SqlDbType = SqlDbType.VarChar,
                            Size = 4000,
                            Value = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Table).Data.GetSqlParam().Value
                        };
                        SqlParamList.Add(p_tblName);

                        p_colName = new SqlParameter()
                        {
                            ParameterName = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Column).Data.GetSqlParam().ParameterName,
                            SqlDbType = SqlDbType.VarChar,
                            Size = 4000,
                            Value = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Column).Data.GetSqlParam().Value
                        };
                        SqlParamList.Add(p_colName);
                    }
                    else
                    {
                        p_dataTypeName = new SqlParameter()
                        {
                            ParameterName = tn.TraverseUpUntil(tn, (int)DbObjectLevel.DataType).Data.GetSqlParam().ParameterName,
                            SqlDbType = SqlDbType.VarChar,
                            Size = 4000,
                            Value = tn.TraverseUpUntil(tn, (int)DbObjectLevel.DataType).Data.GetSqlParam().Value
                        };
                        SqlParamList.Add(p_dataTypeName);
                    }
                    break;

                case (int)DbObjectLevel.Index:
                    
                    p_schName = new SqlParameter()
                    {
                        ParameterName = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Schema).Data.GetSqlParam().ParameterName,
                        SqlDbType = SqlDbType.VarChar,
                        Size = 4000,
                        Value = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Schema).Data.GetSqlParam().Value
                    };
                    SqlParamList.Add(p_schName);
                    
                    p_tblName = new SqlParameter()
                    {
                        ParameterName = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Table).Data.GetSqlParam().ParameterName,
                        SqlDbType = SqlDbType.VarChar,
                        Size = 4000,
                        Value = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Table).Data.GetSqlParam().Value
                    };
                    SqlParamList.Add(p_tblName);
                    
                    p_colName = new SqlParameter()
                    {
                        ParameterName = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Column).Data.GetSqlParam().ParameterName,
                        SqlDbType = SqlDbType.VarChar,
                        Size = 4000,
                        Value = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Column).Data.GetSqlParam().Value
                    };
                    SqlParamList.Add(p_colName);
                    
                    break;
            }
        }

        public struct StrctParMetaData
        {
            public string ValueMember;
            public string DisplayMember;
            public string SelectedText;
            public string ParameterName;
            public string ErrorMsgIfNoneFound;
        }

        public static StrctParMetaData GetParamMetaByObjectLvl(int lvl, int branch)
        {
            StrctParMetaData pm = new StrctParMetaData();            
            pm.ErrorMsgIfNoneFound = string.Concat("Could not find any objects of type: [", DbObject.GetObjectLevelByIndex(lvl), "]");
            switch (lvl)
            {
                case (int)DbObjectLevel.Database:
                    pm.ValueMember = "database_id";
                    pm.DisplayMember = "DatabaseName";
                    pm.SelectedText = "--select database--";
                    pm.ParameterName = "@InstanceName";
                    break;

                case (int)DbObjectLevel.Schema:
                    pm.ValueMember = "schema_id";
                    pm.DisplayMember = "SchemaName";
                    pm.SelectedText = "--select schema--";
                    pm.ParameterName = "@SchemaName";
                    break;

                case (int)DbObjectLevel.Table:
                    pm.ValueMember = "table_id";
                    pm.DisplayMember = "TableName";
                    pm.SelectedText = "--select table--";
                    pm.ParameterName = "@TableName";
                    break;

                case (int)DbObjectLevel.Column:
                    if (branch == (int)DbObjectBranch.TrckTbl)
                    {
                        pm.ValueMember = "project_id";
                        pm.DisplayMember = "ProjectName";
                        pm.SelectedText = "--select project--";
                        pm.ParameterName = "@ProjectName";
                    }
                    else
                    {
                        pm.ValueMember = "column_id";
                        pm.DisplayMember = "ColumnName";
                        pm.SelectedText = "--select column--";
                        pm.ParameterName = "@ColumnName";
                    }
                    break;

                case (int)DbObjectLevel.DataType:
                    if (branch == (int)DbObjectBranch.TrckTbl)
                    {
                        pm.ValueMember = "project_id";
                        pm.DisplayMember = "ProjectDescription";
                        pm.SelectedText = "--select project--";
                        pm.ParameterName = "@ProjectDescription";
                    }
                    else
                    {
                        pm.ValueMember = "data_type_id";
                        pm.DisplayMember = "DataTypeName";
                        pm.SelectedText = "--select data type--";
                        pm.ParameterName = "@DataTypeName";
                    }                    
                    break;

                case (int)DbObjectLevel.PartitionScheme:
                    pm.ValueMember = "partition_scheme_id";
                    pm.DisplayMember = "PartitionSchemeName";
                    pm.SelectedText = "--select partition scheme--";
                    pm.ParameterName = "@PartitionSchemeName";
                    break;

                case (int)DbObjectLevel.Index:
                    pm.ValueMember = "index_id";
                    pm.DisplayMember = "IndexName";
                    pm.SelectedText = "--select index--";
                    pm.ParameterName = "@IndexName";
                    break;
            }
            return pm;
        }
    }
}

