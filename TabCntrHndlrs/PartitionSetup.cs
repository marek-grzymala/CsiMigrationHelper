using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CsiMigrationHelper
{
    public class PartitionSetup
    {
        public EventArgsPartitionSetup e { get; set; }

        private DateTime startFG;
        private DateTime endFG  ;
        private DateTime startPF;
        private DateTime endPF  ;
        private DateTime startPS;
        private DateTime endPS  ;
        private string prefixFG;
        private string prefixFN;
        private string namePF;
        private string namePS;


        public PartitionSetup()
        {

        }
        public PartitionSetup(EventArgsPartitionSetup _e)
        {
            e = _e;
            e.BtnReloadFG.Click += new EventHandler(OnBtnReloadFGClick);
            e.BtnReloadPF.Click += new EventHandler(OnBtnReloadPFClick);
            e.BtnReloadPS.Click += new EventHandler(OnBtnReloadPSClick);

            e.BtnCheckSyntaxFG.Click += new EventHandler(OnBtnCheckSyntaxFGClick);
            e.BtnCheckSyntaxPF.Click += new EventHandler(OnBtnCheckSyntaxPFClick);
            e.BtnCheckSyntaxPS.Click += new EventHandler(OnBtnCheckSyntaxPSClick);

            e.BtnExecuteFG.Click += new EventHandler(OnBtnExecuteFGClick);
            e.BtnExecutePF.Click += new EventHandler(OnBtnExecutePFClick);
            e.BtnExecutePS.Click += new EventHandler(OnBtnExecutePSClick);


            e.PrefixFG.Text = Options.partition_FG_Prefix;
            e.PrefixFN.Text = Options.partition_FI_Prefix;
            e.NamePF.Text = Options.partition_PF_Name;
            e.NamePS.Text = Options.partition_PS_Name;
            e.BoundaryOnRight.Checked = true;

            startFG = e.StartFG.Value;
            prefixFG = e.PrefixFG.Text;
            prefixFN = e.PrefixFN.Text;
        }

        protected virtual void OnBtnReloadFGClick(object sender, EventArgs ea)
        {
            startFG = e.StartFG.Value;
            endFG = e.EndFG.Value;

            DataTable dt = new DataTable();
            dt.Columns.Add("FG");
            dt.Columns.Add("FN");

            string sql = string.Empty;
            while (startFG < endFG)
            {
                string yyyyMM = startFG.AddDays(0).Date.AddSeconds(0).ToString("yyyyMM");
                sql = string.Concat("ALTER DATABASE [", e.TnTgtDatabase.Data.ObjectText, "] ADD FILEGROUP ["
                                              , prefixFG, yyyyMM
                                              , "];", Environment.NewLine
                                              , "ALTER DATABASE [", e.TnTgtDatabase.Data.ObjectText, "] ADD FILE "
                                              , "( NAME = ", prefixFN, yyyyMM
                                              , ", FILENAME = 'C:\\MSSQL\\Data\\", e.TnTgtDatabase.Data.ObjectText, "_", yyyyMM, ".ndf'"
                                              , ", SIZE = 1MB"
                                              , ", FILEGROWTH = 1MB) TO FILEGROUP [", prefixFG, yyyyMM, "];"
                                              );
                Console.WriteLine(sql);
                
                DataRow dr = dt.NewRow();
                dr[0] = string.Concat(prefixFG, yyyyMM);
                dr[1] = string.Concat("'C:\\MSSQL\\Data\\", e.TnTgtDatabase.Data.ObjectText, "_", yyyyMM, ".ndf'");
                dt.Rows.Add(dr);
                
                startFG = startFG.AddMonths(1);
            }
            e.GridFileGroups.DataSource = dt;
        }

        protected virtual void OnBtnReloadPFClick(object sender, EventArgs ea)
        {
        }

        protected virtual void OnBtnReloadPSClick(object sender, EventArgs ea)
        {
        }

        protected virtual void OnBtnCheckSyntaxFGClick(object sender, EventArgs ea)
        {
        }

        protected virtual void OnBtnCheckSyntaxPFClick(object sender, EventArgs ea)
        {
        }

        protected virtual void OnBtnCheckSyntaxPSClick(object sender, EventArgs ea)
        {
        }

        protected virtual void OnBtnExecuteFGClick(object sender, EventArgs ea)
        {
        }

        protected virtual void OnBtnExecutePFClick(object sender, EventArgs ea)
        {
        }

        protected virtual void OnBtnExecutePSClick(object sender, EventArgs ea)
        {
        }

    }
}
