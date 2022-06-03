
namespace DoAnQuanLyChoThueOto
{
    partial class frmKhachHang
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
            this.pnAllFontColor = new System.Windows.Forms.Panel();
            this.txtTenKHFind = new System.Windows.Forms.Label();
            this.txt_TenKHfind = new System.Windows.Forms.TextBox();
            this.lvKhachHang = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnThongTinKH = new System.Windows.Forms.Panel();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.rdNu = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rdNam = new System.Windows.Forms.RadioButton();
            this.txtSCMND = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.btn_updateKH = new System.Windows.Forms.Button();
            this.btn_addKH = new System.Windows.Forms.Button();
            this.pnAllFontColor.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnThongTinKH.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnAllFontColor
            // 
            this.pnAllFontColor.Controls.Add(this.txtTenKHFind);
            this.pnAllFontColor.Controls.Add(this.txt_TenKHfind);
            this.pnAllFontColor.Controls.Add(this.lvKhachHang);
            this.pnAllFontColor.Controls.Add(this.panel2);
            this.pnAllFontColor.Location = new System.Drawing.Point(6, 12);
            this.pnAllFontColor.Name = "pnAllFontColor";
            this.pnAllFontColor.Size = new System.Drawing.Size(1271, 487);
            this.pnAllFontColor.TabIndex = 1;
            // 
            // txtTenKHFind
            // 
            this.txtTenKHFind.AutoSize = true;
            this.txtTenKHFind.Location = new System.Drawing.Point(19, 26);
            this.txtTenKHFind.Name = "txtTenKHFind";
            this.txtTenKHFind.Size = new System.Drawing.Size(115, 17);
            this.txtTenKHFind.TabIndex = 20;
            this.txtTenKHFind.Text = "Tên Khách Hàng";
            // 
            // txt_TenKHfind
            // 
            this.txt_TenKHfind.Location = new System.Drawing.Point(140, 23);
            this.txt_TenKHfind.Name = "txt_TenKHfind";
            this.txt_TenKHfind.Size = new System.Drawing.Size(283, 22);
            this.txt_TenKHfind.TabIndex = 18;
            this.txt_TenKHfind.TextChanged += new System.EventHandler(this.txt_TenKHfind_TextChanged);
            // 
            // lvKhachHang
            // 
            this.lvKhachHang.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvKhachHang.FullRowSelect = true;
            this.lvKhachHang.GridLines = true;
            this.lvKhachHang.HideSelection = false;
            this.lvKhachHang.Location = new System.Drawing.Point(3, 60);
            this.lvKhachHang.MultiSelect = false;
            this.lvKhachHang.Name = "lvKhachHang";
            this.lvKhachHang.Size = new System.Drawing.Size(772, 421);
            this.lvKhachHang.TabIndex = 17;
            this.lvKhachHang.UseCompatibleStateImageBehavior = false;
            this.lvKhachHang.View = System.Windows.Forms.View.Details;
            this.lvKhachHang.SelectedIndexChanged += new System.EventHandler(this.lvKhachHang_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã KH";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên Khách Hàng";
            this.columnHeader2.Width = 164;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "SCMND";
            this.columnHeader3.Width = 141;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "SDT";
            this.columnHeader4.Width = 191;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Địa Chỉ";
            this.columnHeader5.Width = 107;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Giới Tính";
            this.columnHeader6.Width = 113;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnThongTinKH);
            this.panel2.Controls.Add(this.btn_updateKH);
            this.panel2.Controls.Add(this.btn_addKH);
            this.panel2.Location = new System.Drawing.Point(778, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(490, 489);
            this.panel2.TabIndex = 16;
            // 
            // pnThongTinKH
            // 
            this.pnThongTinKH.Controls.Add(this.txtMaKH);
            this.pnThongTinKH.Controls.Add(this.label7);
            this.pnThongTinKH.Controls.Add(this.label1);
            this.pnThongTinKH.Controls.Add(this.txtTenKH);
            this.pnThongTinKH.Controls.Add(this.rdNu);
            this.pnThongTinKH.Controls.Add(this.label2);
            this.pnThongTinKH.Controls.Add(this.rdNam);
            this.pnThongTinKH.Controls.Add(this.txtSCMND);
            this.pnThongTinKH.Controls.Add(this.label5);
            this.pnThongTinKH.Controls.Add(this.label3);
            this.pnThongTinKH.Controls.Add(this.txtDiaChi);
            this.pnThongTinKH.Controls.Add(this.label4);
            this.pnThongTinKH.Controls.Add(this.txtSDT);
            this.pnThongTinKH.Location = new System.Drawing.Point(3, 23);
            this.pnThongTinKH.Name = "pnThongTinKH";
            this.pnThongTinKH.Size = new System.Drawing.Size(451, 269);
            this.pnThongTinKH.TabIndex = 17;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(150, 31);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.ReadOnly = true;
            this.txtMaKH.Size = new System.Drawing.Size(231, 22);
            this.txtMaKH.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Mã KH";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Khách Hàng";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(150, 74);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(231, 22);
            this.txtTenKH.TabIndex = 1;
            // 
            // rdNu
            // 
            this.rdNu.AutoSize = true;
            this.rdNu.Checked = true;
            this.rdNu.Location = new System.Drawing.Point(253, 243);
            this.rdNu.Name = "rdNu";
            this.rdNu.Size = new System.Drawing.Size(47, 21);
            this.rdNu.TabIndex = 10;
            this.rdNu.TabStop = true;
            this.rdNu.Text = "Nữ";
            this.rdNu.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "SCMND";
            // 
            // rdNam
            // 
            this.rdNam.AutoSize = true;
            this.rdNam.Location = new System.Drawing.Point(150, 243);
            this.rdNam.Name = "rdNam";
            this.rdNam.Size = new System.Drawing.Size(58, 21);
            this.rdNam.TabIndex = 9;
            this.rdNam.Text = "Nam";
            this.rdNam.UseVisualStyleBackColor = true;
            // 
            // txtSCMND
            // 
            this.txtSCMND.Location = new System.Drawing.Point(150, 109);
            this.txtSCMND.Name = "txtSCMND";
            this.txtSCMND.Size = new System.Drawing.Size(249, 22);
            this.txtSCMND.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Giới Tính";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Số Điện Thoại";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(150, 198);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(293, 22);
            this.txtDiaChi.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Địa Chỉ";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(150, 151);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(272, 22);
            this.txtSDT.TabIndex = 5;
            // 
            // btn_updateKH
            // 
            this.btn_updateKH.Location = new System.Drawing.Point(127, 314);
            this.btn_updateKH.Name = "btn_updateKH";
            this.btn_updateKH.Size = new System.Drawing.Size(103, 38);
            this.btn_updateKH.TabIndex = 16;
            this.btn_updateKH.Text = "Cập Nhật";
            this.btn_updateKH.UseVisualStyleBackColor = true;
            this.btn_updateKH.Click += new System.EventHandler(this.btn_updateKH_Click);
            // 
            // btn_addKH
            // 
            this.btn_addKH.Location = new System.Drawing.Point(3, 314);
            this.btn_addKH.Name = "btn_addKH";
            this.btn_addKH.Size = new System.Drawing.Size(103, 38);
            this.btn_addKH.TabIndex = 10;
            this.btn_addKH.Text = "Thêm";
            this.btn_addKH.UseVisualStyleBackColor = true;
            this.btn_addKH.Click += new System.EventHandler(this.btn_addKH_Click);
            // 
            // frmKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 503);
            this.Controls.Add(this.pnAllFontColor);
            this.Name = "frmKhachHang";
            this.Text = "frmKhachHang";
            this.Load += new System.EventHandler(this.frmKhachHang_Load);
            this.pnAllFontColor.ResumeLayout(false);
            this.pnAllFontColor.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnThongTinKH.ResumeLayout(false);
            this.pnThongTinKH.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel pnAllFontColor;
        private System.Windows.Forms.Label txtTenKHFind;
        private System.Windows.Forms.TextBox txt_TenKHfind;
        private System.Windows.Forms.ListView lvKhachHang;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_updateKH;
        private System.Windows.Forms.Button btn_addKH;
        private System.Windows.Forms.Panel pnThongTinKH;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.RadioButton rdNu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdNam;
        private System.Windows.Forms.TextBox txtSCMND;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSDT;
    }
}