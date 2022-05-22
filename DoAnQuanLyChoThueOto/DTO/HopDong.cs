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
        private int _tienCoc;
        private int _tienThue;
        public HopDong() { }

        public HopDong(string mahopdong,string makhachhang,int tiencoc,int tienthue)
        {
            this.MaHopDong = mahopdong;
            this.MaKhachHang = makhachhang;
            this.TienCoc = tiencoc;
            this.TienThue = tienthue;
        }
        public HopDong( DataRow item)
        {
            this.MaHopDong = item["MaHopDong"].ToString();
            this.MaKhachHang = item["MaKH"].ToString();
            this.TienCoc = int.Parse(item["TienCoc"].ToString());
            this.TienThue = int.Parse(item["TienThue"].ToString());
        }

        public string MaHopDong { get => _maHopDong; set => _maHopDong = value; }
        public string MaKhachHang { get => _maKhachHang; set => _maKhachHang = value; }
        public int TienCoc { get => _tienCoc; set => _tienCoc = value; }
        public int TienThue { get => _tienThue; set => _tienThue = value; }
    }
}
