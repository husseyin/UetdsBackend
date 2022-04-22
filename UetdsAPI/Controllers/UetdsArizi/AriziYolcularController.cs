using Business.Abstract.UetdsArizi;
using Business.UetdsAriziTest;
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
    public class AriziYolcularController : ApiController
    {
        IAriziYolcuService _ariziYolcuService;

        public AriziYolcularController(IAriziYolcuService ariziYolcuService)
        {
            _ariziYolcuService = ariziYolcuService;
        }

        [HttpPost]
        [ActionName("ariziyolcuekle")]
        public uetdsAriziYolcuIslemSonuc AriziYolcuEkle(long ariziSeferNo, AriziYolcular ariziYolcular)
        {
            return _ariziYolcuService.AriziYolcuEkle(ariziSeferNo, ariziYolcular);
        }

        [HttpGet]
        [ActionName("ariziyolcuiptal")]
        public uetdsGenelIslemSonuc AriziYolcuIptal(long ariziSeferNo, long ariziYolcuNo, string ariziIptalAciklama)
        {
            return _ariziYolcuService.AriziYolcuIptal(ariziSeferNo, ariziYolcuNo, ariziIptalAciklama);
        }

        [HttpGet]
        [ActionName("getall")]
        public List<AriziYolcular> GetAll()
        {
            return _ariziYolcuService.GetAll();
        }

        [HttpGet]
        [ActionName("getallbyarizigrupno")]
        public List<AriziYolcular> GetAllByAriziGrupNo(long ariziGrupNo)
        {
            return _ariziYolcuService.GetAllByAriziGrupNo(ariziGrupNo);
        }
    }
}
