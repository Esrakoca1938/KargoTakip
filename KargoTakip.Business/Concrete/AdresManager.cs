using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using KargoTakip.Business.Abstract;
using KargoTakip.DAL.Abstract;
using KargoTakip.Entity.Models;
using KargoTakip.Business.Concrete;

namespace KargoTakip.Business.Concrete
{
    public class AdresManager : IAdresManager
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public AdresManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<Adres> Ekle(Adres entity)
        {
            await UnitOfWork.AdresRepository.Ekle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<Adres> Getir(Expression<Func<Adres, bool>> filtre, params string[] includeParams)
        {

            return await UnitOfWork.AdresRepository.Getir(filtre, includeParams);
        }

        public async Task<Adres> GetirID(int id)
        {
            return await UnitOfWork.AdresRepository.GetirID(id);
        }

        public async Task<Adres> Guncelle(Adres entity)
        {
            await UnitOfWork.AdresRepository.Guncelle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }


        public async Task<IEnumerable<Adres>> Listele(Expression<Func<Adres, bool>> filtre, params string[] includeParams)
        {
            return await UnitOfWork.AdresRepository.Listele(filtre, includeParams);
        }

        public async Task Sil(int id)
        {
            await UnitOfWork.AdresRepository.Sil(id);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}

