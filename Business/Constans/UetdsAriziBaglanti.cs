using Business.UetdsAriziTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constans
{
    public static class UetdsAriziBaglanti
    {
        public static UdhbUetdsAriziService Baglanti()
        {
            UdhbUetdsAriziService client = new UdhbUetdsAriziService();

            NetworkCredential credential = new NetworkCredential(UetdsYtsKullanici.KullaniciAdi, UetdsYtsKullanici.Parola);
            client.Credentials = credential;

            return client;
        }
    }
}
