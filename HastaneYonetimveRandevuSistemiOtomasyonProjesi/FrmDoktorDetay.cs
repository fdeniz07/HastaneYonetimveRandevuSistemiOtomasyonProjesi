using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace HastaneYonetimveRandevuSistemiOtomasyonProjesi
{
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }

        public string tcNo;
        SQLBaglantisi bgl = new SQLBaglantisi();

        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            lblTCKimlikNo.Text = tcNo;

            //Doktor Ad Soyad

            SqlCommand komut = new SqlCommand("select DoktorAd,DoktorSoyad from tbl_Doktorlar where DoktorTCKimlikNo=@tc", bgl.baglanti());
            komut.Parameters.AddWithValue("@tc", lblTCKimlikNo.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();

            //Randevular

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select (RandevuId) as 'ID',(RandevuTarih) as 'Tarih',(RandevuSaat) as 'Saat',(RandevuBrans) as 'Brans',(RandevuDoktor) as 'Doktor',(RandevuDurum) as 'Durum', (HastaTCKimlikNO) as 'TC No', (HastaSikayet) as 'Sikayet' from tbl_Randevular where RandevuDoktor='" + lblAdSoyad.Text + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDuzenle frm = new FrmDoktorBilgiDuzenle();
            frm.DrTcNo = lblTCKimlikNo.Text;
            frm.Show();
        }

        private void btnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular frd = new FrmDuyurular();
            frd.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            rchSikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
