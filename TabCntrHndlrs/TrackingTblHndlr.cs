using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsiMigrationHelper
{
    public class TrackingTblHndlr
    {
        private ComboBoxExtTrackTbl ProjectsTable;
        private ComboBoxExtTrackTbl ProjectName;
        private DataGridView  GridTrackingTable;
        private EventArgsProjectFields ProjectFields;
        private ImageList ImageList1;
        private string UspNamePreloadMigrationTrackingTbl;


        public TrackingTblHndlr(ComboBoxExtTrackTbl projectsTable
                              , ComboBoxExtTrackTbl projectName
                              , DataGridView gridTrackingTable
                              , EventArgsProjectFields projectFields
                              , ImageList imageList1)
        {
            ProjectsTable = projectsTable;
            ProjectName   = projectName;
            GridTrackingTable = gridTrackingTable;
            ProjectFields = projectFields;

            ProjectsTable.RdButtonCreateNew.CheckedChanged += new EventHandler(OnRdButtonProjectsTableCheckedChanged);
            ProjectsTable.eventCmbxTrackTblSelectedIndexChanged += new HandlerCmbxProjectTblSelectedIndexChanged(OnCmbxProjectsTableSelectedIndexChange);
            ProjectName.eventCmbxProjectNameSelectedIndexChanged += new HandlerCmbxProjectSelectedIndexChanged(OnCmbxProjectNameSelectedIndexChange);
            ProjectName.eventCmbxProjectSelectionEmpty += new HandlerCmbxProjectSelectionEmpty(OnCmbxProjectSelectionEmpty);

            ProjectsTable.SaveButton.Click += new EventHandler(OnProjectsTableSaveButtonClick);
            ProjectName.SaveButton.Click += new EventHandler(OnProjectNameSaveButtonClick);
            ImageList1 = imageList1;
        }

        // if Create New ProjectTable option chosen allow only creating new Projects in it (there is no existing Projects in a New ProjectTable):
        protected virtual void OnRdButtonProjectsTableCheckedChanged(object sender, EventArgs e)
        {            
            if (ProjectsTable.RdButtonCreateNew.Checked)
            {
                ProjectName.UnLockGuiControls(this, EventArgs.Empty);
                ProjectName.RdButtonUseExisting.Enabled = false;
                ProjectName.RdButtonCreateNew.Checked = true;
                ProjectName.RunOnRdButtonCheckedChanged(sender, EventArgs.Empty);
            }
            else
            {
                ProjectName.RdButtonUseExisting.Enabled = true;
            }
        }

        protected virtual void OnCmbxProjectsTableSelectedIndexChange(object sender, EventArgsMigrationTracking e)
        {            
            if (ProjectsTable.SelectedIndex > 0 && VerifyTableName(e))
            {
                ProjectsTable.ProjectTableNameValid = true;
                ProjectName.UnLockGuiControls(this, EventArgs.Empty);                
            }
            else
            {
                ProjectsTable.ProjectTableNameValid = false;
                ProjectName.LockGuiControls();
                MessageBox.Show(string.Concat("Table: [", e.SchemaName, "].[", e.TableName, "] on Instance: ", e.InstanceNode.Data.ObjectText
                    , " is an invalid Project Table"), "Invalid Project Table", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        protected virtual void OnCmbxProjectNameSelectedIndexChange(object sender, EventArgsMigrationTracking e)
        {
            if (ProjectName.SelectedIndex > 0 && VerifyProjectNameEntriesPresentInMgrTrckgTbl(e))
            {
                ProjectName.ProjectNameValid = true;
                GridTrackingTable.DataSource = null;
                if (LoadGrid(e))
                {
                    // 
                }
            }
            else
            {
                ProjectName.ProjectNameValid = false;
                GridTrackingTable.DataSource = null;

                MessageBox.Show(string.Concat("Project: [", ProjectName.TreeNodeOwner,ToString()
                                          , "] listed in Table: [", e.SchemaName, "].[", ProjectsTable.TreeNodeOwner.ToString()
                                          , "] on Instance: [", e.InstanceNode.ToString()
                                          , "] does not have any entries in table: [", ProjectsTable.TreeNodeOwner, Options.migrationTrackingTblSuffix
                                          , "]"), "No Entries in Migration Tracking Table", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual void OnProjectsTableSaveButtonClick(object sender, EventArgs ea)
        {
            if (ProjectFields.TgtArchiveTableCSIndex.IsBranchTextSet(ProjectFields.TgtArchiveTableCSIndex, (int)DbObjectLevel.Instance))
            {
                if (ProjectsTable.RdButtonCreateNew.Checked && ProjectsTable.Text.Length > 0)
                {
                    EventArgsMigrationTracking e = new EventArgsMigrationTracking(
                                              ProjectsTable.TreeNodeOwner.TraverseUpUntil(ProjectsTable.TreeNodeOwner, (int)DbObjectLevel.Instance)
                                            , ProjectsTable.TreeNodeOwner
                                            , ProjectsTable.TreeNodeOwner.Parent.ToString()
                                            , ProjectsTable.TreeNodeOwner.ToString());
                    if (CreateProjectsTable(e))
                    {
                        Console.WriteLine(string.Concat("Successfully Created Project Tables: ", Environment.NewLine
                                                      , "[", e.SchemaName, "].[", e.TableName, "]", Environment.NewLine
                                                      , "[", e.SchemaName, "].[", e.TableName, Options.migrationTrackingTblSuffix, "]"));
                            ProjectsTable.LockGuiControls();
                            ProjectsTable.SaveButton.Image = ImageList1.Images[0];
                    }
                    else
                    {
                        ProjectsTable.SaveButton.Image = ImageList1.Images[1];
                    }
                }
            }
            else
            {
                MessageBox.Show(string.Concat("Missing Target Table Config"), "Missing Target Table Config", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual void OnProjectNameSaveButtonClick(object sender, EventArgs ea)
        {
            if (ProjectFields.TgtArchiveTableCSIndex.IsBranchTextSet(ProjectFields.TgtArchiveTableCSIndex, (int)DbObjectLevel.Instance))
            {
                if (ProjectName.RdButtonCreateNew.Checked && ProjectName.Text.Length > 0)
                {
                    EventArgsMigrationTracking e = new EventArgsMigrationTracking(
                                          ProjectsTable.TreeNodeOwner.TraverseUpUntil(ProjectsTable.TreeNodeOwner, (int)DbObjectLevel.Instance)
                                        , ProjectsTable.TreeNodeOwner
                                        , ProjectsTable.TreeNodeOwner.Parent.Data.ObjectText
                                        , ProjectsTable.TreeNodeOwner.Data.ObjectText);

                    if (CreateProject(e, ProjectName.TreeNodeOwner.Data.ObjectText, ProjectName.ProjectDescription.Text))
                    {                    
                        ProjectName.LockGuiControls();
                        ProjectName.SaveButton.Image = ImageList1.Images[0];
                        //Create Tgt Linked Server:
                        if (CreateLinkedServer(e, ProjectFields.TgtInstance.ToString(), ProjectFields.TgtInstance.Data.Dbu))
                        {
                            Console.WriteLine("Linked Servers created successfully");
                        
                            //Create Usp Preloading the migration tracking table:
                            if (CreateUspPreloadMigrationTrackingTbl(e, ProjectFields))
                            {
                                string projectTableSchema = ProjectsTable.TreeNodeOwner.Parent.Data.ObjectText;
                                string projectTableName = ProjectsTable.TreeNodeOwner.Data.ObjectText;
                                Console.WriteLine(string.Concat("Successfully Created usp: [", projectTableSchema, "].[usp_Preload_", projectTableName, Options.migrationTrackingTblSuffix, "]"));
                                UspNamePreloadMigrationTrackingTbl = string.Concat("[", projectTableSchema, "].[usp_Preload_", projectTableName, Options.migrationTrackingTblSuffix, "]");

                                int r = RunUspPreloadMigrationTrackingTbl(e, ProjectFields);
                                if (r > 0)
                                {
                                    Console.WriteLine(string.Concat("Procedure: ", UspNamePreloadMigrationTrackingTbl, " returned :", r, " records"));
                                    Console.WriteLine(string.Concat("ProjectsTable.TreeNodeOwner: ", ProjectsTable.TreeNodeOwner.ToString()));
                                    LoadGrid(e);
                                }
                                else
                                {
                                    MessageBox.Show(string.Concat("Procedure: ", UspNamePreloadMigrationTrackingTbl
                                        , " did not insert any records; ", Environment.NewLine, "Removing Project: [", ProjectName.TreeNodeOwner.ToString(), "]")
                                        , "No Entries Inserted into Migration Tracking Table", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    RemoveProject(e, ProjectName.TreeNodeOwner.ToString());
                                    OnCmbxProjectSelectionEmpty(this, e);
                                }
                                // drop the usp (it contains a hard-coded linked server definition which may not be valid for new projects after this one)
                                DropUspPreloadMigrationTrackingTbl(e, UspNamePreloadMigrationTrackingTbl);
                            }
                            else
                            {
                                RemoveProject(e, ProjectName.TreeNodeOwner.ToString());
                                OnCmbxProjectSelectionEmpty(this, e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Failed to create Linked Servers!");
                            RemoveProject(e, ProjectName.TreeNodeOwner.ToString());
                            OnCmbxProjectSelectionEmpty(this, e);
                        }
                    }
                    else
                    {
                        ProjectName.SaveButton.Image = ImageList1.Images[1];
                    }
                }
                else
                {
                    MessageBox.Show(string.Concat("Missing Target Table Config"), "Missing Target Table Config", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        protected virtual void OnCmbxProjectSelectionEmpty(object sender, EventArgsMigrationTracking e)
        {
            if (GridTrackingTable.DataSource != null)
            {
                GridTrackingTable.DataSource = null;
            }
        }

        private bool VerifyTableName(EventArgsMigrationTracking e)
        {
            bool result = false;               
            if (e.InstanceNode.Data.Dbu.ParseSql(e.InstanceNode, SqlText.GetSqlTableVerificationProjectsTable(e.SchemaName, e.TableName)))
            {                    
                result = e.InstanceNode.Data.Dbu.ExecuteSqlScalar(e.InstanceNode
                    , SqlText.GetSqlTableVerificationProjectsTable(e.SchemaName, e.TableName)
                    , null ) == 10 ? true : false;
            }
            return result;
        }

        private bool VerifyProjectNameEntriesPresentInMgrTrckgTbl(EventArgsMigrationTracking e)
        {
            bool result = true;
            if (e.InstanceNode.Data.Dbu.ParseSql(e.InstanceNode, SqlText.GetSqlVerifyMigrationTrackingEntryCountPerProjectName(e.TreeNodeOwner)))
            {
                result = e.InstanceNode.Data.Dbu.ExecuteSqlScalar(e.InstanceNode
                    , SqlText.GetSqlVerifyMigrationTrackingEntryCountPerProjectName(e.TreeNodeOwner)
                    , null) > 0 ? true : false;
            }
            return result;
        }

        private bool CreateProjectsTable(EventArgsMigrationTracking e)
        {
            try
            {
                return e.InstanceNode.Data.Dbu.ExecuteSql(e.InstanceNode
                    , SqlText.GetSqlTableDefinitionProjectTable(e.SchemaName, e.TableName)
                    , "Error creating Project Table: [" + e.SchemaName +"].["+ e.TableName +"]");
                
            }
            catch (ExceptionSqlExecError ex)
            {
                // for now do nothing
                return false;
            }
        }

        private bool CreateProject(EventArgsMigrationTracking e, string projectName, string projectDescription)
        {            
            try
            {                
                return e.InstanceNode.Data.Dbu.ExecuteSql(e.InstanceNode
                       , SqlText.GetSqlProjectInsert(e.SchemaName, e.TableName, projectName, projectDescription, ProjectFields)
                       , "Error creating Project: ["+ projectName + "]");
            }
            catch (ExceptionSqlExecError ex)
            {
                // for now do nothing
                return false;
            }
        }

        private bool RemoveProject(EventArgsMigrationTracking e, string projectName)
        {
            try
            {
                return e.InstanceNode.Data.Dbu.ExecuteSql(e.InstanceNode
                       , SqlText.GetSqlProjectRemove(e.SchemaName, e.TableName, projectName)
                       , "Error removing Project: [" + projectName + "]");
            }
            catch (ExceptionSqlExecError ex)
            {
                // for now do nothing
                return false;
            }
        }

        private bool CreateLinkedServer(EventArgsMigrationTracking e, string serverName, DbUtil dbu)
        {
            try
            {
                return e.InstanceNode.Data.Dbu.ExecuteSql(e.InstanceNode
                       , SqlText.GetSqlAddLinkedServer(serverName, dbu)
                       , "Error creating LinkedServer: [" + serverName + "]");
            }
            catch (ExceptionSqlExecError ex)
            {
                // for now do nothing
                return false;
            }
        }

        private bool CreateUspPreloadMigrationTrackingTbl(EventArgsMigrationTracking eMtr, EventArgsProjectFields eProjFields)
        {
            try
            {                
                string projectTableSchema = ProjectsTable.TreeNodeOwner.Parent.Data.ObjectText;
                string projectTableName = ProjectsTable.TreeNodeOwner.Data.ObjectText;
                string projectName = ProjectName.TreeNodeOwner.Data.ObjectText;
                //Console.WriteLine(SqlText.GetSqlCreateUspPreloadMigrationTracking(projectTableSchema, projectTableName, eProjFields));
                
                return eMtr.InstanceNode.Data.Dbu.ExecuteSql(eMtr.InstanceNode
                       , SqlText.GetSqlCreateUspPreloadMigrationTracking(projectTableSchema, projectTableName, eProjFields)
                       , string.Concat("Error Creating usp: [", projectTableSchema, "].[usp_Preload_", projectTableName, Options.migrationTrackingTblSuffix, "]"));
            }
            catch (ExceptionSqlExecError ex)
            {
                // for now do nothing
                return false;
            }
        }

        private bool DropUspPreloadMigrationTrackingTbl(EventArgsMigrationTracking eMtr, string uspName)
        {
            try
            {
                return eMtr.InstanceNode.Data.Dbu.ExecuteSql(eMtr.InstanceNode
                       , string.Concat("DROP PROCEDURE ", uspName)
                       , string.Concat("Error Dropping usp: [", uspName));
            }
            catch (ExceptionSqlExecError ex)
            {
                // for now do nothing
                return false;
            }
        }

        private int RunUspPreloadMigrationTrackingTbl(EventArgsMigrationTracking eMtr, EventArgsProjectFields eProjFields)
        {
            try
            {
                string projectName = ProjectName.TreeNodeOwner.Data.ObjectText;
                string projectTableSchema = ProjectsTable.TreeNodeOwner.Parent.Data.ObjectText;
                string projectTableName = ProjectsTable.TreeNodeOwner.Data.ObjectText;
                //Console.WriteLine(SqlText.GetSqlCreateUspPreloadMigrationTracking(projectTableSchema, projectTableName, eProjFields));

                List<SqlParameter> sqlParamList = new List<SqlParameter>();
                SqlParameter p_ProjectName = new SqlParameter()
                {
                    ParameterName = "@ProjectName",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000,
                    Value = projectName
                };
                sqlParamList.Add(p_ProjectName);

                SqlParameter p_TgtSchema = new SqlParameter()
                {
                    ParameterName = "@TgtSchema",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000,
                    Value = eProjFields.TgtArchiveTableSchema.ToString()
                };
                sqlParamList.Add(p_TgtSchema);

                SqlParameter p_TgtTable = new SqlParameter()
                {
                    ParameterName = "@TgtTable",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000,
                    Value = eProjFields.TgtArchiveTableName.ToString()
                };
                sqlParamList.Add(p_TgtTable);

                SqlParameter p_TgtIndex = new SqlParameter()
                {
                    ParameterName = "@TgtIndex",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4000,
                    Value = eProjFields.TgtArchiveTableCSIndex.ToString()
                };
                sqlParamList.Add(p_TgtIndex);
                return eMtr.InstanceNode.Data.Dbu.ExecuteSqlUsp(eMtr.InstanceNode, UspNamePreloadMigrationTrackingTbl, sqlParamList);
                       
            }
            catch (ExceptionSqlExecError ex)
            {
                // for now do nothing
                return 0;
            }
        }

        private bool LoadGrid(EventArgsMigrationTracking e)
        {
            bool result = false;            
            DataSetForGui ds = e.InstanceNode.Data.Dbu.GetDataSetForGui(e.InstanceNode, ProjectName.TreeNodeOwner, "MigrationTrackingTable");            
            if (ds != null)
            {
                GridTrackingTable.DataSource = ds.Ds;
                GridTrackingTable.DataMember = ds.Ds.Tables["Table"].TableName;
                GridTrackingTable.Columns["PartitionId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridTrackingTable.Columns["PartitionNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridTrackingTable.Columns["RowNumSrc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridTrackingTable.Columns["RowNumTgt"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridTrackingTable.Columns["TotalMB"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridTrackingTable.Columns["UsedMB"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridTrackingTable.Columns["FilegroupName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridTrackingTable.Columns["LowerPartitionBoundary"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridTrackingTable.Columns["UpperPartitionBoundary"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridTrackingTable.Columns["migrated"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridTrackingTable.Update();
                result = true;
            }
            return result;
        }
    }
}
