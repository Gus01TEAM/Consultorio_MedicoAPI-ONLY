using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.Entities.Interfaces
{
    public interface ISecurityDAL
    {
        public string EncriptarSHA256(string str);

        public bool ValidateLogin(Users pUser);

        public Users Login(string Login, string Password);

        public Users ChangePassword(Users users, string PasswordAnt);
    }
}
