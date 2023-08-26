using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using KargoTakip.Business.Abstract;
using KargoTakip.DAL.Abstract;
using KargoTakip.Entity.Models;
using KargoTakip.Business.Concrete;
using KargoTakip.Core.Enum;

namespace KargoTakip.Business.Concrete
{
    public class KargoManager : IKargoManager
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public KargoManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<Kargo> Ekle(Kargo entity)
        {
            await UnitOfWork.KargoRepository.Ekle(entity);

            await UnitOfWork.SaveChangesAsync();
            await UnitOfWork.KargoDetayRepository.Ekle(
                new KargoDetay 
                { 
                    AktifMi = true, 
                    EklenmeTarihi = entity.EklenmeTarihi, 
                    EkleyenPersonelId = entity.EkleyenPersonelId, 
                    GuncellenmeTarihi = entity.GuncellenmeTarihi,
                    GuncelleyenPersonelId = entity.GuncelleyenPersonelId,
                    SilindiMi = false,
                    KargoId = entity.ID,
                    SubeId = entity.AliciSubeId,
                    IslemTuru = KargoDurum.KabulEdildi
                });
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<Kargo> Getir(Expression<Func<Kargo, bool>> filtre, params string[] includeParams)
        {

            return await UnitOfWork.KargoRepository.Getir(filtre, includeParams);
        }

        public async Task<Kargo> GetirID(int id)
        {
            return await UnitOfWork.KargoRepository.GetirID(id);
        }

        public async Task<Kargo> Guncelle(Kargo entity)
        {
            await UnitOfWork.KargoRepository.Guncelle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }


        public async Task<IEnumerable<Kargo>> Listele(Expression<Func<Kargo, bool>> filtre, params string[] includeParams)
        {
            return await UnitOfWork.KargoRepository.Listele(filtre, includeParams);
        }

        public async Task Sil(int id)
        {
            await UnitOfWork.KargoRepository.Sil(id);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
