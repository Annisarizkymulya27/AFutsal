using AFutsal.Data;
using AFutsal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AFutsal.Controllers
{
    public class CustController : Controller
    {
        private readonly ILogger<CustController> _logger;

        private readonly AppDbContext _context;
        public CustController(AppDbContext context, ILogger<CustController> logger)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Lapang()
        {
            var data = _context.Tb_Lapang.ToList();
            return View(data);
        }

        public IActionResult Booking()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Booking(Reservasi x)
        {
            ViewBag.JamSelectList = new SelectList(GetJam(), "Jam");
            x.IdBooking = RandomString(5);
            _context.Tb_Reservasi.Add(x);
            await _context.SaveChangesAsync();

            return Redirect("../Home");
        }

        private static Random random = new Random();
        public static string RandomString(int lenght)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, lenght)
                                        .Select(s => s[random.Next(s.Length)])
                                        .ToArray());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private List<Reservasi> GetJam()
        {
            var jam = new List<Reservasi>();
            jam.Add(new Reservasi() { Jam = "08.00 - 10.00" });
            jam.Add(new Reservasi() { Jam = "10.00 - 12.00" });
            jam.Add(new Reservasi() { Jam = "12.00 - 14.00" });
            jam.Add(new Reservasi() { Jam = "14.00 - 16.00" });
            jam.Add(new Reservasi() { Jam = "16.00 - 18.00" });
            jam.Add(new Reservasi() { Jam = "18.00 - 20.00" });

            return jam;
        }
    }
}

