using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HastaneYonetimveRandevuSistemiOtomasyonProjesi
{
    public partial class FrmHastaKayit : Form
    {
        public FrmHastaKayit()
        {
            InitializeComponent();
        }

        SQLBaglantisi bgl = new SQLBaglantisi();

        private void btnKayitYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_Hastalar (HastaAd,HastaSoyad,HastaTCKimlikNo,HastaTelefon,HastaSifre,HastaCinsiyet) values (@ad,@soyad,@tcno,@telefon,@sifre,@cinsiyet)", bgl.baglanti());
            komut.Parameters.AddWithValue("@ad", txtAd.Text);
            komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@tcno", mskTCKimlikNo.Text);
            komut.Parameters.AddWithValue("@telefon", mskTelefon.Text);
            komut.Parameters.AddWithValue("@sifre", txtSifre.Text);
            komut.Parameters.AddWithValue("@cinsiyet", cmbCinsiyet.Text);
            komut.ExecuteNonQuery();    
            bgl.baglanti().Close();
            MessageBox.Show("Kaydiniz Gerceklesmistir Sifreniz : " + txtSifre.Text, "Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
