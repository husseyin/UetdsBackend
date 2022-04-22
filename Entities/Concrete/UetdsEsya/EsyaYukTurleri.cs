using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.UetdsEsya
{
    public class EsyaYukTurleri : IEntity
    {
        public int Id { get; set; }
        public long TipId { get; set; }
        public string TipAdi { get; set; }
    }
}
