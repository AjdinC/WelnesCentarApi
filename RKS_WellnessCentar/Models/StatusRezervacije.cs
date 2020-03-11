using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RKS_WellnessCentar.Models
{
    [Table("StatusRezervacije")]
    public class StatusRezervacije
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int ID { get; set; }
        public virtual string Naziv { get; set; }
    }
}
