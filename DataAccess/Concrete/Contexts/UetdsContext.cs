using Entities.Concrete;
using Entities.Concrete.UetdsArizi;
using Entities.Concrete.UetdsEsya;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Contexts
{
    public class UetdsContext : DbContext
    {
        public UetdsContext() : base("Uetds")
        {
        }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        //public
        public DbSet<Ilceler> Ilceler { get; set; }
        public DbSet<Iller> Iller { get; set; }

        //arizi
        public DbSet<AriziSeferler> AriziSeferler { get; set; }
        public DbSet<AriziPersoneller> AriziPersoneller { get; set; }
        public DbSet<AriziGruplar> AriziGruplar { get; set; }
        public DbSet<AriziYolcular> AriziYolcular { get; set; }
        public DbSet<AriziPersonelTurleri> AriziPersonelTurleri { get; set; }

        //esya
        public DbSet<EsyaSeferler> EsyaSeferler { get; set; }
        public DbSet<EsyaYukler> EsyaYukler { get; set; }
        public DbSet<EsyaTasimaTurleri> EsyaTasimaTurleri { get; set; }
        public DbSet<EsyaTehlikeliTasimaSekilleri> EsyaTehlikeliTasimaSekilleri { get; set; }
        public DbSet<EsyaYukTurleri> EsyaYukTurleri { get; set; }
        public DbSet<EsyaYukBirimleri> EsyaYukBirimleri { get; set; }
        public DbSet<EsyaUnlar> EsyaUnlar { get; set; }
    }
}
