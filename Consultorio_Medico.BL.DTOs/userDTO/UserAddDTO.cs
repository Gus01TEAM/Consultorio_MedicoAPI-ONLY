using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Consultorio_Medico.BL.DTOs.DoctorSpecialtiesDTO;
using Consultorio_Medico.BL.DTOs.UserSchedule;

namespace Consultorio_Medico.BL.DTOs.userDTO
{
    public class UserAddDTO
    {
    
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


        [Required(ErrorMessage = "El Password es obligatorio. ")]
        [DataType(DataType.Password)]
        [StringLength(32, ErrorMessage = "Password debe estar entre 5 y 32 caracteres", MinimumLength = 5)]
        public string Password { get; set; }

        [Required(ErrorMessage = "El Estado es requerido, 1 activo, 2 inactivo.")]
        public byte Status { get; set; }
        [Display(Name = "Fecha registro")]
        public DateTime FechaRegistro { get; set; }

        [Required(ErrorMessage = "Confirmar el Password")]
        [StringLength(32, ErrorMessage = "Password debe estar entre 5 a 32 caracteres", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password y Confirmar Password deben ser iguales")]
        [Display(Name = "Confirmar Password")]
        [NotMapped]
        public string ConfirmarPassword_aux { get; set; }

        public List<DoctorSpecialtiesInputDTO> DoctorSpecialtie { get; set; }

        public List<UserScheduleSearchInpuntDTO> UserSchedules { get; set; }

    }
   
}


