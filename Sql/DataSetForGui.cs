using System;
using System.Data;

namespace CsiMigrationHelper
{
    public class DataSetForGui : EventArgs
    {

        public DataSet Ds { get; set; }
        public ParamSelector ParamSelect;
        //public string NewCbxSelection { get; set; }

        public DataSetForGui() { }
        
        public DataSetForGui(
                                              DataSet      ds
                                            , ParamSelector parSelect
                                            //, string newCbxSelection
                                           )
        {
            Ds = ds;
            ParamSelect = parSelect;
            //NewCbxSelection = newCbxSelection;
        }
    }
}
