using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace HastaneYonetimveRandevuSistemiOtomasyonProjesi
{
    public partial class FrmDoktorPaneli : Form
    {
        public FrmDoktorPaneli()
        {
            InitializeComponent();
        }

        SQLBaglantisi bgl = new SQLBaglantisi();

        public void Temizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            mskTCKimlikNo.Clear();
            txtSifre.Clear();
        }

        private void FrmDoktorPaneli_Load(object sender, EventArgs e)
        {
            //Doktorlari DataGriw e aktarma

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select(DoktorID) as 'ID', (DoktorAd) as 'AD', (DoktorSoyad) as 'SOYAD', (DoktorBrans) as 'BRANS', (DoktorTCKimlikNo) as 'TC KIMLIK', (DoktorSifre) as 'SIFRE' from tbl_Doktorlar", bgl.baglanti());
            da1.Fill(dt1);
            dgwDoktorPanel.DataSource = dt1;

            //Bransi ComboBox a aktarma

            SqlCommand komut2 = new SqlCommand("Select BransAd from tbl_Branslar", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_Doktorlar (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTCKimlikNo,DoktorSifre) values (@ad,@soyad,@brans,@tc,@sifre)", bgl.baglanti());
            komut.Parameters.AddWithValue("@ad", txtAd.Text);
            komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@brans", cmbBrans.Text);
            komut.Parameters.AddWithValue("@tc", mskTCKimlikNo.Text);
            komut.Parameters.AddWithValue("@sifre", txtSifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Temizle();
        }

        private void dgwDoktorPanel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dgwDoktorPanel.SelectedCells[0].RowIndex;
            txtAd.Text = dgwDoktorPanel.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dgwDoktorPanel.Rows[secilen].Cells[2].Value.ToString();
            cmbBrans.Text = dgwDoktorPanel.Rows[secilen].Cells[3].Value.ToString();
            mskTCKimlikNo.Text = dgwDoktorPanel.Rows[secilen].Cells[4].Value.ToString();
            txtSifre.Text = dgwDoktorPanel.Rows[secilen].Cells[5].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from tbl_Doktorlar where DoktorTCKimlikNo=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("p1", mskTCKimlikNo.Text);
            bgl.baglanti().Close();
            MessageBox.Show("Kayit Silindi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update tbl_Doktorlar set doktorAd=@ad,doktorSoyad=@soyad,doktorBrans=@brans,doktorSifre=@sifre where doktorTCKimlikNo=@tc", bgl.baglanti());
            komut.Parameters.AddWithValue("@ad", txtAd.Text);
            komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@brans", cmbBrans.Text);
            komut.Parameters.AddWithValue("@tc", mskTCKimlikNo.Text);
            komut.Parameters.AddWithValue("@sifre", txtSifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Temizle();
        }

        private void btnListeGuncelle_Click(object sender, EventArgs e)
        {
            //Doktorlari DataGriw e aktarma

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select (DoktorID) as 'ID',(DoktorAd) as 'AD',(DoktorSoyad) as 'SOYAD',(DoktorBrans) as 'BRANS',(DoktorTCKimlikNo) as 'TC KIMLIK' ,(DoktorSifre) as 'SIFRE' from tbl_Doktorlar", bgl.baglanti());
            da1.Fill(dt1);
            dgwDoktorPanel.DataSource = dt1;
        }
    }
}
