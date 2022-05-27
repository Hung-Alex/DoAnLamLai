using System;
using System.Collections.Generic;
using System.Data;
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

        public int InsertHopDong(string mahopdong,string makh, int tiencoc, int tienthue)
        {
            
            return DAO.DataProvider.Instance.ExecuteNonQuery($"exec dbo.usp_InsertHopDong '{mahopdong}' ,'{makh}' ,'{tiencoc}' ,'{tienthue}'");
        }
        public int InsertChiTietHopDong(string mahopdong,string maxe,DateTime ngaythue,DateTime ngaytra)
        {
            return DAO.DataProvider.Instance.ExecuteNonQuery($"exec dbo.usp_InsertChiTietThueXe '{mahopdong}' ,'{maxe}' ,'{ngaythue}' ,'{ngaytra}' ");
        }
        public List<DTO.HopDong> GetListHopDong(int number)
        {
            DataTable data = DAO.DataProvider.Instance.ExecuteQuery($"select a.MaHopDong,c.MaKH,c.TenKH,c.SCMND,b.NgayThue,b.NgayDuKienTra,a.TienThue,a.TienCoc,b.HinhThuc from HOPDONG A,CHITIETTHUEXE B,KHACHHANG C,XE D where a.MaHopDong = b.MaHopDong and a.MaKH = c.MaKH and b.MaXe = d.MaXe and b.HinhThuc='{number}' group by a.MaHopDong, c.MaKH, c.TenKH, c.SCMND, b.NgayThue, b.NgayDuKienTra, a.TienThue, a.TienCoc, b.HinhThuc");
            List<DTO.HopDong> lshopdong = new List<DTO.HopDong>();
            foreach(DataRow item in data.Rows)
            {
                DTO.HopDong itemhopdong = new DTO.HopDong(item);
                lshopdong.Add(itemhopdong);
            }
            return lshopdong;
        }
        public List<DTO.HopDong> GetListHopDong(int number,string hangxe)
        {
            DataTable data = DAO.DataProvider.Instance.ExecuteQuery($"select a.MaHopDong,c.MaKH,c.TenKH,c.SCMND,b.NgayThue,b.NgayDuKienTra,a.TienThue,a.TienCoc,b.HinhThuc from HOPDONG A,CHITIETTHUEXE B,KHACHHANG C,XE D where a.MaHopDong = b.MaHopDong and a.MaKH = c.MaKH and b.MaXe = d.MaXe and b.HinhThuc='{number}' and d.HangXe=N'{hangxe}' group by a.MaHopDong, c.MaKH, c.TenKH, c.SCMND, b.NgayThue, b.NgayDuKienTra, a.TienThue, a.TienCoc, b.HinhThuc");
            List<DTO.HopDong> lshopdong = new List<DTO.HopDong>();
            foreach (DataRow item in data.Rows)
            {
                DTO.HopDong itemhopdong = new DTO.HopDong(item);
                lshopdong.Add(itemhopdong);
            }
            return lshopdong;
        }
        public List<DTO.HopDong> GetListHopDong( string tenkh,int number)
        {
            DataTable data = DAO.DataProvider.Instance.ExecuteQuery($"select a.MaHopDong,c.MaKH,c.TenKH,c.SCMND,b.NgayThue,b.NgayDuKienTra,a.TienThue,a.TienCoc,b.HinhThuc from HOPDONG A,CHITIETTHUEXE B,KHACHHANG C,XE D where a.MaHopDong = b.MaHopDong and a.MaKH = c.MaKH and b.MaXe = d.MaXe and b.HinhThuc='{number}' and TenKH like N'%{tenkh}%' group by a.MaHopDong, c.MaKH, c.TenKH, c.SCMND, b.NgayThue, b.NgayDuKienTra, a.TienThue, a.TienCoc, b.HinhThuc");
            List<DTO.HopDong> lshopdong = new List<DTO.HopDong>();
            foreach (DataRow item in data.Rows)
            {
                DTO.HopDong itemhopdong = new DTO.HopDong(item);
                lshopdong.Add(itemhopdong);
            }
            return lshopdong;
        }
        public int UpdateHopDong(string mahopdong)
        {
            return DAO.DataProvider.Instance.ExecuteNonQuery($"update CHITIETTHUEXE set HinhThuc= 0 where MaHopDong='{mahopdong}'");
        }
        public int RemoveHopDong(string mahopdong)
        {
            return DAO.DataProvider.Instance.ExecuteNonQuery($"delete CHITIETTHUEXE where MaHopDong='{mahopdong}'");
        }
        public int RemoveHopDong_All(string mahopdong)
        {
            return DAO.DataProvider.Instance.ExecuteNonQuery($"delete HOPDONG where MaHopDong='{mahopdong}'");
        }

        public int UpdateHopDong(string mahopdong,string makh,int tiencoc,int tienthue)
        {
            return DAO.DataProvider.Instance.ExecuteNonQuery($"exec usp_UpdateHopDong '{mahopdong}' ,'{makh}' ,'{tiencoc}' ,'{tienthue}' ");
        }

    }
}
