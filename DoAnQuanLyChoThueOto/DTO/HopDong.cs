using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnQuanLyChoThueOto.DTO
{
    class HopDong
    {
        private string _maHopDong;
        private string _maKhachHang;
        private string _tenKhachHang;
        private string _sCMND;
        private DateTime _ngayThue;
        private DateTime _ngayTra;
        private int _tienCoc;
        private int _tienThue;
        private int _hinhThuc;
        public List<Oto> DSXT;   
        public HopDong() { }

        public HopDong(DataRow item)
        {
            this.MaHopDong = item["MaHopDong"].ToString();
            this.MaKhachHang = item["MaKH"].ToString();
            this.TenKhachHang = item["TenKH"].ToString();
            this.SCMND = item["SCMND"].ToString();
            this.NgayThue = DateTime.Parse( item["NgayThue"].ToString());
            this.NgayTra = DateTime.Parse(item["NgayDuKienTra"].ToString());
            this.TienCoc = int.Parse(item["TienCoc"].ToString());
            this.TienThue = int.Parse(item["TienThue"].ToString());
            this.HinhThuc = int.Parse(item["HinhThuc"].ToString());
            this.DSXT = DAO.OtoDAO.Instance.GetListOtoMaHopDong(this.MaHopDong);

        }
        public string[] HienThiListView()
        {
            string[] s = { this.MaHopDong, this.MaKhachHang, this.TenKhachHang, this.SCMND, this.GetMaXeList(),this.GetTenXeList(), this.NgayThue.ToString(), this.NgayTra.ToString(), this.TienCoc.ToString(), this.TienThue.ToString(), this.HinhThuc.ToString() == "1" ? "Chưa Thanh Toán" : "Thanh Toán" };
            return s;
        }
        private string GetTenXeList()
        {
            string s = "";
            foreach (Oto item in this.DSXT)
            {
               s += item.TenXe + " ; ";
            }
            return s;
        }
        private string GetMaXeList()
        {
            string s = "";
            foreach (Oto item in this.DSXT)
            {
                s += item.MaXe + " ; ";
            }
            return s;
        }
        public string MaHopDong { get => _maHopDong; set => _maHopDong = value; }
        public string MaKhachHang { get => _maKhachHang; set => _maKhachHang = value; }
        public string TenKhachHang { get => _tenKhachHang; set => _tenKhachHang = value; }
        public string SCMND { get => _sCMND; set => _sCMND = value; }
        public DateTime NgayThue { get => _ngayThue; set => _ngayThue = value; }
        public DateTime NgayTra { get => _ngayTra; set => _ngayTra = value; }
        public int TienCoc { get => _tienCoc; set => _tienCoc = value; }
        public int TienThue { get => _tienThue; set => _tienThue = value; }
        public int HinhThuc { get => _hinhThuc; set => _hinhThuc = value; }
    }
}
