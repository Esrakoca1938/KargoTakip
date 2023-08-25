using KargoTakip.WebUI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KargoTakip.WebUI.Models
{
    public class SehirDto : BaseDto
    {
        public string SehirAdi { get; set; }
        public virtual ICollection<AdresDto>? Adresler { get; set; }
        public virtual ICollection<IlceDto>? Ilceler { get; set; }
    }
}
