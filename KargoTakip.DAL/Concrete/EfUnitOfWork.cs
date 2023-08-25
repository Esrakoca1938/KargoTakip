
using KargoTakip.DAL.Abstract;
using KargoTakip.DAL.EntityFramework;
using KargoTakip.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace KargoTakip.DAL.Concrete
{
    public class EfUnitOfWork : IUnitOfWork
    {
        public IHttpContextAccessor HttpContextAccessor { get; set; }
        public KargoTakipContext KargoTakipContext { get; set; }
        public EfUnitOfWork(IHttpContextAccessor httpContextAccessor, KargoTakipContext kargoTakipContext)
        {
            KargoTakipContext = kargoTakipContext;
            HttpContextAccessor = httpContextAccessor;
            PersonelRepository = new PersonelRepository(kargoTakipContext);
            KargoRepository = new KargoRepository(kargoTakipContext);
            AdresRepository = new AdresRepository(kargoTakipContext);
            IlceRepository = new IlceRepository(kargoTakipContext);
            IslemTuruRepository = new IslemTuruRepository(kargoTakipContext);
            KargoDetayRepository = new KargoDetayRepository(kargoTakipContext);
            MusteriRepository = new MusteriRepository(kargoTakipContext);
            SehirRepository = new SehirRepository(kargoTakipContext);
            SubeRepository = new SubeRepository(kargoTakipContext);
            UcretRepository = new UcretRepository(kargoTakipContext);
        }
        
        public IPersonelRepository PersonelRepository { get; }
        public IKargoRepository KargoRepository { get; }
        public IAdresRepository AdresRepository { get; }
        public IIlceRepository IlceRepository { get; }
        public IIslemTuruRepository IslemTuruRepository { get; }
        public IKargoDetayRepository KargoDetayRepository { get; }
        public IMusteriRepository MusteriRepository { get; }
        public ISehirRepository SehirRepository { get; }
        public ISubeRepository SubeRepository { get; }
        public IUcretRepository UcretRepository { get; }

        public async Task<int> SaveChangesAsync()
        {
            foreach (var entity in KargoTakipContext.ChangeTracker.Entries<AuditableEntity>())
            {
                if(entity.State == EntityState.Added)
                {
                    //TODO: Ekleyen personel ID eklenecek
                    entity.Entity.EkleyenPersonelId = 1;
                    entity.Entity.EklenmeTarihi = DateTime.Now;
                    if (entity.Entity.AktifMi == null)
                        entity.Entity.AktifMi = true;
                    entity.Entity.SilindiMi = false;
                }
                if(entity.State == EntityState.Modified)
                {
                    //TODO: Ekleyen personel ID eklenecek
                    //entity.Entity.GuncelleyenPersonelId = 1;
                    entity.Entity.GuncellenmeTarihi = DateTime.Now;

                }
            }
            var sonuc = await KargoTakipContext.SaveChangesAsync();
            return sonuc;
        }
    }
}
