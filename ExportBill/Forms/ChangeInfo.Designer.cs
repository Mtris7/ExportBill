namespace ExportBill
{
    partial class ChangeInfo
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
            this.SDTTxt = new System.Windows.Forms.TextBox();
            this.SDTMainChk = new System.Windows.Forms.RadioButton();
            this.SDTChk = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SDTTxt
            // 
            this.SDTTxt.Location = new System.Drawing.Point(67, 33);
            this.SDTTxt.Name = "SDTTxt";
            this.SDTTxt.Size = new System.Drawing.Size(270, 22);
            this.SDTTxt.TabIndex = 0;
            // 
            // SDTMainChk
            // 
            this.SDTMainChk.AutoSize = true;
            this.SDTMainChk.Checked = true;
            this.SDTMainChk.Location = new System.Drawing.Point(67, 71);
            this.SDTMainChk.Name = "SDTMainChk";
            this.SDTMainChk.Size = new System.Drawing.Size(95, 21);
            this.SDTMainChk.TabIndex = 1;
            this.SDTMainChk.TabStop = true;
            this.SDTMainChk.Text = "SĐT chính";
            this.SDTMainChk.UseVisualStyleBackColor = true;
            this.SDTMainChk.CheckedChanged += new System.EventHandler(this.SDTMainChk_CheckedChanged);
            // 
            // SDTChk
            // 
            this.SDTChk.AutoSize = true;
            this.SDTChk.Location = new System.Drawing.Point(252, 71);
            this.SDTChk.Name = "SDTChk";
            this.SDTChk.Size = new System.Drawing.Size(85, 21);
            this.SDTChk.TabIndex = 2;
            this.SDTChk.Text = "SĐT phụ";
            this.SDTChk.UseVisualStyleBackColor = true;
            this.SDTChk.CheckedChanged += new System.EventHandler(this.SDTChk_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SlateGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(134, 104);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 42);
            this.button1.TabIndex = 8;
            this.button1.Text = "Thay đổi";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChangeInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(411, 167);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SDTChk);
            this.Controls.Add(this.SDTMainChk);
            this.Controls.Add(this.SDTTxt);
            this.MaximumSize = new System.Drawing.Size(429, 214);
            this.MinimumSize = new System.Drawing.Size(429, 214);
            this.Name = "ChangeInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi SĐT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SDTTxt;
        private System.Windows.Forms.RadioButton SDTMainChk;
        private System.Windows.Forms.RadioButton SDTChk;
        private System.Windows.Forms.Button button1;
    }
}