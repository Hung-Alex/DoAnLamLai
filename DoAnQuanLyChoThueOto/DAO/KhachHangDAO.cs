using System;
using System.Collections.Generic;
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
    }
}
