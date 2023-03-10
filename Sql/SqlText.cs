using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CsiMigrationHelper
{
    public static class SqlText
    {
        private static string SqlDbList = "SELECT database_id, name AS [DatabaseName] FROM master.sys.databases ORDER BY name;";

        private static string SqlSchList = string.Concat("SELECT DISTINCT s.schema_id, s.name AS [SchemaName] "
                                                  , "FROM        sys.objects o WITH(NOLOCK) "
                                                  , "INNER JOIN  sys.schemas s WITH(NOLOCK) ON o.schema_id = s.schema_id "
                                                  //,"WHERE 		RTRIM(o.type) IN ('U', 'SQ') " /* SQ included to get dbo schema from tempdb */
                                                  , "ORDER BY    s.name ASC;"
                                                  );

        private static string SqlTbList = string.Concat("SELECT DISTINCT "
                                                 , " o.object_id AS [table_id]"
                                                 , ",o.name AS [TableName] "
                                                 , "FROM       sys.objects o "
                                                 , "INNER JOIN sys.schemas s ON o.schema_id = s.schema_id "
                                                 , "WHERE      o.type IN ('U') "
                                                 , "AND        s.name = @SchemaName "
                                                 , "ORDER BY   [TableName];"
                                                 );
        private static string SqlColList = string.Concat("SELECT      DISTINCT "
                                                  , " [c].column_id AS [column_id]"
                                                  , ",[c].name AS [ColumnName] "
                                                  , "FROM       sys.schemas AS s "
                                                  , "INNER JOIN sys.tables AS t ON t.schema_id = s.schema_id "
                                                  , "INNER JOIN sys.columns AS c ON c.object_id = t.object_id "
                                                  , "INNER JOIN sys.types AS tp ON c.system_type_id = tp.system_type_id "
                                                  , "WHERE s.name = @SchemaName "
                                                  , "AND   t.name = @TableName "
                                                  , "AND   c.is_computed <> 1 "
                                                  , "ORDER BY c.column_id;"
                                                  );

        private static string SqlPartSchListByColName = string.Concat(
                                                         "SELECT      DISTINCT "
                                                       , "            [ds].data_space_id    AS [partition_scheme_id] "
                                                       , "           ,[ps].name             AS [PartitionSchemeName] "
                                                       , "FROM sys.partitions               AS [pt] "
                                                       , "INNER JOIN  sys.indexes           AS [ix] ON ix.object_id = pt.object_id AND ix.index_id = pt.index_id "
                                                       , "INNER JOIN  sys.tables            AS [tb] ON pt.object_id = tb.object_id "
                                                       , "INNER JOIN  sys.schemas           AS [sh] ON sh.schema_id = tb.schema_id "
                                                       , "INNER JOIN  sys.index_columns     AS [ic] ON (ic.partition_ordinal > 0 AND ic.index_id = ix.index_id AND ic.object_id = tb.object_id) "
                                                       , "INNER JOIN  sys.columns           AS [co] ON (co.object_id = ic.object_id AND co.column_id = ic.column_id) "
                                                       , "INNER JOIN  sys.data_spaces       AS [ds] ON ds.data_space_id = ix.data_space_id "
                                                       , "INNER JOIN  sys.partition_schemes AS [ps] ON ps.data_space_id = ix.data_space_id "
                                                       , "WHERE [sh].name = @SchemaName "
                                                       , "AND   [tb].name = @TableName "
                                                       , "AND   [co].name = @ColumnName;"
                                                       );


        private static string SqlPartSchListByDataType = string.Concat("SELECT      DISTINCT "
                                                       , "            [ds].data_space_id       AS [partition_scheme_id] "
                                                       , "           ,[ps].name                AS [PartitionSchemeName] "
                                                       , "FROM        sys.partition_schemes    AS [ps] "
                                                       , "INNER JOIN  sys.data_spaces          AS [ds] ON [ds].data_space_id = [ps].data_space_id "
                                                       , "INNER JOIN  sys.partition_functions  AS [pf] ON [ps].function_id = [pf].function_id "
                                                       , "INNER JOIN  sys.partition_parameters AS [pp] ON [pp].function_id = [pf].function_id "
                                                       , "INNER JOIN  sys.types                AS [ty] ON [ty].system_type_id = [pp].system_type_id "
                                                       , "INNER JOIN  sys.columns              AS [co] ON [co].system_type_id = [ty].system_type_id "
                                                       //, "INNER JOIN  sys.tables               AS [tb] ON [tb].object_id = [co].object_id "
                                                       //, "INNER JOIN  sys.schemas              AS [sc] ON [sc].schema_id = [tb].schema_id "
                                                       , "WHERE       [ty].name = @DataTypeName;");


        private static string SqlDataTypeByColName = string.Concat(
                                                 "SELECT																									   "
                                               , "                                                                                                             "
                                               , "    [c].[column_id]      AS [data_type_id]                                                                   "
                                               , "  , CASE [t].[is_user_defined]                                                                               "
                                               , "        WHEN 0 THEN CASE [t].[name]                                                                          "
                                               , "                        WHEN 'nvarchar' THEN CONCAT([t].[name], '(', [c].[max_length] / 2, ')')              "
                                               , "                        WHEN 'varchar' THEN CONCAT([t].[name], '(', [c].[max_length], ')')                   "
                                               , "                        ELSE [t].[name]                                                                      "
                                               , "                    END                                                                                      "
                                               , "        WHEN 1 THEN CASE [fn].[SystemTypeName]                                                               "
                                               , "                        WHEN 'nvarchar' THEN CONCAT([fn].[SystemTypeName], '(', [fn].[max_length] / 2, ')')  "
                                               , "                        WHEN 'varchar' THEN CONCAT([fn].[SystemTypeName], '(', [fn].[max_length], ')')       "
                                               , "                        ELSE [fn].[SystemTypeName]                                                           "
                                               , "                    END                                                                                      "
                                               , "    END AS [DataTypeName]                                                                                    "
                                               , "FROM sys.[objects] AS [o]                                                            	                       "
                                               , "JOIN sys.[schemas] AS [s]   ON [s].[schema_id] = [o].[schema_id]                     	                       "
                                               , "JOIN sys.[columns] AS [c]   ON [o].[object_id] = [c].[object_id]                     	                       "
                                               , "JOIN sys.[types]   AS [t]   ON [c].[user_type_id] = [t].[user_type_id]               	                       "
                                               , "OUTER APPLY (                                                                                                "
                                               , "                SELECT TYPE_NAME([st].[system_type_id]) AS [SystemTypeName]                                  "
                                               , "                     , [st].[max_length]                                                                     "
                                               , "                     , [st].[precision]                                                                      "
                                               , "                     , [st].[scale]                                                                          "
                                               , "                     , [st].[collation_name]                                                                 "
                                               , "                     , [st].[is_nullable]                                                                    "
                                               , "                FROM [sys].[types] AS [st]                                                                   "
                                               , "                WHERE [st].[is_user_defined] = 1                                                             "
                                               , "                AND   [st].[user_type_id] = [c].[user_type_id]                                               "
                                               , "                AND   [st].[system_type_id] = [t].[system_type_id]                                           "
                                               , "            ) AS [fn]                                                                                        "
                                               , "WHERE                                                                                	                       "
                                               , "        [s].[name] = @SchemaName                                                     	                       "
                                               , "AND     [o].[name] = @TableName                                                      	                       "
                                               , "AND     [c].[name] = @ColumnName                                                     	                       "
                                               , "AND     [t].[name] <> 'sysname'                                                                              "
                                               );

        private static string SqlIndexListByColName = string.Concat(
                                                         "SELECT "
                                                       , "             [ix].index_id     AS [index_id] "
                                                       , "            ,[ix].name         AS [IndexName] "
                                                       , "FROM        sys.indexes        AS [ix] "
                                                       , "INNER JOIN  sys.index_columns  AS [ic] ON [ix].object_id = [ic].object_id AND [ix].index_id = [ic].index_id "
                                                       , "INNER JOIN  sys.columns        AS [co] ON [ic].object_id = [co].object_id AND [ic].column_id = [co].column_id "
                                                       , "INNER JOIN  sys.tables         AS [tb] ON [ix].object_id = [tb].object_id "
                                                       , "INNER JOIN  sys.schemas        AS [sh] ON [sh].schema_id = [tb].schema_id "
                                                       , "WHERE       [tb].is_ms_shipped = 0 "
                                                       , "AND         [sh].name = @SchemaName "
                                                       , "AND         [tb].name = @TableName "
                                                       , "AND         [co].name = @ColumnName "
                                                       , "AND         [ix].index_id > 0 " /* we do not want NULL IndexName in case of tables partitioned by the @ColumnName */
                                                       , "ORDER BY    [ix].index_id;"
                                                       );
        private static string SqlTableDefByTableName = string.Concat(
                                                         "SELECT                                                                                                                                                                                      "
                                                       , "           [sc].[column_id] AS [Id]                                                                                                                                                         "
                                                       , "         , QUOTENAME([sc].[name]) AS [ColumnName]                                                                                                                                           "
                                                       , "         , CASE                                                                                                                                                                             "
                                                       , "               WHEN [sc].[is_computed] = 1 THEN 'AS ' + [cc].[definition]                                                                                                                   "
                                                       , "               ELSE                                                                                                                                                                         "
                                                       , "                   UPPER([tp].[name]) + CASE                                                                                                                                                "
                                                       , "                                            WHEN [tp].[name] IN ( 'varchar', 'char', 'varbinary', 'binary', 'text' )                                                                        "
                                                       , "                                            THEN '(' + CASE                                                                                                                                 "
                                                       , "                                                           WHEN [sc].[max_length] = -1 THEN 'MAX'                                                                                           "
                                                       , "                                                           ELSE CAST([sc].[max_length] AS VARCHAR(5))                                                                                       "
                                                       , "                                                       END + ')'                                                                                                                            "
                                                       , "                                            WHEN [tp].[name] IN ( 'nvarchar', 'nchar', 'ntext' )                                                                                            "
                                                       , "                                            THEN '(' + CASE                                                                                                                                 "
                                                       , "                                                           WHEN [sc].[max_length] = -1 THEN 'MAX'                                                                                           "
                                                       , "                                                           ELSE CAST([sc].[max_length] / 2 AS VARCHAR(5))                                                                                   "
                                                       , "                                                       END + ')'                                                                                                                            "
                                                       , "                                            WHEN [tp].[name] IN ( 'datetime2', 'time2', 'datetimeoffset' )                                                                                  "
                                                       , "                                            THEN '(' + CAST([sc].[scale] AS VARCHAR(5)) + ')'                                                                                               "
                                                       , "                                            WHEN [tp].[name] = 'decimal'                                                                                                                    "
                                                       , "                                            THEN '(' + CAST([sc].[precision] AS VARCHAR(5)) + ',' + CAST([sc].[scale] AS VARCHAR(5)) + ')'                                                  "
                                                       , "                                            ELSE ''                                                                                                                                         "
                                                       , "                                        END +                                                                                                                                               " 
                                                       , "                                        CASE                                                                                                                                                "
                                                                                                      /* to do: COLLATE clause cannot be used on user-defined data types: */
                                                       , "                                            WHEN [sc].[collation_name] IS NOT NULL THEN ' COLLATE ' + [sc].[collation_name]                                                                 "
                                                       , "                                            ELSE ''                                                                                                                                         "
                                                       , "                                        END + CASE WHEN [sc].[is_nullable] = 1 THEN ' NULL' ELSE ' NOT NULL' END                                                                            "
                                                       , "                   + CASE                                                                                                                                                                   "
                                                       , "                         WHEN [ic].[is_identity] = 1 THEN ' IDENTITY(' + CAST(ISNULL([ic].[seed_value], '0') AS CHAR(1)) + ',' + CAST(ISNULL([ic].[increment_value], '1') AS CHAR(1)) + ')' "
                                                       , "                         ELSE ''                                                                                                                                                            "
                                                       , "                     END                                                                                                                                                                    "
                                                       , "           END AS [ColumnDefinition]                                                                                                                                                        "
                                                       , "FROM       [sys].[columns]          AS [sc] WITH(NOWAIT)                                                                                                                                    "
                                                       , "INNER JOIN [sys].[types]            AS [tp] WITH(NOWAIT) ON [sc].[user_type_id] = [tp].[user_type_id]                                                                                       "
                                                       , "LEFT  JOIN [sys].[computed_columns] AS [cc] WITH(NOWAIT) ON [sc].[object_id] = [cc].[object_id] AND [sc].[column_id] = [cc].[column_id]                                                     "
                                                       , "LEFT  JOIN [sys].[identity_columns] AS [ic] WITH(NOWAIT) ON  [sc].[is_identity] = 1                                                                                                         "
                                                       , "                                                         AND [sc].[object_id] = [ic].[object_id]                                                                                            "
                                                       , "                                                         AND [sc].[column_id] = [ic].[column_id]                                                                                            "
                                                       , "WHERE      [sc].[object_id] = OBJECT_ID(CONCAT(QUOTENAME(@SchemaName), '.', QUOTENAME(@TableName)));                                                                                        "
                                                       );

        private static string SqlTableDefTranslatedUserTypesByTableName = string.Concat(
               "	SELECT [sc].[column_id] AS [Id]	"
             , "	     , QUOTENAME([sc].[name]) AS [ColumnName]	"
             , "	     , CASE [tp].[is_user_defined]	"
             , "	           WHEN 0 THEN	"
             , "	               CASE	"
             , "	                   WHEN [sc].[is_computed] = 1 THEN 'AS ' + [cc].[definition]	"
             , "	                   ELSE	"
             , "	                       UPPER([tp].[name]) + CASE	"
             , "	                                                WHEN [tp].[name] IN ( 'varchar', 'char', 'varbinary', 'binary', 'text' ) THEN '(' + CASE	"
             , "	                                                                                                                                        WHEN [sc].[max_length] = -1 THEN 'MAX'	"
             , "	                                                                                                                                        ELSE CAST([sc].[max_length] AS VARCHAR(5))	"
             , "	                                                                                                                                    END + ')'	"
             , "	                                                WHEN [tp].[name] IN ( 'nvarchar', 'nchar', 'ntext' ) THEN '(' + CASE	"
             , "	                                                                                                                    WHEN [sc].[max_length] = -1 THEN 'MAX'	"
             , "	                                                                                                                    ELSE CAST([sc].[max_length] / 2 AS VARCHAR(5))	"
             , "	                                                                                                                END + ')'	"
             , "	                                                WHEN [tp].[name] IN ( 'datetime2', 'time2', 'datetimeoffset' ) THEN '(' + CAST([sc].[scale] AS VARCHAR(5)) + ')'	"
             , "	                                                WHEN [tp].[name] = 'decimal' THEN '(' + CAST([sc].[precision] AS VARCHAR(5)) + ',' + CAST([sc].[scale] AS VARCHAR(5)) + ')'	"
             , "	                                                ELSE ''	"
             , "	                                            END + CASE	"
             , "	                                                      WHEN [sc].[collation_name] IS NOT NULL THEN ' COLLATE ' + [sc].[collation_name]	"
             , "	                                                      ELSE ''	"
             , "	                                                  END + CASE WHEN [sc].[is_nullable] = 1 THEN ' NULL' ELSE ' NOT NULL' END	"
             , "	                       + CASE	"
             , "	                             WHEN [ic].[is_identity] = 1 THEN ' IDENTITY(' + CAST(ISNULL([ic].[seed_value], '0') AS CHAR(1)) + ',' + CAST(ISNULL([ic].[increment_value], '1') AS CHAR(1)) + ')'	"
             , "	                             ELSE ''	"
             , "	                         END	"
             , "	               END	"
             , "	           WHEN 1 THEN	"
             , "	               CASE	"
             , "	                   WHEN [sc].[is_computed] = 1 THEN 'AS ' + [cc].[definition]	"
             , "	                   ELSE	"
             , "	                       UPPER([fn].[SystemTypeName]) + CASE	"
             , "	                                                          WHEN [fn].[SystemTypeName] IN ( 'varchar', 'char', 'varbinary', 'binary', 'text' ) THEN '(' + CASE	"
             , "	                                                                                                                                                            WHEN [fn].[max_length] = -1 THEN 'MAX'	"
             , "	                                                                                                                                                            ELSE CAST([fn].[max_length] AS VARCHAR(5))	"
             , "	                                                                                                                                                        END + ')'	"
             , "	                                                          WHEN [fn].[SystemTypeName] IN ( 'nvarchar', 'nchar', 'ntext' ) THEN '(' + CASE	"
             , "	                                                                                                                                        WHEN [fn].[max_length] = -1 THEN 'MAX'	"
             , "	                                                                                                                                        ELSE CAST([fn].[max_length] / 2 AS VARCHAR(5))	"
             , "	                                                                                                                                    END + ')'	"
             , "	                                                          WHEN [fn].[SystemTypeName] IN ( 'datetime2', 'time2', 'datetimeoffset' ) THEN '(' + CAST([fn].[scale] AS VARCHAR(5)) + ')'	"
             , "	                                                          WHEN [fn].[SystemTypeName] = 'decimal' THEN '(' + CAST([fn].[precision] AS VARCHAR(5)) + ',' + CAST([fn].[scale] AS VARCHAR(5)) + ')'	"
             , "	                                                          ELSE ''	"
             , "	                                                      END + CASE	"
             , "	                                                                WHEN [sc].[collation_name] IS NOT NULL THEN ' COLLATE ' + [sc].[collation_name]	"
             , "	                                                                ELSE ''	"
             , "	                                                            END + CASE WHEN [sc].[is_nullable] = 1 THEN ' NULL' ELSE ' NOT NULL' END	"
             , "	                       + CASE	"
             , "	                             WHEN [ic].[is_identity] = 1 THEN ' IDENTITY(' + CAST(ISNULL([ic].[seed_value], '0') AS CHAR(1)) + ',' + CAST(ISNULL([ic].[increment_value], '1') AS CHAR(1)) + ')'	"
             , "	                             ELSE ''	"
             , "	                         END	"
             , "	               END	"
             , "	       END AS [ColumnDefinition]	"
             , "	FROM [sys].[columns] AS [sc] WITH (NOWAIT)	"
             , "	INNER JOIN [sys].[types] AS [tp] WITH (NOWAIT)	"
             , "	    ON [sc].[user_type_id] = [tp].[user_type_id]	"
             , "	LEFT JOIN [sys].[computed_columns] AS [cc] WITH (NOWAIT)	"
             , "	    ON  [sc].[object_id] = [cc].[object_id]	"
             , "	    AND [sc].[column_id] = [cc].[column_id]	"
             , "	LEFT JOIN [sys].[identity_columns] AS [ic] WITH (NOWAIT)	"
             , "	    ON  [sc].[is_identity] = 1	"
             , "	    AND [sc].[object_id] = [ic].[object_id]	"
             , "	    AND [sc].[column_id] = [ic].[column_id]	"
             , "	OUTER APPLY (	"
             , "	                SELECT TYPE_NAME([st].[system_type_id]) AS [SystemTypeName]	"
             , "	                     , [st].[max_length]	"
             , "	                     , [st].[precision]	"
             , "	                     , [st].[scale]	"
             , "	                     , [st].[collation_name]	"
             , "	                     , [st].[is_nullable]	"
             , "	                FROM [sys].[types] AS [st]	"
             , "	                WHERE [st].[is_user_defined] = 1	"
             , "	                AND   [st].[user_type_id] = [sc].[user_type_id]	"
             , "	                AND   [st].[system_type_id] = [tp].[system_type_id]	"
             , "	            ) AS [fn]	"
             , "	WHERE [sc].[object_id] = OBJECT_ID(CONCAT(QUOTENAME(@SchemaName), '.', QUOTENAME(@TableName)));	"
            );

        private static string SqlConstraintDefByTableName = string.Concat(
          "	DECLARE     @table_object_id INT = OBJECT_ID(CONCAT(QUOTENAME(@SchemaName), '.', QUOTENAME(@TableName)));	"
        , "	DECLARE     @object_name      sysname	"
        , "	          , @object_id        INT	"
        , "	          , @crlf             CHAR(2) = CHAR(13) + CHAR(10)	"
        , "	          , @SqlEngineVersion INT;	"
        , "	SELECT     @SqlEngineVersion = CAST(SUBSTRING(CAST(SERVERPROPERTY('ProductVersion') AS VARCHAR(20)), 1, 2) AS INT);	"
        , "	SELECT     @object_id = [o].[object_id]	"
        , "	FROM       [sys].[objects] AS [o]	"
        , "	INNER JOIN [sys].[schemas] AS [s] ON [o].[schema_id] = [s].[schema_id]	"
        , "	WHERE      [o].[object_id] = @table_object_id;	"
        
        , "	DECLARE @ConstraintList TABLE  ( [Id] INT IDENTITY(1,1), [ConstraintName] nvarchar(258), [Type] VARCHAR(2),  [ConstraintType] nvarchar(4000), [ColumnList] nvarchar(max), [ConstraintDefinition] nvarchar(max) )	"
        , "	INSERT INTO @ConstraintList ([ConstraintName], [Type], [ConstraintType], [ColumnList], [ConstraintDefinition])	"
        , "	/* PK lookup: */	"
        , "	/* ============================================================================================================================================ */	"
        , "		"
        , "	SELECT	"
        , "	    QUOTENAME([kc].[name]) AS [ConstraintName]	"
        , "	  , [kc].[type] AS [Type]	"
        , "	  , CONCAT(REPLACE(REPLACE([kc].[type_desc], '_', ' '), 'CONSTRAINT', ''), [si].[type_desc]) AS [ConstraintType]	"
        , "	  , CASE	"
        , "	        WHEN @SqlEngineVersion < 14 THEN /* For SQL Versions older than 14 (2017) use FOR XML PATH for all multi-column constraints: */	"
        , "	  (STUFF((/* STUFF is needed to get rid of comma ',' before the first element of the column list */	"
        , "	             SELECT ', ' + QUOTENAME([sc].[name]) + CASE WHEN [ic].[is_descending_key] = 1 THEN ' DESC' ELSE ' ASC' END	"
        , "	             FROM [sys].[index_columns] AS [ic]	"
        , "	             INNER JOIN [sys].[columns] AS [sc]	"
        , "	                 ON  [sc].[object_id] = [ic].[object_id]	"
        , "	                 AND [sc].[column_id] = [ic].[column_id]	"
        , "	             WHERE [ic].[is_included_column] = 0	"
        , "	             AND   [ic].[object_id] = [kc].[parent_object_id]	"
        , "	             AND   [ic].[index_id] = [kc].[unique_index_id]	"
        , "	             FOR XML PATH(N''), TYPE	"
        , "	         ).[value]('.', 'NVARCHAR(MAX)')	"
        , "	       , 1	"
        , "	       , 2	"
        , "	       , ''	"
        , "	        )	"
        , "	  )	"
        , "	        /* For SQL Versions 2017+ use STRING_AGG for all multi-column constraints: */	"
        , "	        ELSE STRING_AGG(QUOTENAME([sc].[name]) + CASE WHEN [ic].[is_descending_key] = 1 THEN ' DESC' ELSE ' ASC' END, ', ')	"
        , "	    END AS [ColumnList]	"
        , "	  , '' AS [ConstraintDefinition]	"
        , "	FROM [sys].[key_constraints] AS [kc]	"
        , "	LEFT JOIN [sys].[indexes] AS [si]	"
        , "	    ON  [si].[object_id] = [kc].[parent_object_id]	"
        , "	    AND [si].[index_id] = [kc].[unique_index_id]	"
        , "	LEFT JOIN [sys].[index_columns] AS [ic]	"
        , "	    ON  [ic].[object_id] = [kc].[parent_object_id]	"
        , "	    AND [ic].[index_id] = [kc].[unique_index_id]	"
        , "	LEFT JOIN [sys].[columns] AS [sc]	"
        , "	    ON  [sc].[object_id] = [ic].[object_id]	"
        , "	    AND [sc].[column_id] = [ic].[column_id]	"
        , "	WHERE [kc].[parent_object_id] = @object_id	"
        , "	AND   [kc].[type] = 'PK'	"
        , "	GROUP BY [kc].[object_id]	"
        , "	       , [kc].[type]	"
        , "	       , [kc].[type_desc]	"
        , "	       , [si].[type]	"
        , "	       , [si].[type_desc]	"
        , "	       , [kc].[name]	"
        , "	       , [kc].[parent_object_id]	"
        , "	       , [kc].[unique_index_id]	"
        , "	/* ============================================================================================================================================ */	"
        , "	/* end of PK lookup */	"
        , "		"
        , "	INSERT INTO @ConstraintList ([ConstraintName], [Type], [ConstraintType], [ColumnList], [ConstraintDefinition])	"
        , "	/* DEFAULT constraint lookup: */	"
        , "	/* ============================================================================================================================================ */	"
        , "	SELECT "
        , "	    QUOTENAME([dc].[name]) AS [ConstraintName]	"
        , "	  , [dc].[type] AS [Type]	"
        , "	  , REPLACE([dc].[type_desc], '_CONSTRAINT', '') AS [ConstraintType]	"
        , "	  , QUOTENAME([c].[name]) AS [ColumnList]	"
        , "	  , [dc].[definition] AS [ConstraintDefinition]	"
        , "	FROM [sys].[columns] AS [c]	"
        , "	LEFT JOIN [sys].[default_constraints] AS [dc]	"
        , "	    ON  [c].[default_object_id] != 0	"
        , "	    AND [c].[object_id] = [dc].[parent_object_id]	"
        , "	    AND [c].[column_id] = [dc].[parent_column_id]	"
        , "	WHERE [c].[object_id] = @object_id	"
        , "	AND   [dc].[type] = 'D' /* this is not redundant, we do not want NULLs */	"
        , "	/* ============================================================================================================================================ */	"
        , "	/* end of DEFAULT constraint lookup */	"
        , "		"
        , "	INSERT INTO @ConstraintList ([ConstraintName], [Type], [ConstraintType], [ColumnList], [ConstraintDefinition])	"
        , "	/* CK constraint lookup: */	"
        , "	/* ============================================================================================================================================ */	"
        , "		"
        , "	SELECT "
        , "	       QUOTENAME([cc].[name]) AS [ConstraintName]	"
        , "	     , [cc].[type] AS [Type]	"
        , "	     , REPLACE([cc].[type_desc], '_CONSTRAINT', '') AS [ConstraintType]	"
        , "	     , '' AS [ColumnList]	"
        , "	     , [cc].[definition] AS [ConstraintDefinition]	"
        , "	FROM [sys].[check_constraints] AS [cc]	"
        , "	WHERE [cc].[parent_object_id] = @object_id	"
        , "		"
        , "	/* ============================================================================================================================================ */	"
        , "	/* end of CK constraint lookup */	"
        , "		"
        , "	/* FK constraint lookup: */	"
        , "	/* ============================================================================================================================================ */	"
        , "	; WITH [fkc] AS	"
        , "	(SELECT    	"
        , "	           [fk].[object_id] AS [Foreign_Key_Id]	"
        , "	         , [fk].[type] AS [ConstraintType]	"
        , "	         , [fk].[type_desc] AS [ConstraintTypeDescr]	"
        , "	         , [fk].[name] AS [Foreign_Key_Name]	"
        , "	         , [fk].[delete_referential_action]	"
        , "	         , [fk].[update_referential_action]	"
        , "	         , [col_src].[name] AS [Column_Name_Src]	"
        , "	         , [sch_tgt].[SchemaName] AS [Schema_Name_Tgt]	"
        , "	         , (SELECT (OBJECT_NAME([fkc].[referenced_object_id]))) AS [Table_Name_Tgt]	"
        , "	         , [fkc].[referenced_column_id] AS [Column_Id_Tgt]	"
        , "	         , [col_tgt].[name] AS [Column_Name_Tgt]	"
        , "	    FROM [sys].foreign_keys AS [fk]	"
        , "	    CROSS APPLY (	"
        , "	                    SELECT [fkc].[parent_column_id]	"
        , "	                         , [fkc].[parent_object_id]	"
        , "	                         , [fkc].[referenced_object_id]	"
        , "	                         , [fkc].[referenced_column_id]	"
        , "	                    FROM [sys].[foreign_key_columns] AS [fkc]	"
        , "	                    WHERE [fk].[parent_object_id] = [fkc].[parent_object_id]	"
        , "	                    AND   [fk].[referenced_object_id] = [fkc].[referenced_object_id]	"
        , "	                    AND   [fk].[object_id] = [fkc].[constraint_object_id]	"
        , "	                ) AS [fkc]	"
        , "	    CROSS APPLY (	"
        , "	                    SELECT [ss].[name] AS [SchemaName]	"
        , "	                    FROM [sys].[objects] AS [so]	"
        , "	                    INNER JOIN [sys].[schemas] AS [ss]	"
        , "	                        ON [ss].[schema_id] = [so].[schema_id]	"
        , "	                    WHERE [so].[object_id] = [fkc].[parent_object_id]	"
        , "	                ) AS [sch_src]	"
        , "	    CROSS APPLY (	"
        , "	                    SELECT [sc].[name]	"
        , "	                    FROM [sys].[columns] AS [sc]	"
        , "	                    WHERE [sc].[object_id] = [fk].[parent_object_id]	"
        , "	                    AND   [sc].[column_id] = [fkc].[parent_column_id]	"
        , "	                ) AS [col_src]	"
        , "	    CROSS APPLY (	"
        , "	                    SELECT [ss].[schema_id] AS [SchemaId]	"
        , "	                         , [ss].[name] AS [SchemaName]	"
        , "	                    FROM [sys].[objects] AS [so]	"
        , "	                    INNER JOIN [sys].[schemas] AS [ss]	"
        , "	                        ON [ss].[schema_id] = [so].[schema_id]	"
        , "	                    WHERE [so].[object_id] = [fkc].[referenced_object_id]	"
        , "	                ) AS [sch_tgt]	"
        , "	    CROSS APPLY (	"
        , "	                    SELECT [sc].[name]	"
        , "	                    FROM [sys].[columns] AS [sc]	"
        , "	                    WHERE [sc].[object_id] = [fk].[referenced_object_id]	"
        , "	                    AND   [sc].[column_id] = [fkc].[referenced_column_id]	"
        , "	                ) AS [col_tgt]	"
        , "	    WHERE OBJECT_ID('[' + [sch_src].[SchemaName] + '].[' + OBJECT_NAME([fkc].[parent_object_id]) + ']') = @object_id)	"
        , "	INSERT INTO @ConstraintList ([ConstraintName], [Type], [ConstraintType], [ColumnList], [ConstraintDefinition])	"
        , "	(	"
        , "	SELECT 	"
        , "	       QUOTENAME([fkc].[Foreign_Key_Name]) AS [ConstraintName]	"
        , "	     , [fkc].[ConstraintType] AS [Type]	"
        , "	     , REPLACE((REPLACE([fkc].[ConstraintTypeDescr], '_', ' ')), 'CONSTRAINT', '') AS [ConstraintType]	"
        , "	     , CASE	"
        , "	           WHEN @SqlEngineVersion < 14	"
        , "	       /* For SQL Versions older than 14 (2017) use FOR XML PATH for all multi-column constraints: */	"
        , "	       THEN      STUFF((	"
        , "	                         SELECT ', ' + QUOTENAME([t].[Column_Name_Src])	"
        , "	                         FROM [fkc] [t]	"
        , "	                         WHERE [t].[Foreign_Key_Id] = [fkc].[Foreign_Key_Id]	"
        , "	                         ORDER BY [t].[Column_Id_Tgt] 	"
        , "	                         FOR XML PATH(''), TYPE	"
        , "	                     ).[value]('(./text())[1]', 'VARCHAR(MAX)')	"
        , "	                   , 1	"
        , "	                   , 2	"
        , "	                   , ''	"
        , "	                    )	"
        , "	       ELSE	"
        , "	               /* For SQL Versions 2017+ use STRING_AGG for all multi-column constraints: */	"
        , "	               STRING_AGG(QUOTENAME([fkc].[Column_Name_Src]), ', ') WITHIN GROUP (ORDER BY [fkc].[Column_Id_Tgt])	"
        , "	       END AS [ColumnList]	"
        , "	     , CONCAT('REFERENCES ', QUOTENAME([fkc].[Schema_Name_Tgt]) + '.' + QUOTENAME([fkc].[Table_Name_Tgt]) 	"
        , "	     , ' ('	"
        , "	     , CASE	"
        , "	       WHEN @SqlEngineVersion < 14	"
        , "	       /* For SQL Versions older than 14 (2017) use FOR XML PATH for all multi-column constraints: */	"
        , "	       THEN      STUFF((	"
        , "	                         SELECT ', ' + QUOTENAME([t].[Column_Name_Tgt])	"
        , "	                         FROM [fkc] [t]	"
        , "	                         WHERE [t].[Foreign_Key_Id] = [fkc].[Foreign_Key_Id]	"
        , "	                         ORDER BY [t].[Column_Id_Tgt] "
        , "	                         FOR XML PATH(''), TYPE	"
        , "	                     ).[value]('(./text())[1]', 'VARCHAR(MAX)')	"
        , "	                   , 1	"
        , "	                   , 2	"
        , "	                   , ''	"
        , "	                    )	"
        , "	       ELSE	"
        , "	               /* For SQL Versions 2017+ use STRING_AGG for all multi-column constraints: */	"
        , "	               STRING_AGG(QUOTENAME([fkc].[Column_Name_Tgt]), ', ') WITHIN GROUP (ORDER BY [fkc].[Column_Id_Tgt])	"
        , "	       END	"
        , "	     , ')'	"
        , "	     , CASE	"
        , "	             WHEN [fkc].delete_referential_action = 1 THEN ' ON DELETE CASCADE'	"
        , "	             WHEN [fkc].delete_referential_action = 2 THEN ' ON DELETE SET NULL'	"
        , "	             WHEN [fkc].delete_referential_action = 3 THEN ' ON DELETE SET DEFAULT'	"
        , "	             ELSE ''	"
        , "	         END 	"
        , "	       + CASE	"
        , "	             WHEN [fkc].update_referential_action = 1 THEN ' ON UPDATE CASCADE'	"
        , "	             WHEN [fkc].update_referential_action = 2 THEN ' ON UPDATE SET NULL'	"
        , "	             WHEN [fkc].update_referential_action = 3 THEN ' ON UPDATE SET DEFAULT'	"
        , "	             ELSE ''	"
        , "	         END	"
        , "	     ) AS [ConstraintDefinition]	"
        , "	FROM [fkc]	"
        , "	GROUP BY [fkc].[Foreign_Key_Id]	"
        , "	       , [fkc].[ConstraintType]	"
        , "	       , [fkc].[ConstraintTypeDescr]	"
        , "	       , [fkc].[Foreign_Key_Name]	"
        , "	       , [fkc].[Schema_Name_Tgt]	"
        , "	       , [fkc].[Table_Name_Tgt]	"
        , "	       , [fkc].delete_referential_action	"
        , "	       , [fkc].update_referential_action	"
        , "	)	"
        , "	/* ============================================================================================================================================ */	"
        , "	/* end of FK constraint lookup */	"
        , "		"
        , "	/* NON-PK UQ, CL, NCL constraint lookup: */	"
        , "	/* ============================================================================================================================================ */	"
        , "	;	"
        , "	WITH [ColListIdx]	"
        , "	AS (SELECT [si].[index_id] AS [IndexId]	"
        , "	         , CASE WHEN [si].[is_unique] = 1 THEN 'UNIQUE ' ELSE '' END AS [IsUnique]	"
        , "	         , [si].[type] AS [IndexType]	"
        , "	         , [si].[type_desc] AS [IndexTypeDescr]	"
        , "	         , [si].[name] AS [IndexName]	"
        , "	         , STRING_AGG(QUOTENAME([sc].[name]) + CASE WHEN [ic].[is_descending_key] = 1 THEN ' DESC' ELSE ' ASC' END, ', ') WITHIN GROUP (ORDER BY [sc].[column_id]) AS [ColumnListIndexed]	"
        , "	         , [ds].[type_desc] AS [FG_PS]	"
        , "	         , [ds].[name] AS [FG_PS_Name]	"
        , "	         , CASE [si].[has_filter] WHEN 1 THEN CONCAT('WHERE ', [si].[filter_definition]) ELSE '' END AS [FilteredDefinition]	"
        , "	    FROM [sys].[indexes] AS [si]	"
        , "	    INNER JOIN [sys].[index_columns] AS [ic]	"
        , "	        ON  [ic].[object_id] = @object_id	"
        , "	        AND [si].[object_id] = @object_id	"
        , "	    INNER JOIN [sys].[columns] AS [sc]	"
        , "	        ON  [sc].[object_id] = [ic].[object_id]	"
        , "	        AND [sc].[column_id] = [ic].[column_id]	"
        , "	        AND [ic].[index_id] = [si].[index_id]	"
        , "	    INNER JOIN [sys].[data_spaces] AS [ds]	"
        , "	        ON [si].[data_space_id] = [ds].[data_space_id]	"
        , "	    WHERE [si].[is_hypothetical] = 0	"
        , "	    AND   [si].[type] > 0 /* excluding heap objects */	"
        , "	    AND   [si].[index_id] <> 0	"
        , "	    AND   [si].[is_primary_key] = 0	"
        , "	    AND   [ic].[is_included_column] = 0	"
        , "	    GROUP BY [si].[index_id]	"
        , "	           , [si].[is_unique]	"
        , "	           , [si].[type]	"
        , "	           , [si].[type_desc]	"
        , "	           , [si].[name]	"
        , "	           , [ds].[type_desc]	"
        , "	           , [ds].[name]	"
        , "	           , [si].[has_filter]	"
        , "	           , [si].[filter_definition])	"
        , "	   , [ColListIncl]	"
        , "	AS (SELECT [si].[index_id] AS [IndexId]	"
        , "	         , CASE WHEN [si].[is_unique] = 1 THEN 'UNIQUE ' ELSE '' END AS [IsUnique]	"
        , "	         , [si].[type] AS [IndexType]	"
        , "	         , [si].[type_desc] AS [IndexTypeDescr]	"
        , "	         , [si].[name] AS [IndexName]	"
        , "	         , CONCAT('INCLUDE (', STRING_AGG(QUOTENAME([sc].[name]), ', ') WITHIN GROUP (ORDER BY [sc].[column_id]), ')') AS [ColumnListIncl]	"
        , "	    FROM [sys].[indexes] AS [si]	"
        , "	    INNER JOIN [sys].[index_columns] AS [ic]	"
        , "	        ON  [ic].[object_id] = @object_id	"
        , "	        AND [si].[object_id] = @object_id	"
        , "	    INNER JOIN [sys].[columns] AS [sc]	"
        , "	        ON  [sc].[object_id] = [ic].[object_id]	"
        , "	        AND [sc].[column_id] = [ic].[column_id]	"
        , "	        AND [ic].[index_id] = [si].[index_id]	"
        , "	    INNER JOIN [sys].[data_spaces] AS [ds]	"
        , "	        ON [si].[data_space_id] = [ds].[data_space_id]	"
        , "	    WHERE [si].[is_hypothetical] = 0	"
        , "	    AND   [si].[type] > 0 /* excluding heap objects */	"
        , "	    AND   [si].[index_id] <> 0	"
        , "	    AND   [si].[is_primary_key] = 0	"
        , "	    AND   [ic].[is_included_column] = 1	"
        , "	    GROUP BY [si].[index_id]	"
        , "	           , [si].[is_unique]	"
        , "	           , [si].[type]	"
        , "	           , [si].[type_desc]	"
        , "	           , [si].[name])	"
        , "	INSERT INTO @ConstraintList ([ConstraintName], [Type], [ConstraintType], [ColumnList], [ConstraintDefinition])	"
        , "	SELECT 	"
        , "	       QUOTENAME([indx].[IndexName]) AS [ConstraintName]	"
        , "	     , 'IX' AS [Type]	"
        , "	     , CONCAT([indx].[IsUnique], [indx].[IndexTypeDescr]) AS [ConstraintType]    	"
        , "	     , [indx].[ColumnListIndexed] AS [ColumnList]	"
        , "	     , CONCAT([incl].[ColumnListIncl], [indx].[FilteredDefinition]) AS [ConstraintDefinition]	"
        , "	FROM [ColListIdx] AS [indx]	"
        , "	LEFT JOIN [ColListIncl] AS [incl] ON [incl].[IndexId] = [indx].[IndexId];	"
        , "		"
        , "	SELECT * FROM @ConstraintList;	"

        );

        public static string GetSqlConstraintDefinitionByTableName()
        {
            return SqlConstraintDefByTableName;
        }

        public static string GetSqlTableDefinitionByTableName()
        {
            return SqlTableDefByTableName;
        }

        public static string GetSqlTableDefTranslatedUserTypesByTableName()
        {
            return SqlTableDefTranslatedUserTypesByTableName;
        }

        public static string GetSqlTableDefinitionProjectTable(string schemaName, string tableName)
        {
            return string.Concat(  
                                   /* Project Table Deifnition: */
                                   "CREATE TABLE [", schemaName, "].[", tableName, "]("
                                 , "  [ProjectID]                 INT IDENTITY(1,1) NOT NULL"
                                 , ", [ProjectGUID]               UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY CLUSTERED"
                                 , ", [ProjectName]               NVARCHAR(256) UNIQUE NOT NULL"
                                 , ", [ProjectDescription]        NVARCHAR(256) NULL"
                                 , ", [ProjectCreateDate]         DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP"
                                 , ", [SrcInstance]               NVARCHAR(256) NOT NULL"
                                 , ", [SrcDatabase]               NVARCHAR(256) NOT NULL"
                                 , ", [SrcTableSchema]            NVARCHAR(256) NOT NULL"
                                 , ", [SrcTableName]              NVARCHAR(256) NOT NULL"
                                 , ", [SrcColumn]                 NVARCHAR(256) NOT NULL"
                                 , ", [SrcDataType]               NVARCHAR(256) NOT NULL"
                                 , ", [SrcTableIndex]             NVARCHAR(256) NOT NULL"
                                 , ", [SrcSynonym]                NVARCHAR(256) NOT NULL"
                                 , ", [TgtInstance]               NVARCHAR(256) NOT NULL"
                                 , ", [TgtDatabase]               NVARCHAR(256) NOT NULL"
                                 , ", [TgtCurrentSchema]          NVARCHAR(256) NOT NULL"
                                 , ", [TgtCurrentTable]           NVARCHAR(256) NOT NULL"
                                 , ", [TgtStagingSchema]          NVARCHAR(256) NOT NULL"
                                 , ", [TgtStagingTable]           NVARCHAR(256) NOT NULL"
                                 , ", [TgtArchiveSchema]          NVARCHAR(256) NOT NULL"
                                 , ", [TgtArchiveTable]           NVARCHAR(256) NOT NULL"
                                 , ", [TgtColumn]                 NVARCHAR(256) NOT NULL"
                                 , ", [TgtDataType]               NVARCHAR(256) NOT NULL"
                                 , ", [TgtPartitionScheme]        NVARCHAR(256) NOT NULL"
                                 , ", [TgtArchiveTableCSIndex]    NVARCHAR(256) NOT NULL"
                                 , ", [TgtSynonym]                NVARCHAR(256) NOT NULL"
                                 , ", [TrackSynonymProjects]      NVARCHAR(256) NULL"
                                 , ", [TrackSynonymMigrationTrck] NVARCHAR(256) NULL"
                                 , ");", Environment.NewLine
                                 
                                 /* Migration Tracking Table Definition: */
                                 , "CREATE TABLE [", schemaName, "].[", tableName, Options.migrationTrackingTblSuffix, "]("
                                 , "  [ProjectGUID] UNIQUEIDENTIFIER NOT NULL"
                                 , ", [EntryCreateDate] DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP"
                                 , ", [PartitionId] BIGINT NOT NULL"
                                 , ", [PartitionNumber] INT NOT NULL"
                                 , ", [RowNumSrc] BIGINT NULL"
                                 , ", [RowNumTgt] BIGINT NOT NULL"
                                 , ", [TotalMB] DECIMAL(10,2) NOT NULL"
                                 , ", [UsedMB]  DECIMAL(10,2) NOT NULL"
                                 , ", [FilegroupName] NVARCHAR(256) NOT NULL"
                                 , ", [LowerPartitionBoundary] DATETIME NULL"
                                 , ", [UpperPartitionBoundary] DATETIME NULL"
                                 , ", [Migrated] BIT NOT NULL"
                                 , ", [Duration] BIGINT NULL"
                                 , ", [DestinationFlag] NVARCHAR(2) NULL"
                                 , ");", Environment.NewLine
                                 , "ALTER TABLE [", schemaName, "].[", tableName, Options.migrationTrackingTblSuffix, "] ADD CONSTRAINT [FK_", tableName, "_ProjectGUID] "
                                 , "FOREIGN KEY ([ProjectGUID]) REFERENCES [", schemaName, "].[", tableName, "]([ProjectGUID]);"
                                 );
        }

        public static string GetSqlProjectInsert(string schemaName, string tableName, string projectName, string projectDescription, EventArgsProjectFields e)
        {
            return string.Concat(
                  "INSERT INTO [", schemaName, "].[", tableName, "]"
                , "           ( [ProjectGUID]               ", Environment.NewLine
                , "           , [ProjectName]               ", Environment.NewLine
                , "           , [ProjectDescription]        ", Environment.NewLine
                //, "           , [ProjectCreateDate]         ", Environment.NewLine
                , "           , [SrcInstance]               ", Environment.NewLine
                , "           , [SrcDatabase]               ", Environment.NewLine
                , "           , [SrcTableSchema]            ", Environment.NewLine
                , "           , [SrcTableName]              ", Environment.NewLine
                , "           , [SrcColumn]                 ", Environment.NewLine
                , "           , [SrcDataType]               ", Environment.NewLine
                , "           , [SrcTableIndex]             ", Environment.NewLine
                , "           , [SrcSynonym]                ", Environment.NewLine
                , "           , [TgtInstance]               ", Environment.NewLine
                , "           , [TgtDatabase]               ", Environment.NewLine
                , "           , [TgtCurrentSchema]          ", Environment.NewLine
                , "           , [TgtCurrentTable]           ", Environment.NewLine
                , "           , [TgtStagingSchema]          ", Environment.NewLine
                , "           , [TgtStagingTable]           ", Environment.NewLine
                , "           , [TgtArchiveSchema]          ", Environment.NewLine
                , "           , [TgtArchiveTable]           ", Environment.NewLine
                , "           , [TgtColumn]                 ", Environment.NewLine
                , "           , [TgtDataType]               ", Environment.NewLine
                , "           , [TgtPartitionScheme]        ", Environment.NewLine
                , "           , [TgtArchiveTableCSIndex]    ", Environment.NewLine
                , "           , [TgtSynonym]                ", Environment.NewLine
                , "           , [TrackSynonymProjects]      ", Environment.NewLine
                , "           , [TrackSynonymMigrationTrck] ", Environment.NewLine
                , ")" , Environment.NewLine
                , "VALUES	  ("
                , "NEWID()", Environment.NewLine
                , ", '", projectName
                , "', '", projectDescription
                , "', '", e.SrcInstance
                , "', '", e.SrcDatabase
                , "', '", e.SrcSchema
                , "', '", e.SrcTable
                , "', '", e.SrcColumn
                , "', '", e.SrcDataType
                , "', '", e.SrcIndex
                , "', '", e.SrcSynonym
                , "', '", e.TgtInstance
                , "', '", e.TgtDatabase
                , "', '", e.TgtCurrentSchema
                , "', '", e.TgtCurrentTable
                , "', '", e.TgtStagingSchema
                , "', '", e.TgtStagingTable
                , "', '", e.TgtArchiveSchema
                , "', '", e.TgtArchiveTable
                , "', '", e.TgtColumn
                , "', '", e.TgtDataType
                , "', '", e.TgtPartitionScheme
                , "', '", e.TgtIndex
                , "', '", e.TgtSynonym
                , "', '", e.TrackSynonymProjects
                , "', '", e.TrackSynonymMigrationTrck
                , "');"
                );
        }

        public static string GetSqlProjectSettingsByProjectName(string schemaName, string projectTableName)
        {
            return string.Concat(
                         "CREATE PROCEDURE [", schemaName, "].[usp_GetProjectSettingsFrom_", schemaName, "_", projectTableName, "]", Environment.NewLine
                        , "  @ProjectName		   NVARCHAR(256)	    ", Environment.NewLine
                        , ", @SrcInstance               NVARCHAR(256) OUTPUT" , Environment.NewLine
                        , ", @SrcDatabase               NVARCHAR(256) OUTPUT" , Environment.NewLine
                        , ", @SrcSchema                 NVARCHAR(256) OUTPUT" , Environment.NewLine
                        , ", @SrcTable                  NVARCHAR(256) OUTPUT" , Environment.NewLine
                        , ", @SrcColumn                 NVARCHAR(256) OUTPUT" , Environment.NewLine
                        , ", @SrcDataType               NVARCHAR(256) OUTPUT" , Environment.NewLine
                        , ", @SrcIndex                  NVARCHAR(256) OUTPUT" , Environment.NewLine
                        , ", @SrcSynonym                NVARCHAR(256) OUTPUT" , Environment.NewLine
                        , ", @TgtInstance               NVARCHAR(256) OUTPUT" , Environment.NewLine
                        , ", @TgtDatabase               NVARCHAR(256) OUTPUT" , Environment.NewLine
                        , ", @TgtCurrentSchema          NVARCHAR(256) OUTPUT" , Environment.NewLine
                        , ", @TgtCurrentTable           NVARCHAR(256) OUTPUT" , Environment.NewLine
                        , ", @TgtStagingSchema          NVARCHAR(256) OUTPUT" , Environment.NewLine
                        , ", @TgtStagingTable           NVARCHAR(256) OUTPUT" , Environment.NewLine
                        , ", @TgtArchiveSchema          NVARCHAR(256) OUTPUT" , Environment.NewLine
                        , ", @TgtArchiveTable           NVARCHAR(256) OUTPUT" , Environment.NewLine
                        , ", @TgtColumn                 NVARCHAR(256) OUTPUT" , Environment.NewLine
                        , ", @TgtDataType               NVARCHAR(256) OUTPUT" , Environment.NewLine
                        , ", @TgtPartitionScheme        NVARCHAR(256) OUTPUT" , Environment.NewLine
                        , ", @TgtIndex                  NVARCHAR(256) OUTPUT" , Environment.NewLine
                        , ", @TgtSynonym                NVARCHAR(256) OUTPUT" , Environment.NewLine
                        , ", @TrackSynonymProjects      NVARCHAR(256) OUTPUT" , Environment.NewLine
                        , ", @TrackSynonymMigrationTrck	NVARCHAR(256) OUTPUT" , Environment.NewLine
                        , "AS											", Environment.NewLine
                        , "BEGIN										", Environment.NewLine
                        , "	SET NOCOUNT ON;								", Environment.NewLine
                        , "	SELECT 										", Environment.NewLine
                        , "  	@SrcInstance	=	[SrcInstance]              	", Environment.NewLine
                        , ", 	@SrcDatabase	=	[SrcDatabase]              	", Environment.NewLine
                        , ", 	@SrcSchema	=	[SrcTableSchema]           	", Environment.NewLine
                        , ", 	@SrcTable	=	[SrcTableName]             	", Environment.NewLine
                        , ", 	@SrcColumn	=	[SrcColumn]                	", Environment.NewLine
                        , ", 	@SrcDataType	=	[SrcDataType]              	", Environment.NewLine
                        , ", 	@SrcIndex	=	[SrcTableIndex]            	", Environment.NewLine
                        , ", 	@SrcSynonym	=	[SrcSynonym]               	", Environment.NewLine
                        , ", 	@TgtInstance	=	[TgtInstance]              	", Environment.NewLine
                        , ", 	@TgtDatabase	=	[TgtDatabase]              	", Environment.NewLine
                        , ", 	@TgtCurrentSchema	=	[TgtCurrentSchema]         	", Environment.NewLine
                        , ", 	@TgtCurrentTable	=	[TgtCurrentTable]          	", Environment.NewLine
                        , ", 	@TgtStagingSchema	=	[TgtStagingSchema]         	", Environment.NewLine
                        , ", 	@TgtStagingTable	=	[TgtStagingTable]          	", Environment.NewLine
                        , ", 	@TgtArchiveSchema	=	[TgtArchiveSchema]         	", Environment.NewLine
                        , ", 	@TgtArchiveTable	=	[TgtArchiveTable]          	", Environment.NewLine
                        , ", 	@TgtColumn	=	[TgtColumn]                	", Environment.NewLine
                        , ", 	@TgtDataType	=	[TgtDataType]              	", Environment.NewLine
                        , ", 	@TgtPartitionScheme	=	[TgtPartitionScheme]       	", Environment.NewLine
                        , ", 	@TgtIndex	=	[TgtArchiveTableCSIndex]   	", Environment.NewLine
                        , ", 	@TgtSynonym	=	[TgtSynonym]               	", Environment.NewLine
                        , ", 	@TrackSynonymProjects	=	[TrackSynonymProjects]     	", Environment.NewLine
                        , ", 	@TrackSynonymMigrationTrck	=	[TrackSynonymMigrationTrck]	", Environment.NewLine                        
                        , "	FROM [", schemaName, "].[", projectTableName, "] WHERE ProjectName = @ProjectName;", Environment.NewLine
                        , "END;"
                );
        }

        public static string GetSqlVerifyMigrationTrackingEntryCountPerProjectName(TreeNode<DbObject> tn)
        {
            string schema = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Schema).Data.ObjectText;
            string migrationProjectsTbl = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Table).Data.ObjectText;
            string migrationTrackingTbl = string.Concat(migrationProjectsTbl, Options.migrationTrackingTblSuffix);
            string migrationProjectName = tn.Data.ObjectText;

            return string.Concat(
                  "DECLARE		@Count INT;					"
                , "SELECT		@Count = COUNT(mt.[ProjectGUID])	"
                , "FROM         [", schema, "].[", migrationTrackingTbl, "] AS mt ", Environment.NewLine
                , "INNER JOIN   [", schema, "].[", migrationProjectsTbl, "] AS mp ", Environment.NewLine
                , "ON           mp.[ProjectGUID] = mt.[ProjectGUID]                        ", Environment.NewLine
                , "WHERE		mp.[ProjectName] = '", migrationProjectName, "'; ", Environment.NewLine
                , "SELECT @Count;");
        }

        public static string GetSqlTableVerificationProjectsTable(string schemaName, string tableName)
        {
            return string.Concat(
                                 " DECLARE		@Count INT;										"
                                , "SELECT		@Count = COUNT(sc.column_id)					"
                                , "FROM		sys.tables st 										"
                                , "INNER JOIN	sys.schemas ss on ss.schema_id = st.schema_id	"
                                , "INNER JOIN	sys.columns sc on sc.object_id = st.object_id	"
                                , "WHERE 														"
                                , "			ss.name = '", schemaName, "' 						"
                                , "AND		st.name = '", tableName, "'							"
                                , "AND		sc.name IN 											"
                                , "(															"
                                , " 'ProjectID'", Environment.NewLine
                                , ",'ProjectGUID'", Environment.NewLine
                                , ",'ProjectName'", Environment.NewLine
                                , ",'ProjectDescription'", Environment.NewLine
                                , ",'ProjectCreateDate'", Environment.NewLine
                                , ",'SrcInstance'", Environment.NewLine
                                , ",'SrcDatabase'", Environment.NewLine
                                , ",'SrcTableSchema'", Environment.NewLine
                                , ",'SrcTableName'", Environment.NewLine
                                , ",'SrcColumn'", Environment.NewLine
                                , ",'SrcDataType'", Environment.NewLine
                                , ",'SrcTableIndex'", Environment.NewLine
                                , ",'SrcSynonym'", Environment.NewLine
                                , ",'TgtInstance'", Environment.NewLine
                                , ",'TgtDatabase'", Environment.NewLine
                                , ",'TgtCurrentSchema'", Environment.NewLine
                                , ",'TgtCurrentTable'", Environment.NewLine
                                , ",'TgtStagingSchema'", Environment.NewLine
                                , ",'TgtStagingTable'", Environment.NewLine
                                , ",'TgtArchiveSchema'", Environment.NewLine
                                , ",'TgtArchiveTable'", Environment.NewLine
                                , ",'TgtColumn'", Environment.NewLine
                                , ",'TgtDataType'", Environment.NewLine
                                , ",'TgtPartitionScheme'", Environment.NewLine
                                , ",'TgtArchiveTableCSIndex'", Environment.NewLine
                                , ",'TgtSynonym'", Environment.NewLine
                                , ",'TrackSynonymProjects'", Environment.NewLine
                                , ",'TrackSynonymMigrationTrck'", Environment.NewLine
                                , ")															"
                                , "SELECT @Count;												");
        }


        public static string GetSqlProjectRemove(string schema, string tableName, string projectName)
        {
            string migrationProjectsTbl = tableName;
            string migrationTrackingTbl = string.Concat(migrationProjectsTbl, Options.migrationTrackingTblSuffix);

            return string.Concat(
                 "IF (SELECT 1 FROM [", schema, "].[", migrationTrackingTbl, "] mt									"
                , "INNER JOIN [", schema, "].[", migrationProjectsTbl, "] mp 										"
                , "ON mp.ProjectGUID = mt.ProjectGUID																"
                , "WHERE mp.ProjectName = '", projectName, "') > 1													"
                , "BEGIN																						    "
                , "	DELETE mt FROM [", schema, "].[", migrationTrackingTbl, "] mt									"
                , "	INNER JOIN [", schema, "].[", migrationProjectsTbl, "] mp 										"
                , "	ON mp.ProjectGUID = mt.ProjectGUID																"
                , "	WHERE mp.ProjectName = '", projectName, "'														"
                , "END																								"
                , "ELSE 																							"
                , "DELETE FROM [", schema, "].[", migrationProjectsTbl, "] WHERE [ProjectName] = '", projectName, "';"
                );
        }

        public static string GetSqlAddLinkedServer(string serverName, DbUtil dbu)
        {
            string conString = dbu.GetConnectionString();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(conString);

            return string.Concat(
                 " IF EXISTS(SELECT * FROM [master].sys.servers WHERE name = N'", serverName, "')															"
                , "BEGIN																																    "
                , "	EXEC master.dbo.sp_dropserver @server = N'", serverName, "', @droplogins = 'droplogins';												"
                , "END																																		"
                , "EXEC [master].[dbo].sp_addlinkedserver	 @server =	 N'", serverName, "', @srvproduct=N'SQL Server';									"
                , "EXEC [master].[dbo].sp_addlinkedsrvlogin  @rmtsrvname=N'", serverName, "', @useself=N'False',@locallogin=NULL,@rmtuser=N'", builder.UserID, "',@rmtpassword='", builder.Password, "';"
                , "EXEC [master].[dbo].sp_serveroption		 @server =	 N'", serverName, "', @optname=N'collation compatible', @optvalue=N'false';			"
                , "EXEC [master].[dbo].sp_serveroption		 @server =	 N'", serverName, "', @optname=N'data access', @optvalue=N'true';					"
                , "EXEC [master].[dbo].sp_serveroption		 @server =	 N'", serverName, "', @optname=N'dist', @optvalue=N'false';							"
                , "EXEC [master].[dbo].sp_serveroption		 @server =	 N'", serverName, "', @optname=N'pub', @optvalue=N'false';							"
                , "EXEC [master].[dbo].sp_serveroption		 @server =	 N'", serverName, "', @optname=N'rpc', @optvalue=N'true';							"
                , "EXEC [master].[dbo].sp_serveroption		 @server =	 N'", serverName, "', @optname=N'rpc out', @optvalue=N'true';						"
                , "EXEC [master].[dbo].sp_serveroption		 @server =	 N'", serverName, "', @optname=N'sub', @optvalue=N'false';							"
                , "EXEC [master].[dbo].sp_serveroption		 @server =	 N'", serverName, "', @optname=N'connect timeout', @optvalue=N'0';					"
                , "EXEC [master].[dbo].sp_serveroption		 @server =	 N'", serverName, "', @optname=N'collation name', @optvalue=null;					"
                , "EXEC [master].[dbo].sp_serveroption		 @server =	 N'", serverName, "', @optname=N'lazy schema validation', @optvalue=N'false';		"
                , "EXEC [master].[dbo].sp_serveroption		 @server =	 N'", serverName, "', @optname=N'query timeout', @optvalue=N'0';					"
                , "EXEC [master].[dbo].sp_serveroption		 @server =	 N'", serverName, "', @optname=N'use remote collation', @optvalue=N'true';			"
                , "EXEC [master].[dbo].sp_serveroption		 @server =	 N'", serverName, "', @optname=N'remote proc transaction promotion', @optvalue=N'true';"
                );
        }
        public static string GetSqlAddSynonym(string synonymName, string linkedServerName, string dbName, string schemaName, string tableName)
        {
            if (string.IsNullOrEmpty(synonymName) 
                    || string.IsNullOrEmpty(linkedServerName) 
                    || string.IsNullOrEmpty(dbName)
                    || string.IsNullOrEmpty(schemaName)
                    || string.IsNullOrEmpty(tableName)
                    )

            {
                MessageBox.Show(string.Concat("Check if one of the pf is empty: SrcInstance: [", synonymName
                                , "], linkedServerName: [", linkedServerName, ", dbName: ", dbName
                                , "], schemaName: [", schemaName
                                , "] , tableName: [", tableName
                                , "]"), "Empty fileds for synonym?"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return string.Concat(
                  "DROP SYNONYM IF EXISTS [", synonymName, "];"
                , "CREATE SYNONYM [", synonymName, "] FOR [", linkedServerName, "].[", dbName, "].[", schemaName, "].[", tableName, "];"
                );
        }


        public static string GetSqlProjectListFromProjectTable(string schemaName, string tableName)
        {
            return string.Concat("SELECT [ProjectID] AS [project_id] "
                    , "      ,[ProjectName] AS [ProjectName] "
                    , "FROM   [", schemaName, "].[", tableName, "];");
        }

        public static string GetSqlProjectDescriptionByProjectName(string schemaName, string tableName, string projectName)
        {
            return string.Concat(
                      "SELECT [ProjectDescription]				"
                    , "FROM   [", schemaName, "].[", tableName, "]"
                    , "WHERE  [ProjectName] = '", projectName, "'; "
                );
        }

        public static string GetSqlUpdateProjectTblSetTrackTblSynonyms(string schemaName, string tableName, string projectName, string synonymMigrationProject, string synonymMigrationTrackingTbl)
        {
            return string.Concat(
                 "UPDATE [", schemaName, "].[", tableName, "]								"
                , "SET																		"
                , "       [TrackSynonymProjects] = '", synonymMigrationProject, "'			"
                , "      ,[TrackSynonymMigrationTrck] = '", synonymMigrationTrackingTbl, "'	"
                , "WHERE [ProjectName] = '", projectName, "';								"
                );
        }

        public static string GetSqlMigrationTrackingByProjectName(TreeNode<DbObject> tn)
        {
            string schema = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Schema).Data.ObjectText;
            string migrationProjectsTbl = tn.TraverseUpUntil(tn, (int)DbObjectLevel.Table).Data.ObjectText;
            string migrationTrackingTbl = string.Concat(migrationProjectsTbl, Options.migrationTrackingTblSuffix);
            string migrationProjectName = tn.Data.ObjectText;

            return string.Concat(
                  "SELECT														 ", Environment.NewLine
                , "			     mt.[PartitionId]								 ", Environment.NewLine
                , "			   , mt.[PartitionNumber]						     ", Environment.NewLine
                , "			   , mt.[RowNumSrc]									 ", Environment.NewLine
                , "			   , mt.[RowNumTgt]									 ", Environment.NewLine
                , "			   , mt.[TotalMB]									 ", Environment.NewLine
                , "			   , mt.[UsedMB]									 ", Environment.NewLine
                , "			   , mt.[FilegroupName]								 ", Environment.NewLine
                , "			   , mt.[LowerPartitionBoundary]					 ", Environment.NewLine
                , "			   , mt.[UpperPartitionBoundary]					 ", Environment.NewLine
                , "			   , mt.[Migrated]									 ", Environment.NewLine
                , "			   , mt.[Duration]									 ", Environment.NewLine
                , "			   , mt.[DestinationFlag]							 ", Environment.NewLine
                , "FROM        [", schema, "].[", migrationProjectsTbl, "] AS mp ", Environment.NewLine
                , "INNER JOIN  [", schema, "].[", migrationTrackingTbl, "] AS mt ", Environment.NewLine
                , "ON mp.[ProjectGUID] = mt.[ProjectGUID]                        ", Environment.NewLine
                , "WHERE		mp.[ProjectName] = '", migrationProjectName, "'  ", Environment.NewLine
                , "ORDER BY mt.[PartitionId];"
                );
        }

        public static string GetSqlCreateUspPreloadMigrationTracking(string projectTableSchema, string projectTableName, ProjectFields e, string projectName)
        {
            string tgtInstance = e.TgtInstance;
            string tgtDatabase = e.TgtDatabase;
            return string.Concat(
                      "CREATE OR ALTER PROCEDURE [", projectTableSchema, "].[usp_Preload_", projectTableName, Options.migrationTrackingTblSuffix, "_", projectName, "]", Environment.NewLine
                    , "		 @ProjectName NVARCHAR(256)												  ", Environment.NewLine
                    , "		,@TgtSchema SYSNAME														  ", Environment.NewLine
                    , "		,@TgtTable  SYSNAME														  ", Environment.NewLine
                    , "		,@TgtIndex  SYSNAME														  ", Environment.NewLine
                    , "		,@ArchiveCeiling  DATETIME	= '2022-10-01'								  ", Environment.NewLine
                    , "AS																			  ", Environment.NewLine
                    , "DECLARE @ErrorLine        INT																									", Environment.NewLine
                    , "      , @ErrorState       INT																									", Environment.NewLine
                    , "      , @ErrorNumber      INT																									", Environment.NewLine
                    , "      , @ReturnStatus     INT																									", Environment.NewLine
                    , "      , @ErrorMessage     NVARCHAR(4000)																							", Environment.NewLine
                    , "      , @InputMessage     NVARCHAR(4000)																							", Environment.NewLine
                    , "      , @ErrorSeverity    INT = 11																									", Environment.NewLine
                    , "      , @ErrorProcedure   NVARCHAR(200)																							", Environment.NewLine
                    , "																																	", Environment.NewLine
                    , "IF (SELECT COUNT(1) FROM [", tgtInstance, "].[", tgtDatabase, "].sys.schemas ss WHERE ss.name = @TgtSchema) <> 1					", Environment.NewLine
                    , "BEGIN																															", Environment.NewLine
                    , "    SET @InputMessage = CONCAT('Check if Schema [', @TgtSchema, '] exists in Database: [", tgtInstance, "].[", tgtDatabase, "]');", Environment.NewLine
                    , "    RAISERROR(@InputMessage, @ErrorSeverity, @ErrorState) WITH LOG;																", Environment.NewLine
                    , "END;																															    ", Environment.NewLine
                    , "																																	", Environment.NewLine
                    , "IF (SELECT COUNT(1) FROM [", tgtInstance, "].[", tgtDatabase, "].sys.tables st WHERE st.name = @TgtTable) <> 1					", Environment.NewLine
                    , "BEGIN																															", Environment.NewLine
                    , "    SET @InputMessage = CONCAT('Check if Table [', @TgtTable, '] exists in Database: [", tgtInstance, "].[", tgtDatabase, "]');	", Environment.NewLine
                    , "    RAISERROR(@InputMessage, @ErrorSeverity, @ErrorState) WITH LOG;																", Environment.NewLine
                    , "END;																																", Environment.NewLine
                    , "																																	", Environment.NewLine
                    , "IF (SELECT COUNT(1) FROM [", tgtInstance, "].[", tgtDatabase, "].sys.indexes ix WHERE ix.name = @TgtIndex) <> 1					", Environment.NewLine
                    , "BEGIN																														    ", Environment.NewLine
                    , "    SET @InputMessage = CONCAT('Check if Index [', @TgtIndex, '] exists in Database: [", tgtInstance, "].[", tgtDatabase, "]');	", Environment.NewLine
                    , "    RAISERROR(@InputMessage, @ErrorSeverity, @ErrorState) WITH LOG;																", Environment.NewLine
                    , "END;                                                                                                                             ", Environment.NewLine
                    , "IF (SELECT COUNT(1) FROM [", projectTableSchema, "].[", projectTableName, "] WHERE [ProjectName] = @ProjectName) <> 1		    ", Environment.NewLine
                    , "BEGIN																														    ", Environment.NewLine
                    , "    SET @InputMessage = CONCAT('Check if Project [', @ProjectName, '] exists in [", projectTableSchema, "].[", projectTableName, "]');", Environment.NewLine
                    , "    RAISERROR(@InputMessage, @ErrorSeverity, @ErrorState) WITH LOG;																", Environment.NewLine
                    , "END;                                                                                                                             ", Environment.NewLine
                    , "BEGIN TRY																														", Environment.NewLine
                    , "DECLARE	@ProjectGUID AS UNIQUEIDENTIFIER;				", Environment.NewLine
                    , "SELECT   @ProjectGUID = [ProjectGUID] FROM [", projectTableSchema, "].[", projectTableName, "] WHERE [ProjectName] = @ProjectName;", Environment.NewLine
                    , "; WITH cte AS (																														  ", Environment.NewLine
                    , "				SELECT 																													  ", Environment.NewLine
                    , "				 	  st.name AS [TableName]  																							  ", Environment.NewLine
                    , "				    , ISNULL(QUOTENAME(ix.name),'Heap') AS [IndexName]																	  ", Environment.NewLine
                    , "					, ix.type_desc as [type]																							  ", Environment.NewLine
                    , "					, prt.partition_id AS [PartitionId]																					  ", Environment.NewLine
                    , "					, prt.partition_number AS [PartitionNumber]																			  ", Environment.NewLine
                    , "					, prt.data_compression_desc																							  ", Environment.NewLine
                    , "					, ps.name as [PartitionScheme]																						  ", Environment.NewLine
                    , "					, pf.name as [PartitionFunction]																					  ", Environment.NewLine
                    , "					, fg.name as [FilegroupName]																						  ", Environment.NewLine
                    , "					, CASE WHEN ix.index_id < 2 THEN prt.rows ELSE 0 END AS [RowNumTgt]													  ", Environment.NewLine
                    , "					, au.TotalMB																										  ", Environment.NewLine
                    , "					, au.UsedMB																											  ", Environment.NewLine
                    , "					, c.name AS [ColumnName]																							  ", Environment.NewLine
                    , "					, CASE WHEN pf.boundary_value_on_right = 1 THEN 'less than' WHEN pf.boundary_value_on_right IS NULL THEN '' ELSE 'less than or equal to' END AS Comparison", Environment.NewLine
                    , "				    , CASE WHEN pf.boundary_value_on_right = 1 THEN ISNULL(LAG(rv.value) OVER(PARTITION BY pst.object_id ORDER BY pst.object_id, pst.partition_number), CAST('1753-1-1' AS DATETIME))		", Environment.NewLine
                    , "				    																																														", Environment.NewLine
                    , "				      ELSE NULL END AS [LowerPartitionBoundary]																																				", Environment.NewLine
                    , "					, rv.value AS [UpperPartitionBoundary]																																					", Environment.NewLine
                    , "				    , prt.data_compression_desc                    AS [DataCompression]																														", Environment.NewLine
                    , "																																																			", Environment.NewLine
                    , "				FROM 																																														", Environment.NewLine
                    , "								[", tgtInstance, "].[", tgtDatabase, "].sys.partitions prt																													", Environment.NewLine
                    , "					INNER JOIN  [", tgtInstance, "].[", tgtDatabase, "].sys.indexes ix                      ON ix.object_id = prt.object_id AND ix.index_id = prt.index_id                                  ", Environment.NewLine
                    , "					INNER JOIN  [", tgtInstance, "].[", tgtDatabase, "].sys.tables st                       ON prt.object_id = st.object_id 																", Environment.NewLine
                    , "					INNER JOIN  [", tgtInstance, "].[", tgtDatabase, "].sys.schemas ss					   ON ss.schema_id = st.schema_id																	", Environment.NewLine
                    , "					INNER JOIN  [", tgtInstance, "].[", tgtDatabase, "].sys.index_columns ic                ON (ic.partition_ordinal > 0 AND ic.index_id = ix.index_id AND ic.object_id = st.object_id)     ", Environment.NewLine
                    , "					INNER JOIN  [", tgtInstance, "].[", tgtDatabase, "].sys.columns c                       ON (c.object_id = ic.object_id AND c.column_id = ic.column_id)                                  ", Environment.NewLine
                    , "					INNER JOIN  [", tgtInstance, "].[", tgtDatabase, "].sys.data_spaces ds                  ON ds.data_space_id = ix.data_space_id                                                          ", Environment.NewLine
                    , "					LEFT JOIN   [", tgtInstance, "].[", tgtDatabase, "].sys.partition_schemes ps            ON ps.data_space_id = ix.data_space_id                                                          ", Environment.NewLine
                    , "					LEFT JOIN   [", tgtInstance, "].[", tgtDatabase, "].sys.partition_functions pf          ON pf.function_id = ps.function_id                                                              ", Environment.NewLine
                    , "					LEFT JOIN   [", tgtInstance, "].[", tgtDatabase, "].sys.partition_range_values rv       ON rv.function_id = pf.function_id AND rv.boundary_id = prt.partition_number                    ", Environment.NewLine
                    , "					LEFT JOIN   [", tgtInstance, "].[", tgtDatabase, "].sys.destination_data_spaces dds     ON dds.partition_scheme_id = ps.data_space_id AND dds.destination_id = prt.partition_number     ", Environment.NewLine
                    , "					LEFT JOIN   [", tgtInstance, "].[", tgtDatabase, "].sys.filegroups fg                   ON fg.data_space_id = ISNULL(dds.data_space_id,ix.data_space_id)                                ", Environment.NewLine
                    , "					INNER JOIN (																																											", Environment.NewLine
                    , "									SELECT 																																									", Environment.NewLine
                    , "				                                 SUM(total_pages)*8./1024 as [TotalMB]																														", Environment.NewLine
                    , "				                                ,SUM(used_pages)*8./1024 as [UsedMB]																														", Environment.NewLine
                    , "										        ,container_id																																				", Environment.NewLine
                    , "									FROM        [", tgtInstance, "].[", tgtDatabase, "].sys.allocation_units																								", Environment.NewLine
                    , "									GROUP BY    container_id																																				", Environment.NewLine
                    , "								)   AS [au]																																									", Environment.NewLine
                    , "								ON  au.container_id = prt.partition_id																																		", Environment.NewLine
                    , "				    INNER JOIN [", tgtInstance, "].[", tgtDatabase, "].sys.dm_db_partition_stats pst            ON pst.partition_id = prt.partition_id														", Environment.NewLine
                    , "																																																			", Environment.NewLine
                    , "				WHERE ss.name = @TgtSchema", Environment.NewLine
                    , "				AND st.name   = @TgtTable ", Environment.NewLine
                    , "				AND ix.name   = @TgtIndex ", Environment.NewLine
                    , ")																									", Environment.NewLine
                    , "INSERT INTO [", projectTableSchema, "].[", projectTableName, Options.migrationTrackingTblSuffix, "]	", Environment.NewLine
                    , "           ([ProjectGUID]																			", Environment.NewLine
                    , "           ,[PartitionId]																			", Environment.NewLine
                    , "		      ,[PartitionNumber]																		", Environment.NewLine
                    , "           ,[RowNumSrc]																				", Environment.NewLine
                    , "           ,[RowNumTgt]																				", Environment.NewLine
                    , "           ,[TotalMB]																				", Environment.NewLine
                    , "           ,[UsedMB]																					", Environment.NewLine
                    , "           ,[FilegroupName]																			", Environment.NewLine
                    , "           ,[LowerPartitionBoundary]																	", Environment.NewLine
                    , "           ,[UpperPartitionBoundary]																	", Environment.NewLine
                    , "           ,[Migrated]																				", Environment.NewLine
                    , "           ,[DestinationFlag])																		", Environment.NewLine
                    , "																										", Environment.NewLine
                    , "SELECT																								", Environment.NewLine
                    , "			  @ProjectGUID																				", Environment.NewLine
                    , "			, cte.[PartitionId]																			", Environment.NewLine
                    , "			, cte.[PartitionNumber]																		", Environment.NewLine
                    , "			, NULL AS [RowNumSrc]																		", Environment.NewLine
                    , "			, cte.[RowNumTgt]																			", Environment.NewLine
                    , "			, STR(cte.[TotalMB], 10,2) AS [TotalMB]														", Environment.NewLine
                    , "			, STR(cte.[UsedMB], 10,2)  AS [UsedMB]														", Environment.NewLine
                    , "			, cte.[FilegroupName]																		", Environment.NewLine
                    , "			, CONVERT(DATETIME, cte.[LowerPartitionBoundary]) AS [LowerPartitionBoundary]				", Environment.NewLine
                    , "			, CONVERT(DATETIME, cte.[UpperPartitionBoundary]) AS [UpperPartitionBoundary]				", Environment.NewLine
                    , "			, 0                                               AS [Migrated]								", Environment.NewLine
                    , "			, CASE WHEN CONVERT(DATETIME, cte.[UpperPartitionBoundary]) <= @ArchiveCeiling				", Environment.NewLine
                    , "			  THEN 'A' ELSE 'C' END AS [DestinationFlag]				                                ", Environment.NewLine
                    , "FROM		cte 																						", Environment.NewLine
                    , "ORDER BY	cte.[PartitionNumber]", Environment.NewLine
                    , "END TRY																												", Environment.NewLine
                    , "BEGIN CATCH																											", Environment.NewLine
                    , "    IF @@TRANCOUNT <> 0																								", Environment.NewLine
                    , "        ROLLBACK TRAN;																								", Environment.NewLine
                    , "    SET @ErrorNumber = ERROR_NUMBER();																				", Environment.NewLine
                    , "    SET @ErrorSeverity = ERROR_SEVERITY();																			", Environment.NewLine
                    , "    SET @ErrorState = ERROR_STATE();																					", Environment.NewLine
                    , "    SET @ErrorLine = ERROR_LINE();																					", Environment.NewLine
                    , "    SET @ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-');															", Environment.NewLine
                    , "    SET @ErrorMessage = ERROR_MESSAGE();																				", Environment.NewLine
                    , "    SET @ErrorMessage = '[", projectTableSchema, "].[usp_Preload_", projectTableName, Options.migrationTrackingTblSuffix, "]' + N': ' + @ErrorMessage;				", Environment.NewLine
                    , "																														", Environment.NewLine
                    , "	RAISERROR(@ErrorMessage, ", 17, ", 1, @ErrorNumber, @ErrorSeverity, @ErrorState, @ErrorProcedure, @ErrorLine)	", Environment.NewLine
                    , "END CATCH;																											", Environment.NewLine
                );
        }

        public static string GetSqlCreateUspInsertIntoTargetTable(    string srcInstance
                                                                    , string srcDatabase
                                                                    , string tgtInstance
                                                                    , string tgtDatabase
                                                                    , string tgtTableSchema
                                                                    , string tgtTableName
                                                                    )
        {
            return string.Concat(
              "CREATE OR ALTER PROCEDURE [dbo].[usp_Insert_Into_Target_Table]																								", Environment.NewLine
            , "   @SourceSchemaName NVARCHAR(256)																															", Environment.NewLine
            , " , @SourceTableName NVARCHAR(256)																															", Environment.NewLine
            , "	, @SourceColumnName NVARCHAR(256)																															", Environment.NewLine
            , "	, @SourceIndexName NVARCHAR(256)																															", Environment.NewLine
            , " , @SourceSynonym NVARCHAR(256)																																", Environment.NewLine
            , "																																								", Environment.NewLine
            , "	, @TargetSchemaName NVARCHAR(256)																															", Environment.NewLine
            , " , @TargetTableName NVARCHAR(256)																															", Environment.NewLine
            , "	, @TargetSynonym NVARCHAR(256)																																", Environment.NewLine
            , " , @FromDate DATETIME																																		", Environment.NewLine
            , " , @ToDate DATETIME																																			", Environment.NewLine
            , "AS																																							", Environment.NewLine
            , "BEGIN																																						", Environment.NewLine
            , "	SET NOCOUNT ON;																																				", Environment.NewLine
            , " SET XACT_ABORT ON;																																		    ", Environment.NewLine
            , "																																								", Environment.NewLine            
            , "DECLARE @SourceSchemaNameQt NVARCHAR(256) = QUOTENAME(@SourceSchemaName)																							", Environment.NewLine
            , "DECLARE @SourceTableNameQt NVARCHAR(256) = QUOTENAME(@SourceTableName)																							", Environment.NewLine
            , "DECLARE @SourceSynonymQt NVARCHAR(256) = QUOTENAME(@SourceSynonym)																								", Environment.NewLine
            , "																																									", Environment.NewLine
            , "DECLARE @TargetSchemaNameQt NVARCHAR(256) = QUOTENAME(@TargetSchemaName)																							", Environment.NewLine
            , "DECLARE @TargetTableNameQt NVARCHAR(256) = QUOTENAME(@TargetTableName)																							", Environment.NewLine
            , "DECLARE @TargetSynonymQt NVARCHAR(256) = QUOTENAME(@TargetSynonym)																								", Environment.NewLine
            , "																																									", Environment.NewLine
            , "DECLARE @Sql NVARCHAR(MAX)																																		", Environment.NewLine
            , "DECLARE @ColumnListSource NVARCHAR(MAX)																															", Environment.NewLine
            , "DECLARE @ColumnListTarget NVARCHAR(MAX)																															", Environment.NewLine
            , "DECLARE @ErrMsg VARCHAR(MAX)																																		", Environment.NewLine
            , "																																									", Environment.NewLine            
            , "; WITH cte AS (																																					", Environment.NewLine
            , "    SELECT DISTINCT																																				", Environment.NewLine
            , "                '  ['+col.column_name+'] '    AS [ColumnName]  																									", Environment.NewLine
            , "    FROM          [", srcInstance, "].[", srcDatabase, "].INFORMATION_SCHEMA.COLUMNS  col																			", Environment.NewLine
            , "    INNER JOIN    [", srcInstance, "].[", srcDatabase, "].INFORMATION_SCHEMA.TABLES   tbl ON tbl.TABLE_NAME = col.TABLE_NAME										", Environment.NewLine
            , "    WHERE         																																				", Environment.NewLine
            , "    tbl.table_schema            = @SourceSchemaName AND 																											", Environment.NewLine
            , "    tbl.table_name              = @SourceTableName          																										", Environment.NewLine
            , "),																																								", Environment.NewLine
            , "colListNumbered AS (																																				", Environment.NewLine
            , "SELECT 																																							", Environment.NewLine
            , "    ROW_NUMBER() OVER (ORDER BY cte.ColumnName) AS [ColumnNumber],																								", Environment.NewLine
            , "    cte.ColumnName																																				", Environment.NewLine
            , "FROM cte																																							", Environment.NewLine
            , "),																																								", Environment.NewLine
            , "mcv AS (																																							", Environment.NewLine
            , "    SELECT MAX(colListNumbered.[ColumnNumber]) AS MaxColNrVal FROM colListNumbered																				", Environment.NewLine
            , "),																																								", Environment.NewLine
            , "colListFinal AS (																																					", Environment.NewLine
            , "    SELECT  -- adding a comma to all columns except for the last one:																								", Environment.NewLine
            , "            CASE WHEN cln.[ColumnNumber] < (SELECT TOP 1 (mcv.MaxColNrVal) FROM mcv) THEN cln.[ColumnName]+',' ELSE cln.[ColumnName] END AS [ColumnNames]			", Environment.NewLine
            , "    FROM    colListNumbered cln																																	", Environment.NewLine
            , ")																																									", Environment.NewLine
            , "SELECT @ColumnListSource = 																																		", Environment.NewLine
            , "(																																									", Environment.NewLine
            , "     -- flatten all rows into a single row:																														", Environment.NewLine
            , "     SELECT SUBSTRING([ColumnNames], 0, 9999) 																													", Environment.NewLine
            , "     FROM colListFinal FOR XML PATH('') 																															", Environment.NewLine
            , ")																																									", Environment.NewLine            
            , "; WITH cte AS (																																					", Environment.NewLine
            , "    SELECT DISTINCT																																				", Environment.NewLine
            , "                '  ['+col.column_name+'] '    AS [ColumnName]  																									", Environment.NewLine
            , "    FROM          [", tgtInstance, "].[", tgtDatabase, "].INFORMATION_SCHEMA.COLUMNS  col																			", Environment.NewLine
            , "    INNER JOIN    [", tgtInstance, "].[", tgtDatabase, "].INFORMATION_SCHEMA.TABLES   tbl ON tbl.TABLE_NAME = col.TABLE_NAME										", Environment.NewLine
            , "    WHERE         																																				", Environment.NewLine
            , "    tbl.table_schema            = @TargetSchemaName AND 																											", Environment.NewLine
            , "    tbl.table_name              = @TargetTableName          																										", Environment.NewLine
            , "),																																								", Environment.NewLine
            , "colListNumbered AS (																																				", Environment.NewLine
            , "SELECT 																																							", Environment.NewLine
            , "    ROW_NUMBER() OVER (ORDER BY cte.ColumnName) AS [ColumnNumber],																								", Environment.NewLine
            , "    cte.ColumnName																																				", Environment.NewLine
            , "FROM cte																																							", Environment.NewLine
            , "),																																								", Environment.NewLine
            , "mcv AS (																																							", Environment.NewLine
            , "    SELECT MAX(colListNumbered.[ColumnNumber]) AS MaxColNrVal FROM colListNumbered																				", Environment.NewLine
            , "),																																								", Environment.NewLine
            , "colListFinal AS (																																					", Environment.NewLine
            , "    SELECT  -- adding a comma to all columns except for the last one:																								", Environment.NewLine
            , "            CASE WHEN cln.[ColumnNumber] < (SELECT TOP 1 (mcv.MaxColNrVal) FROM mcv) THEN cln.[ColumnName]+',' ELSE cln.[ColumnName] END AS [ColumnNames]			", Environment.NewLine
            , "    FROM    colListNumbered cln																																	", Environment.NewLine
            , ")																																									", Environment.NewLine
            , "SELECT @ColumnListTarget = 																																		", Environment.NewLine
            , "(																																									", Environment.NewLine
            , "     -- flatten all rows into a single row:																														", Environment.NewLine
            , "     SELECT SUBSTRING([ColumnNames], 0, 9999)																														", Environment.NewLine
            , "     FROM colListFinal FOR XML PATH('') 																															", Environment.NewLine
            , ")																																									", Environment.NewLine            
            , "IF ((@ColumnListSource IS NULL OR @ColumnListTarget IS NULL) OR (@ColumnListSource <> @ColumnListTarget))															", Environment.NewLine
            , "BEGIN																																								", Environment.NewLine
            , "      SET @ErrMsg = 'Error executing: ' + COALESCE(OBJECT_NAME(@@PROCID), 'Unknown procedure') + CHAR(13) + '														", Environment.NewLine
            , "      Lists of columns collected for tables: '+@SourceSchemaNameQt+'.'+@SourceTableNameQt+' and '+@TargetSchemaNameQt+'.'+@TargetTableNameQt+' do not match or are emty'+ CHAR(13)", Environment.NewLine
            , "      ;THROW 99001, @ErrMsg, 1;																																				", Environment.NewLine
            , "END																																											", Environment.NewLine            
            , "																																												", Environment.NewLine
            , "PRINT(CONCAT('Inserting from source table: ', @SourceSchemaNameQt, '.', @SourceTableNameQt																					", Environment.NewLine
            , ", ' into table: ', @TargetSchemaNameQt, '.', @TargetTableNameQt, ' with date range from: ', +CONVERT(NVARCHAR(64), @FromDate), ' to: ', CONVERT(NVARCHAR(64), @ToDate)))		", Environment.NewLine
            , "																																												", Environment.NewLine
            , "SET @Sql = N'INSERT INTO [", tgtDatabase, "].'+@TargetSchemaNameQt+'.'+@TargetTableNameQt+'																						", Environment.NewLine
            , "        (																																									", Environment.NewLine
            , "         '+@ColumnListTarget+'																																				", Environment.NewLine
            , "        )																																									", Environment.NewLine
            , "        SELECT 																																								", Environment.NewLine
            , "         '+@ColumnListSource+'																																				", Environment.NewLine
            , "		FROM '+@SourceSynonymQt+' WHERE '+@SourceColumnName+' >= '''+CONVERT(NVARCHAR(64), @FromDate)+''' AND '+@SourceColumnName+' < '''+CONVERT(NVARCHAR(64), @ToDate)+''';'	", Environment.NewLine
            , "EXEC sp_executesql @Sql																																						", Environment.NewLine
            , "END;																																											", Environment.NewLine
            );
        }

        public static string GetSqlUspGetCountFromSrc(string projectTableSchema)
        {
            return string.Concat(
              "CREATE OR ALTER PROCEDURE [", projectTableSchema, "].[usp_GetCountFromSource]", Environment.NewLine
            , "   @SourceSynonym NVARCHAR(256)									", Environment.NewLine
            , "	, @ColumnName NVARCHAR(256)										", Environment.NewLine
            , " , @FromDate DATETIME											", Environment.NewLine
            , " , @ToDate DATETIME												", Environment.NewLine
            , " , @Count BIGINT OUTPUT											", Environment.NewLine
            , "AS																", Environment.NewLine
            , "BEGIN														    ", Environment.NewLine
            , "	SET NOCOUNT ON;														", Environment.NewLine
            , "    SET XACT_ABORT ON;												", Environment.NewLine
            , "DECLARE @SourceSynonymQtd NVARCHAR(256) = QUOTENAME(@SourceSynonym)	", Environment.NewLine
            , "DECLARE @Sql NVARCHAR(MAX)											", Environment.NewLine
            , "DECLARE @Parameter NVARCHAR(500);									", Environment.NewLine
            , "BEGIN																", Environment.NewLine
            , "    SET @Sql = CONCAT(N'SELECT @_count = COUNT_BIG(*) FROM '			", Environment.NewLine
            , "				,@SourceSynonymQtd										", Environment.NewLine
            , "				,' WHERE ', @ColumnName, ' >= '''						", Environment.NewLine
            , "				,CONVERT(NVARCHAR(64), @FromDate)						", Environment.NewLine
            , "				,''' AND ', @ColumnName, ' < '''						", Environment.NewLine
            , "				,CONVERT(NVARCHAR(64), @ToDate)+''';')					", Environment.NewLine
            , "END																	", Environment.NewLine
            , "SET @Parameter = N'@_count varchar(30) OUTPUT'						", Environment.NewLine
            , "EXECUTE sp_executesql @Sql, @Parameter, @_count = @Count OUTPUT		", Environment.NewLine
            , "END																	", Environment.NewLine
                );
        }

        public static string GetSqlUspUpdateMigrationTrackingSrcCountPerProjectName(
              string projectTableSchema
            , string projectTableName
            , string projectName
            , string sourceSynonym
            , string sourceInstance
            , string sourceDatabase
            , string sourceSchema
            , string sourceTable
            , string sourceColumn

            )
        {
            return string.Concat(
                  "CREATE OR ALTER PROCEDURE [", projectTableSchema, "].[usp_Update_", projectTableSchema, projectTableName, Options.migrationTrackingTblSuffix, "_SrcCountPer_", projectName, "]", Environment.NewLine
                , "@ProjectName NVARCHAR(256)														 ", Environment.NewLine
                , "AS																				 ", Environment.NewLine
                , "BEGIN																			 ", Environment.NewLine
                , "DECLARE 																			 ", Environment.NewLine
                , "  @ProjectGUID			UNIQUEIDENTIFIER										 ", Environment.NewLine
                , ", @SourceSynonym		    NVARCHAR(256)											 ", Environment.NewLine
                , ", @ColumnName			NVARCHAR(256)											 ", Environment.NewLine
                , ", @FromDate				DATETIME	 											 ", Environment.NewLine
                , ", @ToDate				DATETIME	 											 ", Environment.NewLine
                , ", @PartitionNumber		INT														 ", Environment.NewLine
                , ", @MaxPartitionNumber	INT														 ", Environment.NewLine
                , ", @RowCount				BIGINT													 ", Environment.NewLine
                , ", @_count                BIGINT                                                   ", Environment.NewLine
                , ", @sql                   NVARCHAR(MAX)                                            ", Environment.NewLine
                , ", @SourceSynonymQtd      NVARCHAR(256)                                            ", Environment.NewLine
                , ", @Parameter NVARCHAR(500)                                                        ", Environment.NewLine 
                , "SELECT  @ProjectGUID    = mp.[ProjectGUID]									     ", Environment.NewLine
                , "		  ,@SourceSynonym  = mp.[SrcSynonym]										 ", Environment.NewLine
                , "		  ,@ColumnName	   = mp.[SrcColumn]											 ", Environment.NewLine
                , "FROM       [", projectTableSchema, "].[", projectTableName, "] AS mp				 ", Environment.NewLine
                , "INNER JOIN [", projectTableSchema, "].[", projectTableName, Options.migrationTrackingTblSuffix, "]  AS mt	 ", Environment.NewLine
                , "ON         mp.[ProjectGUID] = mt.[ProjectGUID]									 ", Environment.NewLine
                , "WHERE	   mp.[ProjectName] = @ProjectName										 ", Environment.NewLine
                , "																					 ", Environment.NewLine
                , "SELECT  @PartitionNumber = MIN(mt.[PartitionNumber])								 ", Environment.NewLine
                , "	   ,@MaxPartitionNumber = MAX(mt.[PartitionNumber])								 ", Environment.NewLine
                , "FROM	[", projectTableSchema, "].[", projectTableName, Options.migrationTrackingTblSuffix, "]  AS mt		 ", Environment.NewLine
                , "WHERE	mt.[ProjectGUID] = @ProjectGUID											 ", Environment.NewLine
                , "																					 ", Environment.NewLine
                , "WHILE (@PartitionNumber <= @MaxPartitionNumber)									 ", Environment.NewLine
                , "BEGIN																			  ", Environment.NewLine
                , "		SELECT @FromDate = mt.[LowerPartitionBoundary]								 ", Environment.NewLine
                , "			  ,@ToDate	 = mt.[UpperPartitionBoundary]								 ", Environment.NewLine
                , "		FROM [", projectTableSchema, "].[", projectTableName, Options.migrationTrackingTblSuffix, "] AS mt	 ", Environment.NewLine
                , "		WHERE mt.[ProjectGUID] = @ProjectGUID										 ", Environment.NewLine
                , "		AND mt.PartitionNumber = @PartitionNumber									 ", Environment.NewLine
                , "     SELECT @RowCount = COUNT_BIG(*) FROM [", sourceSynonym, "]", Environment.NewLine
                , "     WHERE ", sourceColumn, " >= @FromDate AND ", sourceColumn, " < @ToDate ", Environment.NewLine
                , "		UPDATE mt 																	 ", Environment.NewLine
                , "		SET [RowNumSrc] = @RowCount													 ", Environment.NewLine
                , "		FROM [", projectTableSchema, "].[", projectTableName, Options.migrationTrackingTblSuffix, "] AS mt	 ", Environment.NewLine
                , "		WHERE mt.[ProjectGUID] = @ProjectGUID										 ", Environment.NewLine
                , "		AND mt.PartitionNumber = @PartitionNumber									 ", Environment.NewLine
                , "		SET @PartitionNumber = @PartitionNumber + 1								 ", Environment.NewLine
                , "END "
                , "END"
                );
        }

        public static string GetSqlRunMigrationProject(
                                                       string projectName
                                                     , string projectTableSchema
                                                     , string projectTableName
                                                     , string tgtDatabase
                                                     , string tgtSchemaArchive
                                                     , string tgtSchemaCurrent
                                                     , string tgtTableArchive
                                                     , string tgtTableCurrent
                                                     , string tgtColumnListArchive
                                                     , string tgtColumnListCurrent
                                                     , string srcColumnList
                                                     , string srcInstance
                                                     , string srcDatabase
                                                     , string srcSchema
                                                     , string srcTable
                                                     , string srcColumn
            )
        {
            return string.Concat(
                 "CREATE OR ALTER PROCEDURE [dbo].[usp_RunMigrationProject_", projectName, "] 											", Environment.NewLine
                , "  @ProjectName				NVARCHAR(256)																			 ", Environment.NewLine
                , ", @StopAtDate                 DATETIME	 																			 ", Environment.NewLine
                , "AS																													 ", Environment.NewLine
                , "BEGIN																													 ", Environment.NewLine
                , "	SET NOCOUNT ON;																										 ", Environment.NewLine
                , "																														 ", Environment.NewLine
                , "DECLARE 																												 ", Environment.NewLine
                , "  @MigratedCount				INT																						 ", Environment.NewLine
                , ", @ErrorMsg						NVARCHAR(256)																		 ", Environment.NewLine
                , ", @PartitionId                  BIGINT																				 ", Environment.NewLine
                , ", @MaxPartitionId               BIGINT																				 ", Environment.NewLine
                , ", @PartitionNumber              INT																					 ", Environment.NewLine
                , ", @MaxPartitionNumber           INT																					 ", Environment.NewLine
                , ", @RowCountSrc					BIGINT																				 ", Environment.NewLine
                , ", @RowCountTgt					BIGINT																				 ", Environment.NewLine
                , ", @LowerPartitionBoundary		DATETIME																				 ", Environment.NewLine
                , ", @UpperPartitionBoundary		DATETIME																				 ", Environment.NewLine
                , ", @_SourceSchemaName            NVARCHAR(256)																			 ", Environment.NewLine
                , ", @_SourceTableName             NVARCHAR(256)																			 ", Environment.NewLine
                , ", @_SourceColumnName			NVARCHAR(256)																			 ", Environment.NewLine
                , ", @_SourceIndexName				NVARCHAR(256)																		 ", Environment.NewLine
                , ", @_SourceSynonym				NVARCHAR(256)																			 ", Environment.NewLine
                , ", @_TargetCurrentSchemaName     NVARCHAR(256)																			 ", Environment.NewLine
                , ", @_TargetCurrentTableName      NVARCHAR(256)																			 ", Environment.NewLine
                , ", @_TargetArchiveSchemaName     NVARCHAR(256)																			 ", Environment.NewLine
                , ", @_TargetArchiveTableName      NVARCHAR(256)																			 ", Environment.NewLine
                , ", @_TargetColumnName            NVARCHAR(256)																			 ", Environment.NewLine
                , ", @_TargetSynonym				NVARCHAR(256)																			 ", Environment.NewLine
                , ", @Duration_Start               DATETIME																				 ", Environment.NewLine
                , ", @Duration_Stop                DATETIME																				 ", Environment.NewLine
                , ", @Duration                     BIGINT																				 ", Environment.NewLine
                , ", @DestinationFlag				NVARCHAR(2)																			 ", Environment.NewLine
                , "																														 ", Environment.NewLine
                , "																														 ", Environment.NewLine
                , "IF		(																											 ", Environment.NewLine
                , "			SELECT		COUNT(*)																						 ", Environment.NewLine
                , "			FROM		[", projectTableSchema, "].[", projectTableName, Options.migrationTrackingTblSuffix, "] AS mt	 ", Environment.NewLine
                , "			INNER JOIN	[", projectTableSchema, "].[", projectTableName, "] AS mp ON mp.[ProjectGUID] = mt.[ProjectGUID] ", Environment.NewLine
                , "			WHERE		mp.[ProjectName]  = @ProjectName																 ", Environment.NewLine
                , "		)	= 0																											 ", Environment.NewLine
                , "BEGIN																													 ", Environment.NewLine
                , "	SET @ErrorMsg = CONCAT('Could not find any records for Project: '													 ", Environment.NewLine
                , ", @ProjectName, ' in [", projectTableSchema, "].[", projectTableName, Options.migrationTrackingTblSuffix, "]')		 ", Environment.NewLine
                , "	RAISERROR(@ErrorMsg, 14, 10)																						 ", Environment.NewLine
                , "END																													 ", Environment.NewLine
                , "																														 ", Environment.NewLine
                , "																														 ", Environment.NewLine
                , "SELECT 																												 ", Environment.NewLine
                , "		    @_SourceSchemaName = mp.[SrcTableSchema]																	 ", Environment.NewLine
                , "		  , @_SourceTableName  = mp.[SrcTableName]																		 ", Environment.NewLine
                , "		  , @_SourceColumnName = mp.[SrcColumn]																			 ", Environment.NewLine
                , "		  , @_SourceIndexName  = mp.[SrcTableIndex]																		 ", Environment.NewLine
                , "		  , @_SourceSynonym	   = mp.[SrcSynonym]																		 ", Environment.NewLine
                , "		  , @_TargetCurrentSchemaName = mp.[TgtCurrentSchema]															 ", Environment.NewLine
                , "		  , @_TargetCurrentTableName  = mp.[TgtCurrentTable]															 ", Environment.NewLine
                , "		  , @_TargetArchiveSchemaName = mp.[TgtArchiveSchema]															 ", Environment.NewLine
                , "		  , @_TargetArchiveTableName  = mp.[TgtArchiveTable]															 ", Environment.NewLine
                , "		  , @_TargetColumnName = mp.[TgtColumn]																			 ", Environment.NewLine
                , "		  , @_TargetSynonym	   = mp.[TgtSynonym]																		 ", Environment.NewLine
                , "FROM		[", projectTableSchema, "].[", projectTableName, Options.migrationTrackingTblSuffix, "] AS mt				 ", Environment.NewLine
                , "INNER JOIN	[", projectTableSchema, "].[", projectTableName, "] AS mp ON mp.[ProjectGUID] = mt.[ProjectGUID]		 ", Environment.NewLine
                , "WHERE		mp.[ProjectName]  = @ProjectName																			 ", Environment.NewLine
                , "																														 ", Environment.NewLine
                , "																														 ", Environment.NewLine
                , "																														 ", Environment.NewLine
                , "IF	(																												 ", Environment.NewLine
                , "		SELECT		COUNT_BIG(*)																						 ", Environment.NewLine
                , "		FROM		[", projectTableSchema, "].[", projectTableName, Options.migrationTrackingTblSuffix, "] AS mt		 ", Environment.NewLine
                , "		INNER JOIN	[", projectTableSchema, "].[", projectTableName, "] AS mp ON mp.[ProjectGUID] = mt.[ProjectGUID]	 ", Environment.NewLine
                , "		WHERE		mp.[ProjectName]  = @ProjectName																	 ", Environment.NewLine
                , "		AND			mt.[migrated] = 0																					 ", Environment.NewLine
                , "	) < 1																												 ", Environment.NewLine
                , "BEGIN																													 ", Environment.NewLine
                , "	SET @ErrorMsg = CONCAT('No records to be migrated found for Project: ',  @ProjectName)								 ", Environment.NewLine
                , "	RAISERROR(@ErrorMsg, 14, 10)																						 ", Environment.NewLine
                , "END																													 ", Environment.NewLine
                , "																														 ", Environment.NewLine
                , "																														 ", Environment.NewLine
                , "SELECT		@MigratedCount = COUNT(*)																				 ", Environment.NewLine
                , "FROM		[", projectTableSchema, "].[", projectTableName, Options.migrationTrackingTblSuffix, "] AS mt				 ", Environment.NewLine
                , "INNER JOIN	[", projectTableSchema, "].[", projectTableName, "] AS mp ON mp.[ProjectGUID] = mt.[ProjectGUID]		 ", Environment.NewLine
                , "WHERE		mp.[ProjectName]  = @ProjectName																			 ", Environment.NewLine
                , "AND			mt.[migrated] = 1																						 ", Environment.NewLine
                , "																														 ", Environment.NewLine
                , "IF	(@MigratedCount) > 0																							 ", Environment.NewLine
                , "BEGIN																													 ", Environment.NewLine
                , "SET @LowerPartitionBoundary =  COALESCE((																										", Environment.NewLine
                , "								SELECT		MIN([LowerPartitionBoundary])																		", Environment.NewLine
                , "								FROM		[", projectTableSchema, "].[", projectTableName, Options.migrationTrackingTblSuffix, "] AS mt		", Environment.NewLine
                , "								INNER JOIN	[", projectTableSchema, "].[", projectTableName, "] AS mp ON mp.[ProjectGUID] = mt.[ProjectGUID]	", Environment.NewLine
                , "								WHERE		mp.[ProjectName] = @ProjectName																		", Environment.NewLine
                , "								AND			mt.[migrated] = 0																					", Environment.NewLine
                , "								AND			mt.[LowerPartitionBoundary] IS NOT NULL), CAST('1753-1-1' AS DATETIME))								", Environment.NewLine
                , "SET @UpperPartitionBoundary =  (																												", Environment.NewLine
                , "								SELECT		MIN([UpperPartitionBoundary])																		", Environment.NewLine
                , "								FROM		[", projectTableSchema, "].[", projectTableName, Options.migrationTrackingTblSuffix, "] AS mt		", Environment.NewLine
                , "								INNER JOIN	[", projectTableSchema, "].[", projectTableName, "] AS mp ON mp.[ProjectGUID] = mt.[ProjectGUID]	", Environment.NewLine
                , "								WHERE		mp.[ProjectName] = @ProjectName																		", Environment.NewLine
                , "								AND			mt.[migrated] = 0																					", Environment.NewLine
                , "								AND			mt.[UpperPartitionBoundary] IS NOT NULL)															", Environment.NewLine
                , "END																																			", Environment.NewLine
                , "ELSE 																																			", Environment.NewLine
                , "BEGIN																																			", Environment.NewLine
                , "SET @LowerPartitionBoundary =  COALESCE((																										", Environment.NewLine
                , "								SELECT		MIN([LowerPartitionBoundary])																		", Environment.NewLine
                , "								FROM		[", projectTableSchema, "].[", projectTableName, Options.migrationTrackingTblSuffix, "] AS mt		", Environment.NewLine
                , "								INNER JOIN	[", projectTableSchema, "].[", projectTableName, "] AS mp ON mp.[ProjectGUID] = mt.[ProjectGUID]	", Environment.NewLine
                , "								WHERE		mp.[ProjectName] = @ProjectName																		", Environment.NewLine
                , "								AND			mt.[LowerPartitionBoundary] IS NOT NULL), CAST('1753-1-1' AS DATETIME))								", Environment.NewLine
                , "SET @UpperPartitionBoundary =  (																												", Environment.NewLine
                , "								SELECT		MIN([UpperPartitionBoundary])																		", Environment.NewLine
                , "								FROM		[", projectTableSchema, "].[", projectTableName, Options.migrationTrackingTblSuffix, "] AS mt		", Environment.NewLine
                , "								INNER JOIN	[", projectTableSchema, "].[", projectTableName, "] AS mp ON mp.[ProjectGUID] = mt.[ProjectGUID]	", Environment.NewLine
                , "								WHERE		mp.[ProjectName] = @ProjectName																		", Environment.NewLine
                , "								AND			mt.[UpperPartitionBoundary] IS NOT NULL)															", Environment.NewLine
                , "END																																			", Environment.NewLine
                , "																																				", Environment.NewLine
                , "SELECT		@PartitionNumber = MIN([PartitionNumber]) 																						", Environment.NewLine
                , "		   ,@PartitionId = MIN([PartitionId])																									", Environment.NewLine
                , "FROM		[", projectTableSchema, "].[", projectTableName, Options.migrationTrackingTblSuffix, "] AS mt										", Environment.NewLine
                , "INNER JOIN	[", projectTableSchema, "].[", projectTableName, "] AS mp ON mp.[ProjectGUID] = mt.[ProjectGUID]								", Environment.NewLine
                , "WHERE		mp.[ProjectName] = @ProjectName																										", Environment.NewLine
                , "AND			mt.[migrated] = 0																												", Environment.NewLine
                , "																																				", Environment.NewLine
                , "SELECT		@MaxPartitionNumber = MAX([PartitionNumber])																					", Environment.NewLine
                , "		   ,@MaxPartitionId = MAX([PartitionId]) 																								", Environment.NewLine
                , "FROM		[", projectTableSchema, "].[", projectTableName, Options.migrationTrackingTblSuffix, "] AS mt										", Environment.NewLine
                , "INNER JOIN	[", projectTableSchema, "].[", projectTableName, "] AS mp ON mp.[ProjectGUID] = mt.[ProjectGUID]								", Environment.NewLine
                , "WHERE		mp.[ProjectName] = @ProjectName																										", Environment.NewLine
                , "AND			mt.[migrated] = 0																												", Environment.NewLine
                , "																																				", Environment.NewLine
                , "WHILE ((@PartitionId <= @MaxPartitionId) AND (@UpperPartitionBoundary <= @StopAtDate))														", Environment.NewLine
                , "BEGIN																																			", Environment.NewLine
                , "        SELECT																																", Environment.NewLine
                , "				    @DestinationFlag						= mt.[DestinationFlag]																", Environment.NewLine
                , "		FROM		[", projectTableSchema, "].[", projectTableName, Options.migrationTrackingTblSuffix, "] AS mt								", Environment.NewLine
                , "		INNER JOIN	[", projectTableSchema, "].[", projectTableName, "]			 AS mp ON mp.[ProjectGUID] = mt.[ProjectGUID]					", Environment.NewLine
                , "		WHERE		mp.[ProjectName]						= @ProjectName        																", Environment.NewLine
                , "		AND			[PartitionId]							= @PartitionId																		", Environment.NewLine
                , "																																				", Environment.NewLine
                , "																																				", Environment.NewLine
                , "		SELECT @Duration_Start = GETDATE()																										", Environment.NewLine
                , "		IF (@DestinationFlag = 'A')																												", Environment.NewLine
                , "		BEGIN																																	", Environment.NewLine

                , "        SELECT																																", Environment.NewLine
                , "				    @RowCountSrc							= mt.[RowNumSrc]																	", Environment.NewLine
                , "				  , @LowerPartitionBoundary					= mt.[LowerPartitionBoundary]														", Environment.NewLine
                , "				  , @UpperPartitionBoundary					= mt.[UpperPartitionBoundary] 														", Environment.NewLine
                , "		    FROM		[", projectTableSchema, "].[", projectTableName, Options.migrationTrackingTblSuffix, "] AS mt								", Environment.NewLine
                , "		    INNER JOIN	[", projectTableSchema, "].[", projectTableName, "]			 AS mp ON mp.[ProjectGUID] = mt.[ProjectGUID]					", Environment.NewLine
                , "		    WHERE		mp.[ProjectName]						= @ProjectName        																", Environment.NewLine
                , "		    AND			[PartitionId]							= @PartitionId																		", Environment.NewLine
                , "		    AND			mt.[DestinationFlag]					= 'A'																		        ", Environment.NewLine

                , "			SET XACT_ABORT ON;																													", Environment.NewLine
                , "			BEGIN TRY																															", Environment.NewLine
                , "			BEGIN TRANSACTION																													", Environment.NewLine
                , "																																				", Environment.NewLine
                , "				INSERT INTO [", tgtDatabase, "].[", tgtSchemaArchive, "].[", tgtTableArchive, "]												", Environment.NewLine
                , "				( ", tgtColumnListArchive, ")																									", Environment.NewLine
                , "				SELECT  ", srcColumnList, " 																									", Environment.NewLine
                , "				FROM [", srcInstance, "].[", srcDatabase, "].[", srcSchema, "].[", srcTable, "]													", Environment.NewLine
                , "				WHERE [", srcColumn, "] >= @LowerPartitionBoundary AND [", srcColumn, "] < @UpperPartitionBoundary;								", Environment.NewLine
                , "																																				", Environment.NewLine
                , "				COMMIT TRANSACTION;																												", Environment.NewLine
                , "																																				", Environment.NewLine
                , "			END TRY																																", Environment.NewLine
                , "			BEGIN CATCH 																														", Environment.NewLine
                , "				SELECT @ErrorMsg = ERROR_MESSAGE()																								", Environment.NewLine
                , "				ROLLBACK TRANSACTION																											", Environment.NewLine
                , "				RAISERROR(@ErrorMsg, 18, 10)																									", Environment.NewLine
                , "				BREAK																															", Environment.NewLine
                , "			END CATCH																															", Environment.NewLine
                , "		END	 																																	", Environment.NewLine
                , "																																				", Environment.NewLine
                , "		ELSE IF (@DestinationFlag = 'C')																										", Environment.NewLine
                , "         BEGIN                                                                                                                                   ", Environment.NewLine
                , "         SELECT																																", Environment.NewLine
                , "		    		    @RowCountSrc							= mt.[RowNumSrc]																	", Environment.NewLine
                , "		    		  , @LowerPartitionBoundary					= mt.[LowerPartitionBoundary]														", Environment.NewLine
                , "		    		  , @UpperPartitionBoundary					= mt.[UpperPartitionBoundary] 														", Environment.NewLine
                , "		    FROM		[", projectTableSchema, "].[", projectTableName, Options.migrationTrackingTblSuffix, "] AS mt								", Environment.NewLine
                , "		    INNER JOIN	[", projectTableSchema, "].[", projectTableName, "]			 AS mp ON mp.[ProjectGUID] = mt.[ProjectGUID]					", Environment.NewLine
                , "		    WHERE		mp.[ProjectName]						= @ProjectName        																", Environment.NewLine
                , "		    AND			[PartitionId]							= @PartitionId																		", Environment.NewLine
                , "		    AND			mt.[DestinationFlag]					= 'C'																		        ", Environment.NewLine

                , "			SET XACT_ABORT ON;																													", Environment.NewLine
                , "			BEGIN TRY																															", Environment.NewLine
                , "				BEGIN TRANSACTION																												", Environment.NewLine
                , "																																				", Environment.NewLine
                , "				INSERT INTO [", tgtDatabase, "].[", tgtSchemaCurrent, "].[", tgtTableCurrent, "]														", Environment.NewLine
                , "				( ", tgtColumnListCurrent, ")																									", Environment.NewLine
                , "				SELECT ", srcColumnList, "  																									", Environment.NewLine
                , "				FROM [", srcInstance, "].[", srcDatabase, "].[", srcSchema, "].[", srcTable, "]													", Environment.NewLine
                , "				WHERE [", srcColumn, "] >= @LowerPartitionBoundary AND [", srcColumn, "] < @UpperPartitionBoundary;												", Environment.NewLine
                , "																																				", Environment.NewLine
                , "				COMMIT TRANSACTION;																												", Environment.NewLine
                , "			END TRY																																", Environment.NewLine
                , "			BEGIN CATCH 																														", Environment.NewLine
                , "				SELECT @ErrorMsg = ERROR_MESSAGE()																								", Environment.NewLine
                , "				ROLLBACK TRANSACTION																											", Environment.NewLine
                , "				RAISERROR(@ErrorMsg, 18, 10)																									", Environment.NewLine
                , "				BREAK																															", Environment.NewLine
                , "			END CATCH																															", Environment.NewLine
                , "		END																																		", Environment.NewLine
                , "		SELECT @Duration_Stop = GETDATE()    																									", Environment.NewLine
                , "		SELECT @Duration = DATEDIFF(SECOND, @Duration_Start, @Duration_Stop)																	", Environment.NewLine
                , "																																				", Environment.NewLine
                , "		IF (@DestinationFlag = 'A')																												", Environment.NewLine
                , "     BEGIN                                                                                                                                   ", Environment.NewLine
                , "		    SELECT  @RowCountTgt = COUNT_BIG(*)																									", Environment.NewLine
                , "		    FROM	[", tgtDatabase, "].[", tgtSchemaArchive, "].[", tgtTableArchive, "]														", Environment.NewLine
                , "		    WHERE   [", srcColumn, "] >= @LowerPartitionBoundary AND [", srcColumn, "] < @UpperPartitionBoundary								", Environment.NewLine
                , "		END																																		", Environment.NewLine
                , "		ELSE IF (@DestinationFlag = 'C')																										", Environment.NewLine
                , "     BEGIN                                                                                                                                   ", Environment.NewLine
                , "		    SELECT  @RowCountTgt = COUNT_BIG(*)																									", Environment.NewLine
                , "		    FROM	[", tgtDatabase, "].[", tgtSchemaCurrent, "].[", tgtTableCurrent, "]														", Environment.NewLine
                , "		    WHERE   [", srcColumn, "] >= @LowerPartitionBoundary AND [", srcColumn, "] < @UpperPartitionBoundary								", Environment.NewLine
                , "		END																																		", Environment.NewLine
                , "		IF (@RowCountSrc = @RowCountTgt)																										", Environment.NewLine
                , "		BEGIN																																	", Environment.NewLine
                , "         PRINT(CONCAT('Successfully Migrated Partition Nr: ', @PartitionNumber, ' Date Range: ', @LowerPartitionBoundary, ' to: ', @UpperPartitionBoundary)) ", Environment.NewLine
                , "			UPDATE		[", projectTableSchema, "].[", projectTableName, Options.migrationTrackingTblSuffix, "]									", Environment.NewLine
                , "			SET			[RowNumTgt] = @RowCountTgt --@RowNumTgt 																				", Environment.NewLine
                , "					  , [migrated]  = 1																											", Environment.NewLine
                , "					  , [Duration]  = @Duration																									", Environment.NewLine
                , "			WHERE		[PartitionId] = @PartitionId																							", Environment.NewLine
                , "																																				", Environment.NewLine
                , "			SELECT		@PartitionNumber = MIN([PartitionNumber]) 																				", Environment.NewLine
                , "					   ,@PartitionId = MIN([PartitionId])																						", Environment.NewLine
                , "			FROM		[", projectTableSchema, "].[", projectTableName, Options.migrationTrackingTblSuffix, "] AS mt							", Environment.NewLine
                , "			INNER JOIN	[", projectTableSchema, "].[", projectTableName, "] AS mp ON mp.[ProjectGUID] = mt.[ProjectGUID]						", Environment.NewLine
                , "			WHERE		mp.[ProjectName] = @ProjectName																							", Environment.NewLine
                , "			AND			mt.[migrated] = 0																										", Environment.NewLine
                , "																																				", Environment.NewLine
                , "			SELECT																																", Environment.NewLine
                , "					    @RowCountSrc							= mt.[RowNumSrc]																", Environment.NewLine
                , "					  , @LowerPartitionBoundary					= mt.[LowerPartitionBoundary]													", Environment.NewLine
                , "					  , @UpperPartitionBoundary					= mt.[UpperPartitionBoundary] 													", Environment.NewLine
                , "			FROM		[", projectTableSchema, "].[", projectTableName, Options.migrationTrackingTblSuffix, "] AS mt							", Environment.NewLine
                , "			INNER JOIN	[", projectTableSchema, "].[", projectTableName, "]			 AS mp ON mp.[ProjectGUID] = mt.[ProjectGUID]				", Environment.NewLine
                , "			WHERE		mp.[ProjectName]						= @ProjectName        															", Environment.NewLine
                , "			--AND			[PartitionNumber]					= @PartitionNumber															", Environment.NewLine
                , "			AND			[PartitionId]						= @PartitionId																		", Environment.NewLine
                , "																																				", Environment.NewLine
                , "			SET @RowCountTgt = NULL;																											", Environment.NewLine
                , "		END																																		", Environment.NewLine
                , "		ELSE 																																	", Environment.NewLine
                , "		BEGIN																																	", Environment.NewLine
                , "			SET @ErrorMsg = CONCAT('@RowCountSrc: ', @RowCountSrc, ' and @RowCountTgt: ',  @RowCountTgt											", Environment.NewLine
                , "								 , ' for @PartitionNumber ', @PartitionNumber, ' do not match, See previous errors')							", Environment.NewLine
                , "			RAISERROR(@ErrorMsg, 14, 10)																										", Environment.NewLine
                , "			BREAK																																", Environment.NewLine
                , "		END																																		", Environment.NewLine
                , "END																																			", Environment.NewLine
                , "END																																			", Environment.NewLine
                );
        }
        
        
        public static string GetSqlObjectListByNodeLevel(TreeNode<DbObject> tn)
        {
            /*
            Instance        = 1,
            Database        = 2,
            Schema          = 3,
            Table           = 4,
            Column          = 5,
            DataType        = 6,
            PartitionScheme = 7,
            Index           = 8,            
            */

            string result = string.Empty;
            switch (tn.TreeNodeLevel)
            {
                case (int)DbObjectLevel.Database:
                    result = SqlDbList;
                    break;

                case (int)DbObjectLevel.Schema:
                    result = SqlSchList;
                    break;

                case (int)DbObjectLevel.Table:
                    result = SqlTbList;
                    break;

                case (int)DbObjectLevel.Column:
                    if (tn.Data.ObjectBranch == (int)DbObjectBranch.TrckTbl)
                    {                        
                        result = GetSqlProjectListFromProjectTable(tn.TraverseUpUntil(tn, (int)DbObjectLevel.Schema).Data.ObjectText, tn.TraverseUpUntil(tn, (int)DbObjectLevel.Table).Data.ObjectText);
                    }
                    else
                    {
                        result = SqlColList;
                    }
                    break;

                case (int)DbObjectLevel.DataType:
                    if (tn.Data.ObjectBranch == (int)DbObjectBranch.TrckTbl)
                    {
                        result = GetSqlProjectDescriptionByProjectName(tn.TraverseUpUntil(tn, (int)DbObjectLevel.Schema).Data.ObjectText, tn.TraverseUpUntil(tn, (int)DbObjectLevel.Table).Data.ObjectText, tn.TraverseUpUntil(tn, (int)DbObjectLevel.Column).Data.ObjectText);                                             
                    }
                    else
                    {
                        result = SqlDataTypeByColName;
                    }                    
                    break;

                case (int)DbObjectLevel.PartitionScheme:
                    if (tn.Data.ObjectBranch == (int)DbObjectBranch.Tgt)
                    {
                        result = tn.CloneableFromSrc ? SqlPartSchListByDataType : SqlPartSchListByColName;
                    }
                    else
                    {
                        result = SqlPartSchListByColName;
                    }
                    break;

                case (int)DbObjectLevel.Index:
                    result = SqlIndexListByColName;
                    break;
            }
            return result;
        }
    }
}
