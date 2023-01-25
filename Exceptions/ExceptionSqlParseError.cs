using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsiMigrationHelper
{
    public class ExceptionSqlParseError : Exception
    {
        public bool retry { get; set; }

        public ExceptionSqlParseError()
        {
        }

        public ExceptionSqlParseError(string message)
            : base(message)
        {
            if (MessageBox.Show(string.Concat(message, Environment.NewLine
                , "Are you sure you want to keep the selection?"), "Confirm Selection"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                retry = false;
            }
            else
            {
                retry = true;
            }
        }

        public ExceptionSqlParseError(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
