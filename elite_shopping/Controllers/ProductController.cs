using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using elite_shopping.Models;
using System.Data.Entity;

namespace elite_shopping.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Man()
        {
            return View();
        }

        [HttpPost]
        public JsonResult sort(product_features pf, string fit_id, string[] color, string[] size, string sleeve, string category_id, product[] prod_arg)
        {
            elite_shoppingEntities eshopping_entities = new elite_shoppingEntities();
            eshopping_entities.Configuration.ProxyCreationEnabled = false;

            byte sl = 0;
            if (sleeve == "long")
                sl = 1;
            else
                sl = 0;

            List<product_features> s_product_features = eshopping_entities.product_features.ToList();
            //List<product> prod = eshopping_entities.product.AsNoTracking().ToList();
            List<product> prod = prod_arg.ToList();
            List<size_prod_pivot> size_product = eshopping_entities.size_prod_pivot.ToList();
            List<color_prod_pivot> color_product = eshopping_entities.color_prod_pivot.ToList();
            bool unFeature = true;


            if (pf.material_id > 0)
            {
                s_product_features = s_product_features.Where(x => x.material_id == pf.material_id).ToList();
                unFeature = false;
            }

            if (pf.neckline_id > 0)
            {
                s_product_features = s_product_features.Where(x => x.neckline_id == pf.neckline_id).ToList();
                unFeature = false;
            }

            if (pf.pattern_id > 0)
            {
                s_product_features = s_product_features.Where(x => x.pattern_id == pf.pattern_id).ToList();
                unFeature = false;
            }

            if (pf.pocket_id > 0)
            {
                s_product_features = s_product_features.Where(x => x.pocket_id == pf.pocket_id).ToList();
                unFeature = false;
            }

            if (pf.sleeve_id > 0)
            {
                s_product_features = s_product_features.Where(x => x.sleeve_id == sl).ToList();
                unFeature = false;
            }

            try
            {
                if (int.Parse(fit_id) > 0)
                {
                    s_product_features = s_product_features.Where(x => x.upper_fit_id == byte.Parse(fit_id) || x.bottom_fit_id == byte.Parse(fit_id)).ToList();
                    unFeature = false;
                }
            }
            catch (Exception ex)
            {

            }

            if (pf.base_id > 0)
            {
                s_product_features = s_product_features.Where(x => x.base_id == pf.base_id).ToList();
                unFeature = false;
            }

            if (s_product_features.Count > 0)
            {
                try
                {
                    prod = prod.Where(x => x.sub_category_id == byte.Parse(category_id)).ToList();
                }
                catch (Exception ex)
                {

                }

                List<IEnumerable<product>> p_instance = new List<IEnumerable<product>>();

                if (!unFeature)
                {
                    foreach (product_features item in s_product_features)
                    {
                        p_instance.Add(prod.Where(x => x.product_features_id == item.id).ToList());
                    }

                    prod.Clear();

                    foreach (var item in p_instance)
                    {
                        prod = prod.Union(item).ToList();
                    }

                }


                try
                {
                    if (size.Length > 0 && color.Length > 0 && prod.Count > 0)
                    {

                        foreach (product item in prod)
                        {
                            size_product = size_product.Where(x => x.product_id == item.id).ToList();
                        }

                        foreach (product item in prod)
                        {
                            color_product = color_product.Where(x => x.product_id == item.id).ToList();
                        }

                        foreach (string item in size)
                        {
                            size_product = size_product.Union(size_product.Where(x => x.size_id == int.Parse(item))).ToList();
                        }

                        foreach (string item in color)
                        {
                            color_product = color_product.Union(color_product.Where(x => x.color_id == int.Parse(item))).ToList();
                        }
                    }
                }
                catch (Exception ex)
                {
                }

                List<IEnumerable<picture>> pic_instance = new List<IEnumerable<picture>>();
                List<picture> pics = eshopping_entities.picture.ToList();

                foreach (product item in prod)
                {
                    //pics = pics.Union(pics.Where(x=>x.product_id==item.id)).ToList();
                    pic_instance.Add(pics.Where(x => x.product_id == item.id).ToList());
                }

                pics.Clear();

                foreach (var item in pic_instance)
                {
                    pics = pics.Union(item).ToList();
                }

                List<discount> dscount = new List<discount>();

                if (pics.Count > 0)
                    return Json(new { data = prod, pictures = pics }, JsonRequestBehavior.AllowGet);
            }

            return Json(new EmptyResult(), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Sort_Products(int id, product[] pr, picture[] pc)
        {

            elite_shoppingEntities eshopping_entities = new elite_shoppingEntities();
            eshopping_entities.Configuration.ProxyCreationEnabled = false;

            List<discount> dsc = eshopping_entities.discount.AsNoTracking().Where(x => x.active == true).ToList();
            List<product> prd = pr.ToList();

            if (id > 0 && id < 3)
            {
                if (id == 1)
                {
                    prd = prd.OrderBy(x => x.price).ToList();
                }

                else
                {
                    prd = prd.OrderByDescending(x => x.price).ToList();
                }

            }

            else
            {
                if (id == 3)
                {
                    prd = prd.OrderBy(x => x.id).ToList();
                }

                else
                {
                    prd = prd.OrderByDescending(x => x.id).ToList();
                }
            }


            return PartialView(prd);

            //return Json(new { data = pr, pics = pc, dscount = dsc }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Sort_Products_Json(int id, product[] pr, picture[] pc)
        {

            elite_shoppingEntities eshopping_entities = new elite_shoppingEntities();
            eshopping_entities.Configuration.ProxyCreationEnabled = false;

            List<discount> dsc = eshopping_entities.discount.AsNoTracking().Where(x => x.active == true).ToList();
            List<product> prd = pr.ToList();

            if (id > 0 && id < 3)
            {
                if (id == 1)
                {
                    prd = prd.OrderBy(x => x.price).ToList();
                }

                else
                {
                    prd = prd.OrderByDescending(x => x.price).ToList();
                }

            }

            else
            {
                if (id == 3)
                {
                    prd = prd.OrderBy(x => x.id).ToList();
                }

                else
                {
                    prd = prd.OrderByDescending(x => x.id).ToList();
                }
            }


            return Json(new { data = prd }, JsonRequestBehavior.AllowGet);

            //return Json(new { data = pr, pics = pc, dscount = dsc }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult All_Products()
        {

            return PartialView(Classes.connection.el_entities.product.Where(x => x.sex_id == 1).ToList());
        }

        public ActionResult Products_json()
        {
            elite_shoppingEntities es = new elite_shoppingEntities();
            es.Configuration.ProxyCreationEnabled = false;
            return Json(new { data = es.product.ToList() }, JsonRequestBehavior.AllowGet);
        }

    }
}