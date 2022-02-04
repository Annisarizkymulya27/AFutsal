using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFutsal.Models
{
    public class Lapangan
    {
        [Key]
        public string IdLapang { get; set; }
        public string NamaLapang { get; set; }
        public string Fasilitas { get; set; }
        public int Tarif { get; set; }
        public bool Status { get; set; }

    }
}
