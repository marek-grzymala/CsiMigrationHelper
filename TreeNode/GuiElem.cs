using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace CsiMigrationHelper
{
    public class GuiElem
    {
        public ComboBox Cbx { get; set; }
        public ComboBoxExt Cbxt { get; set; }
        public TextBox Tbx { get; set; }
        public TextBoxExt Tbxt { get; set; }

        // constructor has to initialize either Cbx or Tbx (one of those but not both)
        public GuiElem(ComboBox cbx)
        {
            Cbx = cbx;
            //Cbx.DropDownStyle = ComboBoxStyle.DropDownList; // this will prevent any new manual entries into the Cbx
        }

        public GuiElem(ComboBoxExt cbxt)
        {
            Cbxt = cbxt;
            //Cbx.DropDownStyle = ComboBoxStyle.DropDownList; // this will prevent any new manual entries into the Cbx
        }

        public GuiElem(TextBox tbx)
        {
            Tbx = tbx;
        }

        public GuiElem(TextBoxExt tbxt)
        {
            Tbxt = tbxt;
        }

        public Type GetGuiType()
        {
            Type type = null;
            if (Cbx != null)
            {
                type = typeof(ComboBox);
            }
            else if (Cbxt != null)
            {
                type = typeof(ComboBoxExt);
            }
            else if (Tbx != null)
            {
                type = typeof(TextBox);
            }
            else if (Tbxt != null)
            {
                type = typeof(TextBoxExt);
            }
            return type;
        }

        public object GetGuiObject()
        {
            object guiObject = null;
            if (this.GetGuiType() == typeof(ComboBox))
            {
                guiObject = Cbx;
            }
            else if (this.GetGuiType() == typeof(ComboBoxExt))
            {
                guiObject = Cbxt;
            }
            else if (this.GetGuiType() == typeof(TextBox))
            {
                guiObject = Tbx;
            }
            else if (this.GetGuiType() == typeof(TextBoxExt))
            {
                guiObject = Tbxt;
            }
            return guiObject;
        }

        public string GetGuiText()
        {
            string guiText = string.Empty;
            if (this.GetGuiType() == typeof(ComboBox))
            {
                guiText = Cbx.Text;
            }
            else if (this.GetGuiType() == typeof(ComboBoxExt))
            {
                guiText = Cbxt.Text;
            }
            else if (this.GetGuiType() == typeof(TextBox))
            {
                guiText = Tbx.Text;
            }
            else if (this.GetGuiType() == typeof(TextBoxExt))
            {
                guiText = Tbxt.Text;
            }
            return guiText;
        }

        public void SetGuiText(EventArgsDbObjectChanged e)
        {
            if (e.NewObjectText != null)
            {
                if (e.NewObjectText.Length > 0)
                {
                    if (this.GetGuiType() == typeof(ComboBox))
                    {
                        Cbx.Text = e.NewObjectText;
                        Cbx.Enabled = true;
                    }
                    if (this.GetGuiType() == typeof(ComboBoxExt))
                    {
                        Cbxt.Text = e.NewObjectText;
                        Cbxt.Enabled = true;
                    }
                    else if (this.GetGuiType() == typeof(TextBox))
                    {
                        Tbx.Text = e.NewObjectText;
                        Tbx.Enabled = true;
                    }
                    else if (this.GetGuiType() == typeof(TextBoxExt))
                    {
                        Tbxt.Text = e.NewObjectText;
                        Tbxt.Enabled = true;
                    }
                }
                else
                {
                    if (e.DbObj != null)
                    {
                        ClearGui();
                    }
                }
            }
        }

        //public void SetGuiText(EventArgsDbObjectChanged e)
        //{
        //    if (e.NewObjectText != null)
        //    {
        //        if (e.NewObjectText.Length > 0)
        //        {
        //            if (Cbx != null)
        //            {
        //                /* all this below just to handle ComboBox population with ComboBoxStyle.DropDownList: (!) */
        //                DataSet ds = new DataSet();
        //                DataTable dt = new DataTable();

        //                dt.Columns.Add(new DataColumn(ParamSelector.GetParamMetaByObjectLvl(e.DbObj.ObjectLevel).ValueMember, typeof(int))); //ds.ParamSelect.ParamMetaData.ValueMember
        //                dt.Columns.Add(new DataColumn(ParamSelector.GetParamMetaByObjectLvl(e.DbObj.ObjectLevel).DisplayMember, typeof(string))); //e.ParamSelect.ParamMetaData.DisplayMember
        //                DataRow dr = dt.NewRow();
        //                dr[ParamSelector.GetParamMetaByObjectLvl(e.DbObj.ObjectLevel).ValueMember] = 1;
        //                dr[ParamSelector.GetParamMetaByObjectLvl(e.DbObj.ObjectLevel).DisplayMember] = e.NewObjectText;
        //                dt.Rows.Add(dr);
        //                ds.Tables.Add(dt);

        //                Cbx.DataSource = ds.Tables[0];
        //                Cbx.ValueMember = ParamSelector.GetParamMetaByObjectLvl(e.DbObj.ObjectLevel).ValueMember; // "id";
        //                Cbx.DisplayMember = ParamSelector.GetParamMetaByObjectLvl(e.DbObj.ObjectLevel).DisplayMember; // "value";
        //                Cbx.Enabled = true;
        //            }
        //            if (Tbx != null)
        //            {
        //                Tbx.Text = e.NewObjectText;
        //                Tbx.Enabled = true;
        //            }
        //        }
        //        else
        //        {
        //            ClearGui();
        //        }
        //    }
        //}

        public void ClearGui()
        {
            try
            {
                if (this.GetGuiType() == typeof(ComboBox))
                {                  
                    Cbx.DataSource = null;
                    Cbx.Items.Clear();
                    Cbx.SelectedIndex = -1;
                    Cbx.Text = string.Empty;
                    Cbx.Enabled = false;
                }
                else if (this.GetGuiType() == typeof(ComboBoxExt))
                {
                    Cbxt.DataSource = null;
                    Cbxt.Items.Clear();
                    Cbxt.SelectedIndex = -1;
                    Cbxt.Text = string.Empty;
                    Cbxt.Enabled = false;
                }
                else if (this.GetGuiType() == typeof(TextBox))
                {
                    Tbx.Text = string.Empty;
                    Tbx.Clear();
                    Tbx.Enabled = false;
                }
                else if (this.GetGuiType() == typeof(TextBoxExt))
                {
                    Tbxt.Text = string.Empty;
                    Tbxt.Clear();
                    Tbxt.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("Exception in Method: ClearGui: ", ex.Message));
            }
        }

        public void SetEnabled(bool enabled)
        {
            if (GetGuiType() == typeof(ComboBox))
            {
                Cbx.Enabled = enabled;
            }

            else if (GetGuiType() == typeof(ComboBoxExt))
            {
                Cbxt.Enabled = enabled;
            }

            else if (GetGuiType() == typeof(TextBox))
            {
                Tbx.Enabled = enabled;
            }
            else if (GetGuiType() == typeof(TextBoxExt))
            {
                Tbxt.Enabled = enabled;
            }
        }

        public void Disable()
        {
            if (GetGuiType() == typeof(ComboBox))
            {
                Cbx.Enabled = false;
            }

            else if (GetGuiType() == typeof(ComboBoxExt))
            {
                Cbxt.Enabled = false;
            }

            else if (GetGuiType() == typeof(TextBox))
            {
                Tbx.Enabled = false;
            }

            else if (GetGuiType() == typeof(TextBoxExt))
            {
                Tbxt.Enabled = false;
            }
        }

        public void Enable()
        {
            if (GetGuiType() == typeof(ComboBox))
            {
                Cbx.Enabled = true;
            }

            else if (GetGuiType() == typeof(ComboBoxExt))
            {
                Cbxt.Enabled = true;
            }

            else if (GetGuiType() == typeof(TextBox))
            {
                Tbx.Enabled = true;
            }

            else if (GetGuiType() == typeof(TextBoxExt))
            {
                Tbxt.Enabled = true;
            }
        }

        public bool IsTextSet()
        {
            bool isTextSet = false;
            if (GetGuiType() == typeof(ComboBox))
            {
                if (Cbx.Items.Count > 0)
                {
                    isTextSet = Cbx.SelectedIndex > 0;
                }
                else
                {
                    isTextSet = Cbx.Text.Length > 0;
                }
            }

            else if (GetGuiType() == typeof(ComboBoxExt))
            {
                if (Cbxt.Items.Count > 0)
                {
                    isTextSet = Cbxt.SelectedIndex > 0;
                }
                else
                {
                    isTextSet = Cbxt.Text.Length > 0;
                }
            }

            else if (GetGuiType() == typeof(TextBox))
            {
                isTextSet = Tbx.Text.Length > 0;
            }

            else if (GetGuiType() == typeof(TextBoxExt))
            {
                isTextSet = Tbxt.Text.Length > 0;
            }
            return isTextSet;
        }

        public bool IsEnabled()
        {
            bool isEnabled = false;
            
            if (GetGuiType() == typeof(ComboBox))
            {
                isEnabled = Cbx.Enabled;
            }

            else if (GetGuiType() == typeof(ComboBoxExt))
            {
                isEnabled = Cbxt.Enabled;
            }

            else if (GetGuiType() == typeof(TextBox))
            {
                isEnabled = Tbx.Enabled;
            }

            else if (GetGuiType() == typeof(TextBoxExt))
            {
                isEnabled = Tbxt.Enabled;
            }
            return isEnabled;
        }
        public void PopulateGuiElem(GuiElem gui, DataSetForGui ds)
        {
            if (gui != null && ds != null && ds.Ds != null)
            {
                try
                {
                    if (gui.GetGuiType() == typeof(ComboBox))
                    {
                        gui.Cbx.DataSource = ds.Ds.Tables[0];
                        gui.Cbx.ValueMember = ds.ParamSelect.ParamMetaData.ValueMember;
                        gui.Cbx.DisplayMember = ds.ParamSelect.ParamMetaData.DisplayMember;
                        if (Cbx.Items.Count > 1)
                        {
                            gui.Cbx.Enabled = true;
                            gui.Cbx.DroppedDown = Options.autoDropDownComboBoxes;
                            gui.Cbx.SelectedIndex = 0;
                            //gui.Cbx.Focus();
                        }
                    }

                    else if (gui.GetGuiType() == typeof(ComboBoxExt))
                    {
                        gui.Cbxt.DataSource = ds.Ds.Tables[0];
                        gui.Cbxt.ValueMember = ds.ParamSelect.ParamMetaData.ValueMember;
                        gui.Cbxt.DisplayMember = ds.ParamSelect.ParamMetaData.DisplayMember;
                        if (Cbxt.Items.Count > 1)
                        {
                            gui.Cbxt.Enabled = true;
                            gui.Cbxt.DroppedDown = Options.autoDropDownComboBoxes;
                            gui.Cbxt.SelectedIndex = 0;
                            //gui.Cbxt.Focus();
                        }
                    }

                    else if (gui.GetGuiType() == typeof(TextBox))
                    {
                        gui.Tbx.Text = ds.Ds.Tables[0].Rows[1][ds.ParamSelect.ParamMetaData.DisplayMember].ToString();
                        gui.Tbx.Enabled = true;
                        gui.Tbx.Focus();
                    }

                    else if (gui.GetGuiType() == typeof(TextBoxExt))
                    {
                        gui.Tbxt.Text = ds.Ds.Tables[0].Rows[1][ds.ParamSelect.ParamMetaData.DisplayMember].ToString();
                        gui.Tbxt.Enabled = true;
                        gui.Tbxt.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Concat("Exception in Method PopulateGuiElem: ", ex.Message));
                }
            }
        }

        public string GetCbxSelectionChangeCommited(string displayMember)
        {
            string sReturn = string.Empty;
            try
            {
                if (this.GetGuiType() == typeof(ComboBox))
                {
                    DataRowView oDataRowView = Cbx.SelectedItem as DataRowView;

                    if (oDataRowView != null)
                    {
                        sReturn = oDataRowView.Row[displayMember] as string;
                    }
                }
                else if (this.GetGuiType() == typeof(ComboBoxExt))
                {
                    DataRowView oDataRowView = Cbxt.SelectedItem as DataRowView;

                    if (oDataRowView != null)
                    {
                        sReturn = oDataRowView.Row[displayMember] as string;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("Method GetSelectionChangeCommitedFromCbx returned an error: ", ex.Message));
            }
            return sReturn;
        }
    }
}
