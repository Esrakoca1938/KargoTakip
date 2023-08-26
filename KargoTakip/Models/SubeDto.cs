using KargoTakip.WebUI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KargoTakip.WebUI.Models
{
    public class SubeDto : BaseDto
    {
        public string SubeAdi { get; set; }
        public int AdresId { get; set; }
        public virtual AdresDto? Adres { get; set; }
        public virtual ICollection<KargoDetayDto>? KargoDetaylari { get; set; }
        public virtual ICollection<KargoDto>? AliciSubeKargolari { get; set; }
        public virtual ICollection<KargoDto>? GonderenSubeKargolari { get; set; }
    }
}
