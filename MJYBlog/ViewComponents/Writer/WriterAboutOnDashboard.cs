using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJYBlog.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var usermail = User.Identity.Name;
            var writerid = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = wm.GetWriterById(writerid);
            return View(values);
        }
    }
}
