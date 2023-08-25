using KargoTakip.WebUI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KargoTakip.WebUI.Models
{
    public class KargoDetayDto : BaseDto
    {
        public int KargoId { get; set; }
        public int SubeId { get; set; }
        public int IslemTuruId { get; set; }
        public virtual SubeDto Sube { get; set; }
        public virtual IslemTuruDto IslemTuru { get; set; }
        public virtual KargoDto Kargo { get; set; }
    }
}
