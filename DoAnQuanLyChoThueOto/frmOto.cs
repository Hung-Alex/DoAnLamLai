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
    public partial class frmOto : Form
    {
        public frmOto()
        {
            InitializeComponent();
            this.Font = CaiDat.Fonts;
            this.ForeColor = CaiDat.Colors;
        }
       void LoadOto(List<DTO.Oto> x)
        {
            lvOto.Items.Clear();
            foreach (DTO.Oto item in x)
            {
                ListViewItem itemoto = new ListViewItem(item.ThongTinListViewOto());
                itemoto.Tag = item;
                lvOto.Items.Add(itemoto);
            }
        }

        private void frmOto_Load(object sender, EventArgs e)
        {
            LoadOto(DAO.OtoDAO.Instance.GetListOto());
          
        }

        private void txt_findoto_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_findoto.Text.Trim()))
            {
                LoadOto(DAO.OtoDAO.Instance.GetListOto());
            }
            else
            {
                LoadOto(DAO.OtoDAO.Instance.GetListOtoTenXe(txt_findoto.Text.Trim()));
            }
        }
        void HienThiThongTin(DTO.Oto x)
        {
            txt_maxe.Text = x.MaXe;
            txt_tenxe.Text = x.TenXe;
            txt_sochongoi.Text = x.SoChoNgoi.ToString();
            txt_biensoxe.Text = x.BienSoXe;
            txt_hangxe.Text = x.HangXe;
        }
        void Reset()
        {
            txt_maxe.Text = "";
            txt_tenxe.Text = "";
            txt_sochongoi.Text = "";
            txt_biensoxe.Text = "";
            txt_hangxe.Text = "";
        }

        private void listView_oto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvOto.SelectedItems.Count>0)
            {
                HienThiThongTin((lvOto.SelectedItems[0].Tag) as DTO.Oto);
            }
            else
            {
                Reset();
            }
        }

        private void btn_updateoto_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_maxe.Text.Trim()))
            {
                DTO.Oto x = new DTO.Oto();
                x.MaXe = txt_maxe.Text.Trim();
                x.TenXe = txt_tenxe.Text.Trim();
                x.BienSoXe = txt_biensoxe.Text.Trim();
                x.HangXe = txt_hangxe.Text.Trim();
                x.SoChoNgoi = int.Parse(txt_sochongoi.Text.Trim());
                DAO.OtoDAO.Instance.UpdateOto(x);
                LoadOto(DAO.OtoDAO.Instance.GetListOto());
               
               
                MessageBox.Show("Success");
            }
        }
        DTO.Oto GetThongTinOto()
        {
            DTO.Oto x = new DTO.Oto();
            x.MaXe = txt_maxe.Text.Trim();
            x.TenXe = txt_tenxe.Text.Trim();
            x.BienSoXe = txt_biensoxe.Text.Trim();
            x.HangXe = txt_hangxe.Text.Trim();
            x.SoChoNgoi = int.Parse(txt_sochongoi.Text.Trim());
            
            return x;
        }
       
        private void btn_addoto_Click(object sender, EventArgs e)
        {
            if (DAO.OtoDAO.Instance.InsertOto(GetThongTinOto())>0)
            {
                MessageBox.Show("Succes");
                LoadOto(DAO.OtoDAO.Instance.GetListOto());
            }
            else
            {
                MessageBox.Show("False");

            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvOto.Items)
            {
                if (item.Checked)
                {

                }
            }
        }
    }
}
