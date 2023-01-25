using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsiMigrationHelper
{
    public class ExceptionEmptyResultSet : Exception
    {
        public bool retry { get; set; }
        
        public ExceptionEmptyResultSet()
        {
        }

        public ExceptionEmptyResultSet(string message)
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

        public ExceptionEmptyResultSet(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
