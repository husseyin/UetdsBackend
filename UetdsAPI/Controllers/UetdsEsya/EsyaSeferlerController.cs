using Business.Abstract.UetdsEsya;
using Business.UetdsEsyaTest;
using Entities.Concrete.UetdsEsya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UetdsAPI.Controllers.UetdsEsya
{
    public class EsyaSeferlerController : ApiController
    {
        IEsyaSeferService _esyaSeferService;

        public EsyaSeferlerController(IEsyaSeferService esyaSeferService)
        {
            _esyaSeferService = esyaSeferService;
        }

        [HttpPost]
        [ActionName("esyaseferekle")]
        public uetdsEsyaSeferEkleSonucV3 EsyaSeferEkle(EsyaSeferler esyaSeferler)
        {
            return _esyaSeferService.EsyaSeferEkle(esyaSeferler);
        }

        [HttpPost]
        [ActionName("esyaseferduzenle")]
        public uetdsGenelIslemSonuc EsyaSeferDuzenle(long esyaSeferId, EsyaSeferler esyaSeferler)
        {
            return _esyaSeferService.EsyaSeferDuzenle(esyaSeferId, esyaSeferler);
        }

        [HttpGet]
        [ActionName("esyaseferiptalturleri")]
        public paramIptalTurListesi[] EsyaSeferIptalTurleri()
        {
            return _esyaSeferService.EsyaSeferIptalTurleri();
        }

        [HttpGet]
        [ActionName("esyaseferiptal")]
        public uetdsGenelIslemSonuc EsyaSeferIptal(long esyaSeferId, string esyaIptalKodu, string esyaIptalAciklama)
        {
            return _esyaSeferService.EsyaSeferIptal(esyaSeferId, esyaIptalKodu, esyaIptalAciklama);
        }

        [HttpGet]
        [ActionName("esyaseferaktif")]
        public uetdsGenelIslemSonuc EsyaSeferAktif(long esyaSeferId)
        {
            return _esyaSeferService.EsyaSeferAktif(esyaSeferId);
        }

        [HttpGet]
        [ActionName("esyameslekiyeterlilik")]
        public uetdsMesSorguSonuc EsyaMeslekiYeterlilik(string tc)
        {
            return _esyaSeferService.EsyaMeslekiYeterlilik(tc);
        }

        [HttpGet]
        [ActionName("esyayetkibelgesi")]
        public uetdsFirmaSonuc EsyaYetkiBelgesi(string plaka)
        {
            return _esyaSeferService.EsyaYetkiBelgesi(plaka);
        }

        [HttpGet]
        [ActionName("esyaseferpdf")]
        public uetdsGenelPdfSonuc EsyaSeferPDF(long esyaSeferId)
        {
            return _esyaSeferService.EsyaSeferPDF(esyaSeferId);
        }

        [HttpGet]
        [ActionName("getall")]
        public List<EsyaSeferler> GetAll()
        {
            return _esyaSeferService.GetAll();
        }
    }
}
