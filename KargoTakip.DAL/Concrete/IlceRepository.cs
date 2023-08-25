using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KargoTakip.DAL.Abstract;
using KargoTakip.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace KargoTakip.DAL.Concrete
{
    public class IlceRepository : EfRepostiory<Ilce>, IIlceRepository
    {
        public IlceRepository(DbContext context) : base(context)
        {
        }
    }
}
