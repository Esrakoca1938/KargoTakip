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
    public class UcretRepository : EfRepostiory<Ucret>, IUcretRepository
    {
        public UcretRepository(DbContext context) : base(context)
        {
        }
    }
}
