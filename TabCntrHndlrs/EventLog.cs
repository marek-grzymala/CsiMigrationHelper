using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsiMigrationHelper
{
    public class EventLog
    {
        public static RichTextBox evl { get; set; }

        public EventLog(RichTextBox _evl)
        {
            evl = _evl;
        }

        public static void AppendLog(string s)
        {
            StringBuilder sb = new StringBuilder(evl.Text);
            sb.Append(string.Concat(Environment.NewLine, "-----------------------------------", DateTime.Today.ToString(), "-----------------------------------", Environment.NewLine));
            sb.Append(s);
            evl.Text = sb.ToString();
        }
    }
}
