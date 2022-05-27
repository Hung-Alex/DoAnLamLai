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
        public List<DTO.Oto> GetListOtoSoChoNgoi(string sochongoi)
        {
            DataTable data = DAO.DataProvider.Instance.ExecuteQuery($"select * from XE where SoChoNgoi='{sochongoi}'");
            List<DTO.Oto> otos = new List<DTO.Oto>();
            foreach (DataRow item in data.Rows)
            {
                DTO.Oto itemOto = new DTO.Oto(item);
                otos.Add(itemOto);
            }
            return otos;
        }
        public List<DTO.Oto> GetListOtoHangXe(string hangxe)
        {
            DataTable data = DAO.DataProvider.Instance.ExecuteQuery($"select * from XE where HangXe=N'{hangxe}'");
            List<DTO.Oto> otos = new List<DTO.Oto>();
            foreach (DataRow item in data.Rows)
            {
                DTO.Oto itemOto = new DTO.Oto(item);
                otos.Add(itemOto);
            }
            return otos;
        }
        public List<DTO.Oto> GetListOtoTenXe(string tenxe)
        {
            DataTable data = DAO.DataProvider.Instance.ExecuteQuery($"select * from XE where TenXe like N'%{tenxe}%'");
            List<DTO.Oto> otos = new List<DTO.Oto>();
            foreach (DataRow item in data.Rows)
            {
                DTO.Oto itemOto = new DTO.Oto(item);
                otos.Add(itemOto);
            }
            return otos;
        }
        public List<DTO.Oto> GetListOtoMaHopDong(string mahopdong)
        {
            DataTable data = DAO.DataProvider.Instance.ExecuteQuery($"select a.MaXe,a.TenXe,a.HangXe,a.BienSoXe,a.SoChoNgoi,a.TrangThai from XE A,CHITIETTHUEXE B where a.MaXe=b.MaXe and b.MaHopDong='{mahopdong}'");
            List<DTO.Oto> otos = new List<DTO.Oto>();
            foreach (DataRow item in data.Rows)
            {
                DTO.Oto itemOto = new DTO.Oto(item);
                otos.Add(itemOto);
            }
            return otos;
        }
        public int UpdateOtoTrangThai(string maxe)
        {
            return DAO.DataProvider.Instance.ExecuteNonQuery($"update XE set TrangThai = 0 where MaXe = '{maxe}'");
        }
        public int UpdateOto(DTO.Oto x)
        {
            return DAO.DataProvider.Instance.ExecuteNonQuery($"exec dbo.usp_UpdateOto '{x.MaXe}' ,N'{x.TenXe}' ,N'{x.HangXe}' ,'{x.SoChoNgoi}' ,'{x.BienSoXe}'");
        }
        public int InsertOto(DTO.Oto x)
        {
            return DAO.DataProvider.Instance.ExecuteNonQuery($"exec dbo.usp_InsertOto N'{x.TenXe}' ,N'{x.HangXe}' ,'{x.BienSoXe}' ,'{x.SoChoNgoi}'");
        }
    }
}
