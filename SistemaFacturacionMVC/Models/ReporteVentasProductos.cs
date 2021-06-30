using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFacturacionMVC.Models
{
    public class ReporteVentasProductos
    {
        [Display(Name = "Producto")]
        public int codigo_producto { get; set; }

        [Display(Name = "Cantidad Vendida")]
        public decimal cantidadVendida { get; set; }

        [Display(Name = "Fecha")]
        public DateTime fecha { get; set; }
    }
}
