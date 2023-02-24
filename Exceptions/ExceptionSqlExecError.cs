using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsiMigrationHelper
{
    public class ExceptionSqlExecError : Exception
    {
        public bool retry { get; set; }

        public ExceptionSqlExecError()
        {
        }

        public ExceptionSqlExecError(string message, string customMsgOnError)
            : base(message)
        {
            {
                if (MessageBox.Show(string.Concat(customMsgOnError + Environment.NewLine + message, Environment.NewLine
                    , "Do you want to retry?"), "Confirm Selection"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    retry = true;
                }
                else
                {
                    retry = false;
                }
            }
        }

        public ExceptionSqlExecError(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
