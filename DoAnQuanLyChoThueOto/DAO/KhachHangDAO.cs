using DoAnQuanLyChoThueOto.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnQuanLyChoThueOto.DAO
{
    class KhachHangDAO
    {
        private static KhachHangDAO instance;

        internal static KhachHangDAO Instance 
        { 
            get
            {
                if (instance == null)
                {
                    instance = new KhachHangDAO();
                }
                return instance;
            }
           private set => instance = value; 
        }
        private KhachHangDAO() { }
        public int InsertKhachHang(DTO.KhachHang kh)
        {
            return DAO.DataProvider.Instance.ExecuteNonQuery($"exec dbo.usp_InsertKhachhang '{kh.MaKH}' ,N'{kh.TenKH}' ,'{kh.SCMND}' ,'{kh.SoDT}' ,N'{kh.DiaChi}' ,'{kh.GioiTinh}'");
        }
        public int InsertKhachHang(object[] ds)
        {
            return DAO.DataProvider.Instance.ExecuteNonQuery(@"exec dbo.usp_InsertKhachhang @makh , @tenkh , @scmnd , @sodt , @diachi , @gioitinh",ds);
        }
        public List<KhachHang> GetListKhachHang()
        {
            DataTable data = DAO.DataProvider.Instance.ExecuteQuery(@"select * from KHACHHANG");
            List<KhachHang> dskh = new List<KhachHang>();
            foreach (DataRow item in data.Rows)
            {
                KhachHang x = new KhachHang(item);
                dskh.Add(x);
            }
            return dskh;
        }
        public List<KhachHang> FindKH(string tenkh)
        {
            DataTable data = DAO.DataProvider.Instance.ExecuteQuery($"select * from KHACHHANG where TenKH like N'%{tenkh}%'");
            List<KhachHang> dskh = new List<KhachHang>();
            foreach (DataRow item in data.Rows)
            {
                KhachHang x = new KhachHang(item);
                dskh.Add(x);
            }
            return dskh;
        }
        public int UpdateKhachHang(object [] ds)
        {
            return DAO.DataProvider.Instance.ExecuteNonQuery(@"exec dbo.usp_UpdateKhachHang @makh  , @tenkh , @scmnd , @sodt , @diachi , @gioitinh ",ds);
        }
    }
}
