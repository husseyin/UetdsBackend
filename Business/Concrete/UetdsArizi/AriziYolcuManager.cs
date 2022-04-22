using Business.Abstract.UetdsArizi;
using Business.Constans;
using Business.UetdsAriziTest;
using DataAccess.Abstract.UetdsArizi;
using Entities.Concrete;
using Entities.Concrete.UetdsArizi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.UetdsArizi
{
    public class AriziYolcuManager : IAriziYolcuService
    {
        uetdsYtsUser _uetdsYtsKullanici = new uetdsYtsUser() { kullaniciAdi = UetdsYtsKullanici.KullaniciAdi, sifre = UetdsYtsKullanici.Parola };

        IAriziYolcuDal _ariziYolcularDal;

        public AriziYolcuManager(IAriziYolcuDal ariziYolcularDal)
        {
            _ariziYolcularDal = ariziYolcularDal;
        }

        public void Add(AriziYolcular ariziYolcular)
        {
            _ariziYolcularDal.Add(ariziYolcular);
        }

        public uetdsAriziYolcuIslemSonuc AriziYolcuEkle(long ariziSeferNo, AriziYolcular ariziYolcular)
        {
            uetdsAriziSeferYolcuBilgileriInput uetdsAriziSeferYolcuBilgileriInput = new uetdsAriziSeferYolcuBilgileriInput()
            {
                adi = ariziYolcular.Adi,
                cinsiyet = ariziYolcular.Cinsiyet,
                grupId = Convert.ToInt64(ariziYolcular.UetdsGrupRefNo),
                hesKodu = ariziYolcular.HesKodu,
                koltukNo = ariziYolcular.Koltuk,
                soyadi = ariziYolcular.Soyadi,
                tcKimlikPasaportNo = ariziYolcular.TcKimlikPasaportNo,
                telefonNo = ariziYolcular.Telefon,
                uyrukUlke = ariziYolcular.UyrukUlke
            };

            var result = UetdsAriziBaglanti.Baglanti().yolcuEkle(_uetdsYtsKullanici, ariziSeferNo, true, uetdsAriziSeferYolcuBilgileriInput);
            if (result.sonucKodu == 0)
            {
                ariziYolcular.UetdsSeferReferansNo = ariziSeferNo;
                ariziYolcular.UetdsYolcuRefNo = result.uetdsYolcuRefNo;
                ariziYolcular.AktifIptal = "AKTIF";

                _ariziYolcularDal.Add(ariziYolcular);
            }

            return result;
        }

        public uetdsGenelIslemSonuc AriziYolcuIptal(long ariziSeferNo, long ariziYolcuNo, string ariziIptalAciklama)
        {
            var result = UetdsAriziBaglanti.Baglanti().yolcuIptalUetdsYolcuRefNoIle(_uetdsYtsKullanici, ariziSeferNo, true, ariziYolcuNo, true, ariziIptalAciklama);
            if (result.sonucKodu == 0)
            {
                var ariziYolcu = _ariziYolcularDal.Get(y => y.UetdsYolcuRefNo == ariziYolcuNo.ToString());
                ariziYolcu.AktifIptal = "IPTAL";
                ariziYolcu.IptalAciklama = ariziIptalAciklama;

                _ariziYolcularDal.Update(ariziYolcu);
            }

            return result;
        }

        public List<AriziYolcular> GetAll()
        {
            return _ariziYolcularDal.GetAll().ToList();
        }

        public List<AriziYolcular> GetAllByAriziGrupNo(long ariziGrupNo)
        {
            return _ariziYolcularDal.GetAll(y => y.UetdsGrupRefNo == ariziGrupNo.ToString()).ToList();
        }
    }
}
