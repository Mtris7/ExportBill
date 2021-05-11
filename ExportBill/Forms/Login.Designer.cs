namespace ExportBill
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuCheckbox1 = new Bunifu.Framework.UI.BunifuCheckbox();
            this.button1 = new System.Windows.Forms.Button();
            this.PassWordTxt = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.UserNameTxt = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.button13 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(59, 397);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Remember";
            // 
            // bunifuCheckbox1
            // 
            this.bunifuCheckbox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.bunifuCheckbox1.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.bunifuCheckbox1.Checked = false;
            this.bunifuCheckbox1.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.bunifuCheckbox1.ForeColor = System.Drawing.Color.White;
            this.bunifuCheckbox1.Location = new System.Drawing.Point(31, 395);
            this.bunifuCheckbox1.Margin = new System.Windows.Forms.Padding(5);
            this.bunifuCheckbox1.Name = "bunifuCheckbox1";
            this.bunifuCheckbox1.Size = new System.Drawing.Size(20, 20);
            this.bunifuCheckbox1.TabIndex = 5;
            this.bunifuCheckbox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bunifuCheckbox1_KeyDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(37)))), ((int)(((byte)(52)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(30, 427);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(352, 42);
            this.button1.TabIndex = 7;
            this.button1.Text = "Đăng Nhập";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.PassWordTxt.Location = new System.Drawing.Point(31, 333);
            this.PassWordTxt.Margin = new System.Windows.Forms.Padding(5);
            this.PassWordTxt.MaxLength = 32767;
            this.PassWordTxt.Name = "PassWordTxt";
            this.PassWordTxt.Size = new System.Drawing.Size(351, 38);
            this.PassWordTxt.TabIndex = 3;
            this.PassWordTxt.Text = global::ExportBill.Properties.Settings.Default.passWord;
            this.PassWordTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            this.UserNameTxt.Location = new System.Drawing.Point(31, 275);
            this.UserNameTxt.Margin = new System.Windows.Forms.Padding(5);
            this.UserNameTxt.MaxLength = 32767;
            this.UserNameTxt.Name = "UserNameTxt";
            this.UserNameTxt.Size = new System.Drawing.Size(351, 38);
            this.UserNameTxt.TabIndex = 1;
            this.UserNameTxt.Text = global::ExportBill.Properties.Settings.Default.userName;
            this.UserNameTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // button13
            // 
            this.button13.FlatAppearance.BorderSize = 0;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.ForeColor = System.Drawing.Color.White;
            this.button13.Image = ((System.Drawing.Image)(resources.GetObject("button13.Image")));
            this.button13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button13.Location = new System.Drawing.Point(378, 1);
            this.button13.Margin = new System.Windows.Forms.Padding(4);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(42, 43);
            this.button13.TabIndex = 18;
            this.button13.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(37)))), ((int)(((byte)(52)))));
            this.label2.Location = new System.Drawing.Point(138, 487);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Change Password";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Login
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::ExportBill.Properties.Resources.LoginBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(419, 625);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.PassWordTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bunifuCheckbox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.UserNameTxt);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập Tiến Thu";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuCheckbox bunifuCheckbox1;
        private System.Windows.Forms.Button button1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox UserNameTxt;
        private Bunifu.Framework.UI.BunifuMaterialTextbox PassWordTxt;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label label2;
    }
}