namespace ExportBill
{
    partial class ChangeCustomer
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.searchCustomerTxt = new ExportBill.PlaceHolderTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ServiceHeaderCtr = new DevExpress.XtraGrid.GridControl();
            this.gvServiceHeader = new DevExpress.XtraGrid.Views.Grid.GridView();
            this._CustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this._Customer = new DevExpress.XtraGrid.Columns.GridColumn();
            this._Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this._Phone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceHeaderCtr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvServiceHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(667, 76);
            this.panel1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.searchCustomerTxt);
            this.groupControl1.Controls.Add(this.button2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(667, 76);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Thông tin tìm kiếm";
            // 
            // searchCustomerTxt
            // 
            this.searchCustomerTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.searchCustomerTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchCustomerTxt.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Italic);
            this.searchCustomerTxt.ForeColor = System.Drawing.Color.Gray;
            this.searchCustomerTxt.Location = new System.Drawing.Point(4, 38);
            this.searchCustomerTxt.Margin = new System.Windows.Forms.Padding(2);
            this.searchCustomerTxt.Name = "searchCustomerTxt";
            this.searchCustomerTxt.PlaceHolderText = "Tìm khách hàng: SĐT";
            this.searchCustomerTxt.Size = new System.Drawing.Size(204, 25);
            this.searchCustomerTxt.TabIndex = 19;
            this.searchCustomerTxt.Text = "Tìm khách hàng: SĐT";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::ExportBill.Properties.Resources.find21;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(222, 35);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 30);
            this.button2.TabIndex = 20;
            this.button2.Text = "Tìm kiếm";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ServiceHeaderCtr);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(667, 281);
            this.panel2.TabIndex = 1;
            // 
            // ServiceHeaderCtr
            // 
            this.ServiceHeaderCtr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServiceHeaderCtr.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.ServiceHeaderCtr.Location = new System.Drawing.Point(0, 0);
            this.ServiceHeaderCtr.MainView = this.gvServiceHeader;
            this.ServiceHeaderCtr.Margin = new System.Windows.Forms.Padding(2);
            this.ServiceHeaderCtr.Name = "ServiceHeaderCtr";
            this.ServiceHeaderCtr.Size = new System.Drawing.Size(667, 281);
            this.ServiceHeaderCtr.TabIndex = 2;
            this.ServiceHeaderCtr.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvServiceHeader});
            // 
            // gvServiceHeader
            // 
            this.gvServiceHeader.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this._CustomerNumber,
            this._Customer,
            this._Address,
            this._Phone});
            this.gvServiceHeader.DetailHeight = 437;
            this.gvServiceHeader.GridControl = this.ServiceHeaderCtr;
            this.gvServiceHeader.Name = "gvServiceHeader";
            this.gvServiceHeader.OptionsView.ShowGroupPanel = false;
            this.gvServiceHeader.DoubleClick += new System.EventHandler(this.gvServiceHeader_DoubleClick);
            // 
            // _CustomerNumber
            // 
            this._CustomerNumber.Caption = "Mã khách hàng";
            this._CustomerNumber.FieldName = "CustomerNumber";
            this._CustomerNumber.MinWidth = 25;
            this._CustomerNumber.Name = "_CustomerNumber";
            this._CustomerNumber.OptionsColumn.AllowEdit = false;
            this._CustomerNumber.Visible = true;
            this._CustomerNumber.VisibleIndex = 0;
            this._CustomerNumber.Width = 113;
            // 
            // _Customer
            // 
            this._Customer.Caption = "Khách hàng";
            this._Customer.FieldName = "CustomerName";
            this._Customer.MinWidth = 25;
            this._Customer.Name = "_Customer";
            this._Customer.OptionsColumn.AllowEdit = false;
            this._Customer.Visible = true;
            this._Customer.VisibleIndex = 1;
            this._Customer.Width = 169;
            // 
            // _Address
            // 
            this._Address.Caption = "Địa chỉ";
            this._Address.FieldName = "Address";
            this._Address.MinWidth = 25;
            this._Address.Name = "_Address";
            this._Address.OptionsColumn.AllowEdit = false;
            this._Address.Visible = true;
            this._Address.VisibleIndex = 2;
            this._Address.Width = 228;
            // 
            // _Phone
            // 
            this._Phone.Caption = "Số điện thoại";
            this._Phone.FieldName = "Phone";
            this._Phone.MinWidth = 25;
            this._Phone.Name = "_Phone";
            this._Phone.OptionsColumn.AllowEdit = false;
            this._Phone.Visible = true;
            this._Phone.VisibleIndex = 3;
            this._Phone.Width = 127;
            // 
            // ChangeCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 357);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ChangeCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi khách hàng";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ServiceHeaderCtr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvServiceHeader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private PlaceHolderTextBox searchCustomerTxt;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl ServiceHeaderCtr;
        private DevExpress.XtraGrid.Views.Grid.GridView gvServiceHeader;
        private DevExpress.XtraGrid.Columns.GridColumn _CustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn _Customer;
        private DevExpress.XtraGrid.Columns.GridColumn _Address;
        private DevExpress.XtraGrid.Columns.GridColumn _Phone;
    }
}