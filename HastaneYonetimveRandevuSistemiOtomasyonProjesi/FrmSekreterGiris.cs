using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HastaneYonetimveRandevuSistemiOtomasyonProjesi
{
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }

        SQLBaglantisi bgl = new SQLBaglantisi();

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from tbl_Sekreterler where SekreterTCKimlikNo=@tc and SekreterSifre=@sifre", bgl.baglanti());
            komut.Parameters.AddWithValue("@tc", mskTCKimlikNo.Text);
            komut.Parameters.AddWithValue("@sifre", txtSifre.Text);
            SqlDataReader dr= komut.ExecuteReader();
            if (dr.Read())
            {
                FrmSekreterDetay frm = new FrmSekreterDetay();
                frm.tcNo = mskTCKimlikNo.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("TC Kimlik No & Sifre Yanlis", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            bgl.baglanti().Close();
        }
    }
}
