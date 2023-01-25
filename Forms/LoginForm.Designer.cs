
namespace CsiMigrationHelper
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.authenticationCmb = new System.Windows.Forms.ComboBox();
            this.passwordTxtb = new System.Windows.Forms.TextBox();
            this.userNmTxtb = new System.Windows.Forms.TextBox();
            this.serverNmTxtb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.loginBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // authenticationCmb
            // 
            this.authenticationCmb.FormattingEnabled = true;
            this.authenticationCmb.Items.AddRange(new object[] {
            "SQL Server Authentication",
            "Windows Authentication"});
            this.authenticationCmb.Location = new System.Drawing.Point(177, 65);
            this.authenticationCmb.Name = "authenticationCmb";
            this.authenticationCmb.Size = new System.Drawing.Size(407, 21);
            this.authenticationCmb.TabIndex = 22;
            this.authenticationCmb.SelectedIndexChanged += new System.EventHandler(this.AuthMethodChanged);
            // 
            // passwordTxtb
            // 
            this.passwordTxtb.Location = new System.Drawing.Point(177, 142);
            this.passwordTxtb.Name = "passwordTxtb";
            this.passwordTxtb.Size = new System.Drawing.Size(407, 20);
            this.passwordTxtb.TabIndex = 21;
            this.passwordTxtb.UseSystemPasswordChar = true;
            // 
            // userNmTxtb
            // 
            this.userNmTxtb.Location = new System.Drawing.Point(177, 105);
            this.userNmTxtb.Name = "userNmTxtb";
            this.userNmTxtb.Size = new System.Drawing.Size(407, 20);
            this.userNmTxtb.TabIndex = 20;
            // 
            // serverNmTxtb
            // 
            this.serverNmTxtb.Location = new System.Drawing.Point(177, 30);
            this.serverNmTxtb.Name = "serverNmTxtb";
            this.serverNmTxtb.Size = new System.Drawing.Size(407, 20);
            this.serverNmTxtb.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(54, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 18);
            this.label4.TabIndex = 18;
            this.label4.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 17;
            this.label3.Text = "User Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 18);
            this.label2.TabIndex = 16;
            this.label2.Text = "Authentication:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "Server Name:";
            // 
            // loginBtn
            // 
            this.loginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.Location = new System.Drawing.Point(177, 187);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(85, 26);
            this.loginBtn.TabIndex = 13;
            this.loginBtn.Text = "&Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.LoginBtnClick);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(321, 187);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(85, 26);
            this.cancelBtn.TabIndex = 14;
            this.cancelBtn.Text = "&Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 235);
            this.Controls.Add(this.authenticationCmb);
            this.Controls.Add(this.passwordTxtb);
            this.Controls.Add(this.userNmTxtb);
            this.Controls.Add(this.serverNmTxtb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.loginBtn);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox authenticationCmb;
        private System.Windows.Forms.TextBox passwordTxtb;
        private System.Windows.Forms.TextBox userNmTxtb;
        private System.Windows.Forms.TextBox serverNmTxtb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}