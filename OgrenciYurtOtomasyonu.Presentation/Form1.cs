using OgrenciYurtOtomasyonu.BLL;
using OgrenciYurtOtomasyonu.DAL;
using OgrenciYurtOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciYurtOtomasyonu.Presentation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            maskedTextBox1.PasswordChar = '*';
        }
        public static string KullaniciAdi = "";

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Draggable(true);
            this.AcceptButton = button1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int durum = YoneticiBLL.YoneticiLogin(textBox1.Text, maskedTextBox1.Text);

            if (durum > 0)
            {
                KullaniciAdi = textBox1.Text;
                MessageBox.Show(Messages.LoginSuccess);
                this.Hide();
                frmYoneticiPanel yoneticiPanel = new frmYoneticiPanel();
                yoneticiPanel.Show();
            }
            else
            {
                MessageBox.Show(Messages.LoginError1);
            }
        }

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    button1.PerformClick();
            //}
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
    }
}
