using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using KargoTakip.Core.DTO;
using KargoTakip.Entity.Models;

namespace KargoTakip.Business.Abstract
{
    public interface IAccountManager : IGenericManager<LoginDto>
    {
        Task<LoginDto?> KullaniciGetir(LoginDto login);
        Task<LoginDto> MusteriEkle(Musteri musteri);
        Task<LoginDto?> MusteriGetir(Musteri musteri);
    }
}