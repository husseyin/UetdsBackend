using Business.UetdsAriziTest;
using Entities.Concrete;
using Entities.Concrete.UetdsArizi;
using Entities.DTO.UetdsArizi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.UetdsArizi
{
    public interface IAriziGrupService
    {
        List<AriziGruplar> GetAll();
        List<AriziGruplar> GetAllByAriziSeferNo(long ariziSeferNo);
        List<AriziGrupDto> AriziGrupDetay();
        List<AriziGrupDto> AriziGrupDetayBySeferNo(long ariziSeferNo);
        void Add(AriziGruplar ariziGruplar);
        void Update(AriziGruplar ariziGruplar);
        uetdsAriziGrupIslemSonuc AriziGrupEkle(long ariziSeferNo, AriziGruplar ariziGruplar);
        uetdsAriziGrupIslemSonuc AriziGrupGuncelle(long ariziSeferNo, long ariziGrupId, AriziGruplar ariziGruplar);
        uetdsGenelIslemSonuc AriziGrupIptal(long ariziSeferNo, long ariziGrupId, string ariziIptalAciklama);
        Task<uetdsAriziGrupIslemSonuc> AriziGrupListeleAsync(long ariziSeferNo);
        List<Iller> Iller();
        List<Ilceler> IlcelerByIlKodu(int ilKodu);
    }
}
