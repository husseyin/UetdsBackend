using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.UetdsArizi
{
    public class AriziPersoneller : IEntity
    {
        public int Id { get; set; }
        public long UetdsSeferReferansNo { get; set; }
        public int TurKodu { get; set; }
        public string UyrukUlke { get; set; }
        public string TcKimlikPasaportNo { get; set; }
        public string Cinsiyet { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string HesKodu { get; set; }
        public string AktifIptal { get; set; }
        public string IptalAciklama { get; set; }
    }
}
