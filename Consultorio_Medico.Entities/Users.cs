using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Consultorio_Medico.Entities
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [ForeignKey("Rol")]
        public int RolId { get; set; }
        [ForeignKey("WorkPlace")]
        public int WorkplaceId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Dui { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public byte Status { get; set; }
        public DateTime FechaRegistro { get; set; }

       public Rol Rol { get; set; }
      public  WorkPlace WorkPlace { get; set; }
      
    }

    public enum Users_Status          //Sirve para saber el estado del Usuario. Ya que en la base de Datos se guarda en Entero.
    {
        ACTIVE = 1,
        INACTIVE = 2
    }
}
