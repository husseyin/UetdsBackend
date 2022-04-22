using Business.Abstract.UetdsEsya;
using Business.Constans;
using Business.UetdsEsyaTest;
using DataAccess.Abstract;
using DataAccess.Abstract.UetdsEsya;
using Entities.Concrete;
using Entities.Concrete.UetdsEsya;
using Entities.DTO.UetdsEsya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.UetdsEsya
{
    public class EsyaYukManager : IEsyaYukService
    {
        uetdsYtsUser _uetdsYtsKullanici = new uetdsYtsUser() { kullaniciAdi = UetdsYtsKullanici.KullaniciAdi, sifre = UetdsYtsKullanici.Parola };

        IEsyaYukDal _esyaYukDal;
        IEsyaTasimaTurleriDal _esyaTasimaTurleriDal;
        IEsyaTehlikeliTasimaSekilleriDal _esyaTehlikeliTasimaSekilleriDal;
        IEsyaYukTurleriDal _esyaYukTurleriDal;
        IEsyaYukBirimleriDal _esyaYukBirimleriDal;
        IEsyaUnDal _esyaUnDal;
        IIlceDal _ilceDal;
        IIlDal _ilDal;


        public EsyaYukManager(IEsyaYukDal esyaYukDal, IEsyaTasimaTurleriDal esyaTasimaTurleriDal, IEsyaTehlikeliTasimaSekilleriDal esyaTehlikeliTasimaSekilleriDal, IEsyaYukTurleriDal esyaYukTurleriDal, IEsyaYukBirimleriDal esyaYukBirimleriDal, IEsyaUnDal esyaUnDal, IIlceDal ilceDal, IIlDal ilDal)
        {
            _esyaYukDal = esyaYukDal;
            _esyaTasimaTurleriDal = esyaTasimaTurleriDal;
            _esyaTehlikeliTasimaSekilleriDal = esyaTehlikeliTasimaSekilleriDal;
            _esyaYukTurleriDal = esyaYukTurleriDal;
            _esyaYukBirimleriDal = esyaYukBirimleriDal;
            _esyaUnDal = esyaUnDal;
            _ilceDal = ilceDal;
            _ilDal = ilDal;
        }

        public void Add(EsyaYukler esyaYukler)
        {
            _esyaYukDal.Add(esyaYukler);
        }

        public List<EsyaTasimaTurleri> EsyaTasimaTurleri()
        {
            return _esyaTasimaTurleriDal.GetAll().ToList();
        }

        public List<EsyaTehlikeliTasimaSekilleri> EsyaTehlikeliTasimaSekilleri()
        {
            return _esyaTehlikeliTasimaSekilleriDal.GetAll().ToList();
        }

        public List<EsyaUnDto> EsyaUnDetay()
        {
            return _esyaUnDal.EsyaUnDetay().ToList();
        }

        public uetdsGenelIslemSonuc EsyaYukAktif(long esyaYukId)
        {
            var result = UetdsEsyaBaglanti.Baglanti().yukAktifEtV3(_uetdsYtsKullanici, esyaYukId);
            if (result.sonucKodu == 0)
            {
                var esyaYuk = _esyaYukDal.Get(s => s.YukId == esyaYukId);
                esyaYuk.AktifIptal = "AKTIF";
                esyaYuk.IptalKodu = null;
                esyaYuk.IptalAciklama = null;

                _esyaYukDal.Update(esyaYuk);
            }

            return result;
        }

        public List<EsyaYukBirimleri> EsyaYukBirimleri()
        {
            return _esyaYukBirimleriDal.GetAll().ToList();
        }

        public List<EsyaYukDto> EsyaYukDetay()
        {
            return _esyaYukDal.EsyaYukDetay().ToList();
        }

        public List<EsyaYukDto> EsyaYukDetayBySeferId(long esyaSeferId)
        {
            return _esyaYukDal.EsyaYukDetay(e => e.SeferId == esyaSeferId);
        }

        public uetdsGenelIslemSonuc EsyaYukDuzenle(long esyaYukId, EsyaYukler esyaYukler)
        {
            uetdsEsyaYukBilgileriInputV3 uetdsEsyaYukBilgileriInputV3 = new uetdsEsyaYukBilgileriInputV3()
            {
                aliciUnvan = esyaYukler.AliciUnvan,
                aliciVergiNo = esyaYukler.AliciVergiNo,
                bosaltmaIlceMernisKodu = esyaYukler.BosaltmaIlceMernisKodu.ToString(),
                bosaltmaIlMernisKodu = esyaYukler.BosaltmaIlMernisKodu.ToString(),
                bosaltmaSaati = esyaYukler.BosaltmaSaati,
                bosaltmaTarihi = esyaYukler.BosaltmaTarihi,
                bosaltmaUlkeKodu = esyaYukler.BosaltmaUlkeKodu,
                firmaYukNo = esyaYukler.FirmaYukNo,
                gonderenUnvan = esyaYukler.GonderenUnvan,
                gonderenVergiNo = esyaYukler.GonderenVergiNo,
                muafiyetTuru = esyaYukler.MuafiyetTuru,
                tasimaTuruKodu = esyaYukler.TasimaTuruKodu.ToString(),
                tehlikeliMaddeTasimaSekli = esyaYukler.TehlikeliMaddeTasimaKodu.ToString(),
                unId = esyaYukler.UnId,
                yukCinsDigerAciklama = esyaYukler.YukCinsDigerAciklama,
                yukCinsId = esyaYukler.YukCinsId.ToString(),
                yuklemeIlceMernisKodu = esyaYukler.YuklemeIlceMernisKodu.ToString(),
                yuklemeIlMernisKodu = esyaYukler.YuklemeIlMernisKodu.ToString(),
                yuklemeSaati = esyaYukler.YuklemeSaati,
                yuklemeTarihi = esyaYukler.YuklemeTarihi,
                yuklemeUlkeKodu = esyaYukler.YuklemeUlkeKodu,
                yukMiktari = esyaYukler.YukMiktari,
                yukMiktariBirimi = esyaYukler.YukMiktariBirimi
            };

            var result = UetdsEsyaBaglanti.Baglanti().yukDuzenleV3(_uetdsYtsKullanici, esyaYukId, uetdsEsyaYukBilgileriInputV3);
            if (result.sonucKodu == 0)
            {
                var esyaYuk = _esyaYukDal.Get(s => s.YukId == esyaYukId);
                esyaYuk.AliciUnvan = esyaYukler.AliciUnvan;
                esyaYuk.AliciVergiNo = esyaYukler.AliciVergiNo;
                esyaYuk.BosaltmaIlceMernisKodu = esyaYukler.BosaltmaIlceMernisKodu;
                esyaYuk.BosaltmaIlMernisKodu = esyaYukler.BosaltmaIlMernisKodu;
                esyaYuk.BosaltmaSaati = esyaYukler.BosaltmaSaati;
                esyaYuk.BosaltmaTarihi = esyaYukler.BosaltmaTarihi;
                esyaYuk.BosaltmaUlkeKodu = esyaYukler.BosaltmaUlkeKodu;
                esyaYuk.FirmaYukNo = esyaYukler.FirmaYukNo;
                esyaYuk.GonderenUnvan = esyaYukler.GonderenUnvan;
                esyaYuk.GonderenVergiNo = esyaYukler.GonderenVergiNo;
                esyaYuk.MuafiyetTuru = esyaYukler.MuafiyetTuru;
                esyaYuk.TasimaTuruKodu = esyaYukler.TasimaTuruKodu;
                esyaYuk.TehlikeliMaddeTasimaKodu = esyaYukler.TehlikeliMaddeTasimaKodu;
                esyaYuk.UnId = esyaYukler.UnId;
                esyaYuk.YukCinsDigerAciklama = esyaYukler.YukCinsDigerAciklama;
                esyaYuk.YukCinsId = esyaYukler.YukCinsId;
                esyaYuk.YuklemeIlceMernisKodu = esyaYukler.YuklemeIlceMernisKodu;
                esyaYuk.YuklemeIlMernisKodu = esyaYukler.YuklemeIlMernisKodu;
                esyaYuk.YuklemeSaati = esyaYukler.YuklemeSaati;
                esyaYuk.YuklemeTarihi = esyaYukler.YuklemeTarihi;
                esyaYuk.YuklemeUlkeKodu = esyaYukler.YuklemeUlkeKodu;
                esyaYuk.YukMiktari = esyaYukler.YukMiktari;
                esyaYuk.YukMiktariBirimi = esyaYukler.YukMiktariBirimi;

                _esyaYukDal.Update(esyaYuk);
            }

            return result;
        }

        public uetdsEsyaYeniYukEkleSonucV3 EsyaYukEkle(long esyaSeferId, EsyaYukler esyaYukler)
        {
            uetdsEsyaYukBilgileriInputV3 esyaYukBilgisi = new uetdsEsyaYukBilgileriInputV3()
            {
                aliciUnvan = esyaYukler.AliciUnvan,
                aliciVergiNo = esyaYukler.AliciVergiNo,
                bosaltmaIlceMernisKodu = esyaYukler.BosaltmaIlceMernisKodu.ToString(),
                bosaltmaIlMernisKodu = esyaYukler.BosaltmaIlMernisKodu.ToString(),
                bosaltmaSaati = esyaYukler.BosaltmaSaati,
                bosaltmaTarihi = esyaYukler.BosaltmaTarihi,
                bosaltmaUlkeKodu = esyaYukler.BosaltmaUlkeKodu,
                firmaYukNo = esyaYukler.FirmaYukNo,
                gonderenUnvan = esyaYukler.GonderenUnvan,
                gonderenVergiNo = esyaYukler.GonderenVergiNo,
                muafiyetTuru = esyaYukler.MuafiyetTuru,
                tasimaTuruKodu = esyaYukler.TasimaTuruKodu.ToString(),
                tehlikeliMaddeTasimaSekli = esyaYukler.TehlikeliMaddeTasimaKodu.ToString(),
                unId = esyaYukler.UnId,
                yukCinsDigerAciklama = esyaYukler.YukCinsDigerAciklama,
                yukCinsId = esyaYukler.YukCinsId.ToString(),
                yuklemeIlceMernisKodu = esyaYukler.YuklemeIlceMernisKodu.ToString(),
                yuklemeIlMernisKodu = esyaYukler.YuklemeIlMernisKodu.ToString(),
                yuklemeSaati = esyaYukler.YuklemeSaati,
                yuklemeTarihi = esyaYukler.YuklemeTarihi,
                yuklemeUlkeKodu = esyaYukler.YuklemeUlkeKodu,
                yukMiktari = esyaYukler.YukMiktari,
                yukMiktariBirimi = esyaYukler.YukMiktariBirimi
            };

            List<uetdsEsyaYukBilgileriInputV3> uetdsEsyaYukBilgileriInputV3 = new List<uetdsEsyaYukBilgileriInputV3>();
            uetdsEsyaYukBilgileriInputV3.Add(esyaYukBilgisi);

            var result = UetdsEsyaBaglanti.Baglanti().sefereYukEkleV3(_uetdsYtsKullanici, esyaSeferId, uetdsEsyaYukBilgileriInputV3.ToArray());
            if (result.sonucKodu == 0)
            {
                esyaYukler.YukId = result.uetdsEsyaSonuc[0].yukId;
                esyaYukler.SeferId = esyaSeferId;
                esyaYukler.AktifIptal = "AKTIF";

                _esyaYukDal.Add(esyaYukler);
            }

            return result;
        }

        public uetdsGenelIslemSonuc EsyaYukIptal(long esyaYukId, string esyaIptalKodu, string esyaIptalAciklama)
        {
            var result = UetdsEsyaBaglanti.Baglanti().yukIptalEtV3(_uetdsYtsKullanici, esyaYukId, esyaIptalKodu, esyaIptalAciklama);
            if (result.sonucKodu == 0)
            {
                var esyaYuk = _esyaYukDal.Get(s => s.YukId == esyaYukId);
                esyaYuk.AktifIptal = "IPTAL";
                esyaYuk.IptalKodu = esyaIptalKodu;
                esyaYuk.IptalAciklama = esyaIptalAciklama;

                _esyaYukDal.Update(esyaYuk);
            }

            return result;
        }

        public paramIptalTurListesi[] EsyaYukIptalTurleri()
        {
            return UetdsEsyaBaglanti.Baglanti().iptalTurleri(_uetdsYtsKullanici).iptalTuruListesi;
        }

        public List<EsyaYukTurleri> EsyaYukTurleri()
        {
            return _esyaYukTurleriDal.GetAll().ToList();
        }

        public List<EsyaYukler> GetAll()
        {
            return _esyaYukDal.GetAll().ToList();
        }

        public List<EsyaYukler> GetAllByEsyaSeferId(long esyaSeferId)
        {
            return _esyaYukDal.GetAll(e => e.SeferId == esyaSeferId).ToList();
        }

        public List<Ilceler> IlcelerByIlKodu(int ilKodu)
        {
            return _ilceDal.GetAll(i => i.IlKodu == ilKodu).ToList();
        }

        public List<Iller> Iller()
        {
            return _ilDal.GetAll().ToList();
        }

        public void Update(EsyaYukler esyaYukler)
        {
            _esyaYukDal.Update(esyaYukler);
        }
    }
}
