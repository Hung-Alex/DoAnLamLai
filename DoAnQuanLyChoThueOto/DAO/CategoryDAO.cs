using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnQuanLyChoThueOto.DAO
{
    class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get 
            {
                if (instance==null)
                {
                    instance = new CategoryDAO();
                }
                return instance;
                
            }
            private set => instance = value; 
        }
        private CategoryDAO() { }

        public List<DTO.KhachHang> GetKhachHang()
        {
            List<DTO.KhachHang> ds = new List<DTO.KhachHang>();
            DataTable kh = DAO.DataProvider.Instance.ExecuteQuery("select * from KHACHHANG");
            foreach (DataRow item in kh.Rows)
            {
                DTO.KhachHang itemKH = new DTO.KhachHang(item);
                ds.Add(itemKH);
            }
            return ds;
        }

    }
}
