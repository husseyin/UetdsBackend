using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.UetdsEsya
{
    public class EsyaTasimaTurleri : IEntity
    {
        public int Id { get; set; }
        public int Kodu { get; set; }
        public string Aciklama { get; set; }
    }
}
