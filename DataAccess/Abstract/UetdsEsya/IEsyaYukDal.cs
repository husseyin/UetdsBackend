using Core.DataAccess;
using Entities.Concrete.UetdsEsya;
using Entities.DTO.UetdsEsya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.UetdsEsya
{
    public interface IEsyaYukDal : IEntityRepository<EsyaYukler>
    {
        List<EsyaYukDto> EsyaYukDetay(Expression<Func<EsyaYukDto, bool>> filter = null);
    }
}
