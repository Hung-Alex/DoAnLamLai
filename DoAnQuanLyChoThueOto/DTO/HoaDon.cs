using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DoAnQuanLyChoThueOto.DTO
{
    class HoaDon
    {
        private string _maHoaDon;
        private string _maHopDong;
        private string _tenKH;
        private string _tenXe;
        private string _sCMND;
        private string _diaChi;
        private string _soDT;
        private int _tienCoc;
        private int _soTienPhaiTra;
        private int _tongTien;
        private DateTime _ngapLapHoaDon;
        private int _soLuongXe;
        private string _ghiChu;

        public HoaDon(DataRow item)
        {
            this.MaHoaDon =item["MaHoaDon"].ToString();
            this.MaHopDong = item["MaHopDong"].ToString();
            this.TenKH = item["TenKhachHang"].ToString();
            this.TenXe = item["TenXe"].ToString();
            this.SCMND = item["SCMNDHD"].ToString();
            this.DiaChi = item["DiaChiHD"].ToString();
            this.SoDT = item["SoDTHD"].ToString();
            this.TienCoc = int.Parse(item["TienCocHD"].ToString());
            this.SoTienPhaiTra = int.Parse(item["SoTienPhaiTra"].ToString());
            this.TongTien = int.Parse(item["TongTien"].ToString());
            this.NgapLapHoaDon = DateTime.Now;
            this.SoLuongXe = int.Parse(item["SoLuongXe"].ToString()); ;
            this.GhiChu = item["GhiChu"].ToString() ;
        }
        public string [] ThongTinListView()
        {
            string[] s = { this.MaHoaDon,this.MaHopDong,this.TenKH,this.TenXe,this.SCMND,this.DiaChi,this.SoDT,this.TienCoc.ToString(),SoTienPhaiTra.ToString(),this.TongTien.ToString(),this.NgapLapHoaDon.ToString(),this.SoLuongXe.ToString(),this.GhiChu};
            return s; 
        }
        public HoaDon() { }

        public string MaHoaDon { get => _maHoaDon; set => _maHoaDon = value; }
        public string MaHopDong { get => _maHopDong; set => _maHopDong = value; }
        public string TenXe { get => _tenXe; set => _tenXe = value; }
        public string SCMND { get => _sCMND; set => _sCMND = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }
        public string SoDT { get => _soDT; set => _soDT = value; }
        public int TienCoc { get => _tienCoc; set => _tienCoc = value; }
        public int SoTienPhaiTra { get => _soTienPhaiTra; set => _soTienPhaiTra = value; }
        public int TongTien { get => _tongTien; set => _tongTien = value; }
        public DateTime NgapLapHoaDon { get => _ngapLapHoaDon; set => _ngapLapHoaDon = value; }
        public int SoLuongXe { get => _soLuongXe; set => _soLuongXe = value; }
        public string GhiChu { get => _ghiChu; set => _ghiChu = value; }
        public string TenKH { get => _tenKH; set => _tenKH = value; }
    }
}
