using AFutsal.Data;
using AFutsal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFutsal.Controllers
{
    public class FutsalController : Controller
    {
        
        private readonly AppDbContext _context;
        public FutsalController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Tb_Lapang.ToList();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Lapangan x)
        {
            x.IdLapang = RandomString(5);
            _context.Tb_Lapang.Add(x);
           await _context.SaveChangesAsync();
           
            return Redirect("../Cust");
        }
        private static Random random = new Random();
        public static string RandomString(int lenght)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, lenght)
                                        .Select(s => s[random.Next(s.Length)])
                                        .ToArray());
        }
    }
}
