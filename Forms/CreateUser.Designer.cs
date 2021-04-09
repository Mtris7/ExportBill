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
            this.NameTxt = new ExportBill.PlaceHolderTextBox();
            this.CMNDTxt = new ExportBill.PlaceHolderTextBox();
            this.CityTxt = new ExportBill.PlaceHolderTextBox();
            this.SDTTxt = new ExportBill.PlaceHolderTextBox();
            this.DictrictTxt = new ExportBill.PlaceHolderTextBox();
            this.StreetTxt = new ExportBill.PlaceHolderTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.KilometerTxt = new ExportBill.PlaceHolderTextBox();
            this.NoteTxt = new ExportBill.PlaceHolderTextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.CreateSaveBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.placeHolderTextBox1 = new ExportBill.PlaceHolderTextBox();
            this.BSTxt = new ExportBill.PlaceHolderTextBox();
            this.SuspendLayout();
            // 
            // NameTxt
            // 
            this.NameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic);
            this.NameTxt.ForeColor = System.Drawing.Color.Gray;
            this.NameTxt.Location = new System.Drawing.Point(21, 12);
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.PlaceHolderText = "Họ và Tên";
            this.NameTxt.Size = new System.Drawing.Size(213, 22);
            this.NameTxt.TabIndex = 0;
            this.NameTxt.Text = "Họ và Tên";
            // 
            // CMNDTxt
            // 
            this.CMNDTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic);
            this.CMNDTxt.ForeColor = System.Drawing.Color.Gray;
            this.CMNDTxt.Location = new System.Drawing.Point(21, 48);
            this.CMNDTxt.Name = "CMNDTxt";
            this.CMNDTxt.PlaceHolderText = "Số CMND/CCDC";
            this.CMNDTxt.Size = new System.Drawing.Size(213, 22);
            this.CMNDTxt.TabIndex = 1;
            this.CMNDTxt.Text = "Số CMND/CCDC";
            // 
            // CityTxt
            // 
            this.CityTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic);
            this.CityTxt.ForeColor = System.Drawing.Color.Gray;
            this.CityTxt.Location = new System.Drawing.Point(21, 82);
            this.CityTxt.Name = "CityTxt";
            this.CityTxt.PlaceHolderText = "Tỉnh/Thành phố";
            this.CityTxt.Size = new System.Drawing.Size(213, 22);
            this.CityTxt.TabIndex = 2;
            this.CityTxt.Text = "Tỉnh/Thành phố";
            // 
            // SDTTxt
            // 
            this.SDTTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic);
            this.SDTTxt.ForeColor = System.Drawing.Color.Gray;
            this.SDTTxt.Location = new System.Drawing.Point(264, 48);
            this.SDTTxt.Name = "SDTTxt";
            this.SDTTxt.PlaceHolderText = "Số điện thoại";
            this.SDTTxt.Size = new System.Drawing.Size(204, 22);
            this.SDTTxt.TabIndex = 3;
            this.SDTTxt.Text = "Số điện thoại";
            // 
            // DictrictTxt
            // 
            this.DictrictTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic);
            this.DictrictTxt.ForeColor = System.Drawing.Color.Gray;
            this.DictrictTxt.Location = new System.Drawing.Point(264, 82);
            this.DictrictTxt.Name = "DictrictTxt";
            this.DictrictTxt.PlaceHolderText = "Quận/Huyện";
            this.DictrictTxt.Size = new System.Drawing.Size(204, 22);
            this.DictrictTxt.TabIndex = 4;
            this.DictrictTxt.Text = "Quận/Huyện";
            // 
            // StreetTxt
            // 
            this.StreetTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic);
            this.StreetTxt.ForeColor = System.Drawing.Color.Gray;
            this.StreetTxt.Location = new System.Drawing.Point(21, 118);
            this.StreetTxt.Name = "StreetTxt";
            this.StreetTxt.PlaceHolderText = "Số nhà/Tên đường phố";
            this.StreetTxt.Size = new System.Drawing.Size(447, 22);
            this.StreetTxt.TabIndex = 5;
            this.StreetTxt.Text = "Số nhà/Tên đường phố";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.comboBox1.Location = new System.Drawing.Point(264, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(87, 24);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Text = "Giới tính";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(21, 186);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(217, 24);
            this.comboBox3.TabIndex = 8;
            // 
            // KilometerTxt
            // 
            this.KilometerTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic);
            this.KilometerTxt.ForeColor = System.Drawing.Color.Gray;
            this.KilometerTxt.Location = new System.Drawing.Point(264, 186);
            this.KilometerTxt.Name = "KilometerTxt";
            this.KilometerTxt.PlaceHolderText = "Số kilomet";
            this.KilometerTxt.Size = new System.Drawing.Size(204, 22);
            this.KilometerTxt.TabIndex = 9;
            this.KilometerTxt.Text = "Số kilomet";
            // 
            // NoteTxt
            // 
            this.NoteTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic);
            this.NoteTxt.ForeColor = System.Drawing.Color.Gray;
            this.NoteTxt.Location = new System.Drawing.Point(21, 226);
            this.NoteTxt.Multiline = true;
            this.NoteTxt.Name = "NoteTxt";
            this.NoteTxt.PlaceHolderText = "Ghi chú";
            this.NoteTxt.Size = new System.Drawing.Size(447, 84);
            this.NoteTxt.TabIndex = 10;
            this.NoteTxt.Text = "Ghi chú";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(357, 14);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(111, 22);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // CreateSaveBtn
            // 
            this.CreateSaveBtn.Image = ((System.Drawing.Image)(resources.GetObject("CreateSaveBtn.Image")));
            this.CreateSaveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreateSaveBtn.Location = new System.Drawing.Point(306, 316);
            this.CreateSaveBtn.Name = "CreateSaveBtn";
            this.CreateSaveBtn.Size = new System.Drawing.Size(162, 43);
            this.CreateSaveBtn.TabIndex = 12;
            this.CreateSaveBtn.Text = "Lưu và tạo phiếu";
            this.CreateSaveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CreateSaveBtn.UseVisualStyleBackColor = true;
            this.CreateSaveBtn.Click += new System.EventHandler(this.CreateSaveBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Image = ((System.Drawing.Image)(resources.GetObject("SaveBtn.Image")));
            this.SaveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveBtn.Location = new System.Drawing.Point(238, 316);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(68, 43);
            this.SaveBtn.TabIndex = 13;
            this.SaveBtn.Text = "Lưu";
            this.SaveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // placeHolderTextBox1
            // 
            this.placeHolderTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic);
            this.placeHolderTextBox1.ForeColor = System.Drawing.Color.Gray;
            this.placeHolderTextBox1.Location = new System.Drawing.Point(265, 153);
            this.placeHolderTextBox1.Name = "placeHolderTextBox1";
            this.placeHolderTextBox1.PlaceHolderText = "Loại xe";
            this.placeHolderTextBox1.Size = new System.Drawing.Size(204, 22);
            this.placeHolderTextBox1.TabIndex = 15;
            this.placeHolderTextBox1.Text = "Loại xe";
            // 
            // BSTxt
            // 
            this.BSTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic);
            this.BSTxt.ForeColor = System.Drawing.Color.Gray;
            this.BSTxt.Location = new System.Drawing.Point(22, 153);
            this.BSTxt.Name = "BSTxt";
            this.BSTxt.PlaceHolderText = "Biển số xe";
            this.BSTxt.Size = new System.Drawing.Size(213, 22);
            this.BSTxt.TabIndex = 14;
            this.BSTxt.Text = "Biển số xe";
            // 
            // CreateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 367);
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
            this.Controls.Add(this.DictrictTxt);
            this.Controls.Add(this.SDTTxt);
            this.Controls.Add(this.CityTxt);
            this.Controls.Add(this.CMNDTxt);
            this.Controls.Add(this.NameTxt);
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
        private PlaceHolderTextBox CityTxt;
        private PlaceHolderTextBox SDTTxt;
        private PlaceHolderTextBox DictrictTxt;
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
    }
}