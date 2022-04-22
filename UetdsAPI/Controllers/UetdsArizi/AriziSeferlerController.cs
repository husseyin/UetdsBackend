using Business.Abstract.UetdsArizi;
using Business.Concrete;
using Business.UetdsAriziTest;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Concrete.UetdsArizi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UetdsAPI.Controllers.UetdsArizi
{
    public class AriziSeferlerController : ApiController
    {
        IAriziSeferService _ariziSeferService;

        public AriziSeferlerController(IAriziSeferService ariziSeferService)
        {
            _ariziSeferService = ariziSeferService;
        }

        [HttpPost]
        [ActionName("ariziseferekle")]
        public uetdsAriziSeferBildirSonuc AriziSeferEkle(AriziSeferler ariziSeferler)
        {
            return _ariziSeferService.AriziSeferEkle(ariziSeferler);
        }

        [HttpPost]
        [ActionName("ariziseferguncelle")]
        public uetdsTarifeliSeferBildirSonuc AriziSeferGuncelle(long ariziSeferNo, AriziSeferler ariziSeferler)
        {
            return _ariziSeferService.AriziSeferGuncelle(ariziSeferNo, ariziSeferler);
        }

        [HttpGet]
        [ActionName("ariziseferaktif")]
        public uetdsGenelIslemSonuc AriziSeferAktif(long ariziSeferNo, string ariziAktifAciklama)
        {
            return _ariziSeferService.AriziSeferAktif(ariziSeferNo, ariziAktifAciklama);
        }

        [HttpGet]
        [ActionName("ariziseferpasif")]
        public uetdsGenelIslemSonuc AriziSeferPasif(long ariziSeferNo, string ariziPasifAciklama)
        {
            return _ariziSeferService.AriziSeferPasif(ariziSeferNo, ariziPasifAciklama);
        }        

        [HttpGet]
        [ActionName("ariziseferpdf")]
        public uetdsGenelPdfSonuc AriziSeferPDF(long ariziSeferNo)
        {
            return _ariziSeferService.AriziSeferPDF(ariziSeferNo);
        }

        [HttpGet]
        [ActionName("getall")]
        public List<AriziSeferler> GetAll()
        {
            return _ariziSeferService.GetAll();
        }
    }
}
