using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargoTakip.Core.DTO
{
    public class LoginDto
    {
        public string? KimlikNo { get; set; }
        public string? Sifre { get; set; }
        public string? AdSoyad { get; set; }
        public string? Token { get; set; }
        public int? ID { get; set; }
    }
}
