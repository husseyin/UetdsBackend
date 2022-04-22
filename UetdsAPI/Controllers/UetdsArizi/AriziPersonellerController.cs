using Business.Abstract.UetdsArizi;
using Business.Concrete;
using Business.UetdsAriziTest;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Concrete.UetdsArizi;
using Entities.DTO.UetdsArizi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UetdsAPI.Controllers.UetdsArizi
{
    public class AriziPersonellerController : ApiController
    {
        IAriziPersonelService _ariziPersonelService;

        public AriziPersonellerController(IAriziPersonelService ariziPersonelService)
        {
            _ariziPersonelService = ariziPersonelService;
        }

        [HttpPost]
        [ActionName("arizipersonelekle")]
        public uetdsGenelIslemSonuc AriziPersonelEkle(long ariziSeferNo, AriziPersoneller ariziPersoneller)
        {
            return _ariziPersonelService.AriziPersonelEkle(ariziSeferNo, ariziPersoneller);
        }

        [HttpGet]
        [ActionName("arizipersoneliptal")]
        public uetdsGenelIslemSonuc AriziPersonelIptal(string ariziTcPasaportNo, string ariziIptalAciklama)
        {
            return _ariziPersonelService.AriziPersonelIptal(ariziTcPasaportNo, ariziIptalAciklama);
        }        

        [HttpGet]
        [ActionName("getall")]
        public List<AriziPersoneller> GetAll()
        {
            return _ariziPersonelService.GetAll();
        }

        [HttpGet]
        [ActionName("arizipersonelturleri")]
        public List<AriziPersonelTurleri> AriziPersonelTurleri()
        {
            return _ariziPersonelService.AriziPersonelTurleri();
        }

        [HttpGet]
        [ActionName("arizipersoneldetay")]
        public List<AriziPersonelDto> AriziPersonelDetay()
        {
            return _ariziPersonelService.AriziPersonelDetay();
        }

        [HttpGet]
        [ActionName("arizipersoneldetaybyseferno")]
        public List<AriziPersonelDto> AriziPersonelDetayBySeferNo(long ariziSeferNo)
        {
            return _ariziPersonelService.AriziPersonelDetayBySeferNo(ariziSeferNo);
        }
    }
}
