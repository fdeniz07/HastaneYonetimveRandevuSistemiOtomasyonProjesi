using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace HastaneYonetimveRandevuSistemiOtomasyonProjesi
{
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }

        public string tcNo;
        SQLBaglantisi bgl = new SQLBaglantisi();

        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            lblTCKimlikNo.Text = tcNo;


            //Ad Soyad Cekmek Islemi
            SqlCommand komut = new SqlCommand("Select HastaAd,HastaSoyad from tbl_Hastalar where HastaTCKimlikNo=@tcno", bgl.baglanti());
            komut.Parameters.AddWithValue("@tcno", lblTCKimlikNo.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();

            //Randevu Gecmisi
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_Randevular where HastaTCKimlikNo=" + tcNo, bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            //Branslari Cekme
            SqlCommand komut2 = new SqlCommand("Select BransAd from tbl_Branslar",bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();
            
            SqlCommand komut3 = new SqlCommand("Select DoktorAd,DoktorSoyad from tbl_Doktorlar where DoktorBrans=@brans", bgl.baglanti());
            komut3.Parameters.AddWithValue("@brans", cmbBrans.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                cmbDoktor.Items.Add(dr3[0] + " " + dr3[1]);
            }
            bgl.baglanti();
        }

        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //Randevusu bos olanlarin gözükmesi
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_Randevular where RandevuBrans='" + cmbBrans.Text + "'"+ "and RandevuDoktor='" + cmbDoktor.Text + "'and RandevuDurum=0",bgl.baglanti()); 
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void lnkBilgiDuzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDuzenle frm = new FrmBilgiDuzenle();
            frm.TCNo = lblTCKimlikNo.Text;
            frm.Show();

        }

        private void btnRandevuAl_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tbl_Randevular set RandevuDurum=1,HastaTCKimlikNo=@tc,HastaSikayet=@sikayet where RandevuId=@id", bgl.baglanti());
            komut.Parameters.AddWithValue("@tc", lblTCKimlikNo.Text);
            komut.Parameters.AddWithValue("@sikayet", rchSikayet.Text);
            komut.Parameters.AddWithValue("@id", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Alindi", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            txtID.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }
    }
}
