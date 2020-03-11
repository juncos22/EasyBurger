using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyBurger.Models;

namespace EasyBurger.Controllers
{
    public class PedidoController : Controller
    {
        private BurgerContext context;
        // GET: Pedido

        public ActionResult Realizar(int id)
        {
            Usuario usuario = (Usuario)Session["usuario"];
            if (usuario != null)
            {
                context = new BurgerContext();
                Estado estado = context.Estado.Where(e => e.Tipo.Equals("En Proceso")).SingleOrDefault();
                Hamburguesa hamburguesa = context.Hamburguesa.Find(id);
                Usuario u = context.Usuario.Find(usuario.Id);

                Pedido pedido = new Pedido();
                pedido.Estado = estado;
                pedido.Hamburguesa = hamburguesa;
                pedido.Usuario = u;
                pedido.Total = hamburguesa.Precio;
                context.Pedido.Add(pedido);
                context.SaveChanges();
                ViewBag.Mensaje = "Pedido Realizado Con Exito";
            }
            else
            {
                return RedirectToAction("../Usuario/Login");
            }
            return View("../Hamburguesa/Menu");
        }
    }
}