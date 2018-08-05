using elite_shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace elite_shopping.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact

        elite_shoppingEntities el = new elite_shoppingEntities();

        public ActionResult Index()
        {
            return View(el.info.ToList());
        }

        [HttpPost]
        public ActionResult Add_Message(contact_messages cm)
        {
            el.contact_messages.Add(cm);
            el.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles ="Admin")]
        public ActionResult NewPage()
        {
            return View();
        }

    }
}