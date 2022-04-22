using Core.DataAccess;
using DataAccess.Abstract.UetdsEsya;
using DataAccess.Concrete.Contexts;
using Entities.Concrete.UetdsEsya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.UetdsEsya
{
    public class EfEsyaSeferDal : EfEntityRepository<EsyaSeferler, UetdsContext>, IEsyaSeferDal
    {
    }
}
