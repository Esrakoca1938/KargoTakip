using KargoTakip.WebUI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KargoTakip.WebUI.Models
{
    public class AdresDto : BaseDto
    {
        public string AdresAdi { get; set; }
        public int SehirId { get; set; }
        public int? IlceId { get; set; }
        public string Detay { get; set; }
        public string PostaKodu { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public virtual SehirDto? Sehir { get; set; }
        public virtual IlceDto? Ilce { get; set; }
        public virtual ICollection<SubeDto>? Subeler { get; set; }
        public virtual ICollection<MusteriDto>? Musteriler { get; set; }
    }
}
