using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.Entities
{
    public class WorkPlace
    {
        [Key]
        public int WorkPlacesId { get; set; }
        public string WorkPlaces { get; set; }
    }
}
