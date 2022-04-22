using Core.DataAccess;
using Entities.Concrete.UetdsArizi;
using Entities.DTO.UetdsArizi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.UetdsArizi
{
    public interface IAriziGrupDal : IEntityRepository<AriziGruplar>
    {
        List<AriziGrupDto> AriziGrupDetay(Expression<Func<AriziGrupDto, bool>> filter = null);
    }
}
