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
    public class EfAriziPersonelDal : EfEntityRepository<AriziPersoneller, UetdsContext>, IAriziPersonelDal
    {
        public List<AriziPersonelDto> AriziPersonelDetay(Expression<Func<AriziPersonelDto, bool>> filter = null)
        {
            using (UetdsContext context = new UetdsContext())
            {
                var result = from per in context.AriziPersoneller
                             join tur in context.AriziPersonelTurleri
                             on per.TurKodu equals tur.TurKodu

                             select new AriziPersonelDto
                             {
                                 Adi = per.Adi,
                                 Adres = per.Adres,
                                 AktifIptal = per.AktifIptal,
                                 IptalAciklama = per.IptalAciklama,
                                 Cinsiyet = per.Cinsiyet,
                                 HesKodu = per.HesKodu,
                                 Id = per.Id,
                                 Soyadi = per.Soyadi,
                                 TcKimlikPasaportNo = per.TcKimlikPasaportNo,
                                 Telefon = per.Telefon,
                                 TurKodu = per.TurKodu,
                                 TurAdi = tur.TurAdi,
                                 UetdsSeferReferansNo = per.UetdsSeferReferansNo,
                                 UyrukUlke = per.UyrukUlke
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
