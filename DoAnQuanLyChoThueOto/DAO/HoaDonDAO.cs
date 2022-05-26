using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnQuanLyChoThueOto.DAO
{
    class HoaDonDAO
    {
        private static HoaDonDAO _instance;

        public static HoaDonDAO Instance 
        {
            get
            {
                if (_instance==null)
                {
                    _instance = new HoaDonDAO();
                }
                return _instance; }
            private set => _instance = value;
        }
        public HoaDonDAO() { }
        public int  InsertHoaDon(DTO.HoaDon x)
        {
            return DAO.DataProvider.Instance.ExecuteNonQuery($"exec dbo.usp_InsertHoaDon  '{x.MaHoaDon}','{x.MaHopDong}' ,N'{x.TenKH}' ,N'{x.TenXe}' ,'{x.SCMND}' ,N'{x.DiaChi}' ,'{x.SoDT}' ,'{x.TienCoc}' ,'{x.SoTienPhaiTra}' ,'{x.TongTien}' ,'{x.NgapLapHoaDon}' ,'{x.SoLuongXe}' ");
        }
    }
}
