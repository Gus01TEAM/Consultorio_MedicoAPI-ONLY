using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Consultorio_Medico.BL.DTOs.userDTO
{
    public class userUpdateDTO
    {
        public int UserId { get; set; }
        [ForeignKey("Rol")]
        [Required(ErrorMessage = "Rol es obligatorio.")]
        [Display(Name = "Rol")]
        public int RolId { get; set; }


        [Required(ErrorMessage = "Nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Teléfono es obligatorio.")]
        [StringLength(10, ErrorMessage = "Maximo 10 caracteres")]
        [Display(Name = "Teléfono")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "El Dui es obligatorio.")]
        [StringLength(25, ErrorMessage = "Maximo 25 caracteres")]
        public string Dui { get; set; }
        [Required(ErrorMessage = "El Email es obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El usuario para iniciar sesion es obligatorio.")]
        [StringLength(25, ErrorMessage = "Maximo 25 caracteres")]
        public string Login { get; set; }
        [Required(ErrorMessage = "El Estado es requerido.")]
        public byte Status { get; set; }
    }
    public enum Estado_Usuario          //Sirve para saber el estado del Usuario. Ya que en la base de Datos se guarda en Entero.
    {
        ACTIVO = 1,
        INACTIVO = 2
    }
}
