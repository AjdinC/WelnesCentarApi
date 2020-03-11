using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RKS_WellnessCentar.ViewModels
{
    public class RegistracijaVM
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Lozinka { get; set; }
    }
}
