using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KargoTakip.Entity.Models;

namespace KargoTakip.Entity.Models
{
    [Table("Musteri")]
    public partial class Musteri :AuditableEntity
    {
        public Musteri()
        {
            AldigiKargolar = new HashSet<Kargo>();
            GonderdigiKargolar = new HashSet<Kargo>();
        }

        [Required]
        [MaxLength(50)]
        public string Adi { get; set; }

        [Required]
        [MaxLength(50)]
        public string Soyadi { get; set; }


        [MaxLength(11)]
        public string KimlikNo { get; set; }

        public string Sifre { get; set; }

        public int? AdresId { get; set; }

        [NotMapped]
        public string AdSoyad => Adi + " " + Soyadi;

        public virtual Adres? Adres { get; set; }
        public virtual ICollection<Kargo>? AldigiKargolar { get; set; }
        public virtual ICollection<Kargo>? GonderdigiKargolar { get; set; }
    }
}
