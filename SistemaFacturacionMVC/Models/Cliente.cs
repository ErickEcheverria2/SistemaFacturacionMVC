using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

// Creado y modificado por: Erick Eduardo Echeverría Garrido - 14/06/2021

namespace SistemaFacturacionMVC.Models
{
    public class Cliente
    {
        [Key]
        [Display(Name = "Código de Cliente")]
        public int codigo_cliente { get; set; }



        [Required(ErrorMessage = "El campo No puede ir vacio")]
        [Display(Name = "Nombres")]
        public string nombres { get; set; }


        [Required(ErrorMessage = "El campo No puede ir vacio")]
        [Display(Name = "Apellidos")]
        public string apellidos { get; set; }


        [Required(ErrorMessage = "El campo No puede ir vacio")]
        [Display(Name = "NIT")]
        public string nit { get; set; }


        [Required(ErrorMessage = "El campo No puede ir vacio")]
        [Display(Name = "Telefonos")]
        public string telefonos { get; set; }


        [Required(ErrorMessage = "El campo No puede ir vacio")]
        [Display(Name = "Activo")]
        public string activo { get; set; }

    }
}
