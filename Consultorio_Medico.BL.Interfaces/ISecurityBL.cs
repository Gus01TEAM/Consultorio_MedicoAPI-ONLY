using Consultorio_Medico.BL.DTOs.userDTO;
using Consultorio_Medico.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.Interfaces
{
    public interface ISecurityBL
    {
        public Users ChangePassword(Users users, string PasswordAnt);
        public securityDTO Login(LoginDTO login); //string Login, string Password);
    }
}
