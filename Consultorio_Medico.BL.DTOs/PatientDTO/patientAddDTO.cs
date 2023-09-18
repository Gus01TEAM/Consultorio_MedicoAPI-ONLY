using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.DTOs.PatientDTO
{
    public class patientAddDTO
    {
        public int patientId { get; set; }   
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Telefono { get; set; }
        public string DUI { get; set; }
    }
}
