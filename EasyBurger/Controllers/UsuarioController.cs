using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyBurger.Models;

namespace EasyBurger.Controllers
{
    public class UsuarioController : Controller
    {
        private BurgerContext context;

        public ActionResult Perfil()
        {
            Usuario usuario = (Usuario)Session["usuario"];
            context = new BurgerContext();

            ViewBag.Pedidos = context.Pedido.Where(p => p.Usuario_Id == usuario.Id).ToList();
            return View(usuario);
        }

        public ActionResult Clientes()
        {
            context = new BurgerContext();
            return View(context.Usuario.OrderBy(u => u.Nombre).ToList());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                context = new BurgerContext();
                Usuario usuario = context.Usuario.Find(id);
                if (usuario != null)
                {
                    return View(usuario);
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }
            return View("../Home/Index");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            try
            {
                string nombre = collection.Get("Nombre").ToString();
                string contrasenia = collection.Get("Contrasenia").ToString();

                context = new BurgerContext();
                Usuario usuario = context.Usuario.Where(u => u.Nombre.Equals(nombre)
                    && u.Contrasenia.Equals(contrasenia)).SingleOrDefault();

                if (usuario != null)
                {
                    Session.Add("usuario", usuario);
                }
                else
                {
                    ViewBag.Mensaje = "Usuario o Contraseña Incorrectos";
                    return View();
                }

                return RedirectToAction("../Home/Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("usuario");
            return RedirectToAction("../Home/Index");
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (collection.Get("Contrasenia").Equals(collection.Get("Confirmar")))
                {
                    context = new BurgerContext();
                    Usuario usuario = new Usuario();
                    usuario.Nombre = collection.Get("Nombre");
                    usuario.Apellido = collection.Get("Apellido");
                    usuario.Email = collection.Get("Email");
                    usuario.Sexo = collection.Get("Sexo");
                    usuario.Contrasenia = collection.Get("Contrasenia");
                    
                    context.Usuario.Add(usuario);
                    context.SaveChanges();
                }
                else
                {
                    ViewBag.Mensaje = "Las Contraseñas No Coinciden";
                    return View();
                }
                

                return RedirectToAction("../Home/Index");
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
