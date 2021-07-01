using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFacturacionMVC.Models
{
    public class P_VENTAS_PRODUCTO_FILTRADO_CODIGOP
    {
        
        [Display(Name = "Codigo del Producto")]
        public int codigo_producto { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Display(Name = "Fecha")]
        public DateTime Dia { get; set; }

        [Key, Column(Order = 1)]
        [Display(Name = "Cantidad Vendida")]
        public decimal TotalVendido { get; set; }

        
    }
}
