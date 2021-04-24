using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HastaneYonetimveRandevuSistemiOtomasyonProjesi
{
    public partial class FrmBilgiDuzenle : Form
    {
        public FrmBilgiDuzenle()
        {
            InitializeComponent();
        }

        public string TCNo;
        SQLBaglantisi bgl = new SQLBaglantisi();

        private void FrmBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskTCKimlikNo.Text = TCNo;

            //Güncelleme Islemi

            SqlCommand komut = new SqlCommand("select * from tbl_Hastalar where HastaTCKimlikNo=@tcno", bgl.baglanti());
            komut.Parameters.AddWithValue("tcno", mskTCKimlikNo.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();                
                mskTelefon.Text = dr[4].ToString();
                txtSifre.Text = dr[5].ToString();
                cmbCinsiyet.Text = dr[6].ToString();
            }
            bgl.baglanti().Close();
        }

        private void btnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update tbl_hastalar set HastaAd=@ad,HastaSoyad=@soyad,HastaTelefon=@telefon,HastaSifre=@sifre,HastaCinsiyet=@cinsiyet where HastaTCKimlikNo =@tc", bgl.baglanti());
            komut2.Parameters.AddWithValue("@ad", txtAd.Text);
            komut2.Parameters.AddWithValue("@soyad", txtSoyad.Text);
            komut2.Parameters.AddWithValue("@telefon", mskTelefon.Text);
            komut2.Parameters.AddWithValue("@sifre", txtSifre.Text);
            komut2.Parameters.AddWithValue("@cinsiyet", cmbCinsiyet.Text);
            komut2.Parameters.AddWithValue("@tc", mskTCKimlikNo.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Bilgi Güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
    }
}
