using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.UetdsEsya
{
    public class EsyaSeferler : IEntity
    {
        public int Id { get; set; }
        public long SeferId { get; set; }
        public string Plaka1 { get; set; }
        public string Plaka2 { get; set; }
        public string Sofor1TCNo { get; set; }
        public string Sofor2TCNo { get; set; }
        public string FirmaSeferNo { get; set; }
        public string BaslangicTarihi { get; set; }
        public string BaslangicSaati { get; set; }
        public string BitisTarihi { get; set; }
        public string BitisSaati { get; set; }
        public string AktifIptal { get; set; }
        public string IptalKodu { get; set; }
        public string IptalAciklama { get; set; }
    }
}
