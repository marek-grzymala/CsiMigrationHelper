using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsiMigrationHelper
{
    public class EventArgsDbObjectChanged : EventArgs
    {
        public DbObject DbObj { get; set; }
        public string NewObjectText { get; set; }
        public bool NewEnabledState { get; set; }

        public EventArgsDbObjectChanged(DbObject dbObject, string newObjectText)
        {
            DbObj = dbObject;
            NewObjectText = newObjectText;
        }

        public EventArgsDbObjectChanged(DbObject dbObject, bool newEnabledState)
        {
            DbObj = dbObject;
            NewEnabledState = newEnabledState;
        }
    }
}
