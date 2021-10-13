using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MJYBlog.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(Writer w)
        {
            Context c = new Context();
            var datavalue = c.Writers.FirstOrDefault(x => x.WriterEmail == w.WriterEmail && x.WriterPassword == w.WriterPassword);
            if (datavalue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,w.WriterEmail)
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal); //Şifreli bir cookie oluşturuyor
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                return View();
            }
        }
    }
}



//INDEX POST İÇERİĞİ SESSION İLE NORMALDE
//Context c = new Context();
//var datavalue = c.Writers.FirstOrDefault(x => x.WriterEmail == w.WriterEmail && x.WriterPassword == w.WriterPassword);
//if (datavalue != null)
//{
//    HttpContext.Session.SetString("username", w.WriterEmail);
//    return RedirectToAction("Index", "Writer");
//}
//else
//{
//    return View();
//}