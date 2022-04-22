using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;
using Entities.Concrete.UetdsEsya;
using Entities.DTO;
using Entities.DTO.UetdsEsya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfEsyaUnDal : EfEntityRepository<EsyaUnlar, UetdsContext>, IEsyaUnDal
    {
        public IEnumerable<EsyaUnDto> EsyaUnDetay()
        {
            using (UetdsContext context = new UetdsContext())
            {
                var result = from u in context.EsyaUnlar
                             select new EsyaUnDto
                             {
                                 UnId = u.Id,
                                 BakanlikNo = u.BakanlikNo,
                                 UnDetail = u.BakanlikNo + " - " + u.SiniflandirmaKodu + " - " + u.Isim
                             };
                return result.ToList();
            }
        }
    }
}
