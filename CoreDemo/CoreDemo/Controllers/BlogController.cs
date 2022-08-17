using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo.Controllers
{
    [AllowAnonymous] //blogları görüntülemek için authorize olmaya gerek yok.
    public class BlogController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
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

        public IActionResult BlogListByWriter()
        {
            var values = bm.Test(1);
            return View(values);  
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {            
            //DropDownList Kullanımı  :
            //kategorileri dropdown list aracılığı ile çekeceğiz.

            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                   Text=x.CategoryName,
                                                   Value=x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View();  
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            BlogValidator bv = new BlogValidator();
            //ValidationResult'ı çağırırken import edilecek paket DataAnnotations değildir
            //Burada FluentValidation.Results'ı çağıracağız.
            ValidationResult results = bv.Validate(p);

            if (results.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = 1;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog"); // Views/BLog içerisinde BlogListByWriter'a git. 
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogvalue =bm.TGetById(id);

            //DropDownList Kullanımı  :
            //kategorileri dropdown list aracılığı ile çekeceğiz.
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;

            return View(blogvalue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            //her guncellemede create date degerini guncellememesi icin kurdugum yapi : 
            var blogValue = bm.TGetById(p.BlogID); 
            p.BlogCreateDate = DateTime.Parse(blogValue.BlogCreateDate.ToShortDateString());
            
            p.WriterID = 1;
            p.BlogStatus = true;
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
