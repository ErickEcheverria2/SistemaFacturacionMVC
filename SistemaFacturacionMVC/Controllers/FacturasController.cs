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

// Creado y modificado por: Erick Eduardo Echeverría Garrido - 17/06/2021

namespace SistemaFacturacionMVC.Controllers
{
    [Authorize]
    public class FacturasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacturasController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var aplicationDbContext = _context.facturas.Include(p => p.Cliente);
            return View(await aplicationDbContext.ToListAsync());

            //IEnumerable<Factura> list = _context.facturas;
            //return View(list);
        }
        public IActionResult Create()
        {
            var listItems = _context.Clientes.Select(p => new SelectListItem { Value = Convert.ToString(p.codigo_cliente), Text = p.nit + " | " + p.nombres + " " + p.apellidos + "  |  Activo: "+p.activo }).ToList();
            ViewData["nit"] = new SelectList(listItems, "Value", "Text");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Factura factura)
        {
            if (ModelState.IsValid)
            {
                _context.facturas.Add(factura);
                _context.SaveChanges();
                
                TempData["mensaje"] = "La Factura se ha añadido correctamente";

                return RedirectToAction("Index", "Facturas_Productos", new { id = factura.numero_factura });

            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var factura = _context.facturas.Find(id);

            if (factura == null)
            {
                return NotFound();
            }

            var listItems = _context.Clientes.Select(p => new SelectListItem { Value = Convert.ToString(p.codigo_cliente), Text = p.nit + " | " + p.nombres + " " + p.apellidos + "  |  Activo: " + p.activo }).ToList();
            ViewData["nit"] = new SelectList(listItems, "Value", "Text");
            return View(factura);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Factura factura)
        {
            if (ModelState.IsValid)
            {
                _context.facturas.Update(factura);
                _context.SaveChanges();

                TempData["mensaje"] = "La Factura se ha actualizado correctamente";

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

            var factura = _context.facturas.Find(id);

            if (factura == null)
            {
                return NotFound();
            }

            var listItems = _context.Clientes.Select(p => new SelectListItem { Value = Convert.ToString(p.codigo_cliente), Text = p.nit + " | " + p.nombres + " " + p.apellidos + "  |  Activo: " + p.activo }).ToList();
            ViewData["nit"] = new SelectList(listItems, "Value", "Text");

            return View(factura);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFactura(Factura factura)
        {
            if (factura == null)
            {
                return NotFound();
            }

            try
            {
                _context.facturas.Remove(factura);
                _context.SaveChanges();

                TempData["mensaje"] = "La Factura se ha eliminado correctamente";

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorRelacional");
            }
        }

        public IActionResult ErrorRelacional()
        {
            return View();
        }

    }
}
