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

            if (message.Contains("Invalid column name"))
            {
                MessageBox.Show(customMsgOnError + Environment.NewLine + string.Concat(message), customMsgOnError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (MessageBox.Show(string.Concat(customMsgOnError + Environment.NewLine + message, Environment.NewLine
                    , "Do you want to retry?"), "Confirm Selection"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    retry = false;
                }
                else
                {
                    retry = true;
                }
            }
        }

        public ExceptionSqlExecError(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
