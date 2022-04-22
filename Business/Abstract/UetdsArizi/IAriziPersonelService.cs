using Business.UetdsAriziTest;
using Entities.Concrete.UetdsArizi;
using Entities.DTO.UetdsArizi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.UetdsArizi
{
    public interface IAriziPersonelService
    {
        List<AriziPersoneller> GetAll();
        List<AriziPersonelDto> AriziPersonelDetay();
        List<AriziPersonelDto> AriziPersonelDetayBySeferNo(long ariziSeferNo);
        List<AriziPersonelTurleri> AriziPersonelTurleri();
        void Add(AriziPersoneller ariziPersoneller);
        uetdsGenelIslemSonuc AriziPersonelEkle(long ariziSeferNo, AriziPersoneller ariziPersoneller);
        uetdsGenelIslemSonuc AriziPersonelIptal(string ariziTcPasaportNo, string ariziIptalAciklama);
    }
}
