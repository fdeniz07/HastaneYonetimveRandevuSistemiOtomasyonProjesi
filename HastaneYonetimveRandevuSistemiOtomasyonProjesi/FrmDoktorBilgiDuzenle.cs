using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HastaneYonetimveRandevuSistemiOtomasyonProjesi
{
    public partial class FrmDoktorBilgiDuzenle : Form
    {
        public FrmDoktorBilgiDuzenle()
        {
            InitializeComponent();
        }

        SQLBaglantisi bgl = new SQLBaglantisi();
        public string DrTcNo;

        private void FrmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskTCKimlikNo.Text = DrTcNo;

            SqlCommand komut = new SqlCommand("Select * from tbl_Doktorlar where DoktorTCKimlikNo = @tc", bgl.baglanti());
            komut.Parameters.AddWithValue("@tc", mskTCKimlikNo.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                cmbBrans.Text = dr[3].ToString();
                txtSifre.Text = dr[5].ToString();
            }
            bgl.baglanti().Close();
        }

        private void btnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tbl_Doktorlar set DoktorAd=@ad, DoktorSoyad=@soyad, DoktorBrans=@brans, DoktorSifre=@sifre where DoktorTCKimlikNo=@tc", bgl.baglanti());
            komut.Parameters.AddWithValue("@ad", txtAd.Text);
            komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@brans", cmbBrans.Text);
            komut.Parameters.AddWithValue("@sifre", txtSifre.Text);
            komut.Parameters.AddWithValue("@tc", mskTCKimlikNo.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgiler Güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
