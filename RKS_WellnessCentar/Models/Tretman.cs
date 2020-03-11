using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RKS_WellnessCentar.Models
{
    [Table("Tretman")]
    public class Tretman
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int ID { get; set; }
        [MaxLength(100)]
        public virtual string Naziv { get; set; }
        [MaxLength(100)]
        public virtual string Opis { get; set; }
        public virtual decimal Cijena { get; set; }
        public virtual string URLSlika { get; set; }
    }
}
