using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KargoTakip.Entity.Models;

namespace KargoTakip.Entity.Models
{
    [Table("Ucret")]
    public partial class Ucret : AuditableEntity
    {
        public Ucret()
        {
            Kargolar = new HashSet<Kargo>();
        }

        [MaxLength(100)]
        [Required]
        public string Buyukluk { get; set; }

        //[DisplayFormat(DataFormatString = "{0:C0}")]

        [Required]
        public decimal Tutar { get; set; }

        public virtual ICollection<Kargo> Kargolar { get; set; }
    }
}
