using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MJYBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJYBlog.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        RegisterCity rg = new RegisterCity();
        [HttpGet]
        public IActionResult Index()
        {
            GetCityList();
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer w)
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult result = wv.Validate(w);
            if (result.IsValid)
            {
                // Writer Validator Kullanımı Sonrasında Bu şekilde kullabiliriz.
                w.WriterStatus = true;
                wm.TAdd(w);
                return RedirectToAction("Index");

                //Writer Validator ve Writer class'ında WriterConfirmPassword yoksa iaction içeriğine string WriterConfirmPassword eklenmeli ve aşağıdaki kısım kullanılmalı
                //if (w.WriterPassword == WriterConfirmPassword)
                //{
                //    w.WriterStatus = true;
                //    wm.WriterAdd(w);
                //    return RedirectToAction("Index");
                //}
                //else
                //{
                //    return View(w);
                //}
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                GetCityList();
                return View(w);
            }
            
        }
        public void GetCityList()
        {
            List<SelectListItem> values = (from x in rg.RegisterCities()
                                           select new SelectListItem
                                           {
                                               Text = x.CountryName,
                                               Value = x.CountryValue
                                           }).ToList();
            ViewBag.city = values;
        }
    }
}
