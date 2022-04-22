using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.UetdsEsya;
using Entities.DTO;
using Entities.DTO.UetdsEsya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEsyaUnDal : IEntityRepository<EsyaUnlar>
    {
        IEnumerable<EsyaUnDto> EsyaUnDetay();
    }
}
