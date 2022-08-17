using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        //IBlogDal'da tanımladığım metodu implement ettim :
        public List<Blog> GetListWithCategory()
        {
            using (var c = new Context())
            {
                //Include metodunu kullanabilmek icin
                //programa " using Microsoft.EntityFrameworkCore;" kodu ile import etmeliyim.

                return c.Blogs.Include( x=>x.Category).ToList();
            }
                 
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Blogs.Include(x => x.Category).Where(x=>x.WriterID==id).ToList();
            }
        }
    }
}
