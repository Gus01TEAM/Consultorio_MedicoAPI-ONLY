using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.Entities
{
    public class Specialties
    {
        [Key]
        public int SpecialtiesId { get; set; }
        public string Specialty { get; set; }
    }
}
