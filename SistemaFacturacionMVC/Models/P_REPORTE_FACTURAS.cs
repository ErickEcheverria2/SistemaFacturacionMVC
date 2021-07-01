using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFacturacionMVC.Models
{
    public class P_REPORTE_FACTURAS
    {
        [Display(Name = "Fecha")]
        public DateTime Dia { get; set; }

        [Display(Name = "Cantidad de Facturas")]
        public int cantidadFacturas { get; set; }

        [Key, Column(Order = 1)]
        [Display(Name = "Monto Facturado")]
        public decimal montoFacturado { get; set; }

        [Display(Name = "Cantidad De Productos Vendidos")]
        public int cantidadProductos { get; set; }
    }
}
