using KargoTakip.WebUI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KargoTakip.WebUI.Models
{
    public class IslemTuruDto : BaseDto
    {
        public string IslemTuruAdi { get; set; }

        public virtual ICollection<KargoDetayDto>? KargoDetaylari { get; set; }
    }
}
