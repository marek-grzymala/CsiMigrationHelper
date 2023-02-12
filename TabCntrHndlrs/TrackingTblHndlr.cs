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

        public TrackingTblHndlr(ComboBoxExtTrackTbl projectsTable, ComboBoxExtTrackTbl projectName)
        {
            ProjectsTable = projectsTable;
            ProjectName   = projectName;
            ProjectsTable.RdButtonCreateNew.CheckedChanged += new EventHandler(OnRdButtonProjectsTableCheckedChanged);
            ProjectsTable.eventCmbxProjectsTableSelectedIndexChanged += new HandlerCmbxProjectsTableSelectedIndexChanged(OnCmbxProjectsTableSelectedIndexChange);
            ProjectsTable.SaveButton.Click += new EventHandler(OnProjectsTableSaveButtonClick);
            ProjectName.SaveButton.Click += new EventHandler(OnProjectNameSaveButtonClick);
        }

        protected virtual void OnRdButtonProjectsTableCheckedChanged(object sender, EventArgs e)
        {            
            if (ProjectsTable.RdButtonCreateNew.Checked)
            {
                ProjectName.RdButtonUseExisting.Enabled = false;
                ProjectName.RdButtonCreateNew.Checked = true;
                ProjectName.RunOnRdButtonCheckedChanged(sender, EventArgs.Empty);
            }
        }

        protected virtual void OnCmbxProjectsTableSelectedIndexChange(object sender, EventArgsTableData e)
        {
            if (VerifyTableName(e))
            {
                ProjectName.RdButtonUseExisting.Enabled = true;
            }
        }

        protected virtual void OnProjectsTableSaveButtonClick(object sender, EventArgs ea)
        {
            EventArgsTableData e = new EventArgsTableData(
                                      ProjectsTable.TreeNodeOwner.TraverseUpUntil(ProjectsTable.TreeNodeOwner, (int)DbObjectLevel.Instance)
                                    , ProjectsTable.TreeNodeOwner.Parent.Data.ObjectText
                                    , ProjectsTable.TreeNodeOwner.Data.ObjectText);
            if (CreateProjectsTable(e))
            {
                Console.WriteLine(string.Concat("Created Projects Table: [", e.SchemaName, "].[", e.TableName, "] on Instance: ", e.InstanceNode.Data.ObjectText));
            }
        }

        protected virtual void OnProjectNameSaveButtonClick(object sender, EventArgs e)
        {
            if (CreateProject(ProjectName.TreeNodeOwner.Data.ObjectText,
                              new EventArgsTableData(
                                ProjectsTable.TreeNodeOwner.TraverseUpUntil(ProjectsTable.TreeNodeOwner, (int)DbObjectLevel.Instance)
                              , ProjectsTable.TreeNodeOwner.Parent.Data.ObjectText
                              , ProjectsTable.TreeNodeOwner.Data.ObjectText)))
            {
                Console.WriteLine("Project Created");
            }
        }

        private bool VerifyTableName(EventArgsTableData e)
        {
            bool result = false;
            Console.WriteLine(string.Concat("Checking if [", e.SchemaName, "].[", e.TableName, "] is a valid ProjectsTable - Class ComboBoxExt; method: OnSelectedIndexChanged()"));
            // to do: check if this is a valid ProjectsTable            
            result = true;
            return result;
        }

        private bool CreateProjectsTable(EventArgsTableData e)
        {
            try
            {
                return e.InstanceNode.Data.Dbu.ExecuteSql(e.InstanceNode, SqlText.GetSqlTableDefinitionProjectsTable(e.SchemaName, e.TableName));                
            }
            catch (ExceptionSqlExecError ex)
            {
                // for now do nothing
                return false;
            }
        }

        private bool CreateProject(string projectName, EventArgsTableData e)
        {
            bool result = false;
            Console.WriteLine(string.Concat("Creating Project Entry: [", projectName, "] in: [", e.SchemaName, "].[", e.TableName, "] on Instance: ", e.InstanceNode.Data.ObjectText));
            result = true;
            return result;
        }
    }
}
