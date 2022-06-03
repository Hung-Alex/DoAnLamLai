using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnQuanLyChoThueOto.DTO
{
    class Oto
    {

        private string _maXe;
        private string _tenXe;
        private string _hangXe;
        private string _bienSoXe;
        private int _soChoNgoi;
        private int _trangThai;
       

        

        public Oto() { }
        public Oto(string maxe,string tenxe ,string hangxe,string biensoxe,int sochongoi,int trangthai)
        {
            this.MaXe = maxe;
            this.TenXe = tenxe;
            this.HangXe = hangxe;
            this.BienSoXe = biensoxe;
            this.SoChoNgoi = sochongoi;
            this.TrangThai = trangthai;
        }
        public Oto(DataRow item)// Xử lý dữ liệu từ đổ lên từ database
        {
            this.MaXe = item["MaXe"].ToString();
            this.TenXe = item["TenXe"].ToString();
            this.HangXe = item["HangXe"].ToString();
            this.BienSoXe = item["BienSoXe"].ToString();
            this.SoChoNgoi = int.Parse(item["SoChoNgoi"].ToString());
            this.TrangThai = int.Parse(item["TrangThai"].ToString());
        }
       public string[] ThongTinListViewOto()// cái này đưa vào constructor của listviewitem 
        {
            string[] s = { this.MaXe,this.TenXe,this.HangXe,this.BienSoXe,this.SoChoNgoi.ToString(),this.TrangThai.ToString()=="1"?"Thuê":"Trống" };
            return s;
       }
        
        public override string ToString()// lấy chuỗi để cho là button text bên frmtrangchu 
        {
            string s = this.TrangThai == 1 ? "Thuê" : "Trống";
            return $"{this.TenXe}"+ Environment.NewLine+$"{this.HangXe}"+ Environment.NewLine+$"{this.SoChoNgoi}"+ Environment.NewLine+$"{s}";
        }

        public string MaXe { get => _maXe; set => _maXe = value; }
        public string TenXe { get => _tenXe; set => _tenXe = value; }
        public string HangXe { get => _hangXe; set => _hangXe = value; }
        public string BienSoXe { get => _bienSoXe; set => _bienSoXe = value; }
        public int SoChoNgoi { get => _soChoNgoi; set => _soChoNgoi = value; }
        public int TrangThai { get => _trangThai; set => _trangThai = value; }
    }
}
