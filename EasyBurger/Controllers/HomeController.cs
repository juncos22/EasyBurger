using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyBurger.Models;

namespace EasyBurger.Controllers
{
    public class HomeController : Controller
    {
        private BurgerContext context;

        public ActionResult Index()
        {
            context = new BurgerContext();
            return View(context.Hamburguesa.ToList());
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        
    }
}