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
    public partial class frmHopDong : Form
    {
        public frmHopDong()
        {
            InitializeComponent();

        }

        void LoadHopDong(List<DTO.HopDong> x)
        {
            lvHopDong.Items.Clear();
            foreach (DTO.HopDong item in x)
            {
                ListViewItem itemhopdong = new ListViewItem(item.HienThiListView());
                itemhopdong.Tag = item;
                lvHopDong.Items.Add(itemhopdong);
            }
        }

        private void lvHopDong_SelectedIndexChanged(object sender, EventArgs e)// lay thong tin trong hop dong dua ra thong tin để sửa 
        {
            lvDanhSachXeThue.Items.Clear();
            if (lvHopDong.SelectedItems.Count > 0)
            {
                DTO.HopDong x = (lvHopDong.SelectedItems[0].Tag) as DTO.HopDong;
                mstxtMaHopDong.Text = x.MaHopDong;
                cbTenKhachHang.Text = x.TenKhachHang;
                mtxtSCMND.Text = x.SCMND;
                dtpNgayThue.Value = x.NgayThue;
                dtpNgayDuKienTra.Value = x.NgayTra;
                txtTienThue.Text = x.TienThue.ToString();
                txtTienCoc.Text = x.TienCoc.ToString();
                if (x.HinhThuc > 0)
                {
                    rdChuaThanhToanTT.Checked = true;
                }
                else
                {
                    rdThanhToanTT.Checked = true;
                }
                int tiencoc = int.Parse(txtTienCoc.Text);
                int tienthue = int.Parse(txtTienThue.Text);
                txtTienPhaiTra.Text = (tienthue - tiencoc).ToString();
                foreach (DTO.Oto item in x.DSXT)
                {
                    ListViewItem itemoto = new ListViewItem(item.ThongTinListViewOto());
                    itemoto.Tag = item;
                    lvDanhSachXeThue.Items.Add(itemoto);
                }
            }
            else
            {
                Reset();
            }
        }
        void Reset()
        {
            mstxtMaHopDong.Text = "";
            txtTenXe.Text = "";
            txtTienCoc.Text = "";
            txtTienPhaiTra.Text = "";
            txtTienThue.Text = "";
            cbTenKhachHang.Text = "";
            mtxtSCMND.Text = "";
            lvDanhSachXeThue.Items.Clear();
        }
        DTO.HoaDon GetThongTinHoaDon()
        {
            DTO.HoaDon x = new DTO.HoaDon();
            x.MaHopDong = mstxtMaHopDong.Text;
            x.MaHoaDon = DAO.DataProvider.Instance.ExecuteScalar(@"select dbo.ufn_SinhMaHoaDon()").ToString();
            x.NgapLapHoaDon = DateTime.Now;
            x.SCMND = mtxtSCMND.Text;
            x.SoDT = (cbTenKhachHang.SelectedItem as DTO.KhachHang).SoDT;
            x.SoLuongXe = lvDanhSachXeThue.Items.Count;
            x.SoTienPhaiTra = int.Parse(txtTienPhaiTra.Text);
            x.TenKH = cbTenKhachHang.Text;
            x.DiaChi = (cbTenKhachHang.SelectedItem as DTO.KhachHang).DiaChi;
            foreach (ListViewItem item in lvDanhSachXeThue.Items)
            {
                x.TenXe += (item.Tag as DTO.Oto).MaXe + " ; ";
            }
            x.TienCoc = int.Parse(txtTienCoc.Text);
            x.TongTien = int.Parse(txtTienThue.Text);

            return x;
        }
        private void frmHopDong_Load(object sender, EventArgs e)
        {
            LoadHopDong(DAO.HopDongDAO.Instance.GetListHopDong(1));//0 thanh toan  1 chua thanh toan
            LoadKH();
            
            SetEnable();
            rdChuaThanhToanTT.Checked = true;
            Reset();
        }
        void LoadKH()
        {
            cbTenKhachHang.DataSource = DAO.CategoryDAO.Instance.GetKhachHang();
            cbTenKhachHang.DisplayMember = "TenKH";
        }


        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mstxtMaHopDong.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn hợp đồng để thanh toán");
                return;
            }
            else
            {
                if (DAO.HopDongDAO.Instance.UpdateHopDong(mstxtMaHopDong.Text) > 0)
                {
                    foreach (ListViewItem item in lvDanhSachXeThue.Items)
                    {
                        DAO.OtoDAO.Instance.UpdateOtoTrangThai((item.Tag as DTO.Oto).MaXe);
                    }
                    if (DAO.HoaDonDAO.Instance.InsertHoaDon(GetThongTinHoaDon()) > 0)
                    {
                        LoadHopDong(DAO.HopDongDAO.Instance.GetListHopDong(1));

                        Reset();
                        MessageBox.Show("Success");
                    }
                    else
                    {
                        MessageBox.Show("False");
                        return;

                    }
                }
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvHopDong.Items)
            {
                if (item.Checked)
                {
                    DAO.HopDongDAO.Instance.RemoveHopDong((item.Tag as DTO.HopDong).MaHopDong);
                    foreach (DTO.Oto oto in (item.Tag as DTO.HopDong).DSXT)
                    {
                        DAO.OtoDAO.Instance.UpdateOtoTrangThai(oto.MaXe);
                    }
                }
            }
            LoadHopDong(DAO.HopDongDAO.Instance.GetListHopDong(1));
            Reset();

        }

        private void cbTenKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox tenkh = sender as ComboBox;
            if (tenkh.SelectedIndex != -1 && tenkh.SelectedItem != null)
            {
                mtxtSCMND.Text = (tenkh.SelectedItem as DTO.KhachHang).SCMND;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                pnThongTin.Enabled = true;
                btnSua.Text = "Hủy";
                btnThanhToan.Enabled = false;
                gbDanhSachXeThue.Enabled = true;
                btnCapNhat.Enabled = true;
            }
            else
            {
                btnThanhToan.Enabled = true;
                btnCapNhat.Enabled = false;
                pnThongTin.Enabled = false;
                btnSua.Text = "Sửa";
                gbDanhSachXeThue.Enabled = false;
                lvHopDong_SelectedIndexChanged(lvHopDong, null);
            }
            
        }
        void SetEnable()
        {
            btnThanhToan.Enabled = true;
            btnCapNhat.Enabled = false;
            pnThongTin.Enabled = false;
            btnSua.Text = "Sửa";
            gbDanhSachXeThue.Enabled = false;
        }

        private void cbTenKhachHang_Click(object sender, EventArgs e)
        {
            LoadKH();
        }
    } 
}
