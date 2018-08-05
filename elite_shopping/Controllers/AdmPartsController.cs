using elite_shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace elite_shopping.Controllers
{
    public class AdmPartsController : Controller
    {
        // GET: AdmParts
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult category_ajax(int id)
        {
            Models.elite_shoppingEntities es = new elite_shoppingEntities();
            es.Configuration.ProxyCreationEnabled = false;

            var inf = es.sub_category.Where(x => x.sex_id == id);

            return Json(new { data = inf }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult size_ajax(int id)
        {
            Models.elite_shoppingEntities es = new elite_shoppingEntities();
            es.Configuration.ProxyCreationEnabled = false;

            var inf = es.size.Where(x=>x.category_id==id);

            return Json(new { data = inf }, JsonRequestBehavior.AllowGet);
        }
    }
}