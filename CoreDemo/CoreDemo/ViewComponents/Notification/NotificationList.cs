using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.EntityFramework;
using BusinessLayer.Concrete;

namespace CoreDemo.ViewComponents.Notification
{
    public class NotificationList : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke()
        {
            var values = bm.GetLast3Blog();
            return View(values);
        }
    }
}
