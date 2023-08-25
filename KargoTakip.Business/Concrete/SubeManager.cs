using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using KargoTakip.Business.Abstract;
using KargoTakip.DAL.Abstract;
using KargoTakip.Entity.Models;
using KargoTakip.Business.Concrete;

namespace KargoTakip.Business.Concrete
{
    public class SubeManager : ISubeManager
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public SubeManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<Sube> Ekle(Sube entity)
        {
            await UnitOfWork.SubeRepository.Ekle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<Sube> Getir(Expression<Func<Sube, bool>> filtre, params string[] includeParams)
        {

            return await UnitOfWork.SubeRepository.Getir(filtre, includeParams);
        }

        public async Task<Sube> GetirID(int id)
        {
            return await UnitOfWork.SubeRepository.GetirID(id);
        }

        public async Task<Sube> Guncelle(Sube entity)
        {
            await UnitOfWork.SubeRepository.Guncelle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }


        public async Task<IEnumerable<Sube>> Listele(Expression<Func<Sube, bool>> filtre, params string[] includeParams)
        {
            return await UnitOfWork.SubeRepository.Listele(filtre, includeParams);
        }

        public async Task Sil(int id)
        {
            await UnitOfWork.SubeRepository.Sil(id);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
