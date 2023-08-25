using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using KargoTakip.Business.Abstract;
using KargoTakip.DAL.Abstract;
using KargoTakip.Entity.Models;
using KargoTakip.Business.Concrete;

namespace KargoTakip.Business.Concrete
{
    public class MusteriManager : IMusteriManager
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public MusteriManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<Musteri> Ekle(Musteri entity)
        {
            await UnitOfWork.MusteriRepository.Ekle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<Musteri> Getir(Expression<Func<Musteri, bool>> filtre, params string[] includeParams)
        {

            return await UnitOfWork.MusteriRepository.Getir(filtre, includeParams);
        }

        public async Task<Musteri> GetirID(int id)
        {
            return await UnitOfWork.MusteriRepository.GetirID(id);
        }

        public async Task<Musteri> Guncelle(Musteri entity)
        {
            await UnitOfWork.MusteriRepository.Guncelle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }


        public async Task<IEnumerable<Musteri>> Listele(Expression<Func<Musteri, bool>> filtre, params string[] includeParams)
        {
            return await UnitOfWork.MusteriRepository.Listele(filtre, includeParams);
        }

        public async Task Sil(int id)
        {
            await UnitOfWork.MusteriRepository.Sil(id);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
