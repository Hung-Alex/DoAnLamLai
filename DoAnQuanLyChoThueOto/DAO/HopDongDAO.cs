using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnQuanLyChoThueOto.DAO
{
    class HopDongDAO
    {
        private static HopDongDAO instance;

        public static HopDongDAO Instance
        {
            get 
            {
                if (instance==null)
                {
                    instance = new HopDongDAO();
                }
               return instance ;
            }
            private set => instance = value; 
        }
        private HopDongDAO() { }

        public int InsertHopDong(string makh,int tiencoc,int tienthue)
        {
            string mahopdong = DAO.DataProvider.Instance.ExecuteScalar(@"select dbo.ufn_SinhMaHopDong()").ToString();
            return DAO.DataProvider.Instance.ExecuteNonQuery($"exec dbo.usp_InsertHopDong '{mahopdong}' ,'{makh}' ,'{tiencoc}' ,'{tienthue}'");
        }



    }
}
