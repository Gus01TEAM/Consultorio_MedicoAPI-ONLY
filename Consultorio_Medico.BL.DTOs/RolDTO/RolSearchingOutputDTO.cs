using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.DTOs.RolDTO
{
    public class RolSearchingOutputDTO
    {
        public int RolId { get; set; }
        public string Name { get; set; }

        public byte  Status { get; set; }
        string strStatus="";
        public String StrStatus{
            get{
                if(Status==1){
                    strStatus="ACTIVO";
                }
                else{
                    strStatus="INACTIVO";
                }
                return strStatus;
            }
        } 
    }

    }

