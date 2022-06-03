
namespace DoAnQuanLyChoThueOto
{
    partial class frmTaiKhoan
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
            this.components = new System.ComponentModel.Container();
            this.pnAllFontColor = new System.Windows.Forms.Panel();
            this.lvTaiKhoan = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.panel_thongtintk = new System.Windows.Forms.Panel();
            this.rd_NV = new System.Windows.Forms.RadioButton();
            this.rd_admin = new System.Windows.Forms.RadioButton();
            this.btn_XemmatKhau = new System.Windows.Forms.Button();
            this.label_MaKhachHang = new System.Windows.Forms.Label();
            this.txt_TaiKhoan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_TenNguoiDung = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_MatKhau = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_updateTaiKhoan = new System.Windows.Forms.Button();
            this.lvTaiKhTK = new System.Windows.Forms.Button();
            this.pnAllFontColor.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel_thongtintk.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnAllFontColor
            // 
            this.pnAllFontColor.Controls.Add(this.lvTaiKhoan);
            this.pnAllFontColor.Controls.Add(this.panel2);
            this.pnAllFontColor.Location = new System.Drawing.Point(3, 12);
            this.pnAllFontColor.Name = "pnAllFontColor";
            this.pnAllFontColor.Size = new System.Drawing.Size(1271, 495);
            this.pnAllFontColor.TabIndex = 1;
            // 
            // lvTaiKhoan
            // 
            this.lvTaiKhoan.CheckBoxes = true;
            this.lvTaiKhoan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4});
            this.lvTaiKhoan.ContextMenuStrip = this.contextMenuStrip1;
            this.lvTaiKhoan.FullRowSelect = true;
            this.lvTaiKhoan.GridLines = true;
            this.lvTaiKhoan.HideSelection = false;
            this.lvTaiKhoan.Location = new System.Drawing.Point(3, 3);
            this.lvTaiKhoan.MultiSelect = false;
            this.lvTaiKhoan.Name = "lvTaiKhoan";
            this.lvTaiKhoan.Size = new System.Drawing.Size(772, 489);
            this.lvTaiKhoan.TabIndex = 17;
            this.lvTaiKhoan.UseCompatibleStateImageBehavior = false;
            this.lvTaiKhoan.View = System.Windows.Forms.View.Details;
            this.lvTaiKhoan.SelectedIndexChanged += new System.EventHandler(this.lvTaiKhoan_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên Đăng Nhập";
            this.columnHeader1.Width = 206;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tên Người Dùng";
            this.columnHeader3.Width = 217;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Loại Tài Khoản";
            this.columnHeader4.Width = 218;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(105, 28);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnTaiLai);
            this.panel2.Controls.Add(this.panel_thongtintk);
            this.panel2.Controls.Add(this.btn_updateTaiKhoan);
            this.panel2.Controls.Add(this.lvTaiKhTK);
            this.panel2.Location = new System.Drawing.Point(778, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(490, 489);
            this.panel2.TabIndex = 16;
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Location = new System.Drawing.Point(242, 375);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(103, 38);
            this.btnTaiLai.TabIndex = 17;
            this.btnTaiLai.Text = "Tải Lại";
            this.btnTaiLai.UseVisualStyleBackColor = true;
            this.btnTaiLai.Click += new System.EventHandler(this.btnTaiLai_Click);
            // 
            // panel_thongtintk
            // 
            this.panel_thongtintk.Controls.Add(this.rd_NV);
            this.panel_thongtintk.Controls.Add(this.rd_admin);
            this.panel_thongtintk.Controls.Add(this.btn_XemmatKhau);
            this.panel_thongtintk.Controls.Add(this.label_MaKhachHang);
            this.panel_thongtintk.Controls.Add(this.txt_TaiKhoan);
            this.panel_thongtintk.Controls.Add(this.label1);
            this.panel_thongtintk.Controls.Add(this.txt_TenNguoiDung);
            this.panel_thongtintk.Controls.Add(this.label2);
            this.panel_thongtintk.Controls.Add(this.txt_MatKhau);
            this.panel_thongtintk.Controls.Add(this.label4);
            this.panel_thongtintk.Location = new System.Drawing.Point(3, 3);
            this.panel_thongtintk.Name = "panel_thongtintk";
            this.panel_thongtintk.Size = new System.Drawing.Size(482, 343);
            this.panel_thongtintk.TabIndex = 16;
            // 
            // rd_NV
            // 
            this.rd_NV.AutoSize = true;
            this.rd_NV.Location = new System.Drawing.Point(300, 188);
            this.rd_NV.Name = "rd_NV";
            this.rd_NV.Size = new System.Drawing.Size(95, 21);
            this.rd_NV.TabIndex = 19;
            this.rd_NV.TabStop = true;
            this.rd_NV.Text = "Nhân Viên";
            this.rd_NV.UseVisualStyleBackColor = true;
            // 
            // rd_admin
            // 
            this.rd_admin.AutoSize = true;
            this.rd_admin.Location = new System.Drawing.Point(175, 188);
            this.rd_admin.Name = "rd_admin";
            this.rd_admin.Size = new System.Drawing.Size(68, 21);
            this.rd_admin.TabIndex = 18;
            this.rd_admin.TabStop = true;
            this.rd_admin.Text = "Admin";
            this.rd_admin.UseVisualStyleBackColor = true;
            // 
            // btn_XemmatKhau
            // 
            this.btn_XemmatKhau.Location = new System.Drawing.Point(418, 92);
            this.btn_XemmatKhau.Name = "btn_XemmatKhau";
            this.btn_XemmatKhau.Size = new System.Drawing.Size(52, 28);
            this.btn_XemmatKhau.TabIndex = 17;
            this.btn_XemmatKhau.Text = "Xem";
            this.btn_XemmatKhau.UseVisualStyleBackColor = true;
            this.btn_XemmatKhau.Click += new System.EventHandler(this.btn_XemmatKhau_Click);
            // 
            // label_MaKhachHang
            // 
            this.label_MaKhachHang.AutoSize = true;
            this.label_MaKhachHang.Location = new System.Drawing.Point(19, 57);
            this.label_MaKhachHang.Name = "label_MaKhachHang";
            this.label_MaKhachHang.Size = new System.Drawing.Size(109, 17);
            this.label_MaKhachHang.TabIndex = 14;
            this.label_MaKhachHang.Text = "Tên Đăng Nhập";
            // 
            // txt_TaiKhoan
            // 
            this.txt_TaiKhoan.Enabled = false;
            this.txt_TaiKhoan.Location = new System.Drawing.Point(140, 54);
            this.txt_TaiKhoan.Name = "txt_TaiKhoan";
            this.txt_TaiKhoan.Size = new System.Drawing.Size(272, 22);
            this.txt_TaiKhoan.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Người Dùng";
            // 
            // txt_TenNguoiDung
            // 
            this.txt_TenNguoiDung.Location = new System.Drawing.Point(140, 137);
            this.txt_TenNguoiDung.Name = "txt_TenNguoiDung";
            this.txt_TenNguoiDung.Size = new System.Drawing.Size(272, 22);
            this.txt_TenNguoiDung.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật Khẩu";
            // 
            // txt_MatKhau
            // 
            this.txt_MatKhau.Location = new System.Drawing.Point(140, 92);
            this.txt_MatKhau.Name = "txt_MatKhau";
            this.txt_MatKhau.Size = new System.Drawing.Size(272, 22);
            this.txt_MatKhau.TabIndex = 3;
            this.txt_MatKhau.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Loại TK";
            // 
            // btn_updateTaiKhoan
            // 
            this.btn_updateTaiKhoan.Location = new System.Drawing.Point(123, 375);
            this.btn_updateTaiKhoan.Name = "btn_updateTaiKhoan";
            this.btn_updateTaiKhoan.Size = new System.Drawing.Size(103, 38);
            this.btn_updateTaiKhoan.TabIndex = 16;
            this.btn_updateTaiKhoan.Text = "Cập Nhật";
            this.btn_updateTaiKhoan.UseVisualStyleBackColor = true;
            this.btn_updateTaiKhoan.Click += new System.EventHandler(this.btn_updateTaiKhoan_Click);
            // 
            // lvTaiKhTK
            // 
            this.lvTaiKhTK.Location = new System.Drawing.Point(3, 375);
            this.lvTaiKhTK.Name = "lvTaiKhTK";
            this.lvTaiKhTK.Size = new System.Drawing.Size(103, 38);
            this.lvTaiKhTK.TabIndex = 10;
            this.lvTaiKhTK.Text = "Thêm";
            this.lvTaiKhTK.UseVisualStyleBackColor = true;
            this.lvTaiKhTK.Click += new System.EventHandler(this.lvTaiKhTK_Click);
            // 
            // frmTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 522);
            this.Controls.Add(this.pnAllFontColor);
            this.Name = "frmTaiKhoan";
            this.Text = "frmTaiKhoan";
            this.Load += new System.EventHandler(this.frmTaiKhoan_Load);
            this.pnAllFontColor.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel_thongtintk.ResumeLayout(false);
            this.panel_thongtintk.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnAllFontColor;
        private System.Windows.Forms.ListView lvTaiKhoan;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel_thongtintk;
        private System.Windows.Forms.RadioButton rd_NV;
        private System.Windows.Forms.RadioButton rd_admin;
        private System.Windows.Forms.Button btn_XemmatKhau;
        private System.Windows.Forms.Label label_MaKhachHang;
        private System.Windows.Forms.TextBox txt_TaiKhoan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_TenNguoiDung;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_MatKhau;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_updateTaiKhoan;
        private System.Windows.Forms.Button lvTaiKhTK;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
    }
}