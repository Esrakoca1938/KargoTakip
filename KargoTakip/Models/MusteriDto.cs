using KargoTakip.WebUI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KargoTakip.WebUI.Models
{
    public class MusteriDto : BaseDto
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string KimlikNo { get; set; }
        public string Sifre { get; set; }
        public int? AdresId { get; set; }
        public string AdSoyad => Adi + " " + Soyadi;

        public virtual AdresDto? Adres { get; set; }
        public virtual ICollection<KargoDto>? AliciKargolari { get; set; }
        public virtual ICollection<KargoDto>? GondericiKargolari { get; set; }
    }
}
