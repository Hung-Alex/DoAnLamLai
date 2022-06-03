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
    public partial class frmHopDong : Form
    {
        public frmHopDong()
        {
            InitializeComponent();
            this.Font = CaiDat.Fonts;
            this.ForeColor = CaiDat.Colors;
        }

        void LoadHopDong(List<DTO.HopDong> x)//  hiển thị hợp đồng
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
                txtMaKhachHang.Text = x.MaKhachHang;
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
        DTO.HoaDon GetThongTinHoaDon()// lấy thông tin hóa đơn từ thông tin
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
            x.MaKH = txtMaKhachHang.Text;

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
        void UpdateTrangThaiXe(List<DTO.Oto> dsxe)
        {
            foreach (DTO.Oto item in dsxe)
            {
                DAO.OtoDAO.Instance.UpdateOtoTrangThai(item.MaXe);
            }
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
                DTO.HoaDon x = GetThongTinHoaDon();
                DAO.HoaDonDAO.Instance.InsertHoaDon(x);
                ThemXeCTHoaDonXe(GetMaXeListView(),x.MaHoaDon);
                DAO.HopDongDAO.Instance.UpdateHopDong(mstxtMaHopDong.Text.Trim());
                UpdateTrangThaiXe(GetDanhSachXe());
                LoadHopDong(DAO.HopDongDAO.Instance.GetListHopDong(1));
                MessageBox.Show("Success");
                Reset();

            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvHopDong.Items)
            {
                if (item.Checked)
                {
                    if((item.Tag as DTO.HopDong).HinhThuc==1)
                    {
                        DAO.HopDongDAO.Instance.RemoveHopDong((item.Tag as DTO.HopDong).MaHopDong);
                        UpdateTrangThaiXe((item.Tag as DTO.HopDong).DSXT);
                        DAO.HopDongDAO.Instance.RemoveHopDong_All((item.Tag as DTO.HopDong).MaHopDong);
                        LoadHopDong(DAO.HopDongDAO.Instance.GetListHopDong(1));
                    }
                    else
                    {
                        string mahoadon = DAO.HoaDonDAO.Instance.FindMaHoaDon((item.Tag as DTO.HopDong).MaHopDong).ToString();
                        DAO.HoaDonDAO.Instance.RemoveHoaDonChiTietXe(mahoadon);
                        DAO.HopDongDAO.Instance.RemoveHopDong((item.Tag as DTO.HopDong).MaHopDong);
                        DAO.HoaDonDAO.Instance.RemoveHoaDon((mahoadon));
                        DAO.HopDongDAO.Instance.RemoveHopDong_All((item.Tag as DTO.HopDong).MaHopDong);
                        LoadHopDong(DAO.HopDongDAO.Instance.GetListHopDong(1));
                    }
                   

                }
            }

        }

        private void cbTenKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox tenkh = sender as ComboBox;
            if (tenkh.SelectedIndex != -1 && tenkh.SelectedItem != null)
            {
                mtxtSCMND.Text = (tenkh.SelectedItem as DTO.KhachHang).SCMND;
                txtMaKhachHang.Text= (tenkh.SelectedItem as DTO.KhachHang).MaKH;
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
        void ThemXeCTHoaDonXe(List<string> dsXe,string mahoadon)
        {
            foreach (string item in dsXe)
            {
                DAO.HoaDonDAO.Instance.InsertChiTietHoaDon(mahoadon, item,dsXe.Count);
            }
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
        List<string> GetMaXeListView()// cái này lấy item bên listview hopdong để hiển thị qua bên danh sách xe thuê
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
            if (string.IsNullOrWhiteSpace(mstxtMaHopDong.Text))
            {
                MessageBox.Show("Vui Lòng chọn hơp đồng để chỉnh sửa");
               
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtTienCoc.Text)||string.IsNullOrWhiteSpace(txtTienThue.Text))
                {
                    MessageBox.Show("Vui Lòng điền dầy đủ thông tin ");
                    return;

                }
                if (rdChuaThanhToanTT.Checked)
                {
                    object s = DAO.HoaDonDAO.Instance.FindMaHoaDon(mstxtMaHopDong.Text);
                    if (s==DBNull.Value)
                    {

                        DAO.HopDongDAO.Instance.UpdateHopDong(mstxtMaHopDong.Text.Trim(), txtMaKhachHang.Text, int.Parse(txtTienCoc.Text), int.Parse(txtTienThue.Text));
                        DAO.HopDongDAO.Instance.RemoveHopDong(mstxtMaHopDong.Text);
                        UpdateTrangThaiXe(GetDanhSachXe());
                        ThemChiTietThueXe();
                        MessageBox.Show("Success ");
                        Reset();
                        LoadHopDong(DAO.HopDongDAO.Instance.GetListHopDong(1));
                        SetEnable();

                    }
                    else
                    {
                        
                        DAO.HopDongDAO.Instance.UpdateHopDong(mstxtMaHopDong.Text.Trim(), txtMaKhachHang.Text, int.Parse(txtTienCoc.Text), int.Parse(txtTienThue.Text));
                        DAO.HopDongDAO.Instance.RemoveHopDong(mstxtMaHopDong.Text);
                        UpdateTrangThaiXe(GetDanhSachXe());
                        ThemChiTietThueXe();
                        MessageBox.Show("Success ");
                        Reset();
                        LoadHopDong(DAO.HopDongDAO.Instance.GetListHopDong(1));
                        SetEnable();
                    }
                    



                }
                if (rdThanhToanTT.Checked)
                {
                    DAO.HopDongDAO.Instance.UpdateHopDong(mstxtMaHopDong.Text.Trim(), txtMaKhachHang.Text, int.Parse(txtTienCoc.Text), int.Parse(txtTienThue.Text));
                    DAO.HopDongDAO.Instance.RemoveHopDong(mstxtMaHopDong.Text);
                    UpdateTrangThaiXe(GetDanhSachXe());
                    ThemChiTietThueXe();
                    if (string.IsNullOrEmpty(mstxtMaHopDong.Text.Trim()))
                    {
                        MessageBox.Show("Vui lòng chọn hợp đồng để thanh toán");
                        return;
                    }
                    else
                    {
                        DTO.HoaDon x = GetThongTinHoaDon();
                        DAO.HoaDonDAO.Instance.InsertHoaDon(x);
                        ThemXeCTHoaDonXe(GetMaXeListView(), x.MaHoaDon);
                        DAO.HopDongDAO.Instance.UpdateHopDong(mstxtMaHopDong.Text.Trim());
                        UpdateTrangThaiXe(GetDanhSachXe());
                        LoadHopDong(DAO.HopDongDAO.Instance.GetListHopDong(1));
                        btnSua.Text = "Sửa";
                        btnSua.Enabled = true;
                        btnCapNhat.Enabled = false;
                        MessageBox.Show("Success ");
                        Reset();
                        LoadHopDong(DAO.HopDongDAO.Instance.GetListHopDong(1));
                        SetEnable();
                    }
                   
                }
                

            }
        }
        List<DTO.Oto> GetDanhSachXe()// lấy danh sách xe đang select 
        {
            List<DTO.Oto> x = null;
            if (lvHopDong.SelectedItems.Count>0)
            {
                x = (lvHopDong.SelectedItems[0].Tag as DTO.HopDong).DSXT;
            }
            return x;
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
        void ThemChiTietThueXe()
        {
            if (lvDanhSachXeThue.Items.Count<=0)
            {
                MessageBox.Show("Vui lòng chọn xe");
                return;
            }
            else
            {
                foreach (ListViewItem item in lvDanhSachXeThue.Items)
                {
                    DAO.HopDongDAO.Instance.InsertChiTietHopDong(mstxtMaHopDong.Text, (item.Tag as DTO.Oto).MaXe, dtpNgayThue.Value, dtpNgayDuKienTra.Value);
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

        private void btnXemThongTin_Click(object sender, EventArgs e)
        {
            if (cbTenKhachHang.SelectedIndex != -1 || cbTenKhachHang.SelectedItem != null||string.IsNullOrWhiteSpace(cbTenKhachHang.Text))
            {
                frmThemKhachHang f = new frmThemKhachHang();
                f.Text = "Thông Tin Khách Hàng";
                f.HienThiThongTinKH(cbTenKhachHang.SelectedItem as DTO.KhachHang);
                f.Controls.Remove(f.btnReset);
                f.Controls.Remove(f.btnThem);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("vui lòng chọn khách hàng để xem");
            }
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            frmThemKhachHang f = new frmThemKhachHang();
            f.ShowDialog();
        }
    }
}
