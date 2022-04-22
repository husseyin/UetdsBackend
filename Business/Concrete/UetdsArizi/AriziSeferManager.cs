using Business.Abstract.UetdsArizi;
using Business.Constans;
using Business.UetdsAriziTest;
using DataAccess.Abstract.UetdsArizi;
using DataAccess.Concrete;
using Entities.Concrete.UetdsArizi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.UetdsArizi
{
    public class AriziSeferManager : IAriziSeferService
    {
        uetdsYtsUser _uetdsYtsKullanici = new uetdsYtsUser() { kullaniciAdi = UetdsYtsKullanici.KullaniciAdi, sifre = UetdsYtsKullanici.Parola };

        IAriziSeferDal _ariziSeferDal;

        public AriziSeferManager(IAriziSeferDal ariziSeferDal)
        {
            _ariziSeferDal = ariziSeferDal;
        }

        public void Add(AriziSeferler ariziSeferler)
        {
            _ariziSeferDal.Add(ariziSeferler);
        }

        public uetdsGenelIslemSonuc AriziSeferAktif(long ariziSeferNo, string ariziAktifAciklama)
        {
            var result = UetdsAriziBaglanti.Baglanti().seferAktif(_uetdsYtsKullanici, ariziSeferNo, true, ariziAktifAciklama);
            if (result.sonucKodu == 0)
            {
                var ariziSefer = _ariziSeferDal.Get(s => s.UetdsSeferReferansNo == ariziSeferNo);
                ariziSefer.AktifPasif = "AKTIF";
                ariziSefer.AktifPasifAciklama = ariziAktifAciklama;

                _ariziSeferDal.Update(ariziSefer);
            }

            return result;
        }

        public uetdsAriziSeferBildirSonuc AriziSeferEkle(AriziSeferler ariziSeferler)
        {
            uetdsAriziSeferBilgileriInput uetdsAriziSeferBilgileriInput = new uetdsAriziSeferBilgileriInput()
            {
                aracPlaka = ariziSeferler.AracPlaka,
                aracTelefonu = ariziSeferler.AracTelefonu,
                firmaSeferNo = ariziSeferler.FirmaSeferNo,
                hareketSaati = ariziSeferler.HareketSaati,
                hareketTarihi = ariziSeferler.HareketTarihi,
                seferAciklama = ariziSeferler.SeferAciklama,
                seferBitisSaati = ariziSeferler.SeferBitisSaati,
                seferBitisTarihi = ariziSeferler.SeferBitisTarihi
            };

            var result = UetdsAriziBaglanti.Baglanti().seferEkle(_uetdsYtsKullanici, uetdsAriziSeferBilgileriInput);
            if (result.sonucKodu == 0)
            {
                ariziSeferler.UetdsSeferReferansNo = result.uetdsSeferReferansNo;
                ariziSeferler.AktifPasif = "AKTIF";

                _ariziSeferDal.Add(ariziSeferler);
            }

            return result;
        }

        public uetdsTarifeliSeferBildirSonuc AriziSeferGuncelle(long ariziSeferNo, AriziSeferler ariziSeferler)
        {
            uetdsAriziSeferBilgileriInput uetdsAriziSeferBilgileriInput = new uetdsAriziSeferBilgileriInput()
            {
                aracPlaka = ariziSeferler.AracPlaka,
                aracTelefonu = ariziSeferler.AracTelefonu,
                firmaSeferNo = ariziSeferler.FirmaSeferNo,
                hareketSaati = ariziSeferler.HareketSaati,
                hareketTarihi = ariziSeferler.HareketTarihi,
                seferAciklama = ariziSeferler.SeferAciklama,
                seferBitisSaati = ariziSeferler.SeferBitisSaati,
                seferBitisTarihi = ariziSeferler.SeferBitisTarihi
            };

            var result = UetdsAriziBaglanti.Baglanti().seferGuncelle(_uetdsYtsKullanici, ariziSeferNo, true, uetdsAriziSeferBilgileriInput);
            if (result.sonucKodu == 0)
            {
                var ariziSefer = _ariziSeferDal.Get(s => s.UetdsSeferReferansNo == ariziSeferNo);
                ariziSefer.AracPlaka = ariziSeferler.AracPlaka;
                ariziSefer.AracTelefonu = ariziSeferler.AracTelefonu;
                ariziSefer.FirmaSeferNo = ariziSeferler.FirmaSeferNo;
                ariziSefer.HareketSaati = ariziSeferler.HareketSaati;
                ariziSefer.HareketTarihi = ariziSeferler.HareketTarihi;
                ariziSefer.SeferAciklama = ariziSeferler.SeferAciklama;
                ariziSefer.SeferBitisSaati = ariziSeferler.SeferBitisSaati;
                ariziSefer.SeferBitisTarihi = ariziSeferler.SeferBitisTarihi;
                ariziSefer.UetdsSeferReferansNo = result.uetdsSeferReferansNo;

                _ariziSeferDal.Update(ariziSefer);
            }

            return result;
        }

        public uetdsGenelIslemSonuc AriziSeferPasif(long ariziSeferNo, string ariziPasifAciklama)
        {
            var result = UetdsAriziBaglanti.Baglanti().seferIptal(_uetdsYtsKullanici, ariziSeferNo, true, ariziPasifAciklama);
            if (result.sonucKodu == 0)
            {
                var ariziSefer = _ariziSeferDal.Get(s => s.UetdsSeferReferansNo == ariziSeferNo);
                ariziSefer.AktifPasif = "PASIF";
                ariziSefer.AktifPasifAciklama = ariziPasifAciklama;

                _ariziSeferDal.Update(ariziSefer);
            }

            return result;
        }

        public uetdsGenelPdfSonuc AriziSeferPDF(long ariziSeferNo)
        {
            return UetdsAriziBaglanti.Baglanti().seferDetayCiktisiAl(_uetdsYtsKullanici, ariziSeferNo, true);
        }

        public List<AriziSeferler> GetAll()
        {
            return _ariziSeferDal.GetAll().ToList();
        }

        public void Update(AriziSeferler ariziSeferler)
        {
            _ariziSeferDal.Update(ariziSeferler);
        }
    }
}
