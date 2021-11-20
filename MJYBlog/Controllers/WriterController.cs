using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MJYBlog.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MJYBlog.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        Context c = new Context();
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var usermail = User.Identity.Name;
            var writerid = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var writervalues = wm.TGetByID(writerid);
            return View(writervalues);
        }
        [HttpPost]
        public IActionResult WriterEditProfile(Writer p)
        {
            WriterValidator wl = new WriterValidator();
            ValidationResult results = wl.Validate(p);
            if (results.IsValid)
            {
                wm.TUpdate(p);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
        [HttpGet]
        public IActionResult WriterAdd()
        {

            return View();
        }
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new Writer();
            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimagename;
            }
            w.WriterName = p.WriterName;
            w.WriterEmail = p.WriterEmail;
            w.WriterPassword = p.WriterPassword;
            w.WriterPasswordConfirm = p.WriterPasswordConfirm;
            w.WriterStatus = true;
            w.WriterAbout = p.WriterAbout;
            wm.TAdd(w);
            return View();
        }
    }
}
