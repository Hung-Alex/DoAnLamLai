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
            return DAO.DataProvider.Instance.ExecuteNonQuery($"exec dbo.usp_InsertHoaDon '{x.MaHoaDon}','{x.MaHopDong}' ,'{x.MaKH}' ,'{x.TienCoc}' ,'{x.SoTienPhaiTra}' ,'{x.TongTien}' ,'{x.NgapLapHoaDon}' ,N'{x.GhiChu}' ");
        }
        public int RemoveHoaDon(string mahoadon)
        {
            return DAO.DataProvider.Instance.ExecuteNonQuery($"delete HOADON where MaHoaDon='{mahoadon}' ");
        }
        public int InsertChiTietHoaDon(string mahoadon,string maxe,int soluongxe) // số lượng xe thuê của hợp đồng
        {
            return DAO.DataProvider.Instance.ExecuteNonQuery($"exec dbo.usp_InsertChiTietHoaDonXe '{mahoadon}' ,'{maxe}' , {soluongxe}");
        }
        public int RemoveHoaDonChiTietXe(string mahoadon)
        {
            return DAO.DataProvider.Instance.ExecuteNonQuery($"delete CHITIETHOADONXE where MaHoaDon='{mahoadon}' ");
        }
        public object FindMaHoaDon(string mahopdong)
        {
            if (DAO.DataProvider.Instance.ExecuteQuery($"select MaHoaDon from HOADON where MaHopDong='{mahopdong}'").Rows.Count>0)
            {
                return DAO.DataProvider.Instance.ExecuteScalar($"select MaHoaDon from HOADON where MaHopDong='{mahopdong}'").ToString();
            }
            return null;
        }
        public List<DTO.HoaDon> GetListHoaDon(DateTime start, DateTime end)
        {
            DataTable data = DAO.DataProvider.Instance.ExecuteQuery($"exec dbo.usp_GetHoaDon  @ngaybatdau  , @ngayketthuc ",new object[] {start,end });
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
