using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KargoTakip.Entity.Models;

namespace KargoTakip.Entity.Models
{
    [Table("Ilce")]
    public partial class Ilce : AuditableEntity
    {
        public Ilce()
        {
            Adresler = new HashSet<Adres>();
        }

        [MaxLength(50)]
        [Required]
        public string IlceAdi { get; set; }
        public int SehirId { get; set; }

        public virtual Sehir? Sehir { get; set; }
        public virtual ICollection<Adres>? Adresler { get; set; }
    }
}
