using BilgeRestorant.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeRestorant.Models.Entities
{
    public class Siparis:BaseEntity
    {
        public Siparis(string masaNo)
        {
            Isim = masaNo;
        }
        //burda kullanabilmek icin alta cektik.
        public AnaYemek SecilenAnaYemek { get; set; }
        public AraSicak SecilenAraSicak { get; set; }
        public Icecek SecilenIcecek { get; set; }
        public Tatli SecilenTatli { get; set; }



        public void FiyatEkle(YemekCesitleri a)
        {
            switch (a)
            {
                case YemekCesitleri.AnaYemek:
                    Fiyat += SecilenAnaYemek.Fiyat;
                    break;
                case YemekCesitleri.AraSicak:
                    Fiyat += SecilenAraSicak.Fiyat;
                    break;
                case YemekCesitleri.Tatli:
                    Fiyat += SecilenTatli.Fiyat;
                    break;
                case YemekCesitleri.Icecek:
                    Fiyat += SecilenIcecek.Fiyat;
                    break;

            }
        }

        //tutar hesaplama eğer secilen "değil eşit boşa" fiyatekle içindeki yemekcesitleri içindeki anayemek.
        public decimal TutarHesapla()
        {
            if (SecilenAnaYemek != null) FiyatEkle(YemekCesitleri.AnaYemek);
            if (SecilenAraSicak != null) FiyatEkle(YemekCesitleri.AraSicak);
            if (SecilenIcecek != null) FiyatEkle(YemekCesitleri.Icecek);
            if (SecilenTatli != null) FiyatEkle(YemekCesitleri.Tatli);
            return Fiyat;
        }


        public override string ToString()
        {
            string siparisYazdir = null;
            if (SecilenAnaYemek != null) siparisYazdir += $"Ana Yemek : {SecilenAnaYemek.Isim} => Fiyatı : {SecilenAnaYemek.Fiyat},";
            if (SecilenAraSicak != null) siparisYazdir += $"Ara Sıcak : {SecilenAraSicak.Isim} => Fiyatı : {SecilenAraSicak.Fiyat},";
            if (SecilenIcecek != null) siparisYazdir += $"İçecek : {SecilenIcecek.Isim} => Fiyatı : {SecilenIcecek.Fiyat},";
            if (SecilenTatli != null) siparisYazdir += $"Tatlı : {SecilenTatli.Isim} => Fiyatı : {SecilenTatli.Fiyat},";
            return $"{Isim} ->  {siparisYazdir}  Siparisin Toplam tutari {TutarHesapla():C2}";
        }
    }
}
