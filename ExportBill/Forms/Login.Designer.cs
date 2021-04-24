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
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.UserNameTxt = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.PassWordTxt = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(54, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
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
            this.bunifuCheckbox1.Location = new System.Drawing.Point(26, 317);
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
            this.button1.Location = new System.Drawing.Point(25, 349);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(352, 42);
            this.button1.TabIndex = 7;
            this.button1.Text = "Đăng Nhập";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(37)))), ((int)(((byte)(52)))));
            this.button2.Location = new System.Drawing.Point(359, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(38, 33);
            this.button2.TabIndex = 15;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(100, 87);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(245, 47);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
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
            this.UserNameTxt.Location = new System.Drawing.Point(26, 197);
            this.UserNameTxt.Margin = new System.Windows.Forms.Padding(5);
            this.UserNameTxt.MaxLength = 32767;
            this.UserNameTxt.Name = "UserNameTxt";
            this.UserNameTxt.Size = new System.Drawing.Size(351, 38);
            this.UserNameTxt.TabIndex = 1;
            this.UserNameTxt.Text = global::ExportBill.Properties.Settings.Default.userName;
            this.UserNameTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            this.PassWordTxt.Location = new System.Drawing.Point(26, 255);
            this.PassWordTxt.Margin = new System.Windows.Forms.Padding(5);
            this.PassWordTxt.MaxLength = 32767;
            this.PassWordTxt.Name = "PassWordTxt";
            this.PassWordTxt.Size = new System.Drawing.Size(351, 38);
            this.PassWordTxt.TabIndex = 3;
            this.PassWordTxt.Text = global::ExportBill.Properties.Settings.Default.passWord;
            this.PassWordTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.PassWordTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bunifuCheckbox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.UserNameTxt);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập Tiến Thu";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuCheckbox bunifuCheckbox1;
        private System.Windows.Forms.Button button1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox UserNameTxt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox PassWordTxt;
    }
}