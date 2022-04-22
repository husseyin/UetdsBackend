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
using System.Threading.Tasks;
using System.Web.Http;

namespace UetdsAPI.Controllers.UetdsArizi
{
    public class AriziGruplarController : ApiController
    {
        IAriziGrupService _ariziGrupService;

        public AriziGruplarController(IAriziGrupService ariziGrupService)
        {
            _ariziGrupService = ariziGrupService;
        }

        [HttpPost]
        [ActionName("arizigrupekle")]
        public uetdsAriziGrupIslemSonuc AriziGrupEkle(long ariziSeferNo, AriziGruplar ariziGruplar)
        {
            return _ariziGrupService.AriziGrupEkle(ariziSeferNo, ariziGruplar);
        }

        [HttpPost]
        [ActionName("arizigrupguncelle")]
        public uetdsAriziGrupIslemSonuc AriziGrupGuncelle(long ariziSeferNo, long ariziGrupId, AriziGruplar ariziGruplar)
        {
            return _ariziGrupService.AriziGrupGuncelle(ariziSeferNo, ariziGrupId, ariziGruplar);
        }

        [HttpGet]
        [ActionName("arizigrupiptal")]
        public uetdsGenelIslemSonuc AriziGrupIptal(long ariziSeferNo, long ariziGrupId, string ariziIptalAciklama)
        {
            return _ariziGrupService.AriziGrupIptal(ariziSeferNo, ariziGrupId, ariziIptalAciklama);
        }

        [HttpGet]
        [ActionName("getall")]
        public List<AriziGruplar> GetAll()
        {
            return _ariziGrupService.GetAll();
        }

        [HttpGet]
        [ActionName("getallbyariziseferno")]
        public List<AriziGruplar> GetAllByAriziSeferNo(long ariziSeferNo)
        {
            return _ariziGrupService.GetAllByAriziSeferNo(ariziSeferNo);
        }

        [HttpGet]
        [ActionName("arizigrupdetay")]
        public List<AriziGrupDto> AriziGrupDetay()
        {
            return _ariziGrupService.AriziGrupDetay();
        }

        [HttpGet]
        [ActionName("arizigrupdetaybyseferno")]
        public List<AriziGrupDto> AriziGrupDetayBySeferNo(long ariziSeferNo)
        {
            return _ariziGrupService.AriziGrupDetayBySeferNo(ariziSeferNo);
        }

        [HttpGet]
        [ActionName("arizigruplistele")]
        public Task<uetdsAriziGrupIslemSonuc> AriziGrupListeleAsync(long ariziSeferNo)
        {
            return _ariziGrupService.AriziGrupListeleAsync(ariziSeferNo);
        }

        [HttpGet]
        [ActionName("iller")]
        public List<Iller> Iller()
        {
            return _ariziGrupService.Iller();
        }

        [HttpGet]
        [ActionName("ilcelerbyilkodu")]
        public List<Ilceler> IlcelerByIlKodu(int ilKodu)
        {
            return _ariziGrupService.IlcelerByIlKodu(ilKodu);
        }
    }
}
