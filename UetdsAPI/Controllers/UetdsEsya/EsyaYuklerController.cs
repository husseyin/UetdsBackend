using Business.Abstract.UetdsEsya;
using Business.UetdsEsyaTest;
using Entities.Concrete;
using Entities.Concrete.UetdsEsya;
using Entities.DTO.UetdsEsya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UetdsAPI.Controllers.UetdsEsya
{
    public class EsyaYuklerController : ApiController
    {
        IEsyaYukService _esyaYukService;

        public EsyaYuklerController(IEsyaYukService esyaYukService)
        {
            _esyaYukService = esyaYukService;
        }

        [HttpPost]
        [ActionName("esyayukekle")]
        public uetdsEsyaYeniYukEkleSonucV3 EsyaYukEkle(long esyaSeferId, EsyaYukler esyaYukler)
        {
            return _esyaYukService.EsyaYukEkle(esyaSeferId, esyaYukler);
        }

        [HttpPost]
        [ActionName("esyayukduzenle")]
        public uetdsGenelIslemSonuc EsyaYukDuzenle(long esyaYukId, EsyaYukler esyaYukler)
        {
            return _esyaYukService.EsyaYukDuzenle(esyaYukId, esyaYukler);
        }

        [HttpGet]
        [ActionName("esyayukiptalturleri")]
        public paramIptalTurListesi[] EsyaYukIptalTurleri()
        {
            return _esyaYukService.EsyaYukIptalTurleri();
        }

        [HttpGet]
        [ActionName("esyayukiptal")]
        public uetdsGenelIslemSonuc EsyaYukIptal(long esyaYukId, string esyaIptalKodu, string esyaIptalAciklama)
        {
            return _esyaYukService.EsyaYukIptal(esyaYukId, esyaIptalKodu, esyaIptalAciklama);
        }

        [HttpGet]
        [ActionName("esyayukaktif")]
        public uetdsGenelIslemSonuc EsyaYukAktif(long esyaYukId)
        {
            return _esyaYukService.EsyaYukAktif(esyaYukId);
        }

        [HttpGet]
        [ActionName("getall")]
        public List<EsyaYukler> GetAll()
        {
            return _esyaYukService.GetAll();
        }

        [HttpGet]
        [ActionName("getallbyesyaseferid")]
        public List<EsyaYukler> GetAllByEsyaSeferId(long esyaSeferId)
        {
            return _esyaYukService.GetAllByEsyaSeferId(esyaSeferId);
        }

        [HttpGet]
        [ActionName("esyayukdetay")]
        public List<EsyaYukDto> EsyaYukDetay()
        {
            return _esyaYukService.EsyaYukDetay();
        }

        [HttpGet]
        [ActionName("esyayukdetaybyseferid")]
        public List<EsyaYukDto> EsyaYukDetayBySeferId(long esyaSeferId)
        {
            return _esyaYukService.EsyaYukDetayBySeferId(esyaSeferId);
        }

        [HttpGet]
        [ActionName("esyatasimaturleri")]
        public List<EsyaTasimaTurleri> EsyaTasimaTurleri()
        {
            return _esyaYukService.EsyaTasimaTurleri();            
        }

        [HttpGet]
        [ActionName("esyatehlikelitasimasekilleri")]
        public List<EsyaTehlikeliTasimaSekilleri> EsyaTehlikeliTasimaSekilleri()
        {
            return _esyaYukService.EsyaTehlikeliTasimaSekilleri();
        }

        [HttpGet]
        [ActionName("esyayukturleri")]
        public List<EsyaYukTurleri> EsyaYukTurleri()
        {
            return _esyaYukService.EsyaYukTurleri();
        }

        [HttpGet]
        [ActionName("esyayukbirimleri")]
        public List<EsyaYukBirimleri> EsyaYukBirimleri()
        {
            return _esyaYukService.EsyaYukBirimleri();
        }

        [HttpGet]
        [ActionName("iller")]
        public List<Iller> Iller()
        {
            return _esyaYukService.Iller();
        }

        [HttpGet]
        [ActionName("ilcelerbyilkodu")]
        public List<Ilceler> IlcelerByIlKodu(int ilKodu)
        {
            return _esyaYukService.IlcelerByIlKodu(ilKodu);
        }

        [HttpGet]
        [ActionName("esyaundetay")]
        public List<EsyaUnDto> EsyaUnDetay()
        {
            return _esyaYukService.EsyaUnDetay();
        }
    }
}
