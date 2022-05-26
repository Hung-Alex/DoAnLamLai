using DoAnQuanLyChoThueOto.DTO;
using DoAnQuanLyChoThueOto.DAO;
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
    public partial class frmTrangChu : Form
    {
       
        public frmTrangChu()
        {
            InitializeComponent();
           


        }




        #region Events

        private void cbTenKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTenKhachHang.SelectedIndex!=-1||cbTenKhachHang.SelectedItem!=null)
            {
                mtxtSCMND.Text = (cbTenKhachHang.SelectedItem as DTO.KhachHang).SCMND;
            }
           
        }


        private void cbTenKhachHang_Click(object sender, EventArgs e)
        {
            cbTenKhachHang.DataSource = DAO.CategoryDAO.Instance.GetKhachHang();
            cbTenKhachHang.DisplayMember = "TenKH";
        }
        private void btnThemKH_Click(object sender, EventArgs e)
        {
            frmThemKhachHang f = new frmThemKhachHang();
            f.ShowDialog();

        }
        private void ItemOto_Click(object sender, EventArgs e)// click thì thêm vào danh sách xe thue và check xem oto này có trong danh sach chưa 
        {
            Button btnoto = sender as Button;
            Oto oto = btnoto.Tag as Oto;
            foreach (ListViewItem item in lvDanhSachXeThue.Items)
            {
                if (oto.MaXe==((Oto)item.Tag).MaXe)
                {
                    MessageBox.Show("Xe Này Này Đã có Trong Danh Sách Xe Thuê Của Bạn");
                    return;
                }
            }
           
            ListViewItem itemXeThue = new ListViewItem(oto.ThongTinListViewOto());
            itemXeThue.Tag = oto;
           
            
            lvDanhSachXeThue.Items.Add(itemXeThue);
        }


       
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetThongTin();
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            loadOto(DAO.OtoDAO.Instance.GetListOto());
        }

        #endregion

        #region Methods
        void ResetThongTin()
        {
            txtTenXe.Text = "";
            txtTienCoc.Text = "";
            txtTienThue.Text = "";
            mtxtSCMND.Text = "";
            cbTenKhachHang.Text = "";
            lvDanhSachXeThue.Items.Clear();
        }
        void loadOto(List<Oto> oto)
        {
            flpOto.Controls.Clear();
           
            foreach (Oto item in oto)
            {
                Button itemOto = new Button();
                itemOto.Text = item.ToString();
                itemOto.Tag = item;
                itemOto.Width = OtoDAO.OtoWidth;
                itemOto.Height = OtoDAO.OtoHeight;
                if (item.TrangThai == 1)
                {
                    itemOto.BackColor = Color.Red;
                    itemOto.Enabled = false;
                }
                else
                {
                    itemOto.BackColor = Color.Aqua;
                    itemOto.Enabled = true;

                }
                itemOto.Click += ItemOto_Click;
                flpOto.Controls.Add(itemOto);
                ;
            }

        }


        List<string> GetMaXeListView()
        {
            List<string> lsmaxe = new List<string>();
            foreach (ListViewItem item in lvDanhSachXeThue.Items)
            {
                lsmaxe.Add((item.Tag as Oto).MaXe);
            }
            return lsmaxe;
        }


        #endregion

        private void btnXemThongTin_Click(object sender, EventArgs e)
        {
            if (cbTenKhachHang.SelectedIndex!=-1|cbTenKhachHang.SelectedItem!=null)
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

        private void btnTaoHD_Click(object sender, EventArgs e)
        {
            if (lvDanhSachXeThue.Items.Count<=0)
            {
                MessageBox.Show("Vui Lòng Chọn xe muốn thuê");
            }
            else
            {
                DateTime ngaythue = dtpNgayThue.Value;
                DateTime ngaytra = dtpNgayDuKienTra.Value;

                string makh = (cbTenKhachHang.SelectedItem as KhachHang).MaKH;
                 string mahopdong = DAO.DataProvider.Instance.ExecuteScalar(@"select dbo.ufn_SinhMaHopDong()").ToString();
                if (HopDongDAO.Instance.InsertHopDong(mahopdong,makh,int.Parse(txtTienCoc.Text),int.Parse(txtTienThue.Text))>0)
                {
                    List<string> lsxe = GetMaXeListView();
                    foreach (string item in lsxe)
                    {
                        HopDongDAO.Instance.InsertChiTietHopDong(mahopdong, item, ngaythue, ngaytra);
                    }
                    MessageBox.Show("Success");
                    loadOto(DAO.OtoDAO.Instance.GetListOto());
                    lvDanhSachXeThue.Items.Clear();
                }
                else
                {
                    MessageBox.Show("False");

                }

            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvDanhSachXeThue.Items)
            {
                if (item.Checked)
                {
                    lvDanhSachXeThue.Items.RemoveAt(item.Index);
                }
            }
        }

        private void cbSoChoNgoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox chongoi = sender as ComboBox;
            loadOto(OtoDAO.Instance.GetListOtoSoChoNgoi(chongoi.SelectedItem.ToString()));
            lbSLChoNgoi.Text = flpOto.Controls.Count.ToString();
        }
        void LoadSoChoNgoi()
        {
            List<string> sochongoi = CategoryDAO.Instance.GetChoNgoi();
            cbSoChoNgoi.DataSource = sochongoi;
          
        }
        void LoadHangXe()
        {
            List<string> hangxe = CategoryDAO.Instance.GetHangXe();
            cbHangXe.DataSource = hangxe;

        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            loadOto(DAO.OtoDAO.Instance.GetListOto());
            LoadHangXe();
            LoadSoChoNgoi();
        }

        private void cbHangXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox hangxe = sender as ComboBox;
            loadOto(OtoDAO.Instance.GetListOtoHangXe(hangxe.SelectedItem.ToString()));
            lbSLHangXe.Text = flpOto.Controls.Count.ToString();
        }

        private void txtTenXe_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtTenXe.Text.Trim()))
            {
                loadOto(DAO.OtoDAO.Instance.GetListOto()) ;
            }
            else
            {
                loadOto(OtoDAO.Instance.GetListOtoTenXe(txtTenXe.Text.Trim()));
            }
        }

        private void hơpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHopDong f = new frmHopDong();
            
            f.ShowDialog(); 
        }
    }
}
