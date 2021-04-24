using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace HastaneYonetimveRandevuSistemiOtomasyonProjesi
{
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }

        public string tcNo;

        SQLBaglantisi bgl = new SQLBaglantisi();

        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            lblTCKimlikNo.Text = tcNo;

            //Ad Soyad

            SqlCommand komut = new SqlCommand("select SekreterAdSoyad from tbl_Sekreterler where SekreterTCKimlikNo=@tc", bgl.baglanti());
            komut.Parameters.AddWithValue("@tc", lblTCKimlikNo.Text);
            SqlDataReader dr1 = komut.ExecuteReader();
            while (dr1.Read())
            {
                lblAdSoyad.Text = dr1[0].ToString();
            }
            bgl.baglanti().Close();

            //Branslari DataGrid e aktarma

            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select BransId, (BransAd) as 'Brans Adi' from tbl_Branslar", bgl.baglanti());
            da.Fill(dt1);
            dgwBranslar.DataSource = dt1;


            //Doktorlari DataGriw e aktarma

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select (DoktorAd + ' ' + DoktorSoyad) as 'Doktorlar',(DoktorBrans) as 'Brans' from tbl_Doktorlar", bgl.baglanti());
            da2.Fill(dt2);
            dgwDoktorlar.DataSource = dt2;


            //Bransi ComboBox a aktarma

            SqlCommand komut2 = new SqlCommand("Select BransAd from tbl_Branslar", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutKaydet = new SqlCommand("insert into tbl_Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values (@tarih,@saat,@brans,@doktor)", bgl.baglanti());
            komutKaydet.Parameters.AddWithValue("@tarih", mskTarih.Text);
            komutKaydet.Parameters.AddWithValue("@saat", mskSaat.Text);
            komutKaydet.Parameters.AddWithValue("@brans", cmbBrans.Text);
            komutKaydet.Parameters.AddWithValue("@doktor", cmbDoktor.Text);
            komutKaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Olusturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Doktoru ComboBox a getirme

            cmbDoktor.Items.Clear();

            SqlCommand komut = new SqlCommand("Select DoktorAd,DoktorSoyad from tbl_Doktorlar where DoktorBrans=@brans", bgl.baglanti());
            komut.Parameters.AddWithValue("@brans", cmbBrans.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbDoktor.Items.Add(dr[0] + " " + dr[1]);
            }
            bgl.baglanti().Close();
        }

        private void btnDuyuruOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_Duyurular (duyuru) values (@d1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", rchDuyuru.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Olusturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDoktorPaneli_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli drp = new FrmDoktorPaneli();
            drp.Show();
        }

        private void btnBransPaneli_Click(object sender, EventArgs e)
        {
            FrmBransPaneli frb = new FrmBransPaneli();
            frb.Show();

        }

        private void btnRandevuListe_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi frl = new FrmRandevuListesi();
            frl.Show();
        }

        private void btnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular frd = new FrmDuyurular();
            frd.Show();
        }
    }
}
