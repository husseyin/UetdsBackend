using Business.UetdsAriziTest;
using Entities.Concrete.UetdsArizi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.UetdsArizi
{
    public interface IAriziSeferService
    {
        List<AriziSeferler> GetAll();
        void Add(AriziSeferler ariziSeferler);
        void Update(AriziSeferler ariziSeferler);
        uetdsAriziSeferBildirSonuc AriziSeferEkle(AriziSeferler ariziSeferler);
        uetdsTarifeliSeferBildirSonuc AriziSeferGuncelle(long ariziSeferNo, AriziSeferler ariziSeferler);
        uetdsGenelIslemSonuc AriziSeferPasif(long ariziSeferNo, string ariziPasifAciklama);
        uetdsGenelIslemSonuc AriziSeferAktif(long ariziSeferNo, string ariziAktifAciklama);
        uetdsGenelPdfSonuc AriziSeferPDF(long ariziSeferNo);
    }
}
