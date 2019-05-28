using MyEvernote.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEvernote.Entities;
using System.Net;
using MyEvernote.WebApp.ViewModels;

namespace MyEvernote.WebApp.Controllers
{
    public class HomeController : Controller
    {
        CategoryBusiness cb = new CategoryBusiness();
        NoteBusiness nb = new NoteBusiness();
        // GET: Home
        public ActionResult Index()
        {

            return View(nb.SelectAllNotes().OrderByDescending(x => x.ModifiedOn).ToList());   //Sıralama işlemi C# tarafında yapılyor.

            //return View(nb.SelectAllNotesQueryable().OrderByDescending(x => x.ModifiedOn).ToList()); //Sıralama işlemi Sql tarafında yapılır.
        }
        // GET: ByCategory
        public ActionResult ByCategory(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                return View("Index",nb.SelectNotesByCategoryId(id.Value).OrderByDescending(x=>x.ModifiedOn).ToList());
            }
           
        }
        public ActionResult MostLiked()
        {
            return View("Index", nb.SelectAllNotes().OrderByDescending(x => x.LikeCount).ToList());
        }
        public ActionResult Hakkimizda()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.kullaniciAdi=="aaa")
                {
                    ModelState.AddModelError("", "Kullanıcı adı kullanılıyor.");
                }
                if (model.ePosta=="aaa@aa.com")
                {
                    ModelState.AddModelError("", "E-Posta adı kullanılıyor.");
                }

            }
            foreach (var item in ModelState)
            {
                if (item.Value.Errors.Count>0)
                {
                    return View(model);
                }
                
            }
            return RedirectToAction("RegisterOk");
        }
    }
}