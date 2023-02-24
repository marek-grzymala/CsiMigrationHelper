using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsiMigrationHelper
{
    public class EventArgsPartitionSetup : EventArgs
    {
        public TreeNode<DbObject> TgtInstance;
        public TreeNode<DbObject> TgtDatabase;
        public DateTimePicker StartFG         ;
        public DateTimePicker EndFG           ;
        public DateTimePicker StartPF         ;
        public DateTimePicker EndPF           ;
        public TextBox        PrefixFG        ;
        public TextBox        PrefixFN        ;
        public TextBox        NamePF          ;
        public ComboBox       NamePFcbx       ;          
        public TextBox        NamePS          ;
        public RadioButton    BoundaryOnRight ;
        public DataGridView   GridFileGroups  ;
        public DataGridView   GridPF          ;
        public DataGridView   GridPS          ;
        public Button         BtnReloadFG     ;
        public Button         BtnReloadPF     ;
        public Button         BtnReloadPS     ;
        public Button         BtnCheckSyntaxFG;
        public Button         BtnCheckSyntaxPF;
        public Button         BtnCheckSyntaxPS;
        public Button         BtnExecuteFG    ;
        public Button         BtnExecutePF    ;
        public Button         BtnExecutePS    ;
        public ImageList      ImageList1;

        public EventArgsPartitionSetup(
                                        TreeNode<DbObject> tnTgtInstance
                                      , TreeNode<DbObject> tnTgtDatabase
                                      , DateTimePicker startFG
                                      , DateTimePicker endFG
                                      , DateTimePicker startPF
                                      , DateTimePicker endPF
                                      , TextBox prefixFG
                                      , TextBox prefixFN
                                      , TextBox namePF
                                      , ComboBox namePFcbx
                                      , TextBox namePS
                                      , RadioButton boundaryOnRight
                                      , DataGridView gridFileGroups
                                      , DataGridView gridPartitionFunction
                                      , DataGridView gridPartitionScheme
                                      , Button btnReloadFG
                                      , Button btnReloadPF
                                      , Button btnReloadPS
                                      , Button btnCheckSyntaxFG
                                      , Button btnCheckSyntaxPF
                                      , Button btnCheckSyntaxPS
                                      , Button btnExecuteFG
                                      , Button btnExecutePF
                                      , Button btnExecutePS
                                      , ImageList imageList1
                                      )
        {
            TgtInstance   = tnTgtInstance  ;
            TgtDatabase   = tnTgtDatabase  ;
            StartFG         = startFG        ;
            EndFG           = endFG          ;
            StartPF         = startPF        ;
            EndPF           = endPF          ;
            PrefixFG        = prefixFG       ;
            PrefixFN        = prefixFN       ;
            NamePF          = namePF         ;
            NamePFcbx       = namePFcbx      ;
            NamePS          = namePS         ;
            BoundaryOnRight = boundaryOnRight;
            GridFileGroups  = gridFileGroups;
            GridPF          = gridPartitionFunction;
            GridPS          = gridPartitionScheme;
            BtnReloadFG       = btnReloadFG         ;
            BtnReloadPF       = btnReloadPF         ;
            BtnReloadPS       = btnReloadPS         ;
            BtnCheckSyntaxFG  = btnCheckSyntaxFG    ;
            BtnCheckSyntaxPF  = btnCheckSyntaxPF    ;
            BtnCheckSyntaxPS  = btnCheckSyntaxPS    ;
            BtnExecuteFG      = btnExecuteFG        ;
            BtnExecutePF      = btnExecutePF        ;
            BtnExecutePS      = btnExecutePS        ;
            ImageList1        = imageList1          ;

            NamePF.TextChanged += new EventHandler(OnNamePFTextChanged);
            NamePS.TextChanged += new EventHandler(OnNamePSTextChanged);
            NamePFcbx.TextChanged += new EventHandler(OnNamePSTextChanged);
        }

        protected virtual void OnNamePFTextChanged(object sender, EventArgs ea)
        {
            BtnExecutePF.Enabled = false;
            BtnReloadPF.Enabled = string.IsNullOrEmpty(NamePF.Text) ? false : true;
        }

        protected virtual void OnNamePSTextChanged(object sender, EventArgs ea)
        {
            BtnExecutePS.Enabled = false;
            BtnReloadPS.Enabled = string.IsNullOrEmpty(NamePS.Text) || NamePFcbx.Items.Count < 1 ? false : true;
        }
    }
}
