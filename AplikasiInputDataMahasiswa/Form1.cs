using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiInputDataMahasiswa
{
    public partial class Form1 : Form
    {
        private List<Mahasiswa> list = new List<Mahasiswa>();
        public Form1()
        {
            InitializeComponent();
            InisilisasiListView();
        }

        private void lvwMahasiswa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void InisilisasiListView()
        {
            lvwMahasiswa.View = View.Details;
            lvwMahasiswa.FullRowSelect = true;
            lvwMahasiswa.GridLines = true;

            lvwMahasiswa.Columns.Add("No.", 30, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nim.", 91, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nama.", 200, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Kelas.", 70, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nilai.", 50, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nilai Huruf.", 120, HorizontalAlignment.Center);

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            Mahasiswa mhs = new Mahasiswa();
            mhs.Nim = txtNim.Text;
            mhs.Nama = txtNama.Text;
            mhs.Kelas = txtKelas.Text;
            mhs.Nilai = int.Parse(txtNilai.Text);

            if (mhs.Nilai >= 0 && mhs.Nilai <= 20)
            {
                mhs.nilaiHuruf = "E";
            } else if (mhs.Nilai >= 21 && mhs.Nilai <= 40)
            {
                mhs.nilaiHuruf = "D";
            } else if (mhs.Nilai >= 41 && mhs.Nilai <= 60)
            {
                mhs.nilaiHuruf = "c";
            }else if (mhs.Nilai >= 61 && mhs.Nilai <= 80)
            {
                mhs.nilaiHuruf = "B";
            }else if (mhs.Nilai >= 81 && mhs.Nilai <= 100)
            {
                mhs.nilaiHuruf = "A";
            }

            list.Add(mhs);

            var msg = "Data mahasiswa berhasil disimpan.";

            MessageBox.Show(msg, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //ResetForm();



        }


        private void Tampilkandata()
        {
            lvwMahasiswa.Items.Clear();

            foreach (var mhs in list)
            {
                var noUrut = lvwMahasiswa.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(mhs.Nim);
                item.SubItems.Add(mhs.Nama);
                item.SubItems.Add(mhs.Kelas);
                item.SubItems.Add(mhs.Nilai.ToString());
                item.SubItems.Add(mhs.nilaiHuruf);

                lvwMahasiswa.Items.Add(item);
            }
        }

        private void btnTampilkanData_Click(object sender, EventArgs e)
        {
            Tampilkandata();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lvwMahasiswa.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data mahasiswa ingin dihapus?", "Konfirmasi",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    var index = lvwMahasiswa.SelectedIndices[0];
                    list.RemoveAt(index);
                    Tampilkandata();
                }

                

            }else
            {
                MessageBox.Show("Data mahasiswa belum dipilih !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
