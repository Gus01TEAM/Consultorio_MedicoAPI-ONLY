using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.Entities
{
    public class Rol
    {

        public int RolId { get; set; }
        public string Name { get; set; }
        public byte Status { get; set; }
    }
}
