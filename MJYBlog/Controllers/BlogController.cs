using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJYBlog.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c = new Context();
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.blogId = id;
            var values = bm.GetBlogByID(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var usermail = User.Identity.Name;
            var writerid = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = bm.GetListWithCategoryByWriterBm(writerid);
            return View(values);
        }
        public void GetCategoryList()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            GetCategoryList();
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            var usermail = User.Identity.Name;
            var writerid = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterID).FirstOrDefault();
            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(p);
            if (result.IsValid)
            {
                // Writer Validator Kullanımı Sonrasında Bu şekilde kullabiliriz.
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = writerid;
                bm.TAdd(p);
                return RedirectToAction("BlogListWriter", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                GetCategoryList();
                return View(p);
            }
        }
        //public IActionResult DeleteBlog(int id)
        //{
        //    var blogvalue = bm.TGetByID(id);
        //    bm.TDelete(blogvalue);
        //    return RedirectToAction("BlogListWriter", "Blog");

        //}
        public IActionResult DeleteBlog(int id)
        {
            var x = bm.TGetByID(id);
            x.BlogStatus = false;
            bm.TUpdate(x);
            TempData["success"] = "Blog silindi.";
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            GetCategoryList();
            var blog = bm.TGetByID(id);
            return View(blog);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog b)
        {
            var x = bm.TGetByID(b.BlogID);
            x.BlogTitle = b.BlogTitle;
            x.BlogImage = b.BlogImage;
            x.BlogThumbnailImage = b.BlogThumbnailImage;
            x.CategoryID = b.CategoryID;
            x.BlogContent = b.BlogContent;
            bm.TUpdate(x);
            return RedirectToAction("BlogListByWriter");
        }
    }
}

