using PlayerLog.MODEL;
using PlayerLogApp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLog.BLL
{
    public class OyuncuBL
    {
        public bool OyuncuEkle(Oyuncular oyn)
        {
            Helper hlp = new Helper();
            SqlParameter[] p = { new SqlParameter("@TAKIMID", oyn.Takım), new SqlParameter("@BOLGEID", oyn.Bolge), new SqlParameter("@OVERALL", oyn.Overall), new SqlParameter("@AD", oyn.Ad), new SqlParameter("@SOYAD", oyn.Soyad), new SqlParameter("@NUMARA", oyn.Numara), new SqlParameter("@BOY", oyn.Boy), new SqlParameter("@YAS", oyn.DogumTarihi) };
            return hlp.ExecuteNonQuery("Insert into tbl_oyuncu values (@TAKIMID,@BOLGEID,@OVERALL,@AD,@SOYAD,@NUMARA,@BOY,@YAS)", p) > 0;
        }
    }
}
