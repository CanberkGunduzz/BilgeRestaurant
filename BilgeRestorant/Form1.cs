using BilgeRestorant.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilgeRestorant
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<AnaYemek> AnaYemekler = new List<AnaYemek>()
            {
                new AnaYemek {Isim = "Yengeç Burger" , Fiyat = 10},
                new AnaYemek {Isim = "Garfield Lazanya", Fiyat = 10}
            };

            cmbAnaYemek.DataSource = AnaYemekler;
            cmbAnaYemek.SelectedIndex = -1;

            List<AraSicak> AraSicak = new List<AraSicak>()
            {
                new AraSicak {Isim = "Mercimek Çorbası" , Fiyat = 5},
                new AraSicak {Isim = "Tarhana Çorbası", Fiyat = 5}
            };

            cmbAraSicak.DataSource = AraSicak;
            cmbAraSicak.SelectedIndex = -1;

            List<Tatli> Tatli = new List<Tatli>()
            {
                new Tatli {Isim = "Supangile" , Fiyat = 5},
                new Tatli {Isim = "Tremisu", Fiyat = 5}
            };

            cmbTatli.DataSource = Tatli;
            cmbTatli.SelectedIndex = -1;

            List<Icecek> Icecek = new List<Icecek>()
            {
                new Icecek {Isim = "Kola" , Fiyat = 2},
                new Icecek {Isim = "Fanta", Fiyat = 2}
            };

            cmbIcecek.DataSource = Icecek;
            cmbIcecek.SelectedIndex = -1;

        }

        private void btnSiparisVer_Click(object sender, EventArgs e)
        {
            if (txtMasaNo.Text.Trim() == string.Empty)
            {
                MessageBox.Show("OTUR!");
                return;
            }
            if (cmbAnaYemek.SelectedIndex < 0 && cmbAraSicak.SelectedIndex < 0 && cmbTatli.SelectedIndex < 0 && cmbIcecek.SelectedIndex < 0)
            {
                MessageBox.Show("ÜRÜN SEÇ");
                return;
            }
            Siparis s = new Siparis(txtMasaNo.Text);
            if (cmbAnaYemek.SelectedIndex > -1) s.SecilenAnaYemek = cmbAnaYemek.SelectedItem as AnaYemek;
            if (cmbAraSicak.SelectedIndex > -1) s.SecilenAraSicak = cmbAraSicak.SelectedItem as AraSicak;
            if (cmbTatli.SelectedIndex > -1) s.SecilenTatli = cmbTatli.SelectedItem as Tatli;
            if (cmbIcecek.SelectedIndex > -1) s.SecilenIcecek = cmbIcecek.SelectedItem as Icecek;
            lstSiparisler.Items.Add(s);
        }

        private void btnCiro_Click(object sender, EventArgs e)
        {
            decimal ciro = 0;
            foreach (Siparis item in lstSiparisler.Items)
            {
                ciro += item.Fiyat;
            }
            MessageBox.Show($"Bugünün Ciorsu : {ciro:C2}");
        }

        private void btnResetle_Click(object sender, EventArgs e)
        {
            txtMasaNo.Clear();
            cmbAnaYemek.SelectedIndex = cmbAraSicak.SelectedIndex = cmbIcecek.SelectedIndex = cmbTatli.SelectedIndex = -1;
        }
    }
}
