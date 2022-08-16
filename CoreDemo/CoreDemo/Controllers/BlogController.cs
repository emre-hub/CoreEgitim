using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    [AllowAnonymous] //blogları görüntülemek için authorize olmaya gerek yok.
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
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return View(values);
        }

        
    }
}
