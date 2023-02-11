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
            ProjectsTable.TreeNodeOwner.Data.Gui.Cbxtr.RdButtonCreateNew.CheckedChanged += new EventHandler(OnRdButtonProjectsTableCheckedChanged);
            ProjectsTable.TreeNodeOwner.Data.Gui.Cbxtr.eventCmbxProjectsTableSelectedIndexChanged += new HandlerCmbxProjectsTableSelectedIndexChanged(OnCmbxProjectsTableSelectedIndexChange);
        }

        protected virtual void OnRdButtonProjectsTableCheckedChanged(object sender, EventArgs e)
        {            
            if (ProjectsTable.TreeNodeOwner.Data.Gui.Cbxtr.RdButtonCreateNew.Checked)
            {
                ProjectName.RdButtonUseExisting.Enabled = false;
                ProjectName.RdButtonCreateNew.Checked = true;
                ProjectName.RunOnRdButtonCheckedChanged(sender, EventArgs.Empty);
            }
        }

        protected virtual void OnCmbxProjectsTableSelectedIndexChange(object sender, EventArgs e)
        {
            if (ProjectsTable.SelectedIndex > 0)
            {
                // to do: check if this is a valid ProjectsTable
                //Console.WriteLine(string.Concat("Class ComboBoxExt; method: OnSelectedIndexChanged(); Checking if ", newCbxSelection, " is a valid ProjectsTable"));
                ProjectName.RdButtonUseExisting.Enabled = true;
            }
        }
    }
}
