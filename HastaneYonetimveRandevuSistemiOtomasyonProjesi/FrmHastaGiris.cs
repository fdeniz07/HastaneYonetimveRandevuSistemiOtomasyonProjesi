using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HastaneYonetimveRandevuSistemiOtomasyonProjesi
{
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }

        SQLBaglantisi bgl = new SQLBaglantisi();

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from tbl_Hastalar where HastaTCKimlikNo=@tcno and HastaSifre=@sifre", bgl.baglanti());
            komut.Parameters.AddWithValue("tcno", mskTCKimlikNo.Text);
            komut.Parameters.AddWithValue("sifre", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmHastaDetay frm = new FrmHastaDetay();
                frm.tcNo = mskTCKimlikNo.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatali TC Kimlik No & Sifre", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bgl.baglanti().Close();
        }

        private void lnkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit frm = new FrmHastaKayit();
            frm.Show();
        }
    }
}
