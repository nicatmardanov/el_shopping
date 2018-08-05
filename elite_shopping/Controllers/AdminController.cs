using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using elite_shopping.Models;
using System.Drawing;

namespace elite_shopping.Controllers
{
    [Authorize(Roles ="Admin, Moderator")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Product()
        {
            return View(elite_shopping.Classes.connection.el_entities.product.ToList());
        }

        public ActionResult AddProduct()
        {
            ViewBag.Collection = elite_shopping.Classes.connection.el_entities.collection.ToList();
            ViewBag.SubCategory = elite_shopping.Classes.connection.el_entities.sub_category.ToList();
            ViewBag.Material = elite_shopping.Classes.connection.el_entities.material.ToList();
            ViewBag.Neckline = elite_shopping.Classes.connection.el_entities.neckline.ToList();
            ViewBag.Pattern = elite_shopping.Classes.connection.el_entities.pattern.ToList();
            ViewBag.Fit = elite_shopping.Classes.connection.el_entities.fit.ToList();
            ViewBag.Pocket = elite_shopping.Classes.connection.el_entities.pocket.ToList();
            //ViewBag.Size = elite_shopping.Classes.connection.el_entities.size.ToList();
            ViewBag.Color = elite_shopping.Classes.connection.el_entities.color.ToList();

            return View();
        }

        elite_shoppingEntities eshop_entities = new elite_shoppingEntities();

        [HttpPost]
        public ActionResult AddProduct(product pr, string sMale, string sFemale, product_features pf, string sleeveLong, string sleeveShort, int[] size, int[] color, product_info pi, HttpPostedFileBase[] img)
        {
           

            if (sleeveLong == "long")
                pf.sleeve_id = 1;
            else if (sleeveShort == "short")
                pf.sleeve_id = 2;

            if (pf.material_id == 0)
                pf.material_id = null;

            if (pf.neckline_id == 0)
                pf.neckline_id = null;

            if (pf.pattern_id == 0)
                pf.pattern_id = null;

            if (pf.pocket_id == 0)
                pf.pocket_id = null;

            if (pf.upper_fit_id == 0)
                pf.pocket_id = null;

            if (pf.base_id == 0)
                pf.base_id = null;

            if (pf.bottom_fit_id == 0)
                pf.bottom_fit_id = null;


            eshop_entities.product_features.Add(pf);
            eshop_entities.SaveChanges();



            if (sMale == "male")
                pr.sex_id = 1;
            else if (sFemale == "female")
                pr.sex_id = 2;

            if (pr.sub_category_id == 0)
                pr.sub_category_id = null;


            pr.product_features_id = pf.id;

            pr.approved = true;

            eshop_entities.product.Add(pr);
            eshop_entities.SaveChanges();

            for (int i = 0; i < size.Length; i++)
            {
                size_prod_pivot sp = new size_prod_pivot();
                sp.size_id =  (byte)size[i];
                sp.product_id = pf.id;

                eshop_entities.size_prod_pivot.Add(sp);
                eshop_entities.SaveChanges();
            }

            for (int i = 0; i < color.Length; i++)
            {
                color_prod_pivot cp = new color_prod_pivot();
                cp.color_id = (byte)color[i];
                cp.product_id = pf.id;

                eshop_entities.color_prod_pivot.Add(cp);
                eshop_entities.SaveChanges();
            }

            for (int i = 0; i < img.Length; i++)
            {
                string path = "";
                string path_small = "";

                if (img[i] != null)
                {
                    Image myImg = Image.FromStream(img[i].InputStream);

                    Bitmap bm = new Bitmap(myImg, 600, 750);
                    path = "/Content/images/" + Guid.NewGuid() + System.IO.Path.GetExtension(img[i].FileName);
                    bm.Save(Server.MapPath(path));

                    Bitmap bm_small = new Bitmap(myImg, 100, 125);
                    path_small = "/Content/images/" + Guid.NewGuid() + "small"+System.IO.Path.GetExtension(img[i].FileName);
                    bm.Save(Server.MapPath(path_small));

                }

                elite_shopping.Models.picture pc = new picture();
                pc.medium = path;
                pc.product_id = pf.id;

                eshop_entities.picture.Add(pc);
                eshop_entities.SaveChanges();

                elite_shopping.Models.picture pc_small = new picture();
                pc_small.small = path_small;
                pc_small.product_id = pf.id;

                eshop_entities.picture.Add(pc_small);
                eshop_entities.SaveChanges();
            }


            return RedirectToAction("Product");
        }
    }
}