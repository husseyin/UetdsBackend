using Business.Abstract.UetdsEsya;
using Business.Constans;
using Business.UetdsEsyaTest;
using DataAccess.Abstract.UetdsEsya;
using Entities.Concrete.UetdsEsya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.UetdsEsya
{
    public class EsyaSeferManager : IEsyaSeferService
    {
        uetdsYtsUser _uetdsYtsKullanici = new uetdsYtsUser() { kullaniciAdi = UetdsYtsKullanici.KullaniciAdi, sifre = UetdsYtsKullanici.Parola };

        IEsyaSeferDal _esyaSeferDal;

        public EsyaSeferManager(IEsyaSeferDal esyaSeferDal)
        {
            _esyaSeferDal = esyaSeferDal;
        }

        public void Add(EsyaSeferler esyaSeferler)
        {
            _esyaSeferDal.Add(esyaSeferler);
        }

        public uetdsMesSorguSonuc EsyaMeslekiYeterlilik(string tc)
        {
            return UetdsEsyaBaglanti.Baglanti().meslekiYeterlilikSorgula(_uetdsYtsKullanici, tc);
        }

        public uetdsGenelIslemSonuc EsyaSeferAktif(long esyaSeferId)
        {
            var result = UetdsEsyaBaglanti.Baglanti().seferAktifEtV3(_uetdsYtsKullanici, esyaSeferId);
            if (result.sonucKodu == 0)
            {
                var esyaSefer = _esyaSeferDal.Get(s => s.SeferId == esyaSeferId);
                esyaSefer.AktifIptal = "AKTIF";
                esyaSefer.IptalKodu = null;
                esyaSefer.IptalAciklama = null;

                _esyaSeferDal.Update(esyaSefer);
            }

            return result;
        }

        public uetdsGenelIslemSonuc EsyaSeferDuzenle(long esyaSeferId, EsyaSeferler esyaSeferler)
        {
            uetdsEsyaSeferBilgileriInputV3 uetdsEsyaSeferBilgileriInputV3 = new uetdsEsyaSeferBilgileriInputV3()
            {
                baslangicSaati = esyaSeferler.BaslangicSaati,
                baslangicTarihi = esyaSeferler.BaslangicTarihi,
                bitisSaati = esyaSeferler.BitisSaati,
                bitisTarihi = esyaSeferler.BitisTarihi,
                firmaSeferNo = esyaSeferler.FirmaSeferNo,
                plaka1 = esyaSeferler.Plaka1,
                plaka2 = esyaSeferler.Plaka2,
                sofor1TCNo = esyaSeferler.Sofor1TCNo,
                sofor2TCNo = esyaSeferler.Sofor2TCNo
            };

            var result = UetdsEsyaBaglanti.Baglanti().seferDuzenleV3(_uetdsYtsKullanici, esyaSeferId, uetdsEsyaSeferBilgileriInputV3);
            if (result.sonucKodu == 0)
            {
                var esyaSefer = _esyaSeferDal.Get(s => s.SeferId == esyaSeferId);
                esyaSefer.BaslangicSaati = esyaSeferler.BaslangicSaati;
                esyaSefer.BaslangicTarihi = esyaSeferler.BaslangicTarihi;
                esyaSefer.BitisSaati = esyaSeferler.BitisSaati;
                esyaSefer.BitisTarihi = esyaSeferler.BitisTarihi;
                esyaSefer.FirmaSeferNo = esyaSeferler.FirmaSeferNo;
                esyaSefer.Plaka1 = esyaSeferler.Plaka1;
                esyaSefer.Plaka2 = esyaSeferler.Plaka2;
                esyaSefer.Sofor1TCNo = esyaSeferler.Sofor1TCNo;
                esyaSefer.Sofor2TCNo = esyaSeferler.Sofor2TCNo;

                _esyaSeferDal.Update(esyaSefer);
            }

            return result;
        }

        public uetdsEsyaSeferEkleSonucV3 EsyaSeferEkle(EsyaSeferler esyaSeferler)
        {
            uetdsEsyaSeferBilgileriInputV3 uetdsEsyaSeferBilgileriInputV3 = new uetdsEsyaSeferBilgileriInputV3()
            {
                baslangicSaati = esyaSeferler.BaslangicSaati,
                baslangicTarihi = esyaSeferler.BaslangicTarihi,
                bitisSaati = esyaSeferler.BitisSaati,
                bitisTarihi = esyaSeferler.BitisTarihi,
                firmaSeferNo = esyaSeferler.FirmaSeferNo,
                plaka1 = esyaSeferler.Plaka1,
                plaka2 = esyaSeferler.Plaka2,
                sofor1TCNo = esyaSeferler.Sofor1TCNo,
                sofor2TCNo = esyaSeferler.Sofor2TCNo
            };

            var result = UetdsEsyaBaglanti.Baglanti().yeniSeferEkleV3(_uetdsYtsKullanici, uetdsEsyaSeferBilgileriInputV3);
            if (result.sonucKodu == 0)
            {
                esyaSeferler.SeferId = result.seferId;
                esyaSeferler.AktifIptal = "AKTIF";

                _esyaSeferDal.Add(esyaSeferler);
            }

            return result;
        }

        public uetdsGenelIslemSonuc EsyaSeferIptal(long esyaSeferId, string esyaIptalKodu, string esyaIptalAciklama)
        {
            var result = UetdsEsyaBaglanti.Baglanti().seferIptalEtV3(_uetdsYtsKullanici, esyaSeferId, esyaIptalKodu, esyaIptalAciklama);
            if (result.sonucKodu == 0)
            {
                var esyaSefer = _esyaSeferDal.Get(s => s.SeferId == esyaSeferId);
                esyaSefer.AktifIptal = "IPTAL";
                esyaSefer.IptalKodu = esyaIptalKodu;
                esyaSefer.IptalAciklama = esyaIptalAciklama;

                _esyaSeferDal.Update(esyaSefer);
            }

            return result;
        }

        public paramIptalTurListesi[] EsyaSeferIptalTurleri()
        {
            return UetdsEsyaBaglanti.Baglanti().seferIptalTurleri(_uetdsYtsKullanici).iptalTuruListesi;
        }

        public uetdsGenelPdfSonuc EsyaSeferPDF(long esyaSeferId)
        {
            return UetdsEsyaBaglanti.Baglanti().seferRaporuV3(_uetdsYtsKullanici, esyaSeferId);
        }

        public uetdsFirmaSonuc EsyaYetkiBelgesi(string plaka)
        {
            return UetdsEsyaBaglanti.Baglanti().yetkiBelgesiKontrol(_uetdsYtsKullanici, plaka);
        }

        public List<EsyaSeferler> GetAll()
        {
            return _esyaSeferDal.GetAll().ToList();
        }

        public void Update(EsyaSeferler esyaSeferler)
        {
            _esyaSeferDal.Update(esyaSeferler);
        }
    }
}
