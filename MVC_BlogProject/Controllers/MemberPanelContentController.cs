using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;

namespace MVC_BlogProject.Controllers
{
    public class MemberPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();
        // GET: MemberPanelContent
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MyArtContent(string p)
        {

            p = (string)Session["MemberMail"];
            var memberIdInfo = c.Members.Where(x => x.MemberMail == p).Select(y => y.MemberID).FirstOrDefault();
            var contentValues = cm.GetListByMember(memberIdInfo);
            return View(contentValues);

        }
        [HttpGet]
        public ActionResult AddArtContent(int id)
        {
            ViewBag.d = id; //seçilen başlıkta id taşımak gerek bu yüzden buraya atadık ve frontend de hidden şeklinde tuttuk
            return View();
        }
        [HttpPost]
        public ActionResult AddArtContent(Content p)
        {
            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            string mail = (string)Session["MemberMail"];
            var memberIdInfo = c.Members.Where(x => x.MemberMail == mail).Select(y => y.MemberID).FirstOrDefault();
            p.MemberId = memberIdInfo;
            p.ContentStatus = true;
            cm.ContentAdd(p);
            return RedirectToAction("MyArtContent");
        }

        public ActionResult MyHeadingContent(string p)
        {

            p = (string)Session["MemberMail"];
            var memberIdInfo = c.Members.Where(x => x.MemberMail == p).Select(y => y.MemberID).FirstOrDefault();
            var contentValues = cm.GetListByMember(memberIdInfo);
            return View(contentValues);

        }
        [HttpGet]
        public ActionResult AddHeadingContent(int id)
        {
            ViewBag.d = id; //seçilen başlıkta id taşımak gerek bu yüzden buraya atadık ve frontend de hidden şeklinde tuttuk
            return View();
        }
        [HttpPost]
        public ActionResult AddHeadingContent(Content p)
        {
            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            string mail = (string)Session["MemberMail"];
            var memberIdInfo = c.Members.Where(x => x.MemberMail == mail).Select(y => y.MemberID).FirstOrDefault();
            p.MemberId = memberIdInfo;
            p.ContentStatus = true;
            cm.ContentAdd(p);
            return RedirectToAction("MyHeadingContent");
        }

        public ActionResult DeleteArtContent(int id)
        {
            var artContent = cm.GetByArtID(id);
            cm.ContentDelete(artContent);
            return RedirectToAction("MyArtContent");
        }
        public ActionResult DeleteHeadingContent(int id)
        {
            var headingContent = cm.GetByHeadingID(id);
            cm.ContentDelete(headingContent);
            return RedirectToAction("MyHeadingContent");
        }
    }
}