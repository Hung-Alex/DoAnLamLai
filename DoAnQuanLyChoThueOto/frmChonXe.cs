using DoAnQuanLyChoThueOto.DAO;
using DoAnQuanLyChoThueOto.DTO;
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
    public partial class frmChonXe : Form
    {
      
        public frmChonXe()
        {
            InitializeComponent();
        }
        void loadXe(List<DTO.Oto> oto)
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
                itemOto.Click += ItemOto_Click; ;
                flpOto.Controls.Add(itemOto);

            }

        }

        private void ItemOto_Click(object sender, EventArgs e)
        {
            Button btnoto = sender as Button;
            Oto oto = btnoto.Tag as Oto;
            foreach (ListViewItem item in lvDanhSachXeThue.Items)
            {
                if (oto.MaXe == ((Oto)item.Tag).MaXe)
                {
                    MessageBox.Show("Xe Này Này Đã có Trong Danh Sách Xe Thuê Của Bạn");
                    return;
                }
            }

            ListViewItem itemXeThue = new ListViewItem(oto.ThongTinListViewOto());
            itemXeThue.Tag = oto;


            lvDanhSachXeThue.Items.Add(itemXeThue);
        }

        private void frmChonXe_Load(object sender, EventArgs e)
        {
            
            LoadHangXe();
            LoadSoChoNgoi();
            loadXe(OtoDAO.Instance.GetListOto());
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
        private void cbHangXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox hangxe = sender as ComboBox;
            loadXe(OtoDAO.Instance.GetListOtoHangXe(hangxe.SelectedItem.ToString()));
            lbSLHangXe.Text = flpOto.Controls.Count.ToString();
        }

        private void txtTenXe_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenXe.Text.Trim()))
            {
                loadXe(DAO.OtoDAO.Instance.GetListOto());
            }
            else
            {
                loadXe(OtoDAO.Instance.GetListOtoTenXe(txtTenXe.Text.Trim()));
            }
        }
        private void cbSoChoNgoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox chongoi = sender as ComboBox;
            loadXe(OtoDAO.Instance.GetListOtoSoChoNgoi(chongoi.SelectedItem.ToString()));
            lbSLChoNgoi.Text = flpOto.Controls.Count.ToString();
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
        internal  List<Oto> GetOto()
        {
            List<Oto> lsoto = new List<Oto>();
            foreach (ListViewItem item in lvDanhSachXeThue.Items )
            {
                lsoto.Add((item.Tag as Oto));
            }
            return lsoto;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.Hide();
            btnThem.Enabled = false;
        }
    }
}
