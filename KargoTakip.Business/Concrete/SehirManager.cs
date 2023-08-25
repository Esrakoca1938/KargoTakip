using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using KargoTakip.Business.Abstract;
using KargoTakip.DAL.Abstract;
using KargoTakip.Entity.Models;
using KargoTakip.Business.Concrete;

namespace KargoTakip.Business.Concrete
{
    public class SehirManager : ISehirManager
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public SehirManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<Sehir> Ekle(Sehir entity)
        {
            await UnitOfWork.SehirRepository.Ekle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<Sehir> Getir(Expression<Func<Sehir, bool>> filtre, params string[] includeParams)
        {

            return await UnitOfWork.SehirRepository.Getir(filtre, includeParams);
        }

        public async Task<Sehir> GetirID(int id)
        {
            return await UnitOfWork.SehirRepository.GetirID(id);
        }

        public async Task<Sehir> Guncelle(Sehir entity)
        {
            await UnitOfWork.SehirRepository.Guncelle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }


        public async Task<IEnumerable<Sehir>> Listele(Expression<Func<Sehir, bool>> filtre, params string[] includeParams)
        {
            return await UnitOfWork.SehirRepository.Listele(filtre, includeParams);
        }

        public async Task Sil(int id)
        {
            await UnitOfWork.SehirRepository.Sil(id);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
