namespace ExportBill
{
    partial class CreateUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateUser));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.DateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.CreateSaveBtn = new System.Windows.Forms.Button();
            this.InvoceDate = new System.Windows.Forms.DateTimePicker();
            this.ProvinceCbx = new System.Windows.Forms.ComboBox();
            this.DistrictCbx = new System.Windows.Forms.ComboBox();
            this.BSTxt = new ExportBill.PlaceHolderTextBox();
            this.StreetTxt = new ExportBill.PlaceHolderTextBox();
            this.SDTTxt = new ExportBill.PlaceHolderTextBox();
            this.CMNDTxt = new ExportBill.PlaceHolderTextBox();
            this.NameTxt = new ExportBill.PlaceHolderTextBox();
            this.ProductCbx = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.comboBox1.ForeColor = System.Drawing.Color.Black;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.comboBox1.Location = new System.Drawing.Point(241, 12);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(109, 26);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "Giới tính";
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.CalendarForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DateOfBirth.CustomFormat = " ";
            this.DateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.DateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateOfBirth.Location = new System.Drawing.Point(357, 14);
            this.DateOfBirth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DateOfBirth.Name = "DateOfBirth";
            this.DateOfBirth.Size = new System.Drawing.Size(111, 24);
            this.DateOfBirth.TabIndex = 4;
            this.DateOfBirth.ValueChanged += new System.EventHandler(this.DateOfBirth_ValueChanged);
            // 
            // CreateSaveBtn
            // 
            this.CreateSaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.CreateSaveBtn.Image = ((System.Drawing.Image)(resources.GetObject("CreateSaveBtn.Image")));
            this.CreateSaveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreateSaveBtn.Location = new System.Drawing.Point(289, 229);
            this.CreateSaveBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CreateSaveBtn.Name = "CreateSaveBtn";
            this.CreateSaveBtn.Size = new System.Drawing.Size(180, 43);
            this.CreateSaveBtn.TabIndex = 30;
            this.CreateSaveBtn.Text = "Lưu và tạo phiếu";
            this.CreateSaveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CreateSaveBtn.UseVisualStyleBackColor = true;
            this.CreateSaveBtn.Click += new System.EventHandler(this.CreateSaveBtn_Click);
            // 
            // InvoceDate
            // 
            this.InvoceDate.CustomFormat = " ";
            this.InvoceDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.InvoceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.InvoceDate.Location = new System.Drawing.Point(357, 177);
            this.InvoceDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InvoceDate.Name = "InvoceDate";
            this.InvoceDate.Size = new System.Drawing.Size(111, 24);
            this.InvoceDate.TabIndex = 20;
            this.InvoceDate.ValueChanged += new System.EventHandler(this.InvoceDate_ValueChanged);
            // 
            // ProvinceCbx
            // 
            this.ProvinceCbx.FormattingEnabled = true;
            this.ProvinceCbx.Location = new System.Drawing.Point(21, 95);
            this.ProvinceCbx.Margin = new System.Windows.Forms.Padding(4);
            this.ProvinceCbx.Name = "ProvinceCbx";
            this.ProvinceCbx.Size = new System.Drawing.Size(213, 24);
            this.ProvinceCbx.TabIndex = 10;
            this.ProvinceCbx.SelectedIndexChanged += new System.EventHandler(this.ProvinceCbx_SelectedIndexChanged);
            // 
            // DistrictCbx
            // 
            this.DistrictCbx.FormattingEnabled = true;
            this.DistrictCbx.Location = new System.Drawing.Point(244, 95);
            this.DistrictCbx.Margin = new System.Windows.Forms.Padding(4);
            this.DistrictCbx.Name = "DistrictCbx";
            this.DistrictCbx.Size = new System.Drawing.Size(224, 24);
            this.DistrictCbx.TabIndex = 12;
            // 
            // BSTxt
            // 
            this.BSTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BSTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.BSTxt.ForeColor = System.Drawing.Color.Gray;
            this.BSTxt.Location = new System.Drawing.Point(21, 177);
            this.BSTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BSTxt.Name = "BSTxt";
            this.BSTxt.PlaceHolderText = "Biển số xe";
            this.BSTxt.Size = new System.Drawing.Size(145, 24);
            this.BSTxt.TabIndex = 16;
            this.BSTxt.Text = "Biển số xe";
            // 
            // StreetTxt
            // 
            this.StreetTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.StreetTxt.ForeColor = System.Drawing.Color.Gray;
            this.StreetTxt.Location = new System.Drawing.Point(21, 137);
            this.StreetTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StreetTxt.Name = "StreetTxt";
            this.StreetTxt.PlaceHolderText = "Số nhà/Tên đường phố";
            this.StreetTxt.Size = new System.Drawing.Size(447, 24);
            this.StreetTxt.TabIndex = 14;
            this.StreetTxt.Text = "Số nhà/Tên đường phố";
            // 
            // SDTTxt
            // 
            this.SDTTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SDTTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.SDTTxt.ForeColor = System.Drawing.Color.Gray;
            this.SDTTxt.Location = new System.Drawing.Point(241, 54);
            this.SDTTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SDTTxt.Name = "SDTTxt";
            this.SDTTxt.PlaceHolderText = "Số điện thoại";
            this.SDTTxt.Size = new System.Drawing.Size(227, 24);
            this.SDTTxt.TabIndex = 8;
            this.SDTTxt.Text = "Số điện thoại";
            // 
            // CMNDTxt
            // 
            this.CMNDTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.CMNDTxt.ForeColor = System.Drawing.Color.Gray;
            this.CMNDTxt.Location = new System.Drawing.Point(21, 54);
            this.CMNDTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CMNDTxt.Name = "CMNDTxt";
            this.CMNDTxt.PlaceHolderText = "Số CMND/CCDC";
            this.CMNDTxt.Size = new System.Drawing.Size(213, 24);
            this.CMNDTxt.TabIndex = 6;
            this.CMNDTxt.Text = "Số CMND/CCDC";
            // 
            // NameTxt
            // 
            this.NameTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.NameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.NameTxt.ForeColor = System.Drawing.Color.Gray;
            this.NameTxt.Location = new System.Drawing.Point(21, 12);
            this.NameTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.PlaceHolderText = "Họ và Tên";
            this.NameTxt.Size = new System.Drawing.Size(213, 24);
            this.NameTxt.TabIndex = 0;
            this.NameTxt.Text = "Họ và Tên";
            this.NameTxt.WordWrap = false;
            // 
            // ProductCbx
            // 
            this.ProductCbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ProductCbx.FormattingEnabled = true;
            this.ProductCbx.Location = new System.Drawing.Point(175, 177);
            this.ProductCbx.Margin = new System.Windows.Forms.Padding(4);
            this.ProductCbx.Name = "ProductCbx";
            this.ProductCbx.Size = new System.Drawing.Size(175, 24);
            this.ProductCbx.TabIndex = 18;
            // 
            // CreateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(491, 284);
            this.Controls.Add(this.ProductCbx);
            this.Controls.Add(this.DistrictCbx);
            this.Controls.Add(this.ProvinceCbx);
            this.Controls.Add(this.InvoceDate);
            this.Controls.Add(this.BSTxt);
            this.Controls.Add(this.CreateSaveBtn);
            this.Controls.Add(this.DateOfBirth);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.StreetTxt);
            this.Controls.Add(this.SDTTxt);
            this.Controls.Add(this.CMNDTxt);
            this.Controls.Add(this.NameTxt);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CreateUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo mới khách hàng";
            this.Load += new System.EventHandler(this.CreateUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PlaceHolderTextBox NameTxt;
        private PlaceHolderTextBox CMNDTxt;
        private PlaceHolderTextBox SDTTxt;
        private PlaceHolderTextBox StreetTxt;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker DateOfBirth;
        private System.Windows.Forms.Button CreateSaveBtn;
        private PlaceHolderTextBox BSTxt;
        private System.Windows.Forms.DateTimePicker InvoceDate;
        private System.Windows.Forms.ComboBox ProvinceCbx;
        private System.Windows.Forms.ComboBox DistrictCbx;
        private System.Windows.Forms.ComboBox ProductCbx;
    }
}