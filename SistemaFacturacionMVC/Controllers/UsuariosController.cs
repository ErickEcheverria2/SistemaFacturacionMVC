using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaFacturacionMVC.Areas.Identity.Data;
using SistemaFacturacionMVC.Data;
using SistemaFacturacionMVC.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFacturacionMVC.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly AuthDbContext _context;

        public UsuariosController(AuthDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationUser> list = _context.Users;
            return View(list);
        }

        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = _context.Users.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationUser usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Update(usuario);
                _context.SaveChanges();

                TempData["mensaje"] = "El Usuario se ha actualizado correctamente";

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = _context.Users.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteUsuario(ApplicationUser usuario)
        {
            //var cliente = _context.Clientes.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }


            _context.Users.Remove(usuario);
            _context.SaveChanges();

            TempData["mensaje"] = "El Usuario se ha eliminado correctamente";

            return RedirectToAction("Index");

        }


    }
}
