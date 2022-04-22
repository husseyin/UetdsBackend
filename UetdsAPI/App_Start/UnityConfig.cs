using Business.Abstract.UetdsArizi;
using Business.Abstract.UetdsEsya;
using Business.Concrete.UetdsArizi;
using Business.Concrete.UetdsEsya;
using DataAccess.Abstract;
using DataAccess.Abstract.UetdsArizi;
using DataAccess.Abstract.UetdsEsya;
using DataAccess.Concrete;
using DataAccess.Concrete.UetdsArizi;
using DataAccess.Concrete.UetdsEsya;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace UetdsAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //public
            container.RegisterType<IIlDal, EfIlDal>();
            container.RegisterType<IIlceDal, EfIlceDal>();

            //Arizi
            container.RegisterType<IAriziSeferService, AriziSeferManager>();
            container.RegisterType<IAriziSeferDal, EfAriziSeferDal>();
            container.RegisterType<IAriziPersonelService, AriziPersonelManager>();
            container.RegisterType<IAriziPersonelDal, EfAriziPersonelDal>();
            container.RegisterType<IAriziPersonelTuruDal, EfAriziPersonelTuruDal>();
            container.RegisterType<IAriziGrupService, AriziGrupManager>();
            container.RegisterType<IAriziGrupDal, EfAriziGrupDal>();
            container.RegisterType<IAriziYolcuService, AriziYolcuManager>();
            container.RegisterType<IAriziYolcuDal, EfAriziYolcuDal>();

            //Esya
            container.RegisterType<IEsyaSeferService, EsyaSeferManager>();
            container.RegisterType<IEsyaSeferDal, EfEsyaSeferDal>();
            container.RegisterType<IEsyaYukService, EsyaYukManager>();
            container.RegisterType<IEsyaYukDal, EfEsyaYukDal>();
            container.RegisterType<IEsyaTasimaTurleriDal, EfEsyaTasimaTurleriDal>();
            container.RegisterType<IEsyaTehlikeliTasimaSekilleriDal, EfEsyaTehlikeliTasimaSekilleriDal>();
            container.RegisterType<IEsyaYukTurleriDal, EfEsyaYukTurleriDal>();
            container.RegisterType<IEsyaYukBirimleriDal, EfEsyaYukBirimleriDal>();
            container.RegisterType<IEsyaUnDal, EfEsyaUnDal>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}