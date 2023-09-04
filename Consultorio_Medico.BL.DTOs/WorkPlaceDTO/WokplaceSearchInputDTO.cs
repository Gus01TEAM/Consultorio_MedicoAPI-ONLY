using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.DTOs.WorkPlaceDTO
{
    public class WokplaceSearchInputDTO
    {
        public int WorkplacesId { get; set; } 
        public string WorkPlaces{ get; set; }

        public Task Search(WokplaceSearchInputDTO wokplace)
        {
            throw new NotImplementedException();
        }
    }
}
