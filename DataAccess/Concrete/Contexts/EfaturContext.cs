using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Contexts
{
    public class EfaturContext : DbContext
    {
        public EfaturContext() : base("Uetds")
        {

        }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        //public DbSet<UETDSEsyaSeferEkleme> Seferler { get; set; }
        //public DbSet<UETDSEsyaYukEkleme> Yukler { get; set; }
        //public DbSet<UETDSEsyaTasimaTurleri> TasimaTurleri { get; set; }
        //public DbSet<UETDSEsyaTehlikeliMaddeTasimaSekilleri> TehlikeliMaddeTasimaSekilleri { get; set; }
        //public DbSet<UETDSEsyaYukTasimaTurleri> YukTurleri { get; set; }
        //public DbSet<UETDSEsyaYukBirimleri> YukBirimleri { get; set; }
        //public DbSet<UETDSEsyaUnListesi> UnListesi { get; set; }
        //public DbSet<UETDSSeferIslemleri_IL> Sehirler { get; set; }
        //public DbSet<UETDSSeferIslemler_ILCE> Ilceler { get; set; }
        //public DbSet<RuhsatBilgisi> RuhsatBilgileri { get; set; }
    }
}
