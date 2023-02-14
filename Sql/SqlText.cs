using System;
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

        public static string GetSqlTableDefinitionProjectsTable(string schemaName, string tableName)
        {
            return string.Concat( "CREATE TABLE [", schemaName, "].[", tableName, "]("
                                 , "[ProjectID] INT IDENTITY(1,1) NOT NULL,"
                                 , "[ProjectGUID] UNIQUEIDENTIFIER PRIMARY KEY CLUSTERED,"
                                 , "[ProjectName] NVARCHAR(256) UNIQUE NOT NULL,"
                                 , "[ProjectDescription] NVARCHAR(256) NULL,"
                                 , "[ProjectCreateDate] DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP);");
        }

        public static string GetSqlTableVerificationProjectsTable(string schemaName, string tableName)
        {
            return string.Concat("SELECT  [ProjectID]"
                                , "      ,[ProjectGUID]"
                                , "      ,[ProjectName]"
                                , "      ,[ProjectDescription]"
                                , "      ,[ProjectCreateDate]"
                                , "FROM   [", schemaName, "].[", tableName, "]"
                                ,"WHERE  1 = 0");
        }

        public static string GetSqlProjectNameInsert(string schemaName, string tableName, string projectName, string projectDescription)
        {
            //return string.Concat(
            //      "INSERT INTO [", schemaName, "].[", tableName, "] "
            //    , "           ([ProjectID], [ProjectName])		    "
            //    , "VALUES	  (NEWID(), '", projectName, "');	    "
            //    );
            return string.Concat(
                  "INSERT INTO [", schemaName, "].[", tableName, "] "
                , "           ([ProjectName], [ProjectGUID], [ProjectDescription])		    "
                , "VALUES	  ('", projectName, "', NEWID(), '", projectDescription, "');	    "
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
                    , "WHERE  [ProjectName] = '", projectName, "'; " //'My New Csi Migration Project';		"
                );
        }

        public static string GetSqlObjectListByNodeLevel(TreeNode<DbObject> tn) //(int lvl)
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
