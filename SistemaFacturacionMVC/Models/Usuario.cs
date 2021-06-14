using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

// Creado y modificado por: Erick Eduardo Echeverría Garrido - 14/06/2021

namespace SistemaFacturacionMVC.Models
{
    public class Usuario
    {
        [Key]
        [Display(Name = "Código de Usuario")]
        public int codigo_usuario { get; set; }


        [Required(ErrorMessage = "El campo No puede ir vacio")]
        [Display(Name = "Nombre Completo")]
        public string nombreApellido { get; set; }



        [Required(ErrorMessage = "El campo No puede ir vacio")]
        [Display(Name = "Correo Electronico")]
        public string correoElectronico { get; set; }


        [Required(ErrorMessage = "El campo No puede ir vacio")]
        [Display(Name = "Contraseña")]
        public string clave { get; set; }
    }
}
