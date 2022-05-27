using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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
    }
}
