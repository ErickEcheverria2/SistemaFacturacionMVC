using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaFacturacionMVC.DB;
using SistemaFacturacionMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFacturacionMVC.Controllers
{
    [Authorize]
    public class Facturas_ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Facturas_ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? idFactura, int? nit)
        {
            var list = _context.factura_Productos.Find(idFactura,nit);
            return View(list);
        }
        public IActionResult Create()
        {
            ViewData["productos"] = new SelectList(_context.Clientes, "codigo_producto", "nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Factura_Producto detalle)
        {
            if (ModelState.IsValid)
            {
                _context.factura_Productos.Add(detalle);
                _context.SaveChanges();

                TempData["mensaje"] = "El producto se ha añadido correctamente";

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
