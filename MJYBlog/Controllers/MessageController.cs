using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJYBlog.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        public IActionResult Inbox()
        {
            int id = 2;
            var values = mm.GetInboxListByWriter(id);
            return View(values);
        }
        public IActionResult MessageDetails(int id)
        {
            var value = mm.TGetByID(id);
            return View(value);
        }
    }
}
