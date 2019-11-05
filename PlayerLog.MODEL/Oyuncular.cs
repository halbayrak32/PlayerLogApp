using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerLog.MODEL
{
    public class Oyuncular
    {
        #region Fields
        private int oyuncuId;
        private int takımId;
        private int bolgeId;
        private int overall;
        private string ad;
        private string soyad;
        private int numara;
        private int boy;
        private DateTime dogumTarihiId;
        #endregion

        #region Properties
        public int Oyuncu { get => oyuncuId; set => oyuncuId = value; }
        public int Takım { get => takımId; set => takımId = value; }
        public int Bolge { get => bolgeId; set => bolgeId = value; }
        public int Overall { get => overall; set => overall = value; }
        public string Ad { get => ad; set => ad = value; }
        public string Soyad { get => soyad; set => soyad = value; }
        public int Numara { get => numara; set => numara = value; }
        public int Boy { get => boy; set => boy = value; }
        public DateTime DogumTarihi { get => dogumTarihiId; set => dogumTarihiId = value; }
        #endregion

        public void OyuncuBilgileriniGetir(ComboBox cb)
        {
            //cb.Items.Clear();
            SqlConnection con = new SqlConnection(@"Server =.\SQLEXPRESS; Database=PlayerLogDB; Trusted_Connection=true");
            SqlCommand cmd = new SqlCommand("Select * from tbl_oyuncu", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Oyuncular o = new Oyuncular();
                o.Oyuncu = Convert.ToInt32(dr["ID"]);
                o.Takım = Convert.ToInt32(dr["TAKIMID"]);
                o.Bolge = Convert.ToInt32(dr["BOLGEID"]);
                o.Overall = Convert.ToInt32(dr["OVERALL"]);
                o.Ad = Convert.ToString(dr["AD"]);
                o.Soyad = Convert.ToString(dr["SOYAD"]);
                o.Numara = Convert.ToInt32(dr["NUMARA"]);
                o.Boy = Convert.ToInt32(dr["BOY"]);
                o.DogumTarihi = Convert.ToDateTime(dr["DOGUMTARIHI"]);
                cb.Items.Add(o);
            }
            dr.Close();
            con.Close();




        }
    }
}
