using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult PartialAddComment(Comment p)
        {
            p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.CommentStatus = true;
            p.BlogID = 15;
            cm.CommentAdd(p);

            return PartialView();
        }

        public PartialViewResult CommentListByBlog(int id)
        {
           
            var values = cm.GetList(id);
            return PartialView(values);
        }
    }
}
