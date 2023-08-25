using KargoTakip.WebUI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KargoTakip.WebUI.Models
{
    public class PersonelDto : BaseDto
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string KimlikNo { get; set; }
        public string Cinsiyet { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string Pozisyon { get; set; }

        public string AdSoyad => Adi + " " + Soyadi;

        public virtual List<KargoDto>? KabulEdilenKargolar { get; set; }
        public virtual List<KargoDto>? TeslimEdilenKargolar { get; set; }
    }
}
