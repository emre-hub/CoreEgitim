using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository()); //DataAccess
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory(); //İlgili sayfa içerisine veriler Model-List yapısı olarak gidecek
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            var values = bm.GetBlogByID(id);
            return View(values);
        }
    }
}
