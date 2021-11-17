using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_BlogProject.Controllers
{
    public class BloggerPanelController : Controller
    {
        // GET: BloggerPanel
        BloggerManager bm = new BloggerManager(new EfBloggerDal());
        BlogValidator blogValidator = new BlogValidator();
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
       

        [HttpGet]
        public ActionResult BloggerProfile(int id = 0)
        {
            string p = (string)Session["BloggerMail"];
            id = c.Bloggers.Where(x => x.BloggerMail == p).Select(y => y.BloggerID).FirstOrDefault();
            var bloggerValue = bm.GetByID(id);
            return View(bloggerValue);
        }

        [HttpPost]
        public ActionResult BloggerProfile(Blogger p)
        {

            ValidationResult result = blogValidator.Validate(p);
            if (result.IsValid)
            {

                bm.BloggerUpdate(p);
                return RedirectToAction("AllHeading", "BloggerPanel");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult AllHeading(int p = 1)
        {
            var headings = bm.GetList().ToPagedList(p, 4);
            return View(headings);
        }

        public ActionResult MyHeading(string p)
        {

            p = (string)Session["BloggerMail"];
            var bloggerIdInfo = c.Bloggers.Where(x => x.BloggerMail == p).Select(y => y.BloggerID).FirstOrDefault();
            var values = hm.GetListByBlogger(bloggerIdInfo);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewBlog()
        {
            //Dropdown da listeyi tutabilmek için kullandık.
            List<SelectListItem> valueCategory = (from x in cm.GetList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.vlc = valueCategory;

            List<SelectListItem> valueBlogger = (from x in bm.GetList() select new SelectListItem { Text = x.BloggerName + " " + x.BloggerSurName, Value = x.BloggerID.ToString() }).ToList();
            ViewBag.vlw = valueBlogger;
            return View();
        }
        [HttpPost]
        public ActionResult NewBlog(Heading p)
        {
            string writerMailInfo = (string)Session["BloggerMail"];
            var writerIdInfo = c.Bloggers.Where(x => x.BloggerMail == writerMailInfo).Select(y => y.BloggerID).FirstOrDefault();
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString()); //ekleme yaparken tarih olmadığından hata aldık bu yüzden tarih ekledik !!!
            p.BloggerID = writerIdInfo;
            hm.HeadingAdd(p);
            return RedirectToAction("MyHeading");

        }

        [HttpGet]
        public ActionResult EditBlog(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.vlc = valueCategory;

            var headingValue = hm.GetByID(id);
            return View(headingValue);
        }
        [HttpPost]
        public ActionResult EditBlog(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteBlog(int id)
        {
            var headingValue = hm.GetByID(id);
            hm.HeadingDelete(headingValue);
            return RedirectToAction("MyHeading");
        }
    }
}