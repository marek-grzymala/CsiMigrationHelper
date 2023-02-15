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
        public DateTimePicker StartPS         ;
        public DateTimePicker EndPS           ;
        public TextBox        PrefixFG        ;
        public TextBox        PrefixFN        ;
        public TextBox        NamePF          ;
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
                                      , DateTimePicker startPS
                                      , DateTimePicker endPS
                                      , TextBox prefixFG
                                      , TextBox prefixFN
                                      , TextBox namePF
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
            StartPS         = startPS        ;
            EndPS           = endPS          ;
            PrefixFG        = prefixFG       ;
            PrefixFN        = prefixFN       ;
            NamePS          = namePS         ;
            NamePF          = namePF         ;
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
            ImageList1        = imageList1;
        }
    }
}
