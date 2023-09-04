using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.DTOs.userDTO
{
    public class securityDTO
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string Login { get; set; }
        public int rolId { get; set; }
        public string RolName { get; set; }

    }
}
