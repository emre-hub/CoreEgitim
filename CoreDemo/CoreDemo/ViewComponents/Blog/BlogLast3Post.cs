using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
    public class BlogLast3Post : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke()
        {
            //getlast3blog'dan dönen 3 elemanlı listeyi values'a atıp.
         //values'taki veriyi de views/shared/components/bloglast3post/default.cshtml'e gönderiyorum.
         //Bu, ViewComponent yapısıdır
            var values = bm.GetLast3Blog(); 
            return View(values);
        }
    }
}
