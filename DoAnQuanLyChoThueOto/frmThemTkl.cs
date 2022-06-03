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
    public partial class frmThemTkl : Form
    {
        public frmThemTkl()
        {
            InitializeComponent();
            this.Font = CaiDat.Fonts;
            this.ForeColor = CaiDat.Colors;
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
        
        private void btn_themTK_Click(object sender, EventArgs e)
        {
            if (!CheckThongTin())
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin và không được để trống");
                
            }
            else
            {
                if (DAO.AccountDAO.Instance.CheckThongTinTK(txt_TaiKhoan.Text.Trim()) <= 0)
                {
                    if (DAO.AccountDAO.Instance.InsertTaiKhoan(LayThongTinTk()) > 0)
                    {
                        MessageBox.Show("Success");
                        reset();

                    }
                }
                else
                {
                        MessageBox.Show("Tên Đang Nhập đã tồn tại");

                }
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

        private void txt_TaiKhoan_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_TaiKhoan.Text.Trim()))
            {
                lbThongBao.Text = "Không được để trống";
            }
            else
            {
                lbThongBao.Text = "";
                


            }
            
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
    }
}
