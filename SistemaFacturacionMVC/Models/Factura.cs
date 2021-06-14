using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

// Creado y modificado por: Erick Eduardo Echeverría Garrido - 14/06/2021

namespace SistemaFacturacionMVC.Models
{
    public class Factura
    {
        [Key]
        [Display(Name = "Código de Factura")]
        public int numero_factura { get; set; }


        [Display(Name = "Cliente")]
        public int? codigo_cliente { get; set; }
        [ForeignKey("codigo_cliente")]
        public virtual Cliente Cliente { get; set; }


        [Required(ErrorMessage = "El campo No puede ir vacio")]
        [Display(Name = "Fecha")]
        public DateTime fecha { get; set; }


        [Required(ErrorMessage = "El campo No puede ir vacio")]
        [Display(Name = "Total de la Factura")]
        public decimal total_factura { get; set; }


        [Required(ErrorMessage = "El campo No puede ir vacio")]
        [Display(Name = "Anulada")]
        public char anulada { get; set; }
    }
}
