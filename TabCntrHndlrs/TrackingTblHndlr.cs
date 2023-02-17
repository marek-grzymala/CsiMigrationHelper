﻿using System;
using System.Collections.Generic;
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
            if (VerifyTableName(e))
            {
                Console.WriteLine(string.Concat("Table: [", e.SchemaName, "].[", e.TableName, "] on Instance: ", e.InstanceNode.Data.ObjectText, " is a Valid Project Table"));
            }
        }


        protected virtual void OnCmbxProjectNameSelectedIndexChange(object sender, EventArgsMigrationTracking e)
        {
            GridTrackingTable.DataSource = null;
            if (LoadGrid(e))
            {
            Console.WriteLine(string.Concat("Successfully Loaded Project: [", e.TreeNodeOwner.Data.ObjectText, "]", Environment.NewLine
                                        , "On Instance: [", e.InstanceNode.Data.ObjectText, "]", Environment.NewLine
                                        ));
            }
        }

        protected virtual void OnProjectsTableSaveButtonClick(object sender, EventArgs ea)
        {
            if (ProjectsTable.RdButtonCreateNew.Checked && ProjectsTable.Text.Length > 0)
            {
                EventArgsMigrationTracking e = new EventArgsMigrationTracking(
                                          ProjectsTable.TreeNodeOwner.TraverseUpUntil(ProjectsTable.TreeNodeOwner, (int)DbObjectLevel.Instance)
                                        , ProjectsTable.TreeNodeOwner
                                        , ProjectsTable.TreeNodeOwner.Parent.Data.ObjectText
                                        , ProjectsTable.TreeNodeOwner.Data.ObjectText);
                if (CreateProjectsTable(e))
                {
                    Console.WriteLine(string.Concat("Created Projects Table: [", e.SchemaName, "].[", e.TableName, "] on Instance: ", e.InstanceNode.Data.ObjectText));
                    ProjectsTable.LockGuiControls();
                    ProjectsTable.SaveButton.Image = ImageList1.Images[0];
                }
                else
                {
                    ProjectsTable.SaveButton.Image = ImageList1.Images[1];
                }
            }
        }

        protected virtual void OnProjectNameSaveButtonClick(object sender, EventArgs ea)
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
                    // Preload Migration Tracking Table with Partition List:
                    // if (PreloadMigrationTracking()) {}

                }
                else
                {
                    ProjectName.SaveButton.Image = ImageList1.Images[1];
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
            try
            {
                result = e.InstanceNode.Data.Dbu.ExecuteSql(e.InstanceNode
                    , SqlText.GetSqlTableVerificationProjectsTable(e.SchemaName, e.TableName)
                    , "Table [" + e.SchemaName + "].[" + e.TableName + "] is an invalid Project Table" );
            }
            catch (ExceptionSqlExecError ex)
            {
                ProjectsTable.TreeNodeOwner.EmptySubtreeText(ProjectsTable.TreeNodeOwner);
                ProjectsTable.SelectedIndex = 0;
                //ProjectsTable.DroppedDown = true; // .DroppedDown = true;
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
            Console.WriteLine(SqlText.GetSqlProjectNameInsert(e.SchemaName, e.TableName, projectName, projectDescription, ProjectFields));
            try
            {                
                return e.InstanceNode.Data.Dbu.ExecuteSql(e.InstanceNode
                       , SqlText.GetSqlProjectNameInsert(e.SchemaName, e.TableName, projectName, projectDescription, ProjectFields)
                       , "Error creating Project: ["+ projectName + "]");
            }
            catch (ExceptionSqlExecError ex)
            {
                // for now do nothing
                return false;
            }
        }

        private bool PreloadMigrationTracking(EventArgsMigrationTracking eMtr, EventArgsProjectFields eProjFields)
        {
            try
            {
                string projectTable = ProjectsTable.TreeNodeOwner.Data.ObjectText;
                string projectName = ProjectName.TreeNodeOwner.Data.ObjectText;

                return eMtr.InstanceNode.Data.Dbu.ExecuteSql(eMtr.InstanceNode
                       , SqlText.GetSqlPreloadMigrationTracking(projectTable, projectName, eProjFields)
                       , "Error Preloading Migration Tracking Tbl for Project: [" + projectName + "]");
            }
            catch (ExceptionSqlExecError ex)
            {
                // for now do nothing
                return false;
            }
        }

        private bool LoadGrid(EventArgsMigrationTracking e)
        {
            bool result = false;            
            DataSetForGui ds = e.InstanceNode.Data.Dbu.GetDataSetForGui(e.InstanceNode, e.TreeNodeOwner, "MigrationTrackingTable");
            
            if (ds != null)
            {
                GridTrackingTable.DataSource = ds.Ds;
                GridTrackingTable.DataMember = ds.Ds.Tables["Table"].TableName;
                GridTrackingTable.Columns["PartitionId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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
