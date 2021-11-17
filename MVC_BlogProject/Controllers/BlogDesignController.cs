using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_BlogProject.Controllers
{
    public class BlogDesignController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        BloggerManager bm = new BloggerManager(new EfBloggerDal());
        // GET: BlogDesign
        public ActionResult Index()
        {
            var headingValues = hm.GetList();
            return View(headingValues);
            
        }
        [HttpGet]
        public ActionResult AddBlog()
        {
            //Dropdown da listeyi tutabilmek için kullandık.
            List<SelectListItem> valueCategory = (from x in cm.GetList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.vlc = valueCategory;

            List<SelectListItem> valueBlogger = (from x in bm.GetList() select new SelectListItem { Text = x.BloggerName + " " + x.BloggerSurName, Value = x.BloggerID.ToString() }).ToList();
            ViewBag.vlw = valueBlogger;
            return View();
        }
        [HttpPost]
        public ActionResult AddBlog(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString()); //ekleme yaparken tarih olmadığından hata aldık bu yüzden tarih ekledik !!!

            //RESİMLERİ KLASÖRDEN ÇEKMEK İÇİN YAZDIM SQL'E YÜKLENDİ Imaages Klasörününde de Fotolar kaydedilmesine rağmen blog sayfasında gözükmedi
            //
            //if (Request.Files.Count >0)
            //{
            //    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
            //  // ilk deneme //string yol = "~/Images/" + dosyaadi + uzanti;
            //  // ilk deneme  //Request.Files[0].SaveAs(Server.MapPath(yol));
            //  // ilk deneme //p.HeadingImage= "~/Images/" + dosyaadi + uzanti;
            //   //ilk deneme //string uzanti = Path.GetExtension(Request.Files[0].FileName);
            //    string _dosyaAdi = DateTime.Now.ToString("yymmssfff") + dosyaadi;
            //    string yol = "~/Images/" + _dosyaAdi;
            //    Request.Files[0].SaveAs(Server.MapPath(yol));
            //    p.HeadingImage = "~/Images" + _dosyaAdi;
            //}
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditBlog(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.vlc = valueCategory;

            List<SelectListItem> valueBlogger = (from x in bm.GetList() select new SelectListItem { Text = x.BloggerName + " " + x.BloggerSurName, Value = x.BloggerID.ToString() }).ToList();
            ViewBag.vlw = valueBlogger;

            var headingValue = hm.GetByID(id);
            return View(headingValue);
        }
        [HttpPost]
        public ActionResult EditBlog(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }



        public ActionResult DeleteBlog(int id)
        {

            var headingValue = hm.GetByID(id);
            hm.HeadingDelete(headingValue);
            return RedirectToAction("Index");
        }

    }
}