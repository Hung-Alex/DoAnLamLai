using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DoAnQuanLyChoThueOto.DTO;

namespace DoAnQuanLyChoThueOto.DAO
{
    class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get
            {
                if (AccountDAO.instance == null)
                {
                    AccountDAO.instance = new AccountDAO();
                };
                return AccountDAO.instance;
            }
            private set { AccountDAO.instance = value; }
        }
        private AccountDAO() { }

        public bool Login(string username, string password)
        {

            DataTable result = DataProvider.Instance.ExecuteQuery($"exec dbo.usp_Login '{username}' , '{password}'");
            return result.Rows.Count > 0;
        }
        public List<TaiKhoan> GetTaiKhoan()
        {
            DataTable data = DAO.DataProvider.Instance.ExecuteQuery(@"select * from TAIKHOAN");
            List<TaiKhoan> dstk = new List<TaiKhoan>();
            foreach (DataRow item in data.Rows)
            {
                TaiKhoan x = new TaiKhoan(item);
                dstk.Add(x);
            }
            return dstk;
        }
        public int InsertTaiKhoan(TaiKhoan x)
        {
            return DAO.DataProvider.Instance.ExecuteNonQuery("exec dbo.usp_InsertTaiKhoan @tendangnhap  , @matkhau , @tennguoidung , @loaitaikhoan ", new object[] { x.TenTK, x.MatKhau, x.TenNguoiDung, x.LoaiTK });
        }
        public int CheckThongTinTK(string tendangnhap)
        {
            return DAO.DataProvider.Instance.ExecuteQuery("exec dbo.usp_CheckThongTinTK  @tendangnhap ",new object[] { tendangnhap}).Rows.Count;
        }
        public void DeleteTaiKhoan(string tendangnhap)
        {
            DAO.DataProvider.Instance.ExecuteNonQuery($"Delete TAIKHOAN where TenDangNhap='{tendangnhap}'");
        }
        public int UpdateTaiKhoan(TaiKhoan x)
        {
            return DAO.DataProvider.Instance.ExecuteNonQuery("exec dbo.usp_UpdateTaiKhoan @tendangnhap  , @matkhau , @tennguoidung , @loaitaikhoan ", new object[] { x.TenTK, x.MatKhau, x.TenNguoiDung, x.LoaiTK });
        }
        public bool PhanQuyen(string tendangnhap)
        {
            return DAO.DataProvider.Instance.ExecuteQuery("exec dbo.usp_PhanQuyen @tendangnhap", new object[] { tendangnhap }).Rows.Count > 0;
        }
    }
}
