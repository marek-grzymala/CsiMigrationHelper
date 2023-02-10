using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace CsiMigrationHelper
{
    public delegate void HandlerDbObjectTextChanged(object sender, EventArgsDbObjectChanged e);

    public class DbObject
    {
        public event HandlerDbObjectTextChanged eventDbObjectTextChanged;

        public int ObjectBranch { get; set; }
        public int ObjectLevel { get; set; }
        public string ObjectName { get; set; }
        public string ObjectText { get; set; }
        public DbUtil Dbu { get; set; }
        public GuiElem Gui { get; set; }
        private SqlParameter SqlParam { get; set; }

        public DbObject(DbObjectBranch objectBranch, DbObjectLevel objectLevel, string objectName, string objectText, GuiElem gui)
        {
            ObjectBranch = GetIndexOfObjectBranch(objectBranch);
            ObjectLevel = GetIndexOfObjectLevel(objectLevel);
            ObjectName = objectName;
            Gui = gui;
            InitializeDbObject(objectText); // this line has to be last because SetObjectText(objectText) triggers OnDbObjectTextChanged which needs all class members to be instatiated
        }

        public DbObject(DbObjectBranch objectBranch, DbObjectLevel objectLevel, string objectName, string objectText, GuiElem gui, DbUtil dbu)
        {
            ObjectBranch = GetIndexOfObjectBranch(objectBranch);
            ObjectLevel = GetIndexOfObjectLevel(objectLevel);
            ObjectName = objectName;
            Gui = gui;
            Dbu = dbu;
            InitializeDbObject(objectText); // this line has to be last because SetObjectText(objectText) triggers OnDbObjectTextChanged which needs all class members to be instatiated
        }

        public void InitializeDbObject(string newObjectText)
        {
            eventDbObjectTextChanged += new HandlerDbObjectTextChanged(OnDbObjectTextChanged);
            var deleg = eventDbObjectTextChanged as HandlerDbObjectTextChanged;
            if (deleg != null)
            {
                deleg(this, new EventArgsDbObjectChanged(this, newObjectText)); //this line triggers the execution of OnDbObjectTextChanged()
            }
            ObjectText = newObjectText;
            eventDbObjectTextChanged -= new HandlerDbObjectTextChanged(OnDbObjectTextChanged);
        }

        public void SetDbObjectText(TreeNode<DbObject> t, string newObjectText)
        {
            if (t.Data.ObjectText != null)
            {
                if (!t.Data.ObjectText.Equals(newObjectText))
                {
                    eventDbObjectTextChanged += new HandlerDbObjectTextChanged(OnDbObjectTextChanged);

                    ObjectText = newObjectText;                
                    SqlParam = new SqlParameter()
                    {
                        ParameterName = ParamSelector.GetParamMetaByObjectLvl(ObjectLevel).ParameterName, //DbUtil.GetSqlParameterNameByObjectLevel(ObjectLevel),
                        SqlDbType = SqlDbType.VarChar,
                        Size = 4000,
                        Value = ObjectText
                    };

                    var textChanged = eventDbObjectTextChanged as HandlerDbObjectTextChanged;
                    if (textChanged != null)
                    {
                        if ((t.Data != null) && (t.Data is DbObject))
                        {
                            if (t != null)
                            {
                                textChanged(t, new EventArgsDbObjectChanged(t.Data, newObjectText)); //this line triggers the execution of method(s) specified on t.eventNodeAdded in AddEventHandler()
                            }
                        }
                    }
                    if (t.Data.ObjectLevel >= (int)DbObjectLevel.Table && t.HasCousins)
                    {
                        foreach (TreeNode<DbObject> cousin in t.Cousins)
                        {
                            if (
                                   cousin.Enabled
                                && cousin.CloneableFromSrc
                                && cousin.TraverseUpUntil(cousin, (int)DbObjectLevel.Schema).Enabled
                                && cousin.TraverseUpUntil(cousin, (int)DbObjectLevel.Schema).Data.Gui.IsTextSet()
                                && t.Data.ObjectText.Length > 0
                                )
                            {
                                /*
                                Console.WriteLine(string.Concat("CONING INTO Tgt Branch Cousin: [", cousin.Data.ObjectName,
                                                                "] with Text: [", cousin.Data.ObjectText,
                                                                "] detected for: [", t.Data.ObjectName,
                                                                "] with Text: [", t.Data.ObjectText, "]"));
                                */

                                string indexNameTgt = string.Empty;
                                string tableNameSuffix = string.Empty;

                                switch (cousin.Data.ObjectLevel)
                                {
                                    case (int)DbObjectLevel.Table:
                                        tableNameSuffix = Options.GetTableSuffixPerNode(cousin);
                                        // clone Src table name into Tgt cousin appending the suffix:
                                        cousin.SetTreeNodeText(cousin, string.Concat(newObjectText, tableNameSuffix));
                                        break;

                                    case (int)DbObjectLevel.Index:
                                        // clone cousin's index name into Tgt with CSI Prefix:
                                        cousin.SetTreeNodeText(cousin, string.Concat(Options.prefixCSI, newObjectText));
                                        break;

                                    default:
                                        // clone Src object name into Tgt cousin without any change:
                                        cousin.SetTreeNodeText(cousin, newObjectText);
                                        break;
                                }                        
                            }
                            else if (t.Data.ObjectLevel == (int)DbObjectLevel.DataType
                                    &&  cousin.Enabled
                                    && !cousin.CloneableFromSrc
                                    &&  cousin.TraverseUpUntil(cousin, (int)DbObjectLevel.Schema).Enabled
                                    &&  cousin.TraverseUpUntil(cousin, (int)DbObjectLevel.Schema).Data.Gui.IsTextSet()
                                    &&  cousin.Data.ObjectText.Length > 0
                                    &&  t.Data.ObjectText.Length > 0
                                    && !t.Data.ObjectText.Equals(cousin.Data.ObjectText)
                                    )
                            {

                                string cBranch = cousin.Data.ObjectBranch == (int)DbObjectBranch.Src ? "Source" : "Target";
                                string tBranch = t.Data.ObjectBranch == (int)DbObjectBranch.Src ? "Source" : "Target";

                                string errorMsg = string.Concat("DataType mismatch detected between: ", Environment.NewLine, 
                                                                "Data Types in ", cBranch, ": [", cousin.Data.ObjectText
                                                                , "] and in ", tBranch, ": [", t.Data.ObjectText, "]", Environment.NewLine);
                                
                                eventDbObjectTextChanged -= new HandlerDbObjectTextChanged(OnDbObjectTextChanged);
                                throw new ExceptionDataTypeMismatch(errorMsg);
                            }
                        }
                    }
                    eventDbObjectTextChanged -= new HandlerDbObjectTextChanged(OnDbObjectTextChanged);
                }
            }
        }

        public override string ToString()
        {
            return ObjectText != null ? ObjectText : "[DbObject is null]";
        }

        public static int GetIndexOfObjectLevel(DbObjectLevel ol)
        {
            var enumValues = Enum.GetValues(typeof(DbObjectLevel)).Cast<DbObjectLevel>().ToList();
            return enumValues.IndexOf(ol);
        }

        public static int GetIndexOfObjectBranch(DbObjectBranch ob)
        {
            var enumValues = Enum.GetValues(typeof(DbObjectBranch)).Cast<DbObjectBranch>().ToList();
            return enumValues.IndexOf(ob);
        }

        public static string GetObjectLevelByIndex(int index)
        {
            if (Enum.IsDefined(typeof(DbObjectLevel), index))
                return ((DbObjectLevel)index).ToString();
            else
                return string.Concat("Method GetObjectLevelByIndex() received an invalid Index Value: [", index.ToString(), "]");
        }

        public SqlParameter GetSqlParam()
        {
            return SqlParam;
        }
        public void OnDbObjectTextChanged(object sender, EventArgsDbObjectChanged e)
        {
            if (Gui != null && e.NewObjectText != null)
            {
                Gui.SetGuiText(e);
            }
        }
    }

    public enum DbObjectLevel : int
    {
        Unassigned          = -1,
        Root                = 0,
        Instance            = 1,
        Database            = 2,
        Schema              = 3,
        Table               = 4,
        Column              = 5,
        DataType            = 6,
        PartitionScheme     = 7,
        Index               = 8,
    }

    public enum DbObjectBranch : int
    {        
        Dummy = -1,
        Root = 0,
        Src = 1,
        Tgt = 2,
        TrckTbl = 3,
    }
}
