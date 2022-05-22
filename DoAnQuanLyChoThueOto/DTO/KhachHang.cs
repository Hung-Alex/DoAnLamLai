using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnQuanLyChoThueOto.DTO
{
    public class KhachHang
    {
        private string _maKH;
        private string _tenKH;
        private string _sCMND;
        private string _soDT;
        private string _diaChi;
        private int _gioiTinh;
        public KhachHang() { }
        public KhachHang(string makh,string tenkh,string scmnd,string sodt,string diachi,int gioitinh)
        {
            this.MaKH = makh;
            this.TenKH = tenkh;
            this.SCMND = scmnd;
            this.SoDT = sodt;
            this.DiaChi = diachi;
            this.GioiTinh = gioitinh;
        }
        public KhachHang(DataRow item)
        {
            this.MaKH = item["MaKH"].ToString();
            this.TenKH = item["TenKH"].ToString();
            this.SCMND = item["SCMND"].ToString();
            this.SoDT = item["SoDT"].ToString();
            this.DiaChi = item["DiaChi"].ToString();
            this.GioiTinh = int.Parse(item["GioiTinh"].ToString());
        }
        public string [] ThongTinListviewKhachHang()
        {
            string[] s = {this.MaKH,this.TenKH,this.SCMND,this.SoDT,this.DiaChi,this.GioiTinh==1?"Nam":"Nữ" };
            return s;
        }
        public string MaKH { get => _maKH; set => _maKH = value; }
        public string TenKH { get => _tenKH; set => _tenKH = value; }
        public string SCMND { get => _sCMND; set => _sCMND = value; }
        public string SoDT { get => _soDT; set => _soDT = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }
        public int GioiTinh { get => _gioiTinh; set => _gioiTinh = value; }
    }
}
