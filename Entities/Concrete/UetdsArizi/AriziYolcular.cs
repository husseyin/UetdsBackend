using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.UetdsArizi
{
    public class AriziYolcular : IEntity
    {
        public int Id { get; set; }
        public long UetdsSeferReferansNo { get; set; }
        public string UetdsGrupRefNo { get; set; }
        public string UetdsYolcuRefNo { get; set; }
        public string UyrukUlke { get; set; }
        public string Cinsiyet { get; set; }
        public string TcKimlikPasaportNo { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Koltuk { get; set; }
        public string Telefon { get; set; }
        public string HesKodu { get; set; }
        public string AktifIptal { get; set; }
        public string IptalAciklama { get; set; }
    }
}
