using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.UetdsArizi
{
    public class AriziGrupDto
    {
        public int Id { get; set; }
        public long UetdsSeferReferansNo { get; set; }
        public long UetdsGrupRefNo { get; set; }
        public string GrupAdi { get; set; }
        public string GrupAciklama { get; set; }
        public string GrupUcret { get; set; }
        public string BaslangicUlke { get; set; }
        public int BaslangicIl { get; set; }
        public string BaslangicIlAdi { get; set; }
        public int BaslangicIlce { get; set; }
        public string BaslangicIlceAdi { get; set; }
        public string BaslangicYer { get; set; }
        public string BitisUlke { get; set; }
        public int BitisIl { get; set; }
        public string BitisIlAdi { get; set; }
        public int BitisIlce { get; set; }
        public string BitisIlceAdi { get; set; }
        public string BitisYer { get; set; }
        public string AktifIptal { get; set; }
        public string IptalAciklama { get; set; }
    }
}
