using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using KargoTakip.Business.Abstract;
using KargoTakip.DAL.Abstract;
using KargoTakip.Entity.Models;
using KargoTakip.Business.Concrete;

namespace KargoTakip.Business.Concrete
{
    public class KargoDetayManager : IKargoDetayManager
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public KargoDetayManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<KargoDetay> Ekle(KargoDetay entity)
        {
            await UnitOfWork.KargoDetayRepository.Ekle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<KargoDetay> Getir(Expression<Func<KargoDetay, bool>> filtre, params string[] includeParams)
        {

            return await UnitOfWork.KargoDetayRepository.Getir(filtre, includeParams);
        }

        public async Task<KargoDetay> GetirID(int id)
        {
            return await UnitOfWork.KargoDetayRepository.GetirID(id);
        }

        public async Task<KargoDetay> Guncelle(KargoDetay entity)
        {
            await UnitOfWork.KargoDetayRepository.Guncelle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }


        public async Task<IEnumerable<KargoDetay>> Listele(Expression<Func<KargoDetay, bool>> filtre, params string[] includeParams)
        {
            return await UnitOfWork.KargoDetayRepository.Listele(filtre, includeParams);
        }

        public async Task Sil(int id)
        {
            await UnitOfWork.KargoDetayRepository.Sil(id);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
