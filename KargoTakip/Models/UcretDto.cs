using KargoTakip.WebUI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KargoTakip.WebUI.Models
{
    public class UcretDto : BaseDto
    {
        public string Buyukluk { get; set; }
        public decimal Tutar { get; set; }

        public virtual ICollection<KargoDto>? Kargolar { get; set; }
    }
}
