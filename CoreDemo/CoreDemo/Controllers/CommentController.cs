using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class CommentController : Controller
    {
        //CommentController : Web UI, PresentationLayer
        //CommentManager : BusinessLayer
        //EfRepository : DataAccessLayer
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
    
        public PartialViewResult CommentListByBlog(int id)
        {
           
            var values = cm.GetList(id);
            return PartialView(values);
        }
    }
}
