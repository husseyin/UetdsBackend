using Business.UetdsEsyaTest;
using Entities.Concrete.UetdsEsya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.UetdsEsya
{
    public interface IEsyaSeferService
    {
        List<EsyaSeferler> GetAll();
        void Add(EsyaSeferler esyaSeferler);
        void Update(EsyaSeferler esyaSeferler);
        uetdsEsyaSeferEkleSonucV3 EsyaSeferEkle(EsyaSeferler esyaSeferler);
        uetdsGenelIslemSonuc EsyaSeferDuzenle(long esyaSeferId, EsyaSeferler esyaSeferler);
        paramIptalTurListesi[] EsyaSeferIptalTurleri();
        uetdsGenelIslemSonuc EsyaSeferIptal(long esyaSeferId, string esyaIptalKodu, string esyaIptalAciklama);
        uetdsGenelIslemSonuc EsyaSeferAktif(long esyaSeferId);
        uetdsMesSorguSonuc EsyaMeslekiYeterlilik(string tc);
        uetdsFirmaSonuc EsyaYetkiBelgesi(string plaka);
        uetdsGenelPdfSonuc EsyaSeferPDF(long esyaSeferId);
    }
}
