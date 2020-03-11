using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RKS_WellnessCentar.Models
{
    [Table("Korisnik")]
    public class Korisnik
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int ID { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string KorisnickoIme { get; set; }
        public virtual string Email { get; set; }
        public virtual string Telefon { get; set; }
        public virtual string Lozinka { get; set; }
    }
}
