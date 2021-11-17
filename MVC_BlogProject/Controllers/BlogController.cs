using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
namespace MVC_BlogProject.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        // GET: Blog

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BlogHeadings(int p=1)
        {
            var allBlog = hm.GetList().ToPagedList(p,5);
            return View(allBlog);
        }
        public ActionResult Blogs()
        {
            var allBlog = hm.GetList();
            return View(allBlog);
        }
        public ActionResult BlogDetail(int id)
        {
            var detailBlog = hm.GetByID(id);
            return View(detailBlog);
        }

        public PartialViewResult GetBlogContents(int id)
        {
            var getContent = contentManager.GetListByHeadingID(id);
            return PartialView(getContent);
        }
    }
}