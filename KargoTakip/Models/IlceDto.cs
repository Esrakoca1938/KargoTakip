using KargoTakip.WebUI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KargoTakip.WebUI.Models
{
    public class IlceDto : BaseDto
    {
        public string IlceAdi { get; set; }
        public int SehirId { get; set; }

        public virtual SehirDto? Sehir { get; set; }
        public virtual ICollection<AdresDto>? Adresler { get; set; }
    }
}
