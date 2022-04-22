using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.UetdsEsya
{
    public class EsyaYukler : IEntity
    {
        public int Id { get; set; }
        public long SeferId { get; set; }
        public long YukId { get; set; }
        public string FirmaYukNo { get; set; }
        public int TasimaTuruKodu { get; set; }
        public string GonderenVergiNo { get; set; }
        public string GonderenUnvan { get; set; }
        public string AliciVergiNo { get; set; }
        public string AliciUnvan { get; set; }
        public string YuklemeUlkeKodu { get; set; }
        public int YuklemeIlMernisKodu { get; set; }
        public int YuklemeIlceMernisKodu { get; set; }
        public string BosaltmaUlkeKodu { get; set; }
        public int BosaltmaIlMernisKodu { get; set; }
        public int BosaltmaIlceMernisKodu { get; set; }
        public string YuklemeTarihi { get; set; }
        public string YuklemeSaati { get; set; }
        public string BosaltmaTarihi { get; set; }
        public string BosaltmaSaati { get; set; }
        public long YukCinsId { get; set; }
        public string YukCinsDigerAciklama { get; set; }
        public string YukMiktariBirimi { get; set; }
        public string YukMiktari { get; set; }
        public int TehlikeliMaddeTasimaKodu { get; set; }
        public string UnId { get; set; }
        public string MuafiyetTuru { get; set; }
        public string AktifIptal { get; set; }
        public string IptalKodu { get; set; }
        public string IptalAciklama { get; set; }
    }
}
