using DoAnQuanLyChoThueOto.DTO;
using DoAnQuanLyChoThueOto.Setting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnQuanLyChoThueOto
{
    public partial class frmTaiKhoan : Form
    {
        public frmTaiKhoan()
        {
            InitializeComponent();
            this.ForeColor = CaiDat.Colors;
            this.Font = CaiDat.Fonts;
        }
        void LoadTK(List<TaiKhoan> ds)
        {
            lvTaiKhoan.Items.Clear();
            foreach (TaiKhoan item in ds)
            {
                ListViewItem itemtk = new ListViewItem(item.HienThiThongTinTaiKhoan());
                itemtk.Tag = item;
                lvTaiKhoan.Items.Add(itemtk);
            }
        }
        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadTK(DAO.AccountDAO.Instance.GetTaiKhoan());
        }

        private void btn_XemmatKhau_Click(object sender, EventArgs e)
        {
            if (btn_XemmatKhau.Text=="Xem")
            {
                txt_MatKhau.UseSystemPasswordChar = false;
                btn_XemmatKhau.Text = "Hủy";
            }
            else
            {
                txt_MatKhau.UseSystemPasswordChar = true;
                btn_XemmatKhau.Text = "Xem";
            }
            


        }
        bool CheckThongTin()
        {
            foreach (Control item in panel_thongtintk.Controls)
            {
                if (item is TextBox && string.IsNullOrWhiteSpace((item as TextBox).Text) == true)
                {
                    return false;
                }
            }
            return true;
        }

        private void btn_XemmatKhau_Leave(object sender, EventArgs e)
        {
            txt_MatKhau.UseSystemPasswordChar = true;
        }

        void reset()
        {
            foreach (Control item in panel_thongtintk.Controls)
            {
                if (item is TextBox)
                {
                    (item as TextBox).Clear();
                }
            }
        }
        private void lvTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTaiKhoan.SelectedItems.Count>0)
            {
                TaiKhoan x = lvTaiKhoan.SelectedItems[0].Tag as TaiKhoan;
                txt_TaiKhoan.Text = x.TenTK.Trim();
                txt_MatKhau.Text = x.MatKhau.Trim();
                txt_TenNguoiDung.Text = x.TenNguoiDung.Trim();
                if (x.LoaiTK==1)
                {
                    rd_admin.Checked = true;
                }
                else
                {
                    rd_NV.Checked = true;
                }
            }
            else
            {
                reset();
            }
        }

        private void lvTaiKhTK_Click(object sender, EventArgs e)
        {
            frmThemTkl f = new frmThemTkl();
            f.ShowDialog();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadTK(DAO.AccountDAO.Instance.GetTaiKhoan());
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvTaiKhoan.Items)
            {
                if (item.Checked)
                {
                    DAO.AccountDAO.Instance.DeleteTaiKhoan((item.Tag as TaiKhoan).TenTK);
                }
            }
            LoadTK(DAO.AccountDAO.Instance.GetTaiKhoan());
        }
        TaiKhoan LayThongTinTk()
        {
            TaiKhoan x = new TaiKhoan();
            x.TenTK = txt_TaiKhoan.Text;
            x.MatKhau = txt_MatKhau.Text;
            x.TenNguoiDung = txt_TenNguoiDung.Text;
            if (rd_admin.Checked)
            {
                x.LoaiTK = 1;
            }
            else
            {
                x.LoaiTK = 0;
            }
            return x;
        }
        private void btn_updateTaiKhoan_Click(object sender, EventArgs e)
        {
            if (!CheckThongTin())
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin và không được để trống");
            }
            else
            {
                if (DAO.AccountDAO.Instance.UpdateTaiKhoan(LayThongTinTk())>0)
                {
                    MessageBox.Show("Success");
                }
                else
                {
                    MessageBox.Show("False");

                }
            }
        }
    }
}
