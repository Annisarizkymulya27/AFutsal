using AFutsal.Data;
using AFutsal.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AFutsal.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Daftar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Daftar(UserViewModel datanya)
        {
            var data = new User()
            {
                Username = datanya.Username,
                Password = datanya.Password,
                Email = datanya.Email,
                Name = datanya.Name,
                Roles = _context.Tb_Roles.Where(x => x.Id == datanya.Roles).FirstOrDefault(),                
            };

            _context.Add(data); // insert to tb_user
            await _context.SaveChangesAsync(); // eksekusi

            //return RedirectToAction(controllerName:"Akun",actionName:"Masuk");
            return RedirectToAction("Masuk");
            //return Redirect("Masuk");
        }
        public IActionResult Masuk()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Masuk(User datanya)
        {
           
            var cariusername = _context.Tb_User.Where(bebas => bebas.Username == datanya.Username).FirstOrDefault();

            if (cariusername != null)
            {
                var cekpassword = _context.Tb_User.Where(  // proses pengecekan username & pass
                                            bebas =>
                                            bebas.Username == datanya.Username
                                            &&
                                            bebas.Password == datanya.Password
                                            )
                                    .Include(bebas2 => bebas2.Roles)
                                    .FirstOrDefault();

                if (cekpassword != null)
                {
                    // proses tampungan data
                    var daftar = new List<Claim>
                    {
                        new Claim("Username", cariusername.Username),
                        new Claim("Role", cariusername.Roles.Id)
                    };

                    // proses daftar auth
                    await HttpContext.SignInAsync(
                        new ClaimsPrincipal(
                            new ClaimsIdentity(daftar, "Cookie", "Username", "Role")
                            )
                        );

                    if (cariusername.Roles.Id == "1")
                    {
                        return RedirectToAction(controllerName: "Futsal", actionName: "Index");
                    }
                    else if(cariusername.Roles.Id == "2")
                    {
                        return RedirectToAction(controllerName: "Cust", actionName: "Index");
                    }

                    return RedirectToAction(controllerName: "Home", actionName: "Index");
                }

                ViewBag.pesan = "passwordnya salah";

                return View(datanya);
            }

            ViewBag.pesan = "username anda tidak ada";

            return View(datanya);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
