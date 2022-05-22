using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnQuanLyChoThueOto.DAO
{
    class OtoDAO
    {
        private static OtoDAO instance;

        public static OtoDAO Instance 
        {
            get
            {
                if (instance == null)
                {

                    instance = new OtoDAO();
                }
                return instance;
                ;
            }
           private set => instance = value; 
        }
        private OtoDAO() { }
        public static int OtoWidth=110;
        public static int OtoHeight = 110;
        public List<DTO.Oto> GetListOto()
        {
            DataTable data = DAO.DataProvider.Instance.ExecuteQuery($"select * from XE");
            List<DTO.Oto> otos = new List<DTO.Oto>();
            foreach (DataRow item in data.Rows)
            {
                DTO.Oto itemOto = new DTO.Oto(item);
                otos.Add(itemOto);
            }
            return otos;
        }
    }
}
