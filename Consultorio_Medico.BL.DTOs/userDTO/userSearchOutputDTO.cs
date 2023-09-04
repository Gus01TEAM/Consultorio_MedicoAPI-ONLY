using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.DTOs.userDTO
{
    public class userSearchOutputDTO
    {
        [DisplayName("Id Usuario")]
        public int UserId { get; set; }
        [DisplayName("Rol")]
        public int RolId { get; set; }
        [DisplayName("Lugar de Trabajo")]
        public int WorkplaceId { get; set; }
        public string WorkPlaceName { get; set; }
        public string RolName { get; set; }
        [DisplayName("Nombre")]
        public string Name { get; set; }
        [DisplayName("Apellido")]
        public string LastName { get; set; }
        [DisplayName("Telefono")]
        public string PhoneNumber { get; set; }
        [DisplayName("DUI")]
        public string Dui { get; set; }
        [DisplayName("Login")]
        public string? Login { get; set; }
        [DisplayName("Email")]
        public string? Email { get; set; }
        [DisplayName("Estado")]
        public byte Status { get; set; }
        [DisplayName("Fecha Registro")]
        public DateTime FechaRegistro { get; set; }
    }

}
