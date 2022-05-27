using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
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
        public int RemoveHoaDon(string mahopdong)
        {
            return DAO.DataProvider.Instance.ExecuteNonQuery($"delete HOADON where MaHopDong='{mahopdong}' ");
        }
        public List<DTO.HoaDon> GetListHoaDon(DateTime start ,DateTime end)
        {
            DataTable data = DAO.DataProvider.Instance.ExecuteQuery($"select * from HOADON where NgayLapHoaDon>='{start}' and NgayLapHoaDon<='{end}'");
            List<DTO.HoaDon> lshoadon = new List<DTO.HoaDon>();
            foreach (DataRow item in data.Rows)
            {
                DTO.HoaDon x = new DTO.HoaDon(item);
                lshoadon.Add(x);
            }
            return lshoadon;
        }
    }
}
