using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.Entities
{
    public class Clinic
    {
        [Key]
        public int ClinicsId { get; set; }

        public string OfficeName { get; set; }

        public string OfficeAddres { get; set; }

        public string OfficeEmail  { get; set; } 

        public string OfficePhone { get; set; }
       
    }
}
