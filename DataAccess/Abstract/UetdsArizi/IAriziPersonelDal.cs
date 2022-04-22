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
    public interface IAriziPersonelDal : IEntityRepository<AriziPersoneller>
    {
        List<AriziPersonelDto> AriziPersonelDetay(Expression<Func<AriziPersonelDto, bool>> filter = null);
    }
}
