using Microsoft.AspNetCore.Mvc;
using SistemaFacturacionMVC.DB;
using SistemaFacturacionMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Creado y modificado por: Erick Eduardo Echeverría Garrido - 15/06/2021

namespace SistemaFacturacionMVC.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Producto> listProductos = _context.Productos;
            return View(listProductos);
        }
        public IActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Add(producto);
                _context.SaveChanges();

                TempData["mensaje"] = "El Producto se ha añadido correctamente";

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var libro = _context.Productos.Find(id);

            if(libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Update(producto);
                _context.SaveChanges();

                TempData["mensaje"] = "El Producto se ha actualizado correctamente";

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var libro = _context.Productos.Find(id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProducto(int? id)
        {
            var producto = _context.Productos.Find(id);

            if (producto == null)
            {
                return NotFound();
            }


            _context.Productos.Remove(producto);
            _context.SaveChanges();

            TempData["mensaje"] = "El Producto se ha eliminado correctamente";

            return RedirectToAction("Index");

        }

    }
}
