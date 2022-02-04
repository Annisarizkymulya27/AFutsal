using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFutsal.Models
{
    public class Reservasi
    {
        [Key]
        public string IdBooking { get; set; }
        public string Nama { get; set; }
        public string NoHP { get; set; }
        public string Email { get; set; }
        public DateTime Tanggal { get; set; }
        public string Jam { get; set; }

    }
}
