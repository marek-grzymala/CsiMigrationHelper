using System;
using System.Windows.Forms;
using System.Configuration;

namespace CsiMigrationHelper
{
    public partial class LoginForm : Form, IDisposable
    {

        private DbUtil con;
        public LoginForm()
        {
            InitializeComponent();
            authenticationCmb.Text = ConfigurationManager.AppSettings["Authentication"];
            serverNmTxtb.Text = ConfigurationManager.AppSettings["ServerName"];
            userNmTxtb.Text = ConfigurationManager.AppSettings["UserName"];
            passwordTxtb.Text = ConfigurationManager.AppSettings["Password"];
            this.con = new DbUtil();
        }

        public DbUtil GetConnection()
        {
            return con;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void authLb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoginBtnClick(object sender, EventArgs e)
        {
            using (DbUtil conTmp = new DbUtil())
            {
                switch (authenticationCmb.Text)
                {
                    case ("Windows Authentication"):
                        conTmp.SetConnectionString(string.Concat("Data Source = "
                                                              , serverNmTxtb.Text
                                                              , ";Initial Catalog = master; Integrated Security=SSPI;"));
                        break;

                    case ("SQL Server Authentication"):
                        conTmp.SetConnectionString(string.Concat("Data Source = "
                                                              , serverNmTxtb.Text
                                                              , ";Initial Catalog = master; Persist Security Info=True;User ID="
                                                              , userNmTxtb.Text
                                                              , ";Password="
                                                              , passwordTxtb.Text));
                        break;

                    default:
                        conTmp.SetConnectionString(string.Concat("Data Source = "
                                                              , serverNmTxtb.Text
                                                              , ";Initial Catalog = master; Integrated Security=SSPI;"));
                        break;
                }

                if (conTmp.OpenConnection() == 0)
                {
                    this.con = conTmp;
                    this.Hide();
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.DialogResult = DialogResult.Cancel;
        }

        public static bool HandleLoginBtnClick(object sender, TreeNode<DbObject> currentNode)
        {
            DialogResult diagResult;
            using (LoginForm login = new LoginForm())
            {
                diagResult = login.ShowDialog();
                if (diagResult == DialogResult.OK)
                {
                    currentNode.Data.Dbu = login.GetConnection();
                    currentNode.SetTreeNodeText(currentNode, currentNode.Data.Dbu.GetDataSource());
                    CmBxSelectHndlr.PopulateChildNodes(sender, currentNode);
                }
            }
            return diagResult == DialogResult.OK;
        }

        private void AuthMethodChanged(object sender, EventArgs e)
        {
            switch (authenticationCmb.Text)
            {
                case ("Windows Authentication"):
                    userNmTxtb.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                    userNmTxtb.Enabled = false;
                    passwordTxtb.Enabled = false;
                    break;

                case ("SQL Server Authentication"):
                    userNmTxtb.Text = "sa";
                    userNmTxtb.Enabled = true;
                    passwordTxtb.Enabled = true;
                    break;

                default:
                    userNmTxtb.Text = "sa";
                    userNmTxtb.Enabled = true;
                    passwordTxtb.Enabled = true;
                    break;
            }
        }
    }
}
