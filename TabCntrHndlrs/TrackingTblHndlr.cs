using System;
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
        private ImageList ImageList1;

        public TrackingTblHndlr(ComboBoxExtTrackTbl projectsTable, ComboBoxExtTrackTbl projectName, ImageList imageList1)
        {
            ProjectsTable = projectsTable;
            ProjectName   = projectName;
            //ProjectDescription = projectDescription;
            ProjectsTable.RdButtonCreateNew.CheckedChanged += new EventHandler(OnRdButtonProjectsTableCheckedChanged);
            ProjectsTable.eventCmbxProjectsTableSelectedIndexChanged += new HandlerCmbxProjectsTableSelectedIndexChanged(OnCmbxProjectsTableSelectedIndexChange);
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

        protected virtual void OnCmbxProjectsTableSelectedIndexChange(object sender, EventArgsTableName e)
        {
            if (VerifyTableName(e))
            {
                Console.WriteLine(string.Concat("Table: [", e.SchemaName, "].[", e.TableName, "] on Instance: ", e.InstanceNode.Data.ObjectText, " is a Valid Project Table"));
            }
        }

        protected virtual void OnProjectsTableSaveButtonClick(object sender, EventArgs ea)
        {
            if (ProjectsTable.RdButtonCreateNew.Checked && ProjectsTable.Text.Length > 0)
            {
                EventArgsTableName e = new EventArgsTableName(
                                          ProjectsTable.TreeNodeOwner.TraverseUpUntil(ProjectsTable.TreeNodeOwner, (int)DbObjectLevel.Instance)
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
                EventArgsTableName e = new EventArgsTableName(
                                      ProjectsTable.TreeNodeOwner.TraverseUpUntil(ProjectsTable.TreeNodeOwner, (int)DbObjectLevel.Instance)
                                    , ProjectsTable.TreeNodeOwner.Parent.Data.ObjectText
                                    , ProjectsTable.TreeNodeOwner.Data.ObjectText);

                if (CreateProject(e, ProjectName.TreeNodeOwner.Data.ObjectText, ProjectName.ProjectDescription.Text))
                {                    
                    ProjectName.LockGuiControls();
                    ProjectName.SaveButton.Image = ImageList1.Images[0];
                }
                else
                {
                    ProjectName.SaveButton.Image = ImageList1.Images[1];
                }
            }
        }

        private bool VerifyTableName(EventArgsTableName e)
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
                ProjectsTable.DroppedDown = true;
            }
            return result;
        }

        private bool CreateProjectsTable(EventArgsTableName e)
        {
            try
            {
                return e.InstanceNode.Data.Dbu.ExecuteSql(e.InstanceNode
                    , SqlText.GetSqlTableDefinitionProjectsTable(e.SchemaName, e.TableName)
                    , "Error creating Project Table: [" + e.SchemaName +"].["+ e.TableName +"]");                
            }
            catch (ExceptionSqlExecError ex)
            {
                // for now do nothing
                return false;
            }
        }

        private bool CreateProject(EventArgsTableName e, string projectName, string projectDescription)
        {
            try
            {
                return e.InstanceNode.Data.Dbu.ExecuteSql(e.InstanceNode
                    , SqlText.GetSqlProjectNameInsert(e.SchemaName, e.TableName, projectName, projectDescription)
                    , "Error creating Project: ["+ projectName + "]");
            }
            catch (ExceptionSqlExecError ex)
            {
                // for now do nothing
                return false;
            }
        }
    }
}
