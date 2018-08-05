using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace elite_shopping.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public PartialViewResult MenCategories()
        {
            ViewBag.SubCategory = Classes.connection.el_entities.sub_category.Where(x => x.sex_id == 1);
            ViewBag.Fit = Classes.connection.el_entities.fit.ToList();
            ViewBag.Color = Classes.connection.el_entities.color.ToList();
            ViewBag.Material = Classes.connection.el_entities.material.ToList();
            ViewBag.Pattern = Classes.connection.el_entities.pattern.ToList();
            ViewBag.Neckline = Classes.connection.el_entities.neckline.ToList();
            ViewBag.Pocket = Classes.connection.el_entities.pocket.ToList();
            ViewBag.Size = Classes.connection.el_entities.size.ToList();

            return PartialView();
        }
    }
}