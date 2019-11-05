using PlayerLog.BLL;
using PlayerLog.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerLogApp
{
    public partial class frmEkle : Form
    {

        SqlConnection connection = null;

        public frmEkle()
        {
            InitializeComponent();

        }
        private void frmEkle_Load(object sender, EventArgs e)
        {
            Oyuncular o = new Oyuncular();
            o.OyuncuBilgileriniGetir(cbBolgeler);
            o.OyuncuBilgileriniGetir(cbTakimlar);


            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=PlayerLogDB;Integrated Security=SSPI";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT *FROM tbl_takimlar";           
            komut.Connection = connection;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            connection.Open();
            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                cbTakimlar.Items.Add(dr["TAKIMADI"]);
          

            }
            connection.Close();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Uyarı!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {




            try
            {
                Oyuncular oyuncu = new Oyuncular();
                oyuncu.Takım = Convert.ToInt32(cbTakimlar.Text.Trim());
                oyuncu.Bolge = Convert.ToInt32(cbBolgeler.Text.Trim());
                oyuncu.Overall = Convert.ToInt32(txtOvr.Text.Trim());
                oyuncu.Ad = txtAd.Text.Trim();
                oyuncu.Soyad = txtSoyad.Text.Trim();
                oyuncu.Numara = Convert.ToInt32(txtNo.Text.Trim());
                oyuncu.Boy = Convert.ToInt32(txtBoy.Text.Trim());
                oyuncu.DogumTarihi = dateTimePicker1.Value;
                OyuncuBL obl = new OyuncuBL();
                MessageBox.Show(obl.OyuncuEkle(oyuncu) ? "Başarılı" : "Başarısız");
            }
            catch (SqlException ex)
            {
                //switch (ex.Number)
                //{
                //    case 245:
                //        MessageBox.Show("Numara girişinde hata!!!");
                //        break;
                //    default:
                //        MessageBox.Show("Veritabanı hatası!!!");
                //        break;
                //}
            }
            //catch (Exception)
            //{
            //    MessageBox.Show("Bir HATA Oluştu!!!");
            //}
        }

        private void cbTakimlar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
//Güncelleme2