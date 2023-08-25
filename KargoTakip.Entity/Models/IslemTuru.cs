using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KargoTakip.Entity.Models;

namespace KargoTakip.Entity.Models
{
    [Table("IslemTuru")]
    public partial class IslemTuru : AuditableEntity
    {
        public IslemTuru()
        {
            KargoDetaylari = new HashSet<KargoDetay>();
        }

        [Required]
        [MaxLength(50)]
        public string IslemTuruAdi { get; set; }

        public virtual ICollection<KargoDetay>? KargoDetaylari { get; set; }
    }
}
