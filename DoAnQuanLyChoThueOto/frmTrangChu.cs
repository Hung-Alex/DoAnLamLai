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
            loadOto();
            
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


        private void lvDanhSachXeThue_SelectedIndexChanged(object sender, EventArgs e)// click vào item trong lvdanhsachxethue thì xóa item đó
        {
            if (lvDanhSachXeThue.SelectedItems.Count > 0)
            {
                lvDanhSachXeThue.Items.RemoveAt(lvDanhSachXeThue.SelectedItems[0].Index);
            }

        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetThongTin();
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            loadOto();
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
        void loadOto()
        {
            flpOto.Controls.Clear();
            List<Oto> oto = OtoDAO.Instance.GetListOto();
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
    }
}
