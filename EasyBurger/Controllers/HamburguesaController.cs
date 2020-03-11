using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyBurger.Models;

namespace EasyBurger.Controllers
{
    public class HamburguesaController : Controller
    {
        private BurgerContext context;

        // GET: Hamburguesa
        public ActionResult Menu()
        {
            context = new BurgerContext();
            return View(context.Hamburguesa.ToList());
        }

        public ActionResult Detalles(int id)
        {
            context = new BurgerContext();
            return View(context.Hamburguesa.Find(id));
        }
    }
}