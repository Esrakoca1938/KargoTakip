using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using KargoTakip.Business.Abstract;
using KargoTakip.DAL.Abstract;
using KargoTakip.Entity.Models;
using KargoTakip.Business.Concrete;
using KargoTakip.Core.DTO;

namespace KargoTakip.Business.Concrete
{
    public class AccountManager : IAccountManager
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public AccountManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<LoginDto?> MusteriGetir(Musteri musteri)
        {
            var mus = await UnitOfWork.MusteriRepository
                .Getir(x => x.SilindiMi == false && x.AktifMi == true && x.KimlikNo == musteri.KimlikNo && x.Sifre == musteri.Sifre);
            LoginDto login = null;
            if (mus != null)
                login = new LoginDto { AdSoyad = musteri.AdSoyad, ID = musteri.ID, KimlikNo = musteri.KimlikNo };
            return login;
        }

        public async Task<LoginDto?> KullaniciGetir(LoginDto login)
        {
            var musteri = await UnitOfWork.MusteriRepository
                .Getir(x => x.SilindiMi == false && x.AktifMi == true && x.KimlikNo == login.KimlikNo && x.Sifre == login.Sifre);
            if (musteri != null)
                login = new LoginDto { AdSoyad = musteri.AdSoyad, ID = musteri.ID, KimlikNo = musteri.KimlikNo };
            else
            {
                var personel = await UnitOfWork.PersonelRepository
                    .Getir(x => x.SilindiMi == false && x.AktifMi == true && x.KimlikNo == login.KimlikNo && x.Sifre == login.Sifre);
                if (personel != null)
                    login = new LoginDto { AdSoyad = personel.AdSoyad, ID = personel.ID, KimlikNo = personel.KimlikNo };
                else
                    login = null;
            }
            return login;
        }

        public Task<LoginDto> GetirID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginDto> Getir(Expression<Func<LoginDto, bool>> filtre, params string[] includeParams)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LoginDto>> Listele(Expression<Func<LoginDto, bool>> filtre, params string[] includeParams)
        {
            throw new NotImplementedException();
        }

        public Task<LoginDto> Ekle(LoginDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<LoginDto> Guncelle(LoginDto entity)
        {
            throw new NotImplementedException();
        }

        public Task Sil(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginDto> MusteriEkle(Musteri musteri)
        {
            await UnitOfWork.MusteriRepository.Ekle(musteri);
            await UnitOfWork.SaveChangesAsync();
            return new LoginDto { AdSoyad = musteri.AdSoyad, ID = musteri.ID, KimlikNo = musteri.KimlikNo };
        }
    }
}

