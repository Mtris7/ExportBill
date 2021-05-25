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
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.CreateSaveBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.ProvinceCbx = new System.Windows.Forms.ComboBox();
            this.DistrictCbx = new System.Windows.Forms.ComboBox();
            this.placeHolderTextBox1 = new ExportBill.PlaceHolderTextBox();
            this.BSTxt = new ExportBill.PlaceHolderTextBox();
            this.NoteTxt = new ExportBill.PlaceHolderTextBox();
            this.KilometerTxt = new ExportBill.PlaceHolderTextBox();
            this.StreetTxt = new ExportBill.PlaceHolderTextBox();
            this.SDTTxt = new ExportBill.PlaceHolderTextBox();
            this.CMNDTxt = new ExportBill.PlaceHolderTextBox();
            this.NameTxt = new ExportBill.PlaceHolderTextBox();
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
            this.comboBox1.Location = new System.Drawing.Point(181, 10);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(83, 23);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "Giới tính";
            // 
            // comboBox3
            // 
            this.comboBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.comboBox3.ForeColor = System.Drawing.Color.Black;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Kiểm tra định kỳ",
            "Kiểm tra định kỳ thiện chí",
            "Sữa chữa lưu động ",
            "Sữa chữa - thay thế phụ tùng",
            "Sữa chữa thiện chí",
            "Sữa chữa xe bảo hiểm",
            "Sữa chữa xe bảo hành",
            "Sữa chữa xe tai nạn"});
            this.comboBox3.Location = new System.Drawing.Point(16, 178);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(181, 23);
            this.comboBox3.TabIndex = 22;
            this.comboBox3.Text = "sữa chửa thay thế phụ tùng";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(268, 11);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(84, 21);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // CreateSaveBtn
            // 
            this.CreateSaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.CreateSaveBtn.Image = ((System.Drawing.Image)(resources.GetObject("CreateSaveBtn.Image")));
            this.CreateSaveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreateSaveBtn.Location = new System.Drawing.Point(217, 303);
            this.CreateSaveBtn.Margin = new System.Windows.Forms.Padding(2);
            this.CreateSaveBtn.Name = "CreateSaveBtn";
            this.CreateSaveBtn.Size = new System.Drawing.Size(135, 35);
            this.CreateSaveBtn.TabIndex = 30;
            this.CreateSaveBtn.Text = "Lưu và tạo phiếu";
            this.CreateSaveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CreateSaveBtn.UseVisualStyleBackColor = true;
            this.CreateSaveBtn.Click += new System.EventHandler(this.CreateSaveBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.SaveBtn.Image = ((System.Drawing.Image)(resources.GetObject("SaveBtn.Image")));
            this.SaveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveBtn.Location = new System.Drawing.Point(153, 303);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(60, 35);
            this.SaveBtn.TabIndex = 28;
            this.SaveBtn.Text = "Lưu";
            this.SaveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(268, 144);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(84, 21);
            this.dateTimePicker2.TabIndex = 20;
            // 
            // ProvinceCbx
            // 
            this.ProvinceCbx.FormattingEnabled = true;
            this.ProvinceCbx.Location = new System.Drawing.Point(16, 77);
            this.ProvinceCbx.Name = "ProvinceCbx";
            this.ProvinceCbx.Size = new System.Drawing.Size(161, 21);
            this.ProvinceCbx.TabIndex = 10;
            this.ProvinceCbx.SelectedIndexChanged += new System.EventHandler(this.ProvinceCbx_SelectedIndexChanged);
            // 
            // DistrictCbx
            // 
            this.DistrictCbx.FormattingEnabled = true;
            this.DistrictCbx.Location = new System.Drawing.Point(183, 77);
            this.DistrictCbx.Name = "DistrictCbx";
            this.DistrictCbx.Size = new System.Drawing.Size(169, 21);
            this.DistrictCbx.TabIndex = 12;
            // 
            // placeHolderTextBox1
            // 
            this.placeHolderTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.placeHolderTextBox1.ForeColor = System.Drawing.Color.Gray;
            this.placeHolderTextBox1.Location = new System.Drawing.Point(130, 144);
            this.placeHolderTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.placeHolderTextBox1.Name = "placeHolderTextBox1";
            this.placeHolderTextBox1.PlaceHolderText = "Loại xe";
            this.placeHolderTextBox1.Size = new System.Drawing.Size(134, 21);
            this.placeHolderTextBox1.TabIndex = 18;
            this.placeHolderTextBox1.Text = "Loại xe";
            // 
            // BSTxt
            // 
            this.BSTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.BSTxt.ForeColor = System.Drawing.Color.Gray;
            this.BSTxt.Location = new System.Drawing.Point(16, 144);
            this.BSTxt.Margin = new System.Windows.Forms.Padding(2);
            this.BSTxt.Name = "BSTxt";
            this.BSTxt.PlaceHolderText = "Biển số xe";
            this.BSTxt.Size = new System.Drawing.Size(110, 21);
            this.BSTxt.TabIndex = 16;
            this.BSTxt.Text = "Biển số xe";
            // 
            // NoteTxt
            // 
            this.NoteTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.NoteTxt.ForeColor = System.Drawing.Color.Gray;
            this.NoteTxt.Location = new System.Drawing.Point(16, 215);
            this.NoteTxt.Margin = new System.Windows.Forms.Padding(2);
            this.NoteTxt.Multiline = true;
            this.NoteTxt.Name = "NoteTxt";
            this.NoteTxt.PlaceHolderText = "Ghi chú";
            this.NoteTxt.Size = new System.Drawing.Size(336, 69);
            this.NoteTxt.TabIndex = 26;
            this.NoteTxt.Text = "Ghi chú";
            // 
            // KilometerTxt
            // 
            this.KilometerTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.KilometerTxt.ForeColor = System.Drawing.Color.Gray;
            this.KilometerTxt.Location = new System.Drawing.Point(201, 178);
            this.KilometerTxt.Margin = new System.Windows.Forms.Padding(2);
            this.KilometerTxt.Name = "KilometerTxt";
            this.KilometerTxt.PlaceHolderText = "Số kilomet";
            this.KilometerTxt.Size = new System.Drawing.Size(151, 21);
            this.KilometerTxt.TabIndex = 24;
            this.KilometerTxt.Text = "Số kilomet";
            // 
            // StreetTxt
            // 
            this.StreetTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.StreetTxt.ForeColor = System.Drawing.Color.Gray;
            this.StreetTxt.Location = new System.Drawing.Point(16, 111);
            this.StreetTxt.Margin = new System.Windows.Forms.Padding(2);
            this.StreetTxt.Name = "StreetTxt";
            this.StreetTxt.PlaceHolderText = "Số nhà/Tên đường phố";
            this.StreetTxt.Size = new System.Drawing.Size(336, 21);
            this.StreetTxt.TabIndex = 14;
            this.StreetTxt.Text = "Số nhà/Tên đường phố";
            // 
            // SDTTxt
            // 
            this.SDTTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.SDTTxt.ForeColor = System.Drawing.Color.Gray;
            this.SDTTxt.Location = new System.Drawing.Point(181, 44);
            this.SDTTxt.Margin = new System.Windows.Forms.Padding(2);
            this.SDTTxt.Name = "SDTTxt";
            this.SDTTxt.PlaceHolderText = "Số điện thoại";
            this.SDTTxt.Size = new System.Drawing.Size(171, 21);
            this.SDTTxt.TabIndex = 8;
            this.SDTTxt.Text = "Số điện thoại";
            // 
            // CMNDTxt
            // 
            this.CMNDTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.CMNDTxt.ForeColor = System.Drawing.Color.Gray;
            this.CMNDTxt.Location = new System.Drawing.Point(16, 44);
            this.CMNDTxt.Margin = new System.Windows.Forms.Padding(2);
            this.CMNDTxt.Name = "CMNDTxt";
            this.CMNDTxt.PlaceHolderText = "Số CMND/CCDC";
            this.CMNDTxt.Size = new System.Drawing.Size(161, 21);
            this.CMNDTxt.TabIndex = 6;
            this.CMNDTxt.Text = "Số CMND/CCDC";
            // 
            // NameTxt
            // 
            this.NameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.NameTxt.ForeColor = System.Drawing.Color.Gray;
            this.NameTxt.Location = new System.Drawing.Point(16, 10);
            this.NameTxt.Margin = new System.Windows.Forms.Padding(2);
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.PlaceHolderText = "Họ và Tên";
            this.NameTxt.Size = new System.Drawing.Size(161, 21);
            this.NameTxt.TabIndex = 0;
            this.NameTxt.Text = "Họ và Tên";
            this.NameTxt.WordWrap = false;
            // 
            // CreateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(368, 359);
            this.Controls.Add(this.DistrictCbx);
            this.Controls.Add(this.ProvinceCbx);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.placeHolderTextBox1);
            this.Controls.Add(this.BSTxt);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.CreateSaveBtn);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.NoteTxt);
            this.Controls.Add(this.KilometerTxt);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.StreetTxt);
            this.Controls.Add(this.SDTTxt);
            this.Controls.Add(this.CMNDTxt);
            this.Controls.Add(this.NameTxt);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.ComboBox comboBox3;
        private PlaceHolderTextBox KilometerTxt;
        private PlaceHolderTextBox NoteTxt;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button CreateSaveBtn;
        private System.Windows.Forms.Button SaveBtn;
        private PlaceHolderTextBox placeHolderTextBox1;
        private PlaceHolderTextBox BSTxt;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ComboBox ProvinceCbx;
        private System.Windows.Forms.ComboBox DistrictCbx;
    }
}