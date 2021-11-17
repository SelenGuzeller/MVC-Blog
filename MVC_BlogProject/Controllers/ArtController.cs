using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_BlogProject.Controllers
{
    public class ArtController : Controller
    {
        // GET: Art
        ArtManager artManager = new ArtManager(new EfArtDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        CategoryTypeManager ctm = new CategoryTypeManager(new EfCategoryTypeDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            var artValues = artManager.GetList();
            return View(artValues);
        }

        [HttpGet]
        public ActionResult AddArt()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.vlc = valueCategory;
            
            List<SelectListItem> valueType = (from x in ctm.GetList() select new SelectListItem { Text = x.TypeName, Value = x.TypeID.ToString() }).ToList();
            ViewBag.vlt = valueType;
            return View();
        }

        [HttpPost]
        public ActionResult AddArt(Art art)
        {
            //ArtValidator artValidator = new ArtValidator();
            //ValidationResult result = artValidator.Validate(art);
            //if (result.IsValid)
            //{
            //    artManager.ArtAdd(art);
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    foreach (var item in result.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}
            artManager.ArtAdd(art);
            return RedirectToAction("Index");
        }





        //DENEME BAŞLANGICIIIII
        [HttpGet]
        public ActionResult AddArt2()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.vlc = valueCategory;

            List<SelectListItem> valueType = (from x in ctm.GetList() select new SelectListItem { Text = x.TypeName, Value = x.TypeID.ToString() }).ToList();
            ViewBag.vlt = valueType;
            return View();
        }

        [HttpPost]
        public ActionResult AddArt2(Art art)
        {
            Art_Validator validationRules = new Art_Validator();
            //ArtValidator av = new ArtValidator();
            ValidationResult result = validationRules.Validate(art);
            if (result.IsValid)
            {
                artManager.ArtAdd(art);
                return RedirectToAction("Index");
            }

            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            //artManager.ArtAdd(art);
            //return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditArt(int id)
        {
           
            List<SelectListItem> valueCategory = (from x in cm.GetList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.vlc = valueCategory;

            List<SelectListItem> valueType = (from x in ctm.GetList() select new SelectListItem { Text = x.TypeName, Value = x.TypeID.ToString() }).ToList();
            ViewBag.vlt = valueType;

            var artValue = artManager.GetByID(id);
            return View(artValue);
        }
        [HttpPost]
        public ActionResult EditArt(Art p)
        {
            artManager.ArtUpdate(p);
            return RedirectToAction("Index");
        }


        public ActionResult DeleteArt(int id)
        {

            var artValue = artManager.GetByID(id);
            artValue.ArtStatus = false;
            artManager.ArtDelete(artValue);
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public ActionResult ArtDetails(int id)
        {
            var getArt = artManager.GetByID(id);
            return View(getArt);
        }
        [AllowAnonymous]
        public PartialViewResult GetArtContents(int id)
        {
            var getContent = contentManager.GetListByArtID(id);
            return PartialView(getContent);
        }
    }
}