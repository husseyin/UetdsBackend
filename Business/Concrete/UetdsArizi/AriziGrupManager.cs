using Business.Abstract.UetdsArizi;
using Business.Constans;
using Business.UetdsAriziTest;
using DataAccess.Abstract;
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
    public class AriziGrupManager : IAriziGrupService
    {
        uetdsYtsUser _uetdsYtsKullanici = new uetdsYtsUser() { kullaniciAdi = UetdsYtsKullanici.KullaniciAdi, sifre = UetdsYtsKullanici.Parola };

        IAriziGrupDal _ariziGrupDal;
        IIlceDal _ilceDal;
        IIlDal _ilDal;

        public AriziGrupManager(IAriziGrupDal ariziGrupDal, IIlceDal ilceDal, IIlDal ilDal)
        {
            _ariziGrupDal = ariziGrupDal;
            _ilceDal = ilceDal;
            _ilDal = ilDal;
        }

        public void Add(AriziGruplar ariziGruplar)
        {
            _ariziGrupDal.Add(ariziGruplar);
        }

        public List<AriziGrupDto> AriziGrupDetay()
        {
            return _ariziGrupDal.AriziGrupDetay();
        }

        public List<AriziGrupDto> AriziGrupDetayBySeferNo(long ariziSeferNo)
        {
            return _ariziGrupDal.AriziGrupDetay(g => g.UetdsSeferReferansNo == ariziSeferNo);
        }

        public uetdsAriziGrupIslemSonuc AriziGrupEkle(long ariziSeferNo, AriziGruplar ariziGruplar)
        {
            uetdsAriziGrupBilgileriInput uetdsAriziGrupBilgileriInput = new uetdsAriziGrupBilgileriInput()
            {
                baslangicIl = ariziGruplar.BaslangicIl,
                baslangicIlce = ariziGruplar.BaslangicIlce,
                baslangicUlke = ariziGruplar.BaslangicUlke,
                baslangicYer = ariziGruplar.BaslangicYer,
                bitisIl = ariziGruplar.BitisIl,
                bitisIlce = ariziGruplar.BitisIlce,
                bitisUlke = ariziGruplar.BitisUlke,
                bitisYer = ariziGruplar.BitisYer,
                grupAciklama = ariziGruplar.GrupAciklama,
                grupAdi = ariziGruplar.GrupAdi,
                grupUcret = ariziGruplar.GrupUcret
            };

            var result = UetdsAriziBaglanti.Baglanti().seferGrupEkle(_uetdsYtsKullanici, ariziSeferNo, true, uetdsAriziGrupBilgileriInput);
            if (result.sonucKodu == 0)
            {
                ariziGruplar.UetdsSeferReferansNo = ariziSeferNo;
                ariziGruplar.UetdsGrupRefNo = Convert.ToInt64(result.uetdsGrupRefNo);
                ariziGruplar.AktifIptal = "AKTIF";

                _ariziGrupDal.Add(ariziGruplar);
            }

            return result;
        }

        public uetdsAriziGrupIslemSonuc AriziGrupGuncelle(long ariziSeferNo, long ariziGrupId, AriziGruplar ariziGruplar)
        {
            uetdsAriziGrupBilgileriInput uetdsAriziGrupBilgileriInput = new uetdsAriziGrupBilgileriInput()
            {
                baslangicIl = ariziGruplar.BaslangicIl,
                baslangicIlce = ariziGruplar.BaslangicIlce,
                baslangicUlke = ariziGruplar.BaslangicUlke,
                baslangicYer = ariziGruplar.BaslangicYer,
                bitisIl = ariziGruplar.BitisIl,
                bitisIlce = ariziGruplar.BitisIlce,
                bitisUlke = ariziGruplar.BitisUlke,
                bitisYer = ariziGruplar.BitisYer,
                grupAciklama = ariziGruplar.GrupAciklama,
                grupAdi = ariziGruplar.GrupAdi,
                grupUcret = ariziGruplar.GrupUcret
            };

            var result = UetdsAriziBaglanti.Baglanti().seferGrupGuncelle(_uetdsYtsKullanici, ariziSeferNo, true, ariziGrupId, true, uetdsAriziGrupBilgileriInput);
            if (result.sonucKodu == 0)
            {
                var ariziGrup = _ariziGrupDal.Get(g => g.UetdsGrupRefNo == ariziGrupId);
                ariziGrup.BaslangicIl = ariziGruplar.BaslangicIl;
                ariziGrup.BaslangicIlce = ariziGruplar.BaslangicIlce;
                ariziGrup.BaslangicUlke = ariziGruplar.BaslangicUlke;
                ariziGrup.BaslangicYer = ariziGruplar.BaslangicYer;
                ariziGrup.BitisIl = ariziGruplar.BitisIl;
                ariziGrup.BitisIlce = ariziGruplar.BitisIlce;
                ariziGrup.BitisUlke = ariziGruplar.BitisUlke;
                ariziGrup.BitisYer = ariziGruplar.BitisYer;
                ariziGrup.GrupAciklama = ariziGruplar.GrupAciklama;
                ariziGrup.GrupAdi = ariziGruplar.GrupAdi;
                ariziGrup.GrupUcret = ariziGruplar.GrupUcret;
                ariziGrup.UetdsSeferReferansNo = ariziSeferNo;
                ariziGrup.UetdsGrupRefNo = Convert.ToInt64(result.uetdsGrupRefNo);

                _ariziGrupDal.Update(ariziGrup);
            }

            return result;
        }

        public uetdsGenelIslemSonuc AriziGrupIptal(long ariziSeferNo, long ariziGrupId, string ariziIptalAciklama)
        {
            var result = UetdsAriziBaglanti.Baglanti().seferGrupIptal(_uetdsYtsKullanici, ariziSeferNo, true, ariziGrupId, true, ariziIptalAciklama);
            if (result.sonucKodu == 0)
            {
                var ariziGrup = _ariziGrupDal.Get(g => g.UetdsGrupRefNo == ariziGrupId);
                ariziGrup.AktifIptal = "IPTAL";
                ariziGrup.IptalAciklama = ariziIptalAciklama;

                _ariziGrupDal.Update(ariziGrup);
            }

            return result;
        }

        public async Task<uetdsAriziGrupIslemSonuc> AriziGrupListeleAsync(long ariziSeferNo)
        {
            return await Task.Run(() =>
            {
                var result = UetdsAriziBaglanti.Baglanti().seferGrupListesi(_uetdsYtsKullanici, ariziSeferNo, true);

                return result;
            });

        }

        public List<Ilceler> IlcelerByIlKodu(int ilKodu)
        {
            return _ilceDal.GetAll(i => i.IlKodu == ilKodu).ToList();
        }

        public List<Iller> Iller()
        {
            return _ilDal.GetAll().ToList();
        }

        public List<AriziGruplar> GetAll()
        {
            return _ariziGrupDal.GetAll().ToList();
        }

        public List<AriziGruplar> GetAllByAriziSeferNo(long ariziSeferNo)
        {
            return _ariziGrupDal.GetAll(s => s.UetdsSeferReferansNo == ariziSeferNo).ToList();
        }

        public void Update(AriziGruplar ariziGruplar)
        {
            _ariziGrupDal.Update(ariziGruplar);
        }
    }
}
