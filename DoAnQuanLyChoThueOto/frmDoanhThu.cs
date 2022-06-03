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
    public partial class frmDoanhThu : Form
    {
        public frmDoanhThu()
        {
            InitializeComponent();
            this.Font = CaiDat.Fonts;
            this.ForeColor = CaiDat.Colors;
        }
        void LoadHoaDon(DateTime start,DateTime end)
        {
            txtTongTien.Text = "0 đ";
            lvHoaDon.Items.Clear();
            decimal money = 0;
            List<DTO.HoaDon> ds = DAO.HoaDonDAO.Instance.GetListHoaDon(start, end);
            foreach (DTO.HoaDon item in ds)
            {
                ListViewItem itemhoadon = new ListViewItem(item.ThongTinListView());
                lvHoaDon.Items.Add(itemhoadon);
                money += item.TongTien;
                var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
                txtTongTien.Text = String.Format(info, "{0:c}", money);

            }
        }
        private void frmDoanhThu_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            dtpFrom.Value = firstDayOfMonth;
            dtpTo.Value = lastDayOfMonth;
            LoadHoaDon(firstDayOfMonth, lastDayOfMonth);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
           LoadHoaDon(dtpFrom.Value, dtpTo.Value);
        }
    }
}
