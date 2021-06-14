using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

// Creado y modificado por: Erick Eduardo Echeverría Garrido - 14/06/2021

namespace SistemaFacturacionMVC.Models
{
    public class Factura_Producto
    {
        [Key, Column(Order = 1)]
        [Display(Name = "Factura")]
        public int? numero_factura { get; set; }
        [ForeignKey("numero_factura")]
        public virtual Factura Factura { get; set; }


        [Key, Column(Order = 2)]
        [Display(Name = "Producto")]
        public int? codigo_producto { get; set; }
        [ForeignKey("codigo_producto")]
        public virtual Producto Producto { get; set; }


        [Required(ErrorMessage = "El campo No puede ir vacio")]
        [Display(Name = "Cantidad")]
        public int cantidad { get; set; }


        [Required(ErrorMessage = "El campo No puede ir vacio")]
        [Display(Name = "Precio Unitario")]
        public decimal precio_unitario { get; set; }


    }
}
