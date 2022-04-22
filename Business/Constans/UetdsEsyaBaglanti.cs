using Business.UetdsEsyaTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constans
{
    public static class UetdsEsyaBaglanti
    {
        public static UdhbUetdsEsyaWsService Baglanti()
        {
            UdhbUetdsEsyaWsService client = new UdhbUetdsEsyaWsService();

            NetworkCredential credential = new NetworkCredential(UetdsYtsKullanici.KullaniciAdi, UetdsYtsKullanici.Parola);
            client.Credentials = credential;

            return client;
        }
    }
}
