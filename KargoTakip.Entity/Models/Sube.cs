using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KargoTakip.Entity.Models;

namespace KargoTakip.Entity.Models
{
    [Table("Sube")]
    public partial class Sube : AuditableEntity
    {
        public Sube()
        {
            KargoDetaylari = new HashSet<KargoDetay>();
            AliciSubeKargolari = new HashSet<Kargo>();
            GonderenSubeKargolari = new HashSet<Kargo>();
        }

        [MaxLength(100)]
        [Required]
        public string SubeAdi { get; set; }

        [Required]
        public int AdresId { get; set; }

        public virtual Adres Adres { get; set; }
        public virtual ICollection<KargoDetay>? KargoDetaylari { get; set; }
        public virtual ICollection<Kargo>? AliciSubeKargolari { get; set; }
        public virtual ICollection<Kargo>? GonderenSubeKargolari { get; set; }
    }
}
