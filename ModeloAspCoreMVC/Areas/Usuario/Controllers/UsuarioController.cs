using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModeloAspCoreMVC.Compartilhado;
using Microsoft.AspNetCore.Http;

namespace ModeloAspCoreMVC.Areas.Usuario.Controllers
{
    public class UsuarioController : Controller
    {
        IHttpContextAccessor contexto;
        public UsuarioController(IHttpContextAccessor contexto)
        {
            this.contexto = contexto;
        }
        public IActionResult Login()
        {
            
            return View();
        }
        public IActionResult Perfil()
        {
            if (Autorizacao.EhAutorizado(contexto))
            {
                ViewData["Nome"] = Autorizacao.getUsuario(contexto).Nome;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }
    }
}