using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.Entities
{
    public class DoctorSpecialties
    {
        [Key]
        public int DoctorSpecialtiesId { get; set; }
        [ForeignKey("users")]
        public int UserId { get; set; }
        [ForeignKey("specialties")]
        public int SpecialtieId { get; set; }

        public Users user { get; set; }
        public Specialties specialties { get; set; }
    }
}
