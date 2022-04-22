using Business.UetdsAriziTest;
using Entities.Concrete.UetdsArizi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.UetdsArizi
{
    public interface IAriziYolcuService
    {
        List<AriziYolcular> GetAll();
        List<AriziYolcular> GetAllByAriziGrupNo(long ariziGrupNo);
        void Add(AriziYolcular ariziYolcular);
        uetdsAriziYolcuIslemSonuc AriziYolcuEkle(long ariziSeferNo, AriziYolcular ariziYolcular);
        uetdsGenelIslemSonuc AriziYolcuIptal(long ariziSeferNo, long ariziYolcuNo, string ariziIptalAciklama);
    }
}
