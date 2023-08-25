using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using KargoTakip.Business.Abstract;
using KargoTakip.DAL.Abstract;
using KargoTakip.Entity.Models;
using KargoTakip.Business.Concrete;

namespace KargoTakip.Business.Concrete
{
    public class UcretManager : IUcretManager
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public UcretManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<Ucret> Ekle(Ucret entity)
        {
            await UnitOfWork.UcretRepository.Ekle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<Ucret> Getir(Expression<Func<Ucret, bool>> filtre, params string[] includeParams)
        {

            return await UnitOfWork.UcretRepository.Getir(filtre, includeParams);
        }

        public async Task<Ucret> GetirID(int id)
        {
            return await UnitOfWork.UcretRepository.GetirID(id);
        }

        public async Task<Ucret> Guncelle(Ucret entity)
        {
            await UnitOfWork.UcretRepository.Guncelle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }


        public async Task<IEnumerable<Ucret>> Listele(Expression<Func<Ucret, bool>> filtre, params string[] includeParams)
        {
            return await UnitOfWork.UcretRepository.Listele(filtre, includeParams);
        }

        public async Task Sil(int id)
        {
            await UnitOfWork.UcretRepository.Sil(id);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
