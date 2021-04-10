namespace ExportBill
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BikeGrid = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CreateServiceGrid = new System.Windows.Forms.DataGridView();
            this.DatetimeLb = new System.Windows.Forms.Label();
            this.egencylb = new System.Windows.Forms.Label();
            this.Diemltn = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.Diemltn2 = new System.Windows.Forms.Label();
            this.egencylb2 = new System.Windows.Forms.Label();
            this.DatetimeLb2 = new System.Windows.Forms.Label();
            this.chkBS = new System.Windows.Forms.RadioButton();
            this.chkSDT = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.Total = new System.Windows.Forms.TextBox();
            this.TotalLbl = new System.Windows.Forms.Label();
            this.placeHolderTextBox1 = new ExportBill.PlaceHolderTextBox();
            this.SearchTxt = new ExportBill.PlaceHolderTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BikeGrid)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CreateServiceGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1180, 552);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage1.Controls.Add(this.placeHolderTextBox1);
            this.tabPage1.Controls.Add(this.Total);
            this.tabPage1.Controls.Add(this.TotalLbl);
            this.tabPage1.Controls.Add(this.pictureBox3);
            this.tabPage1.Controls.Add(this.pictureBox2);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.Diemltn);
            this.tabPage1.Controls.Add(this.egencylb);
            this.tabPage1.Controls.Add(this.DatetimeLb);
            this.tabPage1.Controls.Add(this.BikeGrid);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1172, 523);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Danh sách xe làm dịch vụ";
            // 
            // BikeGrid
            // 
            this.BikeGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BikeGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.BikeGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BikeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BikeGrid.Location = new System.Drawing.Point(6, 98);
            this.BikeGrid.Name = "BikeGrid";
            this.BikeGrid.RowTemplate.Height = 24;
            this.BikeGrid.Size = new System.Drawing.Size(1163, 391);
            this.BikeGrid.TabIndex = 5;
            this.BikeGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BikeGrid_CellClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(248, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 36);
            this.button1.TabIndex = 4;
            this.button1.Text = "Tìm kiếm";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage2.Controls.Add(this.SearchTxt);
            this.tabPage2.Controls.Add(this.pictureBox4);
            this.tabPage2.Controls.Add(this.pictureBox5);
            this.tabPage2.Controls.Add(this.pictureBox6);
            this.tabPage2.Controls.Add(this.Diemltn2);
            this.tabPage2.Controls.Add(this.egencylb2);
            this.tabPage2.Controls.Add(this.DatetimeLb2);
            this.tabPage2.Controls.Add(this.chkBS);
            this.tabPage2.Controls.Add(this.chkSDT);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.CreateServiceGrid);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1172, 523);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tạo phiếu dịch vụ";
            // 
            // CreateServiceGrid
            // 
            this.CreateServiceGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateServiceGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.CreateServiceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CreateServiceGrid.Location = new System.Drawing.Point(6, 98);
            this.CreateServiceGrid.Name = "CreateServiceGrid";
            this.CreateServiceGrid.RowTemplate.Height = 24;
            this.CreateServiceGrid.Size = new System.Drawing.Size(1160, 417);
            this.CreateServiceGrid.TabIndex = 10;
            this.CreateServiceGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CreateServiceGrid_CellDoubleClick);
            // 
            // DatetimeLb
            // 
            this.DatetimeLb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DatetimeLb.AutoSize = true;
            this.DatetimeLb.Location = new System.Drawing.Point(972, 9);
            this.DatetimeLb.Name = "DatetimeLb";
            this.DatetimeLb.Size = new System.Drawing.Size(64, 17);
            this.DatetimeLb.TabIndex = 6;
            this.DatetimeLb.Text = "Datetime";
            // 
            // egencylb
            // 
            this.egencylb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.egencylb.AutoSize = true;
            this.egencylb.Location = new System.Drawing.Point(972, 38);
            this.egencylb.Name = "egencylb";
            this.egencylb.Size = new System.Drawing.Size(81, 17);
            this.egencylb.TabIndex = 7;
            this.egencylb.Text = "Tường phát";
            // 
            // Diemltn
            // 
            this.Diemltn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Diemltn.AutoSize = true;
            this.Diemltn.Location = new System.Drawing.Point(973, 66);
            this.Diemltn.Name = "Diemltn";
            this.Diemltn.Size = new System.Drawing.Size(55, 17);
            this.Diemltn.TabIndex = 8;
            this.Diemltn.Text = "Diemltn";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(931, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 17);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(931, 38);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 17);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(931, 66);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(35, 17);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(934, 66);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(35, 17);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 27;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(934, 39);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(35, 17);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 26;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(934, 12);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(35, 17);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 25;
            this.pictureBox6.TabStop = false;
            // 
            // Diemltn2
            // 
            this.Diemltn2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Diemltn2.AutoSize = true;
            this.Diemltn2.Location = new System.Drawing.Point(976, 66);
            this.Diemltn2.Name = "Diemltn2";
            this.Diemltn2.Size = new System.Drawing.Size(55, 17);
            this.Diemltn2.TabIndex = 24;
            this.Diemltn2.Text = "Diemltn";
            // 
            // egencylb2
            // 
            this.egencylb2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.egencylb2.AutoSize = true;
            this.egencylb2.Location = new System.Drawing.Point(975, 39);
            this.egencylb2.Name = "egencylb2";
            this.egencylb2.Size = new System.Drawing.Size(81, 17);
            this.egencylb2.TabIndex = 23;
            this.egencylb2.Text = "Tường phát";
            // 
            // DatetimeLb2
            // 
            this.DatetimeLb2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DatetimeLb2.AutoSize = true;
            this.DatetimeLb2.Location = new System.Drawing.Point(975, 12);
            this.DatetimeLb2.Name = "DatetimeLb2";
            this.DatetimeLb2.Size = new System.Drawing.Size(64, 17);
            this.DatetimeLb2.TabIndex = 22;
            this.DatetimeLb2.Text = "Datetime";
            // 
            // chkBS
            // 
            this.chkBS.AutoSize = true;
            this.chkBS.Location = new System.Drawing.Point(161, 59);
            this.chkBS.Name = "chkBS";
            this.chkBS.Size = new System.Drawing.Size(94, 21);
            this.chkBS.TabIndex = 21;
            this.chkBS.TabStop = true;
            this.chkBS.Text = "Biển số xe";
            this.chkBS.UseVisualStyleBackColor = true;
            // 
            // chkSDT
            // 
            this.chkSDT.AutoSize = true;
            this.chkSDT.Checked = true;
            this.chkSDT.Location = new System.Drawing.Point(19, 59);
            this.chkSDT.Name = "chkSDT";
            this.chkSDT.Size = new System.Drawing.Size(112, 21);
            this.chkSDT.TabIndex = 20;
            this.chkSDT.TabStop = true;
            this.chkSDT.Text = "Số điện thoại";
            this.chkSDT.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(274, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 36);
            this.button2.TabIndex = 19;
            this.button2.Text = "Tìm kiếm";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // Total
            // 
            this.Total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Total.Enabled = false;
            this.Total.Location = new System.Drawing.Point(942, 495);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(191, 22);
            this.Total.TabIndex = 31;
            // 
            // TotalLbl
            // 
            this.TotalLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalLbl.AutoSize = true;
            this.TotalLbl.Location = new System.Drawing.Point(860, 498);
            this.TotalLbl.Name = "TotalLbl";
            this.TotalLbl.Size = new System.Drawing.Size(76, 17);
            this.TotalLbl.TabIndex = 30;
            this.TotalLbl.Text = "Tổng cộng";
            // 
            // placeHolderTextBox1
            // 
            this.placeHolderTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic);
            this.placeHolderTextBox1.ForeColor = System.Drawing.Color.Gray;
            this.placeHolderTextBox1.Location = new System.Drawing.Point(8, 39);
            this.placeHolderTextBox1.Multiline = true;
            this.placeHolderTextBox1.Name = "placeHolderTextBox1";
            this.placeHolderTextBox1.PlaceHolderText = "Nhập biển số xe";
            this.placeHolderTextBox1.Size = new System.Drawing.Size(234, 36);
            this.placeHolderTextBox1.TabIndex = 32;
            this.placeHolderTextBox1.Text = "Nhập biển số xe";
            // 
            // SearchTxt
            // 
            this.SearchTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic);
            this.SearchTxt.ForeColor = System.Drawing.Color.Gray;
            this.SearchTxt.Location = new System.Drawing.Point(19, 12);
            this.SearchTxt.Multiline = true;
            this.SearchTxt.Name = "SearchTxt";
            this.SearchTxt.PlaceHolderText = "Tìm khách hàng: Biển số/SĐT";
            this.SearchTxt.Size = new System.Drawing.Size(236, 38);
            this.SearchTxt.TabIndex = 28;
            this.SearchTxt.Text = "Tìm khách hàng: Biển số/SĐT";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 553);
            this.Controls.Add(this.tabControl1);
            this.Name = "Main";
            this.Text = "Main";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BikeGrid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CreateServiceGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView BikeGrid;
        private System.Windows.Forms.DataGridView CreateServiceGrid;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Diemltn;
        private System.Windows.Forms.Label egencylb;
        private System.Windows.Forms.Label DatetimeLb;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label Diemltn2;
        private System.Windows.Forms.Label egencylb2;
        private System.Windows.Forms.Label DatetimeLb2;
        private System.Windows.Forms.RadioButton chkBS;
        private System.Windows.Forms.RadioButton chkSDT;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox Total;
        private System.Windows.Forms.Label TotalLbl;
        private PlaceHolderTextBox placeHolderTextBox1;
        private PlaceHolderTextBox SearchTxt;
    }
}