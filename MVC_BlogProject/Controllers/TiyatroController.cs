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
    public class TiyatroController : Controller
    {
        ArtManager artManager = new ArtManager(new EfArtDal());
        CategoryTypeManager ct = new CategoryTypeManager(new EfCategoryTypeDal());
        // GET: Tiyatro
        public ActionResult Index(int id)
        {
            var allTheater = artManager.GetByCategoryID(id);
            return View(allTheater);

        }
        public ActionResult TheaterByType(int id)
        {
            var theaterType = artManager.GetByTypeID(3, id);
            return View(theaterType);
        }
        public PartialViewResult TheaterFilter()
        {
            var allType = ct.GetList();
            return PartialView(allType);
        }
    }
}