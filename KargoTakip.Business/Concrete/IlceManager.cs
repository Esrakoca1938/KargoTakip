using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using KargoTakip.Business.Abstract;
using KargoTakip.DAL.Abstract;
using KargoTakip.Entity.Models;
using KargoTakip.Business.Concrete;

namespace KargoTakip.Business.Concrete
{
    public class IlceManager : IIlceManager
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public IlceManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<Ilce> Ekle(Ilce entity)
        {
            await UnitOfWork.IlceRepository.Ekle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<Ilce> Getir(Expression<Func<Ilce, bool>> filtre, params string[] includeParams)
        {

            return await UnitOfWork.IlceRepository.Getir(filtre, includeParams);
        }

        public async Task<Ilce> GetirID(int id)
        {
            return await UnitOfWork.IlceRepository.GetirID(id);
        }

        public async Task<Ilce> Guncelle(Ilce entity)
        {
            await UnitOfWork.IlceRepository.Guncelle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }


        public async Task<IEnumerable<Ilce>> Listele(Expression<Func<Ilce, bool>> filtre, params string[] includeParams)
        {
            return await UnitOfWork.IlceRepository.Listele(filtre, includeParams);
        }

        public async Task Sil(int id)
        {
            await UnitOfWork.IlceRepository.Sil(id);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
