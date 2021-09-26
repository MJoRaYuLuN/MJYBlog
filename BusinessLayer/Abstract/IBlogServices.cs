﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogServices
    {
        void BlogAdd(Blog category);
        void BlogDelete(Blog category);
        void BlogUpdate(Blog category);
        List<Blog> GetList();
        Blog GetById(int id);
        List<Blog> GetBlogListWithCategory();
    }
}
