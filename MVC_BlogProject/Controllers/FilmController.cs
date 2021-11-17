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
    public class FilmController : Controller
    {
        ArtManager artManager = new ArtManager(new EfArtDal());
        CategoryTypeManager ct = new CategoryTypeManager(new EfCategoryTypeDal());
        // GET: Movie 
        public ActionResult Index(int id,string p)
        {
            var allMovie = artManager.GetByCategoryID(id);
            //if (!string.IsNullOrEmpty(p))
            //{
            //    allMovie = allMovie.Where(x =>x.ArtName.Contains("p")).ToList();
            //}
           
            return View(allMovie);
        }

        public ActionResult MovieByType(int id)
        {
            var movieType = artManager.GetByTypeID(1,id);
            return View(movieType);
        }

        public PartialViewResult MovieFilter()
        {
            var allType = ct.GetList();
            return PartialView(allType);
        }

        
    }
}