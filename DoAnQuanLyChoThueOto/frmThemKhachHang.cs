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
    public partial class frmThemKhachHang : Form
    {
        public frmThemKhachHang()
        {
            InitializeComponent();
            this.Font = CaiDat.Fonts;
            this.ForeColor = CaiDat.Colors;
        }

        void Reset()
        {
            txtTenKH.Text = "";
            txtSCMND.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
        }
        DTO.KhachHang GetKhachHang()
        {
            DTO.KhachHang kh = new DTO.KhachHang();

            kh.MaKH = DAO.DataProvider.Instance.ExecuteScalar($"select dbo.ufn_SinhMaKhachHang()").ToString();
            kh.TenKH = txtTenKH.Text.Trim();
            kh.SCMND = txtSCMND.Text.Trim();
            kh.SoDT = txtSDT.Text.Trim();
            kh.DiaChi = txtDiaChi.Text.Trim();
            if (rdNam.Checked)// nam là 1 // nữ là 0
            {
                kh.GioiTinh = 1;
            }
            if(rdNu.Checked)
            {
                kh.GioiTinh = 0;

            }
            return kh;
        }
        bool CheckThongTin()// kiểm tra xem người dùng có để trống thông tin không 
        {
            if (string.IsNullOrEmpty(txtTenKH.Text.Trim())|| string.IsNullOrEmpty(txtSCMND.Text.Trim())|| string.IsNullOrEmpty(txtSDT.Text.Trim())|| string.IsNullOrEmpty(txtDiaChi.Text.Trim()))
            {
                return false;
            }
            return true;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!CheckThongTin())
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return;
            }
            if (DAO.KhachHangDAO.Instance.InsertKhachHang(GetKhachHang())>0)
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
