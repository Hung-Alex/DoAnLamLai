
namespace DoAnQuanLyChoThueOto
{
    partial class frmOto
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
            this.label6 = new System.Windows.Forms.Label();
            this.txt_findoto = new System.Windows.Forms.TextBox();
            this.lvOto = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel_editOto = new System.Windows.Forms.Panel();
            this.txt_sochongoi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label_MaKhachHang = new System.Windows.Forms.Label();
            this.txt_maxe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_hangxe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_tenxe = new System.Windows.Forms.TextBox();
            this.txt_biensoxe = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_updateoto = new System.Windows.Forms.Button();
            this.btn_addoto = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnAllFontColor.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel_editOto.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnAllFontColor
            // 
            this.pnAllFontColor.Controls.Add(this.label6);
            this.pnAllFontColor.Controls.Add(this.txt_findoto);
            this.pnAllFontColor.Controls.Add(this.lvOto);
            this.pnAllFontColor.Controls.Add(this.panel2);
            this.pnAllFontColor.Location = new System.Drawing.Point(12, 12);
            this.pnAllFontColor.Name = "pnAllFontColor";
            this.pnAllFontColor.Size = new System.Drawing.Size(1271, 495);
            this.pnAllFontColor.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "Tên Xe";
            // 
            // txt_findoto
            // 
            this.txt_findoto.Location = new System.Drawing.Point(79, 23);
            this.txt_findoto.Name = "txt_findoto";
            this.txt_findoto.Size = new System.Drawing.Size(306, 22);
            this.txt_findoto.TabIndex = 18;
            this.txt_findoto.TextChanged += new System.EventHandler(this.txt_findoto_TextChanged);
            // 
            // lvOto
            // 
            this.lvOto.CheckBoxes = true;
            this.lvOto.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvOto.FullRowSelect = true;
            this.lvOto.GridLines = true;
            this.lvOto.HideSelection = false;
            this.lvOto.Location = new System.Drawing.Point(3, 60);
            this.lvOto.MultiSelect = false;
            this.lvOto.Name = "lvOto";
            this.lvOto.Size = new System.Drawing.Size(772, 421);
            this.lvOto.TabIndex = 17;
            this.lvOto.UseCompatibleStateImageBehavior = false;
            this.lvOto.View = System.Windows.Forms.View.Details;
            this.lvOto.SelectedIndexChanged += new System.EventHandler(this.listView_oto_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã Xe";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên Xe";
            this.columnHeader2.Width = 164;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Hãng Xe";
            this.columnHeader3.Width = 141;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Biển Số Xe";
            this.columnHeader4.Width = 191;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Số Chỗ Ngồi";
            this.columnHeader5.Width = 107;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Trạng Thái";
            this.columnHeader6.Width = 113;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel_editOto);
            this.panel2.Controls.Add(this.btn_updateoto);
            this.panel2.Controls.Add(this.btn_addoto);
            this.panel2.Location = new System.Drawing.Point(778, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(490, 489);
            this.panel2.TabIndex = 16;
            // 
            // panel_editOto
            // 
            this.panel_editOto.Controls.Add(this.txt_sochongoi);
            this.panel_editOto.Controls.Add(this.label3);
            this.panel_editOto.Controls.Add(this.label_MaKhachHang);
            this.panel_editOto.Controls.Add(this.txt_maxe);
            this.panel_editOto.Controls.Add(this.label1);
            this.panel_editOto.Controls.Add(this.txt_hangxe);
            this.panel_editOto.Controls.Add(this.label2);
            this.panel_editOto.Controls.Add(this.txt_tenxe);
            this.panel_editOto.Controls.Add(this.txt_biensoxe);
            this.panel_editOto.Controls.Add(this.label4);
            this.panel_editOto.Location = new System.Drawing.Point(3, 3);
            this.panel_editOto.Name = "panel_editOto";
            this.panel_editOto.Size = new System.Drawing.Size(482, 343);
            this.panel_editOto.TabIndex = 16;
            // 
            // txt_sochongoi
            // 
            this.txt_sochongoi.Location = new System.Drawing.Point(140, 238);
            this.txt_sochongoi.Name = "txt_sochongoi";
            this.txt_sochongoi.Size = new System.Drawing.Size(67, 22);
            this.txt_sochongoi.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Số Chỗ Ngồi";
            // 
            // label_MaKhachHang
            // 
            this.label_MaKhachHang.AutoSize = true;
            this.label_MaKhachHang.Location = new System.Drawing.Point(19, 57);
            this.label_MaKhachHang.Name = "label_MaKhachHang";
            this.label_MaKhachHang.Size = new System.Drawing.Size(48, 17);
            this.label_MaKhachHang.TabIndex = 14;
            this.label_MaKhachHang.Text = "Mã Xe";
            // 
            // txt_maxe
            // 
            this.txt_maxe.Enabled = false;
            this.txt_maxe.Location = new System.Drawing.Point(140, 54);
            this.txt_maxe.Name = "txt_maxe";
            this.txt_maxe.Size = new System.Drawing.Size(272, 22);
            this.txt_maxe.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hãng Xe";
            // 
            // txt_hangxe
            // 
            this.txt_hangxe.Location = new System.Drawing.Point(140, 137);
            this.txt_hangxe.Name = "txt_hangxe";
            this.txt_hangxe.Size = new System.Drawing.Size(272, 22);
            this.txt_hangxe.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Xe";
            // 
            // txt_tenxe
            // 
            this.txt_tenxe.Location = new System.Drawing.Point(140, 92);
            this.txt_tenxe.Name = "txt_tenxe";
            this.txt_tenxe.Size = new System.Drawing.Size(272, 22);
            this.txt_tenxe.TabIndex = 3;
            // 
            // txt_biensoxe
            // 
            this.txt_biensoxe.Location = new System.Drawing.Point(140, 190);
            this.txt_biensoxe.Name = "txt_biensoxe";
            this.txt_biensoxe.Size = new System.Drawing.Size(272, 22);
            this.txt_biensoxe.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Biển Số Xe";
            // 
            // btn_updateoto
            // 
            this.btn_updateoto.Location = new System.Drawing.Point(123, 375);
            this.btn_updateoto.Name = "btn_updateoto";
            this.btn_updateoto.Size = new System.Drawing.Size(103, 38);
            this.btn_updateoto.TabIndex = 16;
            this.btn_updateoto.Text = "Cập Nhật";
            this.btn_updateoto.UseVisualStyleBackColor = true;
            this.btn_updateoto.Click += new System.EventHandler(this.btn_updateoto_Click);
            // 
            // btn_addoto
            // 
            this.btn_addoto.Location = new System.Drawing.Point(3, 375);
            this.btn_addoto.Name = "btn_addoto";
            this.btn_addoto.Size = new System.Drawing.Size(103, 38);
            this.btn_addoto.TabIndex = 10;
            this.btn_addoto.Text = "Thêm";
            this.btn_addoto.UseVisualStyleBackColor = true;
            this.btn_addoto.Click += new System.EventHandler(this.btn_addoto_Click);
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
            // frmOto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 519);
            this.Controls.Add(this.pnAllFontColor);
            this.Name = "frmOto";
            this.Text = "fOto";
            this.Load += new System.EventHandler(this.frmOto_Load);
            this.pnAllFontColor.ResumeLayout(false);
            this.pnAllFontColor.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel_editOto.ResumeLayout(false);
            this.panel_editOto.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnAllFontColor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel_editOto;
        private System.Windows.Forms.Label label_MaKhachHang;
        private System.Windows.Forms.TextBox txt_maxe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_hangxe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_tenxe;
        private System.Windows.Forms.TextBox txt_biensoxe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_updateoto;
        private System.Windows.Forms.Button btn_addoto;
        private System.Windows.Forms.ListView lvOto;
        private System.Windows.Forms.TextBox txt_sochongoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_findoto;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
    }
}