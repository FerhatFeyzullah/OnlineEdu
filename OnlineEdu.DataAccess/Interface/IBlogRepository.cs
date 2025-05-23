﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Interface
{
    public interface IBlogRepository : IRepository<Blog>
    {
        List<Blog> GetBlogsWithCategory();
        List<Blog> GetBlogsByCategoryId(int id);
        Blog GetBlogsWithCategory(int id);
        List<Blog> GetLast4BlogWithCategory();

        List<Blog> GetBlogsWithCategoryByWriter(int id);
    }
}
