using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RKS_WellnessCentar.ViewModels
{
    public class MojeRezervacijeVM
    {
        public int ID { get; set; }
        public int? FK_Korisnik { get; set; }
        public int? FK_Tretman { get; set; }
        public string RezervisanoZa { get; set; }
        public int? FK_StatusRezervacije { get; set; }
        public decimal Cijena { get; set; }
        public string DataDeletedDate { get; set; }
        public bool DataDeleted { get; set; }
        public string TretmanNaziv { get; set; }
        public string StatusRezervacije { get; set; }
        public string UrlSlika { get; set; }
    }
}
