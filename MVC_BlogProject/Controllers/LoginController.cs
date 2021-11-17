using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_BlogProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        BloggerLoginManager bm = new BloggerLoginManager(new EfBloggerDal());
        MemberLoginManager mm = new MemberLoginManager(new EfMemberDal());
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult BloggerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BloggerLogin(Blogger p)
        {
            var bloggerUserInfo = bm.GetBlogger(p.BloggerMail, p.BloggerPassword);
            if (bloggerUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(bloggerUserInfo.BloggerMail, false);
                Session["BloggerMail"] = bloggerUserInfo.BloggerMail;
                return RedirectToAction("BloggerProfile", "BloggerPanel");
            }
            else
            {
                return RedirectToAction("BloggerLogin");

            }
        }

        [HttpGet]
        public ActionResult MemberLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MemberLogin(Member p)
        {
            var memberUserInfo = mm.GetMember(p.MemberMail, p.MemberPassword);
            if (memberUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(memberUserInfo.MemberMail, false);
                Session["MemberMail"] = memberUserInfo.MemberMail;
                return RedirectToAction("Inbox", "MemberMessage");
            }
            else
            {
                return RedirectToAction("MemberLogin");

            }
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Member member)
        {
            mm.AddMember(member);
            return RedirectToAction("MemberLogin","Login");
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

    }
}