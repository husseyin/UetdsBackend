using Core.DataAccess;
using DataAccess.Abstract.UetdsArizi;
using DataAccess.Concrete.Contexts;
using Entities.Concrete.UetdsArizi;
using Entities.DTO.UetdsArizi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.UetdsArizi
{
    public class EfAriziGrupDal : EfEntityRepository<AriziGruplar, UetdsContext>, IAriziGrupDal
    {
        public List<AriziGrupDto> AriziGrupDetay(Expression<Func<AriziGrupDto, bool>> filter = null)
        {
            using (UetdsContext context = new UetdsContext())
            {
                var result = from gru in context.AriziGruplar
                             join bsil in context.Iller
                             on gru.BaslangicIl equals bsil.IlKodu
                             join btil in context.Iller
                             on gru.BitisIl equals btil.IlKodu
                             join bsilc in context.Ilceler
                             on gru.BaslangicIlce equals bsilc.IlceKodu
                             join btilc in context.Ilceler
                             on gru.BitisIlce equals btilc.IlceKodu
                             orderby gru.Id

                             select new AriziGrupDto
                             {
                                 AktifIptal = gru.AktifIptal,
                                 BaslangicUlke = gru.BaslangicUlke,
                                 BaslangicIl = gru.BaslangicIl,
                                 BaslangicIlAdi = bsil.IlAdi,
                                 BaslangicIlce = gru.BaslangicIlce,
                                 BaslangicIlceAdi = bsilc.IlceAdi,
                                 BaslangicYer = gru.BaslangicYer,
                                 BitisUlke = gru.BitisUlke,
                                 BitisIl = gru.BitisIl,
                                 BitisIlAdi = btil.IlAdi,
                                 BitisIlce = gru.BitisIlce,
                                 BitisIlceAdi = btilc.IlceAdi,
                                 BitisYer = gru.BitisYer,
                                 GrupAciklama = gru.GrupAciklama,
                                 GrupAdi = gru.GrupAdi,
                                 GrupUcret = gru.GrupUcret,
                                 Id = gru.Id,
                                 IptalAciklama = gru.IptalAciklama,
                                 UetdsGrupRefNo = gru.UetdsGrupRefNo,
                                 UetdsSeferReferansNo = gru.UetdsSeferReferansNo
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
