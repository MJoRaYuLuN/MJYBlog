using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _catagoryDal;
        public CategoryManager(ICategoryDal catagoryDal)
        {
            _catagoryDal = catagoryDal;
        }

        public void CategoryAdd(Category category)
        {
            _catagoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _catagoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _catagoryDal.Update(category);
        }

        public Category GetById(int id)
        {
            return _catagoryDal.GetByID(id);
        }

        public List<Category> GetList()
        {
            return _catagoryDal.GetListAll();
        }
    }
}
