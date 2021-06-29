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
        
        public async Task<IActionResult> Index(int? id)
        {
            var aplicationDbContext = _context.factura_Productos.Where(p => p.numero_factura == id).Include(p => p.Producto);
            TempData["NoFactura"] = id;
            return View(await aplicationDbContext.ToListAsync());
        }

        public IActionResult Create(int? id)
        {
            ViewData["productos"] = new SelectList(_context.Productos.Where(p => p.activo == 'S').ToList(), "codigo_producto", "nombre");
            ViewData["precios"] = new SelectList(_context.Productos, "codigo_producto", "precio");
            ViewData["existencia"] = new SelectList(_context.Productos, "codigo_producto", "existencia");

            TempData["NoFactura"] = id;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Factura_Producto detalle)
        {
            if (ModelState.IsValid)
            {
                Producto p = _context.Productos.Find(detalle.codigo_producto);
                detalle.precio_unitario = p.precio; // Le asigna el precio unitario ya que desde la vista lo trae érroneo

                _context.factura_Productos.Add(detalle);
                _context.SaveChanges();

                // -----------------------------
                // -Actualizacion de Existencia-
                // -----------------------------
                Producto producto = _context.Productos.Find(detalle.codigo_producto); // Traigo el producto al objeto
                producto.existencia = producto.existencia - detalle.cantidad; // Resto existencia

                _context.Productos.Update(producto); // Actualizo todo nuevamente
                _context.SaveChanges(); // Guardo Cambios

                // ---------------------------------------
                // -Actualizacion del Total de la Factura-
                // ---------------------------------------
                Factura factura = _context.facturas.Find(detalle.numero_factura);
                factura.total_factura = factura.total_factura + (detalle.precio_unitario * detalle.cantidad);
                _context.facturas.Update(factura);
                _context.SaveChanges();


                TempData["mensaje"] = "La compra se ha añadido correctamente";
                return RedirectToAction("Index", new { id = detalle.numero_factura });

            }

            return View();
        }

        public IActionResult Edit(int? id, int? codigo_producto)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var detalle = _context.factura_Productos.Find(id,codigo_producto);

            if (detalle == null)
            {
                return NotFound();
            }
            TempData["NoFactura"] = id;
            TempData["CodigoProducto"] = codigo_producto;

            Producto p = _context.Productos.Find(detalle.codigo_producto);

            ViewData["productos"] = new SelectList(_context.Productos.Where(p => p.codigo_producto == codigo_producto).ToList(), "codigo_producto", "nombre");
            TempData["precioUnitario"] = detalle.precio_unitario;
            TempData["existencia"] = p.existencia + detalle.cantidad;
            return View(detalle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Factura_Producto detalleRecibido)
        {
            if (ModelState.IsValid)
            {
                int? IdFactura = detalleRecibido.numero_factura;
                int? IdCodigoProducto = detalleRecibido.codigo_producto;

                var detalleObtenerCosto = await _context.factura_Productos.AsNoTracking().FirstOrDefaultAsync(x => x.numero_factura == IdFactura && x.codigo_producto == IdCodigoProducto);

                Factura factura = _context.facturas.Find(detalleRecibido.numero_factura);
                factura.total_factura = factura.total_factura - (detalleObtenerCosto.cantidad * detalleObtenerCosto.precio_unitario); // Descontamos el precio anterior
                factura.total_factura = factura.total_factura + (detalleRecibido.cantidad * detalleRecibido.precio_unitario); // Sumamos la nueva compra

                _context.factura_Productos.Update(detalleRecibido);
                _context.SaveChanges();

                _context.facturas.Update(factura);
                _context.SaveChanges();

                

                TempData["mensaje"] = "La Compra se ha actualizado correctamente";

                return RedirectToAction("Index", new { id = detalleRecibido.numero_factura });
            }

            return View();
        }

        public void actualizarDetalle(Factura_Producto detalleRecibido)
        {
            _context.factura_Productos.Update(detalleRecibido);
            _context.SaveChanges();
        }


    }
}
