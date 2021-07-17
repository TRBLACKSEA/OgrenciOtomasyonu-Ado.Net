using OgrenciYurtOtomasyonu.BLL;
using OgrenciYurtOtomasyonu.DAL;
using OgrenciYurtOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciYurtOtomasyonu.Presentation
{
    public partial class frmYoneticiPanel : Form
    {
        public frmYoneticiPanel()
        {
            InitializeComponent();
            this.Draggable(true);

        }
        int ID;
        private void frmYoneticiPanel_Load(object sender, EventArgs e)
        {


            //List<Yonetici> yoneticis = new List<Yonetici>();
            //for (int i = 0; i < 3; i++)
            //{
            //    Yonetici yonetici = new Yonetici()
            //    {
            //        Ad = FakeData.NameData.GetFirstName() + " " + FakeData.NameData.GetSurname(),
            //        Sifre = FakeData.NameData.GetFirstName()
            //    };
            //    yoneticis.Add(yonetici);
            //}

            //int a = YoneticiBLL.YoneticileriEkle(yoneticis);

            //MessageBox.Show(a.ToString() + " adet kayıt eklendi");

            lblKullaniciAdi.Text = Form1.KullaniciAdi;

            List<Bolum> bolumler = BolumBLL.SelectAll();

            foreach (Bolum bolum in bolumler)
            {
                cmbBolumler.Items.Add(bolum.AD);
            }






            dgvYoneticiler.DataSource = YoneticiBLL.SelectAll();
            dgvYoneticiler.Columns["ID"].Visible = false;

            dgvBolumler.DataSource = BolumBLL.SelectAll();
            dgvBolumler.Columns["ID"].Visible = false;

            dgvOdalar.DataSource = OdaBLL.SelectAll();
            dgvOdalar.Columns["ID"].Visible = false;

            dgvOgrenciler.DataSource = OgrenciBLL.SelectAll();
            dgvOgrenciler.Columns["ID"].Visible = false;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int kayitDurum = YoneticiBLL.YoneticiLogin(txtKullaniciAdi.Text, txtSifre.Text);
            if (kayitDurum > 0)
            {
                MessageBox.Show(Messages.RepetitiveUserError);
            }
            else
            {
                int eklenen = 0;
                Yonetici yonetici = new Yonetici()
                {
                    AD = txtKullaniciAdi.Text,
                    SIFRE = txtSifre.Text
                };
                eklenen = YoneticiBLL.Insert(yonetici);
                if (eklenen > 0)
                {
                    MessageBox.Show(Messages.InsertMessage);
                    txtKullaniciAdi.Text = "";
                    txtSifre.Text = "";
                    dgvYoneticiler.DataSource = YoneticiBLL.SelectAll();
                }
            }

        }

        private void dgvYoneticiler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(dgvYoneticiler.CurrentRow.Cells[0].Value);
            // MessageBox.Show(ID.ToString());
            txtKullaniciAdi.Text = dgvYoneticiler.CurrentRow.Cells["ad"].Value.ToString();
            txtSifre.Text = dgvYoneticiler.CurrentRow.Cells["sifre"].Value.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int etkilenen = YoneticiBLL.Delete(ID);
            dgvYoneticiler.DataSource = YoneticiBLL.SelectAll();
            txtKullaniciAdi.Text = "";
            txtSifre.Text = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int durum = -1;
            Yonetici yonetici = new Yonetici()
            {
                ID = this.ID,
                AD = txtKullaniciAdi.Text,
                SIFRE = txtSifre.Text
            };
            durum = YoneticiBLL.Update(yonetici);
            if (durum > 0)
            {
                MessageBox.Show(Messages.UpdateSuccess);
                dgvYoneticiler.DataSource = YoneticiBLL.SelectAll();
            }
            else
            {
                MessageBox.Show(Messages.UpdateError);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 5;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 6;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 7;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            form1.Show();
        }

        private void pcrKullanici_Click(object sender, EventArgs e)
        {

        }

        private void dgvBolumler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(dgvBolumler.CurrentRow.Cells[0].Value);
            txtBolum.Text = dgvBolumler.CurrentRow.Cells["ad"].Value.ToString();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            int durum = BolumBLL.Control(txtBolum.Text);
            if (durum > 0)
            {
                MessageBox.Show(Messages.RepetitiveUserError);
            }
            else
            {
                try
                {
                    Bolum bolum = new Bolum() { ID = this.ID, AD = txtBolum.Text };
                    int eklenen = BolumBLL.Insert(bolum);

                    if (eklenen > 0)
                    {
                        MessageBox.Show(Messages.InsertMessage);
                        dgvBolumler.DataSource = BolumBLL.SelectAll();
                    }
                    else
                    {
                        MessageBox.Show(Messages.InsertError);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }

        }

        private void button16_Click(object sender, EventArgs e)
        {
            BolumBLL.Delete(this.ID);
            dgvBolumler.DataSource = BolumBLL.SelectAll();
            txtBolum.Text = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Bolum bolum = new Bolum() { ID = this.ID, AD = txtBolum.Text };
            int durum = BolumBLL.Update(bolum);
            if (durum > 0)
            {
                MessageBox.Show(Messages.UpdateSuccess);
                dgvBolumler.DataSource = BolumBLL.SelectAll();
            }
            else
            {
                MessageBox.Show(Messages.UpdateError);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://tr-tr.facebook.com/idealyurtlari");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/idealyurtlari/?hl=tr");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/idealyurtlar");
        }

        private void btkOgrenciEkle_Click(object sender, EventArgs e)
        {


            Ogrenci ogrenci = new Ogrenci()
            {
                AD = txtOgrenciAd.Text,
                SOYAD = txtOgrenciSoyad.Text,
                TC = mskOgrenciTc.Text,
                TELEFON = mskOgrenciTelefon.Text,
                DOGUMTARIHI = dtpOgrenciDogum.Value,
                MAIL = txtOgrenciMail.Text,
                VELIADSOYAD = txtVeliAdSoyad.Text,
                VELITELEFON = mskVeliTelefon.Text,
                VELIADRES = txtVeliAdres.Text,
                BOLUM = cmbBolumler.Text
            };
            int durum = OgrenciBLL.Control(ogrenci.TC);
            if (durum > 0)
            {
                MessageBox.Show(Messages.RepetitiveUserError);
            }
            else
            {
                int eklenen = OgrenciBLL.Insert(ogrenci);
                if (eklenen > 0)
                {
                    MessageBox.Show(Messages.InsertMessage);
                    dgvOgrenciler.DataSource = OgrenciBLL.SelectAll();
                }
                else
                {
                    MessageBox.Show(Messages.InsertError);
                }
            }
        }

        private void dgvOgrenciler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(dgvOgrenciler.CurrentRow.Cells[0].Value);
            txtOgrenciAd.Text = dgvOgrenciler.CurrentRow.Cells["ad"].Value.ToString();
            txtOgrenciSoyad.Text = dgvOgrenciler.CurrentRow.Cells["soyad"].Value.ToString();
            mskOgrenciTc.Text = dgvOgrenciler.CurrentRow.Cells["tc"].Value.ToString();
            mskOgrenciTelefon.Text = dgvOgrenciler.CurrentRow.Cells["telefon"].Value.ToString();
            dtpOgrenciDogum.Value = Convert.ToDateTime(dgvOgrenciler.CurrentRow.Cells["dogumtarihi"].Value);
            txtOgrenciMail.Text = dgvOgrenciler.CurrentRow.Cells["mail"].Value.ToString();
            cmbBolumler.SelectedItem = dgvOgrenciler.CurrentRow.Cells["bolum"].Value;
            txtVeliAdSoyad.Text = dgvOgrenciler.CurrentRow.Cells["veliAdSoyad"].Value.ToString();
            mskVeliTelefon.Text = dgvOgrenciler.CurrentRow.Cells["veliTelefon"].Value.ToString();
            txtVeliAdres.Text = dgvOgrenciler.CurrentRow.Cells["veliAdres"].Value.ToString();
        }

        private void btnOgrenciGuncelle_Click(object sender, EventArgs e)
        {
            int durum = 0;
            Ogrenci ogrenci = new Ogrenci()
            {
                ID = Convert.ToInt32(dgvOgrenciler.CurrentRow.Cells[0].Value),
                AD = txtOgrenciAd.Text,
                SOYAD = txtOgrenciSoyad.Text,
                TC = mskOgrenciTc.Text,
                TELEFON = mskOgrenciTelefon.Text,
                DOGUMTARIHI = dtpOgrenciDogum.Value,
                MAIL = txtOgrenciMail.Text,
                BOLUM = cmbBolumler.Text,
                VELIADSOYAD = txtVeliAdSoyad.Text,
                VELITELEFON = mskVeliTelefon.Text,
                VELIADRES = txtVeliAdres.Text
            };
            durum = OgrenciBLL.Update(ogrenci);
            if(durum>0)
            {
                MessageBox.Show(Messages.UpdateSuccess);
                dgvOgrenciler.DataSource = OgrenciBLL.SelectAll();
            }
            else
            {
                MessageBox.Show(Messages.UpdateError);
            }
        }

        private void btnOgrenciSil_Click(object sender, EventArgs e)
        {
            OgrenciBLL.Delete(ID);
            txtOgrenciAd.Text = "";
            txtOgrenciSoyad.Text = "";
            mskOgrenciTc.Text = "";
            mskOgrenciTelefon.Text = "";
            dtpOgrenciDogum.Value =DateTime.Now;
            txtOgrenciMail.Text = "";
            cmbBolumler.SelectedIndex = 0;
            txtVeliAdSoyad.Text = "";
            mskVeliTelefon.Text = "";
            txtVeliAdres.Text = "";
            dgvOgrenciler.DataSource = OgrenciBLL.SelectAll();
        }
    }
}
