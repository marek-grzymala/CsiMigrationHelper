using System;
using System.Text;
using System.Data;
using System.Windows.Forms;

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

        private string sqlExecuteFG;
        private string sqlExecutePF;
        private string sqlExecutePS;

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


            DateTime defaultStart = DateTime.Parse("2022-01-01 00:00:00");
            DateTime defaultEnd = DateTime.Parse("2023-01-01 00:00:00");

            e.StartFG.Value = defaultStart;
            e.EndFG.Value = defaultEnd;
            e.StartPF.Value = defaultStart;
            e.EndPF.Value = defaultEnd;
            e.StartPS.Value = defaultStart;
            e.EndPS.Value = defaultEnd;

            startFG = e.StartFG.Value;
            endFG   = e.EndFG.Value;
            prefixFG = e.PrefixFG.Text;
            prefixFN = e.PrefixFN.Text;
            startPF = e.StartPF.Value;
            endPF = e.EndPF.Value;
            startPS = e.StartPS.Value;
            endPS = e.EndPS.Value;
        }

        protected virtual void OnBtnReloadFGClick(object sender, EventArgs ea)
        {
            if (LoadGridFG())
            {
                e.BtnReloadFG.Image = e.ImageList1.Images[0];
                e.BtnCheckSyntaxFG.Enabled = true;
                e.BtnCheckSyntaxFG.Image = null;
                e.BtnExecuteFG.Enabled = false;
                e.BtnExecuteFG.Image = null;

            }
            else
            {
                e.BtnReloadFG.Image = e.ImageList1.Images[1];
                e.BtnCheckSyntaxFG.Enabled = false;
                e.BtnCheckSyntaxFG.Image = null;
                e.BtnExecuteFG.Enabled = false;
                e.BtnExecuteFG.Image = null;
            }
        }

        protected virtual void OnBtnReloadPFClick(object sender, EventArgs ea)
        {
            if (LoadGridPF())
            {
                e.BtnReloadPF.Image = e.ImageList1.Images[0];
                e.BtnCheckSyntaxPF.Enabled = true;
                e.BtnCheckSyntaxPF.Image = null;
                e.BtnExecutePF.Enabled = false;
                e.BtnExecutePF.Image = null;

            }
            else
            {
                e.BtnReloadPF.Image = e.ImageList1.Images[1];
                e.BtnCheckSyntaxPF.Enabled = false;
                e.BtnCheckSyntaxPF.Image = null;
                e.BtnExecutePF.Enabled = false;
                e.BtnExecutePF.Image = null;
            }
        }

        protected virtual void OnBtnReloadPSClick(object sender, EventArgs ea)
        {
            if (LoadGridPS())
            {
                e.BtnReloadPS.Image = e.ImageList1.Images[0];
                e.BtnCheckSyntaxPS.Enabled = true;
                e.BtnCheckSyntaxPS.Image = null;
                e.BtnExecutePS.Enabled = false;
                e.BtnExecutePS.Image = null;

            }
            else
            {
                e.BtnReloadPS.Image = e.ImageList1.Images[1];
                e.BtnCheckSyntaxPS.Enabled = false;
                e.BtnCheckSyntaxPS.Image = null;
                e.BtnExecutePS.Enabled = false;
                e.BtnExecutePS.Image = null;
            }
        }

        protected virtual void OnBtnCheckSyntaxFGClick(object sender, EventArgs ea)
        {
            if (CheckSqlSyntaxFG())
            {
                e.BtnCheckSyntaxFG.Image = e.ImageList1.Images[0];
            }
            else
            {
                e.BtnCheckSyntaxFG.Image = e.ImageList1.Images[1];
            }
        }

        protected virtual void OnBtnCheckSyntaxPFClick(object sender, EventArgs ea)
        {
            if (CheckSqlSyntaxPF())
            {
                e.BtnCheckSyntaxPF.Image = e.ImageList1.Images[0];
            }
            else
            {
                e.BtnCheckSyntaxPF.Image = e.ImageList1.Images[1];
            }
        }

        protected virtual void OnBtnCheckSyntaxPSClick(object sender, EventArgs ea)
        {
            if (CheckSqlSyntaxPS())
            {
                e.BtnCheckSyntaxPS.Image = e.ImageList1.Images[0];
            }
            else
            {
                e.BtnCheckSyntaxPS.Image = e.ImageList1.Images[1];
            }
        }

        protected virtual void OnBtnExecuteFGClick(object sender, EventArgs ea)
        {
            try
            {
                if (e.TgtInstance.Data.Dbu.ExecuteSql(e.TgtInstance
                    , sqlExecuteFG
                    , string.Concat("Error Creating FileGroups")))
                {
                    e.BtnExecuteFG.Image = e.ImageList1.Images[0];
                }
            }
            catch (ExceptionSqlExecError ex) 
            {
                e.BtnExecuteFG.Image = e.ImageList1.Images[1];
                if (ex.retry)
                {
                    OnBtnExecuteFGClick(sender, ea);
                }
            }
        }

        protected virtual void OnBtnExecutePFClick(object sender, EventArgs ea)
        {
            try
            {
                if (e.TgtInstance.Data.Dbu.ExecuteSql(e.TgtInstance
                    , sqlExecutePF
                    , string.Concat("Error Creating Partition Function: ", e.NamePF.Text)))
                {
                    e.BtnExecutePF.Image = e.ImageList1.Images[0];
                }
            }
            catch (ExceptionSqlExecError ex)
            {
                e.BtnExecutePF.Image = e.ImageList1.Images[1];
                if (ex.retry)
                {
                    OnBtnExecutePFClick(sender, ea);
                }
            }
        }

        protected virtual void OnBtnExecutePSClick(object sender, EventArgs ea)
        {
            try
            {
                if (e.TgtInstance.Data.Dbu.ExecuteSql(e.TgtInstance
                    , sqlExecutePS
                    , string.Concat("Error Creating Partition Scheme: ", e.NamePS.Text)))
                {
                    e.BtnExecutePS.Image = e.ImageList1.Images[0];
                }
            }
            catch (ExceptionSqlExecError ex)
            {
                e.BtnExecutePS.Image = e.ImageList1.Images[1];
                if (ex.retry)
                {
                    OnBtnExecutePSClick(sender, ea);
                }
            }
        }

        
        private bool LoadGridFG()
        {
            startFG = e.StartFG.Value;
            endFG = e.EndFG.Value;
            prefixFG = e.PrefixFG.Text;
            prefixFN = e.PrefixFN.Text;

            DataTable dt = new DataTable();
            dt.Columns.Add("Rn");
            dt.Columns.Add("FileGroup");
            dt.Columns.Add("FileName");
            dt.Columns.Add("FilePath");

            int rn = 1;
            while (startFG < endFG)
            {
                string yyyyMM = startFG.AddDays(0).Date.AddSeconds(0).ToString("yyyyMM");
                DataRow dr = dt.NewRow();
                dr["Rn"] = rn;
                dr["FileGroup"] = string.Concat(prefixFG, yyyyMM);
                dr["FileName"] = string.Concat(prefixFN, yyyyMM);
                dr["FilePath"] = string.Concat("'C:\\MSSQL\\Data\\", e.TgtDatabase.Data.ObjectText, "_", yyyyMM, ".ndf'");
                dt.Rows.Add(dr);

                startFG = startFG.AddMonths(1);
                rn++;
            }
            e.GridFileGroups.DataSource = dt;
            e.GridFileGroups.Columns["FileGroup"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            e.GridFileGroups.Columns["FileName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            e.GridFileGroups.Columns["FilePath"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            return true;
        }

        private bool LoadGridPF()
        {
            if (e.GridFileGroups.RowCount < 1)
            {
                MessageBox.Show("Load FileGroups First", "Load FileGroups First", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                startPF = e.StartPF.Value;
                endPF = e.EndPF.Value;
                DataTable dt = new DataTable();

                dt.Columns.Add("Rn");
                dt.Columns.Add("Condition");
                dt.Columns.Add("DateBoudary");
                string condition = e.BoundaryOnRight.Checked ? "before" : "after";
                int counter = 1;
                while (startPF < endPF && counter < e.GridFileGroups.RowCount - 1)
                {
                    DataRow dr = dt.NewRow();
                    dr["Rn"] = counter;
                    dr["Condition"] = condition;
                    if (e.BoundaryOnRight.Checked)
                    {
                        dr["DateBoudary"] = startPF.AddMonths(1).Date.AddSeconds(0).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        dr["DateBoudary"] = startPF.AddDays(0).Date.AddSeconds(0).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    dt.Rows.Add(dr);
                    startPF = startPF.AddMonths(1);
                    counter++;
                }
                e.GridPF.DataSource = dt;
                e.GridPF.Columns["Condition"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                e.GridPF.Columns["DateBoudary"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                return true;
            }
        }

        private bool LoadGridPS()
        {
            if (e.GridFileGroups.RowCount < 1)
            {
                MessageBox.Show("Load FileGroups First", "Load FileGroups First", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                startPS = e.StartPS.Value;
                endPS = e.EndPS.Value;

                DataTable dt = new DataTable();
                dt.Columns.Add("Rn");
                dt.Columns.Add("FileGroupMapped");
                int i = 0;
                while (i < e.GridFileGroups.RowCount - 1)
                {
                    DataRow dr = dt.NewRow();
                    dr["Rn"] = i + 1;
                    dr["FileGroupMapped"] = string.Concat("'", e.GridFileGroups.Rows[i].Cells[1].Value, "'");
                    dt.Rows.Add(dr);
                    startPS = startPS.AddMonths(1);
                    Console.WriteLine(string.Concat("i: ", e.GridFileGroups.Rows[i].Cells[1].Value));
                    i++;
                }
                e.GridPS.DataSource = dt;
                e.GridPS.Columns["FileGroupMapped"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;            
                return true;
            }
        }

        private bool CheckSqlSyntaxFG()
        {
            bool result = false;
            StringBuilder sql = new StringBuilder();
            foreach (DataGridViewRow row in e.GridFileGroups.Rows)
            {
                if (row.Cells["FileGroup"].Value != null)
                {
                    StringBuilder sbFG = new StringBuilder();
                    sbFG.Append(string.Concat("ALTER DATABASE [", e.TgtDatabase.Data.ObjectText, "] ADD FILEGROUP [", row.Cells["FileGroup"].Value, "];", Environment.NewLine));
                    sbFG.Append(string.Concat("ALTER DATABASE [", e.TgtDatabase.Data.ObjectText, "] ADD FILE (NAME = "
                                                                    , row.Cells["FileName"].Value
                                                                    , ", FILENAME = ", row.Cells["FilePath"].Value
                                                                    , ", SIZE = 1MB"
                                                                    , ", FILEGROWTH = 1MB"
                                                                    , ") TO FILEGROUP [", row.Cells["FileGroup"].Value, "];"));
                //Console.WriteLine(sbFG.ToString());
                sql.Append(sbFG);
                }
            }

            try
            {
                if (e.TgtInstance.Data.Dbu.ParseSql(e.TgtInstance, sql.ToString()))
                {
                    e.BtnExecuteFG.Image = null;
                    e.BtnExecuteFG.Enabled = true;
                    sqlExecuteFG = sql.ToString();
                    result = true;
                }
            }
            catch (ExceptionSqlParseError ex)
            {
                e.BtnExecuteFG.Image = null;
                e.BtnExecuteFG.Enabled = false;
                result = false;
            }
            return result;
        }

        private bool CheckSqlSyntaxPF()
        {
            bool result = false;
            StringBuilder sql = new StringBuilder();
            sql.Append(string.Concat("CREATE PARTITION FUNCTION [", e.NamePF.Text, "] (DATETIME) AS RANGE", e.BoundaryOnRight.Checked ? " RIGHT " : " LEFT "
                                    , "FOR VALUES (", Environment.NewLine));
            foreach (DataGridViewRow row in e.GridPF.Rows)
            {
                StringBuilder sbPF = new StringBuilder();
                if (row.Cells["DateBoudary"].Value != null)
                {
                    sbPF.Append(string.Concat("'", row.Cells["DateBoudary"].Value, "'", (row.Index + 2) < e.GridPF.RowCount ? ", " : ");"));
                    sql.Append(sbPF);
                }
            }
            try
            {
                if (e.TgtInstance.Data.Dbu.ParseSql(e.TgtInstance, sql.ToString()))
                {
                    e.BtnExecutePF.Image = null;
                    e.BtnExecutePF.Enabled = true;
                    sqlExecutePF = sql.ToString();
                    result = true;
                }
            }
            catch (ExceptionSqlParseError ex)
            {
                e.BtnExecutePF.Image = null;
                e.BtnExecutePF.Enabled = false;
                result = false;
            }
            return result;
        }

        private bool CheckSqlSyntaxPS()
        {
            
            bool result = false;
            StringBuilder sql = new StringBuilder();
            sql.Append(string.Concat("CREATE PARTITION SCHEME [", e.NamePS.Text, "] AS PARTITION [", e.NamePF.Text
                                    , "] TO (", Environment.NewLine));
            foreach (DataGridViewRow row in e.GridPS.Rows)
            {
                StringBuilder sbPS = new StringBuilder();
                if (row.Cells["FileGroupMapped"].Value != null)
                {
                    sbPS.Append(string.Concat(row.Cells["FileGroupMapped"].Value, (row.Index + 1) < e.GridPF.RowCount ? ", " : ");"));
                    sql.Append(sbPS);
                }
            }
            try
            {
                if (e.TgtInstance.Data.Dbu.ParseSql(e.TgtInstance, sql.ToString()))
                {
                    e.BtnExecutePS.Image = null;
                    e.BtnExecutePS.Enabled = true;
                    sqlExecutePS = sql.ToString();
                    result = true;
                }
            }
            catch (ExceptionSqlParseError ex)
            {
                e.BtnExecutePS.Image = null;
                e.BtnExecutePS.Enabled = false;
                result = false;
            }
            return result;
        }
    }
}
