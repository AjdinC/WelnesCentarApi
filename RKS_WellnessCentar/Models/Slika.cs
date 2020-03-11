using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RKS_WellnessCentar.Models
{
    [Table("Slika")]
    public class Slika
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int ID { get; set; }
        [MaxLength]
        public virtual string URL { get; set; }
        public virtual int FK_Tretman { get; set; }
        public virtual bool GlavnaSlika { get; set; }
    }
}
