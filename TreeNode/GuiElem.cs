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
        public TextBox Tbx { get; set; }

        // constructor has to initialize either Cbx or Tbx (one of those but not both)
        public GuiElem(ComboBox cbx)
        {
            Cbx = cbx;
            //Cbx.DropDownStyle = ComboBoxStyle.DropDownList; // this will prevent any new manual entries into the Cbx
        }

        public GuiElem(TextBox tbx)
        {
            Tbx = tbx;
        }

        public Type GetGuiType()
        {
            Type type = null;
            if (Cbx != null)
            {
                type = typeof(ComboBox);
            }
            if (Tbx != null)
            {
                type = typeof(TextBox);
            }
            return type;
        }

        public string GetGuiText()
        {
            string guiText = string.Empty;
            if (this.GetGuiType() == typeof(ComboBox))
            {
                guiText = Cbx.Text;
            }
            if (this.GetGuiType() == typeof(TextBox))
            {
                guiText = Tbx.Text;
            }
            return guiText;
        }

        public void SetGuiText(EventArgsDbObjectChanged e)
        {
            if (e.NewObjectText != null)
            {
                if (e.NewObjectText.Length > 0)
                {
                    if (Cbx != null)
                    {
                        if (e.NewObjectText.Length > 0)
                        {
                            Cbx.Text = e.NewObjectText;
                            Cbx.Enabled = true;
                        }
                        else
                        {
                            Cbx.DataSource = null;
                            Cbx.Items.Clear();
                            Cbx.SelectedIndex = -1;
                            Cbx.Text = string.Empty;
                            Cbx.Enabled = false;
                        }
                    }
                    if (Tbx != null)
                    {
                        if (e.NewObjectText.Length > 0)
                        {
                            Tbx.Text = e.NewObjectText;
                            Tbx.Enabled = true;
                        }
                        else
                        {
                            Tbx.Text = string.Empty;
                            Tbx.Clear();
                            Tbx.Enabled = false;
                        }
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
                if (Cbx != null)
                {                  
                    Cbx.DataSource = null;
                    Cbx.Items.Clear();
                    Cbx.SelectedIndex = -1;
                    Cbx.Text = string.Empty;
                    Cbx.Enabled = false;
                }

                if (Tbx != null)
                {
                    Tbx.Text = string.Empty;
                    Tbx.Clear();
                    Tbx.Enabled = false;
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

            if (GetGuiType() == typeof(TextBox))
            {
                Tbx.Enabled = enabled;
            }
        }

        public void Disable()
        {
            if (GetGuiType() == typeof(ComboBox))
            {
                Cbx.Enabled = false;
            }

            if (GetGuiType() == typeof(TextBox))
            {
                Tbx.Enabled = false;
            }
        }

        public void Enable()
        {
            if (GetGuiType() == typeof(ComboBox))
            {
                Cbx.Enabled = true;
            }

            if (GetGuiType() == typeof(TextBox))
            {
                Tbx.Enabled = true;
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
            if (GetGuiType() == typeof(TextBox))
            {
                isTextSet = Tbx.Text.Length > 0;
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
            if (GetGuiType() == typeof(TextBox))
            {
                isEnabled = Tbx.Enabled;
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
                            gui.Cbx.DroppedDown = true;
                            gui.Cbx.SelectedIndex = 0;
                            //gui.Cbx.Focus();
                        }
                        else
                        {
                            //gui.Cbx.Enabled = false;
                        }
                    }
                    if (gui.GetGuiType() == typeof(TextBox))
                    {
                        gui.Tbx.Text = ds.Ds.Tables[0].Rows[1][ds.ParamSelect.ParamMetaData.DisplayMember].ToString();
                        gui.Tbx.Enabled = true;
                        gui.Tbx.Focus();
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
                DataRowView oDataRowView = Cbx.SelectedItem as DataRowView;

                if (oDataRowView != null)
                {
                    sReturn = oDataRowView.Row[displayMember] as string;
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
