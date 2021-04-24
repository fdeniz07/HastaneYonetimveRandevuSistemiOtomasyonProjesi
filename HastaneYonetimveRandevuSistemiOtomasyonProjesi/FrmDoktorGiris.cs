using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HastaneYonetimveRandevuSistemiOtomasyonProjesi
{
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }

        SQLBaglantisi bgl = new SQLBaglantisi();

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from tbl_Doktorlar where DoktorTCKimlikNo=@tc and DoktorSifre=@sifre", bgl.baglanti());
            komut.Parameters.AddWithValue("@tc", mskTCKimlikNo.Text);
            komut.Parameters.AddWithValue("@sifre", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmDoktorDetay frm = new FrmDoktorDetay();
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
