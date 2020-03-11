using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RKS_WellnessCentar.Models
{
    [Table("Rezervacija")]
    public class Rezervacija
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int ID { get; set; }
        public virtual int? FK_Korisnik { get; set; }
        public virtual int? FK_Tretman { get; set; }
        public virtual DateTime RezervisanoZa { get; set; }
        public virtual int? FK_StatusRezervacije { get; set; }
        public virtual decimal Cijena { get; set; }
        [Dapper.Contrib.Extensions.Write(false)]
        [Dapper.Contrib.Extensions.Computed]
        public virtual DateTime DataDeletedDate { get; set; }
        public virtual bool DataDeleted { get; set; }
    }
}
