using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFacturacionMVC.Models
{
    public class P_VENTAS_CLIENTE
    {
        [Display(Name = "Codigo del Cliente")]
        public int codigo_cliente { get; set; }

        [Display(Name = "Nombres y Apellidos")]
        public string nombres { get; set; }

        [Display(Name = "Fecha")]
        public DateTime Dia { get; set; }

        [Key, Column(Order = 1)]
        [Display(Name = "Cantidad Vendida")]
        public decimal TotalVendido { get; set; }
    }
}
