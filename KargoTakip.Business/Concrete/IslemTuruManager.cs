using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using KargoTakip.Business.Abstract;
using KargoTakip.DAL.Abstract;
using KargoTakip.Entity.Models;
using KargoTakip.Business.Concrete;

namespace KargoTakip.Business.Concrete
{
    public class IslemTuruManager : IIslemTuruManager
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public IslemTuruManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<IslemTuru> Ekle(IslemTuru entity)
        {
            await UnitOfWork.IslemTuruRepository.Ekle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<IslemTuru> Getir(Expression<Func<IslemTuru, bool>> filtre, params string[] includeParams)
        {

            return await UnitOfWork.IslemTuruRepository.Getir(filtre, includeParams);
        }

        public async Task<IslemTuru> GetirID(int id)
        {
            return await UnitOfWork.IslemTuruRepository.GetirID(id);
        }

        public async Task<IslemTuru> Guncelle(IslemTuru entity)
        {
            await UnitOfWork.IslemTuruRepository.Guncelle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }


        public async Task<IEnumerable<IslemTuru>> Listele(Expression<Func<IslemTuru, bool>> filtre, params string[] includeParams)
        {
            return await UnitOfWork.IslemTuruRepository.Listele(filtre, includeParams);
        }

        public async Task Sil(int id)
        {
            await UnitOfWork.IslemTuruRepository.Sil(id);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
