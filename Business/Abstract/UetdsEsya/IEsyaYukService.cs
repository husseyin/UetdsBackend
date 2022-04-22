using Business.UetdsEsyaTest;
using Entities.Concrete;
using Entities.Concrete.UetdsEsya;
using Entities.DTO.UetdsEsya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.UetdsEsya
{
    public interface IEsyaYukService
    {
        List<EsyaYukler> GetAll();
        List<EsyaYukler> GetAllByEsyaSeferId(long esyaSeferId);
        List<EsyaYukDto> EsyaYukDetay();
        List<EsyaYukDto> EsyaYukDetayBySeferId(long esyaSeferId);
        void Add(EsyaYukler esyaYukler);
        void Update(EsyaYukler esyaYukler);
        uetdsEsyaYeniYukEkleSonucV3 EsyaYukEkle(long esyaSeferId, EsyaYukler esyaYukler);
        uetdsGenelIslemSonuc EsyaYukDuzenle(long esyaYukId, EsyaYukler esyaYukler);
        paramIptalTurListesi[] EsyaYukIptalTurleri();
        uetdsGenelIslemSonuc EsyaYukIptal(long esyaYukId, string esyaIptalKodu, string esyaIptalAciklama);
        uetdsGenelIslemSonuc EsyaYukAktif(long esyaYukId);
        List<EsyaTasimaTurleri> EsyaTasimaTurleri();
        List<EsyaTehlikeliTasimaSekilleri> EsyaTehlikeliTasimaSekilleri();
        List<EsyaYukTurleri> EsyaYukTurleri();
        List<EsyaYukBirimleri> EsyaYukBirimleri();
        List<Iller> Iller();
        List<Ilceler> IlcelerByIlKodu(int ilKodu);
        List<EsyaUnDto> EsyaUnDetay();
    }
}
