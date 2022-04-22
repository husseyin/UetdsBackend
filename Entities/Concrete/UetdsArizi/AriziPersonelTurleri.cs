using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.UetdsArizi
{
    public class AriziPersonelTurleri : IEntity
    {
        public int Id { get; set; }
        public int TurKodu { get; set; }
        public string TurAdi { get; set; }
    }
}
