using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

// Creado y modificado por: Erick Eduardo Echeverría Garrido - 14/06/2021

namespace SistemaFacturacionMVC.Models
{
    public class Producto
    {
        [Key]
        [Display(Name = "Código de Producto")]
        public int codigo_producto { get; set; }


        [Required(ErrorMessage = "El campo No puede ir vacio")]
        [Display(Name = "Tipo de Producto")]
        public string tipo_producto { get; set; }


        [Required(ErrorMessage = "El campo No puede ir vacio")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }


        [Required(ErrorMessage = "El campo No puede ir vacio")]
        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }


        [Required(ErrorMessage = "El campo No puede ir vacio")]
        [Display(Name = "Precio")]
        public decimal precio { get; set; }


        [Required(ErrorMessage = "El campo No puede ir vacio")]
        [Display(Name = "Costo")]
        public decimal costo { get; set; }


        [Required(ErrorMessage = "El campo No puede ir vacio")]
        [Display(Name = "Existencia")]
        public decimal existencia { get; set; }


        [Required(ErrorMessage = "El campo No puede ir vacio")]
        [Display(Name = "Activo")]
        public char activo { get; set; }
    }
}
