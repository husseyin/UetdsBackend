using Core.DataAccess;
using DataAccess.Abstract.UetdsEsya;
using DataAccess.Concrete.Contexts;
using Entities.Concrete.UetdsEsya;
using Entities.DTO.UetdsEsya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.UetdsEsya
{
    public class EfEsyaYukDal : EfEntityRepository<EsyaYukler, UetdsContext>, IEsyaYukDal
    {
        public List<EsyaYukDto> EsyaYukDetay(Expression<Func<EsyaYukDto, bool>> filter = null)
        {
            using (UetdsContext context = new UetdsContext())
            {
                var result = from yuk in context.EsyaYukler
                             join bsil in context.Iller
                             on yuk.YuklemeIlMernisKodu equals bsil.IlKodu
                             join btil in context.Iller
                             on yuk.BosaltmaIlMernisKodu equals btil.IlKodu
                             join bsilc in context.Ilceler
                             on yuk.YuklemeIlceMernisKodu equals bsilc.IlceKodu
                             join btilc in context.Ilceler
                             on yuk.BosaltmaIlceMernisKodu equals btilc.IlceKodu
                             join tur in context.EsyaTasimaTurleri
                             on yuk.TasimaTuruKodu equals tur.Kodu
                             join cins in context.EsyaYukTurleri
                             on yuk.YukCinsId equals cins.TipId
                             join birm in context.EsyaYukBirimleri
                             on yuk.YukMiktariBirimi equals birm.Kodu
                             join tehse in context.EsyaTehlikeliTasimaSekilleri
                             on yuk.TehlikeliMaddeTasimaKodu equals tehse.Kodu into temp
                             from yuktehse in temp.DefaultIfEmpty()
                             orderby yuk.Id

                             select new EsyaYukDto
                             {
                                 AktifIptal = yuk.AktifIptal,
                                 AliciUnvan = yuk.AliciUnvan,
                                 AliciVergiNo = yuk.AliciVergiNo,
                                 BosaltmaIlceMernisAdi = btilc.IlceAdi,
                                 BosaltmaIlceMernisKodu = btilc.IlceKodu,
                                 BosaltmaIlMernisAdi = btil.IlAdi,
                                 BosaltmaIlMernisKodu = btilc.IlKodu,
                                 BosaltmaSaati = yuk.BosaltmaSaati,
                                 BosaltmaTarihi = yuk.BosaltmaTarihi,
                                 BosaltmaUlkeKodu = yuk.BosaltmaUlkeKodu,
                                 FirmaYukNo = yuk.FirmaYukNo,
                                 GonderenUnvan = yuk.GonderenUnvan,
                                 GonderenVergiNo = yuk.GonderenVergiNo,
                                 Id = yuk.Id,
                                 IptalAciklama = yuk.IptalAciklama,
                                 IptalKodu = yuk.IptalKodu,
                                 MuafiyetTuru = yuk.MuafiyetTuru,
                                 SeferId = yuk.SeferId,
                                 TasimaTuru = tur.Aciklama,
                                 TasimaTuruKodu = tur.Kodu,
                                 TehlikeliMaddeTasimaKodu = yuktehse.Kodu,
                                 TehlikeliMaddeTasimaSekli = yuktehse.Aciklama,
                                 UnId = yuk.UnId,
                                 YukCinsAdi = cins.TipAdi,
                                 YukCinsDigerAciklama = yuk.YukCinsDigerAciklama,
                                 YukCinsId = cins.TipId,
                                 YukId = yuk.YukId,
                                 YuklemeIlceMernisAdi = bsilc.IlceAdi,
                                 YuklemeIlceMernisKodu = bsilc.IlceKodu,
                                 YuklemeIlMernisAdi = bsil.IlAdi,
                                 YuklemeIlMernisKodu = bsil.IlKodu,
                                 YuklemeSaati = yuk.YuklemeSaati,
                                 YuklemeTarihi = yuk.YuklemeTarihi,
                                 YuklemeUlkeKodu = yuk.YuklemeUlkeKodu,
                                 YukMiktariBirimAdi = birm.Aciklama,
                                 YukMiktariBirimi = birm.Kodu,
                                 YukMiktari = yuk.YukMiktari
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
