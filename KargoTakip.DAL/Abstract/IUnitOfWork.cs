using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargoTakip.DAL.Abstract
{
    public interface IUnitOfWork
    {
        IPersonelRepository PersonelRepository { get; }
        IKargoRepository KargoRepository { get; }
        IAdresRepository AdresRepository { get; }
        IIlceRepository IlceRepository { get; }
        IIslemTuruRepository IslemTuruRepository { get; }
        IKargoDetayRepository KargoDetayRepository { get; }
        IMusteriRepository MusteriRepository { get; }
        ISehirRepository SehirRepository { get; }
        ISubeRepository SubeRepository { get; }
        IUcretRepository UcretRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
