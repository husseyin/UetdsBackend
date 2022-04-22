using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.Abstract.UetdsArizi;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;
using Entities.Concrete.UetdsArizi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.UetdsArizi
{
    public class EfIlDal : EfEntityRepository<Iller, UetdsContext>, IIlDal
    {
    }
}
