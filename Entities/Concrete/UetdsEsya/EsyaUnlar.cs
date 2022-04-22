using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.UetdsEsya
{
    public class EsyaUnlar : IEntity
    {
        public int Id { get; set; }
        public string BakanlikNo { get; set; }
        public string UnNo { get; set; }
        public string Isim { get; set; }
        public string Sinif { get; set; }
        public string SiniflandirmaKodu { get; set; }
        public string PaketlemeGrubu { get; set; }
    }
}
