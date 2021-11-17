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
    public class DiziController : Controller
    {
        ArtManager artManager = new ArtManager(new EfArtDal());
        CategoryTypeManager ct = new CategoryTypeManager(new EfCategoryTypeDal());
        // GET: Dizi
        public ActionResult Index(int id)
        {
            var allSeries = artManager.GetByCategoryID(id);
            return View(allSeries);
        }
        public ActionResult SerisByType(int id)
        {
            var seriesType = artManager.GetByTypeID(2, id);
            return View(seriesType);
        }

        public PartialViewResult SeriesFilter()
        {
            var allType = ct.GetList();
            return PartialView(allType);
        }
    }
}