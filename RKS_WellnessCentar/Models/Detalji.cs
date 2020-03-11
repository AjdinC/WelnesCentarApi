using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RKS_WellnessCentar.Models
{
    [Table("Detalji")]
    public class Detalji
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int ID { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Ikona { get; set; }
        public virtual int FK_Tretman { get; set; }
    }
}
