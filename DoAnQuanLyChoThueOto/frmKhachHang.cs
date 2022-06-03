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
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
            this.Font = CaiDat.Fonts;
            this.ForeColor = CaiDat.Colors;
        }
        void LoadKH(List<KhachHang> ds)
        {
            lvKhachHang.Items.Clear();
            foreach (KhachHang item in ds)
            {
                ListViewItem itemkh = new ListViewItem(item.ThongTinListviewKhachHang());
                itemkh.Tag = item;
                lvKhachHang.Items.Add(itemkh);

            }
        }
        void HienThiThongTinKH(KhachHang x)
        {
            txtMaKH.Text = x.MaKH.ToString();
            txtTenKH.Text = x.TenKH;
            txtSCMND.Text = x.SCMND;
            txtSDT.Text = x.SoDT;
            txtDiaChi.Text = x.DiaChi;
            if (x.GioiTinh==1)
            {
                rdNam.Checked = true;
            }
            else
            {
                rdNu.Checked = true;
            }
        }
        bool CheckThongTinKH()
        {
            if ( string.IsNullOrWhiteSpace(txtTenKH.Text)|| string.IsNullOrWhiteSpace(txtSDT.Text)|| string.IsNullOrWhiteSpace(txtSCMND.Text)|| string.IsNullOrWhiteSpace(txtDiaChi.Text))
                return false;            
            return true;
        }
        object [] GetThongTinKhachHang()
        {
          
            return new object[] {txtMaKH.Text,txtTenKH.Text,txtSCMND.Text,txtSDT.Text,txtDiaChi.Text,rdNam.Checked==true?1:0 };
        }
        object[] GetThongTinKhachHangThem()// cái này cho hàm thêm 2/6
        {
            string makh= DAO.DataProvider.Instance.ExecuteScalar(@"select dbo.ufn_SinhMaKhachHang()").ToString();
            return new object[] { makh, txtTenKH.Text, txtSCMND.Text, txtSDT.Text, txtDiaChi.Text, rdNam.Checked == true ? 1 : 0 };
        }
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadKH(DAO.KhachHangDAO.Instance.GetListKhachHang());
        }

        private void btn_updateKH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng nhập Đủ Thông Tin Hoặc Chọn khách hàng muốn cập nhật");
                return;
            }
            if (!CheckThongTinKH())
            {
                MessageBox.Show("Vui lòng nhập Đủ Thông Tin Hoặc Chọn khách hàng muốn cập nhật");
            }
            else
            {
                if (DAO.KhachHangDAO.Instance.UpdateKhachHang(GetThongTinKhachHang())>0)
                {
                    MessageBox.Show("Succes");
                    LoadKH(DAO.KhachHangDAO.Instance.GetListKhachHang());

                }
                else
                {
                    MessageBox.Show("False");

                }
            }
        }

        private void lvKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvKhachHang.SelectedItems.Count>0)
            {
                HienThiThongTinKH(lvKhachHang.SelectedItems[0].Tag as KhachHang);
            }
            else
            {
                ResetThongTinKhachHang();
            }
        }
        void ResetThongTinKhachHang()
        {
            foreach (Control item in pnThongTinKH.Controls)
            {
                if (item is TextBox)
                {
                    (item as TextBox).Clear();
                }
            }
        }

        private void btn_addKH_Click(object sender, EventArgs e)
        {
            if (!CheckThongTinKH())
            {
                MessageBox.Show("Vui lòng nhập Đủ Thông Tin");
            }
            else
            {
                if (DAO.KhachHangDAO.Instance.InsertKhachHang(GetThongTinKhachHangThem())>0)
                {
                    MessageBox.Show("Succes");
                    LoadKH(DAO.KhachHangDAO.Instance.GetListKhachHang());

                }
                else
                {
                    MessageBox.Show("False");

                }
            }
        }

        private void txt_TenKHfind_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_TenKHfind.Text))
            {
                LoadKH(DAO.KhachHangDAO.Instance.GetListKhachHang());

            }
            else
            {
                LoadKH(DAO.KhachHangDAO.Instance.FindKH(txt_TenKHfind.Text));
            }
        }
    }
}
