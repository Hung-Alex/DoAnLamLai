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
                    lvDanhSachXeThue.Tag = x.DSXT;
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
            txtTenKH.Text = "";
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
            LoadHangXe();
            SetEnable();
            rdChuaThanhToanTT.Checked = true;
            Reset();
        }
        void LoadKH()
        {
            cbTenKhachHang.DataSource = DAO.CategoryDAO.Instance.GetKhachHang();
            cbTenKhachHang.DisplayMember = "TenKH";
        }
        void LoadHangXe()
        {
            List<string> hangxe = DAO.CategoryDAO.Instance.GetHangXe();
            cbHangXe.DataSource = hangxe;

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
                    DAO.HoaDonDAO.Instance.RemoveHoaDon((item.Tag as DTO.HopDong).MaHopDong);
                    DAO.HopDongDAO.Instance.RemoveHopDong_All((item.Tag as DTO.HopDong).MaHopDong);
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

        private void btnThemXe_Click(object sender, EventArgs e)
        {
            frmChonXe f = new frmChonXe();
            f.ShowDialog();
            if (!f.btnThem.Enabled)
            {
                foreach (DTO.Oto item in f.GetOto())
                {
                    if (!this.CheckXe(item.MaXe,lvDanhSachXeThue))
                    {
                        ListViewItem itemoto = new ListViewItem(item.ThongTinListViewOto());
                        itemoto.Tag = item;
                        lvDanhSachXeThue.Items.Add(itemoto);
                    }
                }

            }
        }
        bool CheckXe(string maxe,ListView x)
        {
            foreach (ListViewItem item in x.Items)
            {
                if(string.Compare(maxe,(item.Tag as DTO.Oto).MaXe)==0)
                {
                    return true;
                }
            }
            return false;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvDanhSachXeThue.Items)
            {
                if (item.Checked)
                {
                    lvDanhSachXeThue.Items.RemoveAt(item.Index);
                }
            }
        }
        List<string> GetMaXeListView()
        {
            List<string> lsmaxe = new List<string>();
            foreach (ListViewItem item in lvDanhSachXeThue.Items)
            {
                lsmaxe.Add((item.Tag as DTO.Oto).MaXe);
            }
            return lsmaxe;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mstxtMaHopDong.Text))
            {
                MessageBox.Show("Vui Lòng Chọn Hợp Đồng");
                return;
            }
            if (string.IsNullOrEmpty(txtTienCoc.Text)||string.IsNullOrEmpty(txtTienThue.Text))
            {
                MessageBox.Show("Vui Lòng Không Để Trống thông tin");
                return;
            }
            if (rdChuaThanhToanTT.Checked)
            {

                if (lvDanhSachXeThue.Items.Count<=0)
                {
                    MessageBox.Show("Vui long Chọn Xe");
                    return;
                }
                if (DAO.HopDongDAO.Instance.UpdateHopDong(mstxtMaHopDong.Text, (cbTenKhachHang.SelectedItem as DTO.KhachHang).MaKH, int.Parse(txtTienCoc.Text.Trim()), int.Parse(txtTienThue.Text.Trim())) > 0)
                {
                    
                        
                        foreach (DTO.Oto item in (lvDanhSachXeThue.Tag as List<DTO.Oto>))
                        {
                            DAO.OtoDAO.Instance.UpdateOtoTrangThai(item.MaXe);
                        }
                    
                    DAO.HopDongDAO.Instance.RemoveHopDong(mstxtMaHopDong.Text);
                    DAO.HoaDonDAO.Instance.RemoveHoaDon(mstxtMaHopDong.Text);

                    DateTime ngaythue = dtpNgayThue.Value;
                    DateTime ngaytra = dtpNgayDuKienTra.Value;
                    List<string> lsxe = GetMaXeListView();
                    foreach (string item in lsxe)
                    {
                        DAO.HopDongDAO.Instance.InsertChiTietHopDong(mstxtMaHopDong.Text, item, ngaythue, ngaytra);
                       
                    }
                    LoadHopDong(DAO.HopDongDAO.Instance.GetListHopDong(1));
                    MessageBox.Show("Success");
                    SetEnable();


                }
            }
            if (rdThanhToanTT.Checked)
            {
                if (lvDanhSachXeThue.Items.Count <= 0)
                {
                    MessageBox.Show("Vui long Chọn Xe");
                    return;
                }
                if (DAO.HopDongDAO.Instance.UpdateHopDong(mstxtMaHopDong.Text, (cbTenKhachHang.SelectedItem as DTO.KhachHang).MaKH, int.Parse(txtTienCoc.Text.Trim()), int.Parse(txtTienThue.Text.Trim())) > 0)
                {
                  
                    DAO.HopDongDAO.Instance.RemoveHopDong(mstxtMaHopDong.Text);
                    DAO.HoaDonDAO.Instance.RemoveHoaDon(mstxtMaHopDong.Text);
                    DateTime ngaythue = dtpNgayThue.Value;
                    DateTime ngaytra = dtpNgayDuKienTra.Value;
                    List<string> lsxe = GetMaXeListView();
                    foreach (string item in lsxe)
                    {
                        DAO.HopDongDAO.Instance.InsertChiTietHopDong(mstxtMaHopDong.Text, item, ngaythue, ngaytra);
                    }
                    DAO.DataProvider.Instance.ExecuteNonQuery($"update CHITIETTHUEXE set HinhThuc=0 where MaHopDong='{mstxtMaHopDong.Text}'");

                    foreach (string item in lsxe)
                    {
                        DAO.OtoDAO.Instance.UpdateOtoTrangThai(item);
                    }
                    if (DAO.HoaDonDAO.Instance.InsertHoaDon(GetThongTinHoaDon()) > 0)
                    {
                        LoadHopDong(DAO.HopDongDAO.Instance.GetListHopDong(1));

                        Reset();
                        MessageBox.Show("Success");
                        SetEnable();
                    }
                    else
                    {
                        MessageBox.Show("False");
                        return;

                    }


                }
            }
        }

        private void cbHangXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbHangXe.SelectedIndex!=-1 &&cbHangXe.SelectedItem!=null)
            {
                if (rdThanhToan.Checked)
                {
                    LoadHopDong(DAO.HopDongDAO.Instance.GetListHopDong(0, cbHangXe.SelectedItem as string));
                }
                if (rdChuaThanhToan.Checked)
                {
                    LoadHopDong(DAO.HopDongDAO.Instance.GetListHopDong(1, cbHangXe.SelectedItem as string));
                }
            }
        }

        private void txtTenXe_TextChanged(object sender, EventArgs e)
        {
            if (rdThanhToan.Checked)
            {
                LoadHopDong(DAO.HopDongDAO.Instance.GetListHopDong(txtTenKH.Text.Trim(),0));
            }
            if (rdChuaThanhToan.Checked)
            {
                LoadHopDong(DAO.HopDongDAO.Instance.GetListHopDong(txtTenKH.Text.Trim(),1));
            }
        }
    }
}
