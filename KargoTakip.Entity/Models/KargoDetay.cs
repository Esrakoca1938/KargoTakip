using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KargoTakip.Entity.Models;

namespace KargoTakip.Entity.Models
{
    [Table("KargoDetay")]
    public partial class KargoDetay : AuditableEntity
    {
        [Required]
        public int KargoId { get; set; }
        [Required]
        public int SubeId { get; set; }
        [Required]
        public int IslemTuruId { get; set; }

        public virtual Sube Sube { get; set; }
        public virtual IslemTuru IslemTuru { get; set; }
        public virtual Kargo Kargo { get; set; }
    }
}
