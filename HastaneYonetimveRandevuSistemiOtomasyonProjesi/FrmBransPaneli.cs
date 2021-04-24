using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace HastaneYonetimveRandevuSistemiOtomasyonProjesi
{
    public partial class FrmBransPaneli : Form
    {
        public FrmBransPaneli()
        {
            InitializeComponent();
        }

        SQLBaglantisi bgl = new SQLBaglantisi();

        public void FormTemizle()
        {
            txtBransID.Clear();
            txtBransAd.Clear();
        }

        private void FrmBransPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_Branslar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_Branslar (BransAd) values (@bransad)", bgl.baglanti());
            komut.Parameters.AddWithValue("@bransad", txtBransAd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti();
            MessageBox.Show("Brans Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FormTemizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtBransID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtBransAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from tbl_Branslar where BransId=@id", bgl.baglanti());
            komut.Parameters.AddWithValue("@id", txtBransID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti();
            MessageBox.Show("Brans Silindi", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            FormTemizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tbl_Branslar set BransAd=@ad where BransId=@id", bgl.baglanti());
            komut.Parameters.AddWithValue("@ad", txtBransAd.Text);
            komut.Parameters.AddWithValue("@id", txtBransID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Brans Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FormTemizle();
        }

        private void btnListeGuncelle_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from tbl_Branslar", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }
    }
}
