using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJYBlog.Controllers
{
    [AllowAnonymous]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.v1 = c.Blogs.Where(x => x.BlogStatus == true).Count();
            ViewBag.v2 = c.Blogs.Where(x => x.WriterID==1).Count();
            ViewBag.v3 = c.Categories.Where(x => x.CategoryStatus==true).Count();
            return View();
        }
    }
}
