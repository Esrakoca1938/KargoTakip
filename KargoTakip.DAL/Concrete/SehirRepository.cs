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
    public class SehirRepository : EfRepostiory<Sehir>, ISehirRepository
    {
        public SehirRepository(DbContext context) : base(context)
        {
        }
    }
}
