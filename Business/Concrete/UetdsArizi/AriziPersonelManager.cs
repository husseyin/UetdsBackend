using Business.Abstract.UetdsArizi;
using Business.Constans;
using Business.UetdsAriziTest;
using DataAccess.Abstract.UetdsArizi;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Concrete.UetdsArizi;
using Entities.DTO.UetdsArizi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.UetdsArizi
{
    public class AriziPersonelManager : IAriziPersonelService
    {
        uetdsYtsUser _uetdsYtsKullanici = new uetdsYtsUser() { kullaniciAdi = UetdsYtsKullanici.KullaniciAdi, sifre = UetdsYtsKullanici.Parola };

        IAriziPersonelDal _ariziPersonelDal;
        IAriziPersonelTuruDal _ariziPersonelTuruDal;

        public AriziPersonelManager(IAriziPersonelDal ariziPersonelDal, IAriziPersonelTuruDal ariziPersonelTuruDal)
        {
            _ariziPersonelDal = ariziPersonelDal;
            _ariziPersonelTuruDal = ariziPersonelTuruDal;
        }

        public void Add(AriziPersoneller ariziPersoneller)
        {
            _ariziPersonelDal.Add(ariziPersoneller);
        }

        public List<AriziPersonelDto> AriziPersonelDetay()
        {
            return _ariziPersonelDal.AriziPersonelDetay();
        }

        public List<AriziPersonelDto> AriziPersonelDetayBySeferNo(long ariziSeferNo)
        {
            return _ariziPersonelDal.AriziPersonelDetay(p => p.UetdsSeferReferansNo == ariziSeferNo);
        }

        public uetdsGenelIslemSonuc AriziPersonelEkle(long ariziSeferNo, AriziPersoneller ariziPersoneller)
        {
            uetdsAriziSeferPersonelBilgileriInput[] uetdsAriziSeferPersonelBilgileriInput = new uetdsAriziSeferPersonelBilgileriInput[]
            {
                new uetdsAriziSeferPersonelBilgileriInput(){
                    adi = ariziPersoneller.Adi,
                    adres = ariziPersoneller.Adres,
                    cinsiyet = ariziPersoneller.Cinsiyet,
                    hesKodu = ariziPersoneller.HesKodu,
                    soyadi = ariziPersoneller.Soyadi,
                    tcKimlikPasaportNo = ariziPersoneller.TcKimlikPasaportNo,
                    telefon = ariziPersoneller.Telefon,
                    turKodu = ariziPersoneller.TurKodu,
                    uyrukUlke = ariziPersoneller.UyrukUlke
                }
            };

            var result = UetdsAriziBaglanti.Baglanti().personelEkle(_uetdsYtsKullanici, ariziSeferNo, uetdsAriziSeferPersonelBilgileriInput);
            if (result.sonucKodu == 0)
            {
                ariziPersoneller.UetdsSeferReferansNo = ariziSeferNo;
                ariziPersoneller.AktifIptal = "AKTIF";

                _ariziPersonelDal.Add(ariziPersoneller);
            }

            return result;
        }

        public uetdsGenelIslemSonuc AriziPersonelIptal(string ariziTcPasaportNo, string ariziIptalAciklama)
        {
            var ariziPersonel = _ariziPersonelDal.Get(p => p.TcKimlikPasaportNo == ariziTcPasaportNo);

            uetdsPersonelIptalInput uetdsPersonelIptalInput = new uetdsPersonelIptalInput()
            {
                iptalAciklama = ariziIptalAciklama,
                personelTCKimlikPasaportNo = ariziTcPasaportNo,
                uetdsSeferReferansNo = ariziPersonel.UetdsSeferReferansNo
            };

            var result = UetdsAriziBaglanti.Baglanti().personelIptal(_uetdsYtsKullanici, uetdsPersonelIptalInput);
            if (result.sonucKodu == 0)
            {
                ariziPersonel.AktifIptal = "IPTAL";
                ariziPersonel.IptalAciklama = ariziIptalAciklama;

                _ariziPersonelDal.Update(ariziPersonel);
            }

            return result;
        }

        public List<AriziPersonelTurleri> AriziPersonelTurleri()
        {
            return _ariziPersonelTuruDal.GetAll().ToList();
        }

        public List<AriziPersoneller> GetAll()
        {
            return _ariziPersonelDal.GetAll().ToList();
        }
    }
}
