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

        public void TAdd(Category t)
        {
            _catagoryDal.Insert(t);
        }

        public void TDelete(Category t)
        {
            _catagoryDal.Delete(t);
        }

        public void TUpdate(Category t)
        {
            _catagoryDal.Update(t);
        }
        public Category GetById(int id)
        {
            return _catagoryDal.GetByID(id);
        }
        public List<Category> GetList()
        {
            return _catagoryDal.GetListAll();
        }

        //public void CategoryAdd(Category category)
        //{
        //    _catagoryDal.Insert(category);
        //}

        //public void CategoryDelete(Category category)
        //{
        //    _catagoryDal.Delete(category);
        //}

        //public void CategoryUpdate(Category category)
        //{
        //    _catagoryDal.Update(category);
        //}

    }
}
