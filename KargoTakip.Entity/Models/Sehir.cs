using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KargoTakip.Entity.Models;

namespace KargoTakip.Entity.Models
{
    [Table("Sehir")]
    public partial class Sehir : AuditableEntity
{
        public Sehir()
        {
            Adresler = new HashSet<Adres>();
            Ilceler = new HashSet<Ilce>();
        }

        [Required]
        [MaxLength(50)]
        public string SehirAdi { get; set; }

        public virtual ICollection<Adres>? Adresler { get; set; }
        public virtual ICollection<Ilce>? Ilceler { get; set; }
    }
}
