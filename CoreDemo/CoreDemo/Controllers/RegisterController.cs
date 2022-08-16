using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());

        //Ekleme işlemi yapılırken, HttpGet ve HttpPost attribute'larının
        //tanımlandığı metodların adları aynı olmak zorundadır.
        //(bkz. aşağıdaki iki adet metodun da adı Index) : 

        //HttpGet : Sayfa yüklenince çalışır
        //HttpPost : Buton tetiklendiğinde çalışacak.
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer p)
        {
            WriterValidator wv = new WriterValidator();
            //ValidationResult'ı çağırırken import edilecek paket DataAnnotations değildir
            //Burada FluentValidation.Results'ı çağıracağız.
            ValidationResult results = wv.Validate(p);

            if (results.IsValid)
            {
                p.WriterStatus = true;
                p.WriterAbout = "Deneme Test";
                wm.WriterAdd(p);
                return RedirectToAction("Index", "Blog"); //BlogController içinde Index Actiona git. 
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
