using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnQuanLyChoThueOto.DTO
{
    class TaiKhoan
    {
        private string _tenTK;
        private string _matKhau;
        private string _tenNguoiDung;
        private int _loaiTK;
        
        public TaiKhoan() { }
        public TaiKhoan(DataRow item)
        {
            this.TenTK = item["TenDangNhap"].ToString();
            this.MatKhau= item["MatKhau"].ToString();
            this.TenNguoiDung= item["TenNguoiDung"].ToString();
            this.LoaiTK = int.Parse(item["LoaiTaiKhoan"].ToString());
        }
        public string [] HienThiThongTinTaiKhoan()
        {
            string []s= {this.TenTK,this.TenNguoiDung,this.LoaiTK==1?"admin":"NV" };
            return s;
        }

        public string TenTK { get => _tenTK; set => _tenTK = value; }
        public string MatKhau { get => _matKhau; set => _matKhau = value; }
        public string TenNguoiDung { get => _tenNguoiDung; set => _tenNguoiDung = value; }
        public int LoaiTK { get => _loaiTK; set => _loaiTK = value; }
    }
}
