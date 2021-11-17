using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_BlogProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //HeadingManager hm = new HeadingManager(new EfHeadingDal());
        //ArtManager artManager = new ArtManager(new EfArtDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        BloggerManager bm = new BloggerManager(new EfBloggerDal());
        // GET: Home
        public ActionResult Index()
        {
            var allCategory = cm.GetList();
            return View(allCategory);
        }

        public PartialViewResult GetBlogger()
        {
            var allBlogger = bm.GetList();
            return PartialView(allBlogger);
        }
       

    }
}