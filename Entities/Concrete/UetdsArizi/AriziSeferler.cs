using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.UetdsArizi
{
    public class AriziSeferler : IEntity
    {
        public int Id { get; set; }
        public long UetdsSeferReferansNo { get; set; }
        public string AracPlaka { get; set; }
        public DateTime HareketTarihi { get; set; }
        public string HareketSaati { get; set; }
        public string SeferAciklama { get; set; }
        public string AracTelefonu { get; set; }
        public string FirmaSeferNo { get; set; }
        public DateTime SeferBitisTarihi { get; set; }
        public string SeferBitisSaati { get; set; }
        public string AktifPasif { get; set; }
        public string AktifPasifAciklama { get; set; }
    }
}
