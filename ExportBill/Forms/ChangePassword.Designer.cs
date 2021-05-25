namespace ExportBill
{
    partial class ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            this.PassWordTxt = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.button1 = new System.Windows.Forms.Button();
            this.UserNameTxt = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.ConfirmPasswordTxt = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.button13 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NewPasswordTxt = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PassWordTxt
            // 
            this.PassWordTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.PassWordTxt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.PassWordTxt.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.PassWordTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PassWordTxt.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ExportBill.Properties.Settings.Default, "passWord", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PassWordTxt.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.PassWordTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PassWordTxt.HintForeColor = System.Drawing.Color.Empty;
            this.PassWordTxt.HintText = "Password";
            this.PassWordTxt.isPassword = true;
            this.PassWordTxt.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(37)))), ((int)(((byte)(52)))));
            this.PassWordTxt.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(37)))), ((int)(((byte)(52)))));
            this.PassWordTxt.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(37)))), ((int)(((byte)(52)))));
            this.PassWordTxt.LineThickness = 3;
            this.PassWordTxt.Location = new System.Drawing.Point(33, 134);
            this.PassWordTxt.Margin = new System.Windows.Forms.Padding(5);
            this.PassWordTxt.MaxLength = 32767;
            this.PassWordTxt.Name = "PassWordTxt";
            this.PassWordTxt.Size = new System.Drawing.Size(351, 38);
            this.PassWordTxt.TabIndex = 2;
            this.PassWordTxt.Text = global::ExportBill.Properties.Settings.Default.passWord;
            this.PassWordTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(37)))), ((int)(((byte)(52)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(32, 362);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(352, 42);
            this.button1.TabIndex = 8;
            this.button1.Text = "Change Password";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UserNameTxt
            // 
            this.UserNameTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.UserNameTxt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.UserNameTxt.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.UserNameTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.UserNameTxt.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ExportBill.Properties.Settings.Default, "userName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.UserNameTxt.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.UserNameTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UserNameTxt.HintForeColor = System.Drawing.Color.Empty;
            this.UserNameTxt.HintText = "Mã nhân viên";
            this.UserNameTxt.isPassword = false;
            this.UserNameTxt.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(37)))), ((int)(((byte)(52)))));
            this.UserNameTxt.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(37)))), ((int)(((byte)(52)))));
            this.UserNameTxt.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(37)))), ((int)(((byte)(52)))));
            this.UserNameTxt.LineThickness = 3;
            this.UserNameTxt.Location = new System.Drawing.Point(33, 48);
            this.UserNameTxt.Margin = new System.Windows.Forms.Padding(5);
            this.UserNameTxt.MaxLength = 32767;
            this.UserNameTxt.Name = "UserNameTxt";
            this.UserNameTxt.Size = new System.Drawing.Size(351, 38);
            this.UserNameTxt.TabIndex = 0;
            this.UserNameTxt.Text = global::ExportBill.Properties.Settings.Default.userName;
            this.UserNameTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ConfirmPasswordTxt
            // 
            this.ConfirmPasswordTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ConfirmPasswordTxt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ConfirmPasswordTxt.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ConfirmPasswordTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ConfirmPasswordTxt.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ExportBill.Properties.Settings.Default, "passWord", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ConfirmPasswordTxt.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.ConfirmPasswordTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ConfirmPasswordTxt.HintForeColor = System.Drawing.Color.Empty;
            this.ConfirmPasswordTxt.HintText = "Password";
            this.ConfirmPasswordTxt.isPassword = true;
            this.ConfirmPasswordTxt.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(37)))), ((int)(((byte)(52)))));
            this.ConfirmPasswordTxt.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(37)))), ((int)(((byte)(52)))));
            this.ConfirmPasswordTxt.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(37)))), ((int)(((byte)(52)))));
            this.ConfirmPasswordTxt.LineThickness = 3;
            this.ConfirmPasswordTxt.Location = new System.Drawing.Point(33, 290);
            this.ConfirmPasswordTxt.Margin = new System.Windows.Forms.Padding(5);
            this.ConfirmPasswordTxt.MaxLength = 32767;
            this.ConfirmPasswordTxt.Name = "ConfirmPasswordTxt";
            this.ConfirmPasswordTxt.Size = new System.Drawing.Size(351, 38);
            this.ConfirmPasswordTxt.TabIndex = 6;
            this.ConfirmPasswordTxt.Text = global::ExportBill.Properties.Settings.Default.passWord;
            this.ConfirmPasswordTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // button13
            // 
            this.button13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button13.FlatAppearance.BorderSize = 0;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.ForeColor = System.Drawing.Color.White;
            this.button13.Image = ((System.Drawing.Image)(resources.GetObject("button13.Image")));
            this.button13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button13.Location = new System.Drawing.Point(374, 1);
            this.button13.Margin = new System.Windows.Forms.Padding(4);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(42, 34);
            this.button13.TabIndex = 25;
            this.button13.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.Location = new System.Drawing.Point(33, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Mật khẩu";
            // 
            // NewPasswordTxt
            // 
            this.NewPasswordTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.NewPasswordTxt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.NewPasswordTxt.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.NewPasswordTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NewPasswordTxt.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ExportBill.Properties.Settings.Default, "passWord", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NewPasswordTxt.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.NewPasswordTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NewPasswordTxt.HintForeColor = System.Drawing.Color.Empty;
            this.NewPasswordTxt.HintText = "Password";
            this.NewPasswordTxt.isPassword = true;
            this.NewPasswordTxt.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(37)))), ((int)(((byte)(52)))));
            this.NewPasswordTxt.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(37)))), ((int)(((byte)(52)))));
            this.NewPasswordTxt.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(37)))), ((int)(((byte)(52)))));
            this.NewPasswordTxt.LineThickness = 3;
            this.NewPasswordTxt.Location = new System.Drawing.Point(33, 206);
            this.NewPasswordTxt.Margin = new System.Windows.Forms.Padding(5);
            this.NewPasswordTxt.MaxLength = 32767;
            this.NewPasswordTxt.Name = "NewPasswordTxt";
            this.NewPasswordTxt.Size = new System.Drawing.Size(351, 38);
            this.NewPasswordTxt.TabIndex = 4;
            this.NewPasswordTxt.Text = global::ExportBill.Properties.Settings.Default.passWord;
            this.NewPasswordTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label2.Location = new System.Drawing.Point(33, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "Mật khẩu mới";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.Location = new System.Drawing.Point(33, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 17);
            this.label3.TabIndex = 29;
            this.label3.Text = "Xác nhận lại mật khẩu";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.button13);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 39);
            this.panel1.TabIndex = 30;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // ChangePassword
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NewPasswordTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConfirmPasswordTxt);
            this.Controls.Add(this.PassWordTxt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.UserNameTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePassword";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuMaterialTextbox PassWordTxt;
        private System.Windows.Forms.Button button1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox UserNameTxt;
        private Bunifu.Framework.UI.BunifuMaterialTextbox ConfirmPasswordTxt;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox NewPasswordTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
    }
}