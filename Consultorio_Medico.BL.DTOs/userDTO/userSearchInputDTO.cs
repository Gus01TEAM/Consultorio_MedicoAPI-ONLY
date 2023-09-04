using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.DTOs.userDTO
{
    public class userSearchInputDTO
    {
        public string? NameLike { get; set; }
        public string? PhonNumberLike { get; set; }
    }
}
