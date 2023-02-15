﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsiMigrationHelper
{
    public class ComboBoxExtTrackTbl : ComboBoxExt
    {

        public Button      BtnLoginTrackTbl;
        public TextBox     Tbx_TrackTbl_Instance;
        public ComboBoxExt Cbxt_TrackTbl_Database;
        public ComboBoxExt Cbxt_TrackTbl_Schema;
        public RadioButton RdButtonCreateNew;
        public RadioButton RdButtonUseExisting;
        public GroupBox    RdButtonsGroupBox;
        public Button      SaveButton;
        public Button      EditButton;
        public TextBox     ProjectDescription;

        public ComboBoxExtTrackTbl()
        {

        }

        public void SetParentTreeNode(TreeNode<DbObject> tn
                                    , Button        btnLoginTrackTbl
                                    , TextBox       tbx_TrackTbl_Instance
                                    , ComboBoxExt   cbxt_TrackTbl_Database
                                    , ComboBoxExt   cbxt_TrackTbl_Schema
                                    , RadioButton rbtnNew
                                    , RadioButton rbtnExisting
                                    , GroupBox rdButtonsGroupBox
                                    , Button saveButton
                                    , Button renameButton
                                    , TextBox projectDescription)
        {
            TreeNodeOwner       = tn                    != null ? tn : null;
            BtnLoginTrackTbl        = btnLoginTrackTbl       != null ? btnLoginTrackTbl       : null;
            Tbx_TrackTbl_Instance   = tbx_TrackTbl_Instance  != null ? tbx_TrackTbl_Instance  : null;
            Cbxt_TrackTbl_Database  = cbxt_TrackTbl_Database != null ? cbxt_TrackTbl_Database : null;
            Cbxt_TrackTbl_Schema = cbxt_TrackTbl_Schema != null ? cbxt_TrackTbl_Schema : null;

            RdButtonCreateNew   = rbtnNew               != null ? rbtnNew : null;
            RdButtonUseExisting = rbtnExisting          != null ? rbtnExisting : null;
            RdButtonsGroupBox   = rdButtonsGroupBox     != null ? rdButtonsGroupBox : null;
            SaveButton          = saveButton            != null ? saveButton : null;
            EditButton          = renameButton          != null ? renameButton : null;
            ProjectDescription  = projectDescription    != null ? projectDescription : null;
            if (RdButtonCreateNew != null)
            {
                RdButtonCreateNew.CheckedChanged += new EventHandler(OnRdButtonCheckedChanged);
            }
            this.TextChanged += new EventHandler(OnTextChanged);
            EditButton.Click += new EventHandler(UnLockGuiControls);
        }
        protected virtual void OnTextChanged(object sender, EventArgs e)
        {
            if (RdButtonCreateNew.Checked && Text.Length > 0)
            {
                this.TreeNodeOwner.SetTreeNodeTextNoSubtreeClearing(TreeNodeOwner, Text, false);
                /* enable or disable Save Button depending on Text Length: */
                this.SaveButton.Enabled = true;
                this.SaveButton.Image = null;
            }
            else
            {
                this.SaveButton.Enabled = false;
                this.SaveButton.Image = null;
            }
        }

        public void RunOnRdButtonCheckedChanged(object sender, EventArgs e)
        {
            this.OnRdButtonCheckedChanged(sender, e);
        }

        protected virtual void OnRdButtonCheckedChanged(object sender, EventArgs e)
        {
            if (TreeNodeOwner.Data.ObjectBranch == (int)DbObjectBranch.TrckTbl && RdButtonCreateNew != null && SaveButton != null)
            {
                if (RdButtonCreateNew.Checked)
                {
                    if (TreeNodeOwner.Parent.IsTextSet())
                    {
                        int objectLevel = TreeNodeOwner.Data.ObjectLevel;
                        switch (objectLevel)
                        {
                            case (int)DbObjectLevel.Table:
                                TreeNodeOwner.Data.Gui.ClearGui();
                                TreeNodeOwner.SetTreeNodeText(TreeNodeOwner, Options.projectsTableDefaultName, false);
                                break;

                            case (int)DbObjectLevel.Column:
                                TreeNodeOwner.Data.Gui.ClearGui();                                
                                TreeNodeOwner.SetTreeNodeText(TreeNodeOwner, Options.newProjectDefaultName, false);
                                TreeNodeOwner.SetTextOfDirectChildren(TreeNodeOwner, Options.newProjectDefaultDescription);
                                break;
                        }
                    }
                    /* enable or disable Save Button depending on RdButton State and Cbx Text Length: */
                    SaveButton.Enabled = (Text.Length > 0) ? true : false;
                }
                else
                {
                    SaveButton.Enabled = false;
                }
            }
        }

        public void LockGuiControls()
        {
            this.Enabled                = false;
            BtnLoginTrackTbl.Enabled    = false;
            Tbx_TrackTbl_Instance.Enabled       = false;
            Cbxt_TrackTbl_Database.Enabled      = false;
            Cbxt_TrackTbl_Schema.Enabled        = false;

            RdButtonsGroupBox.Enabled   = false;
            SaveButton.Enabled          = false;
            EditButton.Enabled          = true;
            if (ProjectDescription != null)
            {
                ProjectDescription.Enabled = false;
            }
        }

        public void UnLockGuiControls(object sender, EventArgs e)
        {
            this.Enabled                = true;
            BtnLoginTrackTbl.Enabled = true;
            Tbx_TrackTbl_Instance.Enabled = true;
            Cbxt_TrackTbl_Database.Enabled = true;
            Cbxt_TrackTbl_Schema.Enabled = true;

            RdButtonsGroupBox.Enabled   = true;
            SaveButton.Enabled          = true;
            EditButton.Enabled          = false;
            if (ProjectDescription != null)
            {
                ProjectDescription.Enabled = true;
            }
        }
    }
}
