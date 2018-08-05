using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using elite_shopping.Models;
using System.Web.Security;

namespace elite_shopping.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(user u)
        {
            string uname = ValidateUser(u.name, u.password);

            if (!string.IsNullOrEmpty(uname))
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, u.name, DateTime.Now, DateTime.Now.AddMinutes(60), true, u.name, FormsAuthentication.FormsCookiePath);
                HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName);

                Response.Cookies.Add(ck);

                FormsAuthentication.RedirectFromLoginPage(u.name, true);

                if (ticket.IsPersistent)
                {
                    ck.Expires = ticket.Expiration;
                }
            }

            return RedirectToAction("NewPage", "Contact");
        }

        public ActionResult LogOut(string url)
        {
            FormsAuthentication.SignOut();
            return Redirect(url);
        }

        private string ValidateUser(string un, string pwd)
        {
            user u = elite_shopping.Classes.connection.el_entities.user.FirstOrDefault(x => x.name == un && x.password == pwd);

            if (u != null)
                return u.name;
            return "";
        }
    }
}