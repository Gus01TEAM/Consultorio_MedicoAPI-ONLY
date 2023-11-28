using Consultorio_Medico.BL.DTOs.userDTO;
using Consultorio_Medico.Entities;
using Consultorio_Medico.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.DAL
{
    public class SecurityDAL: ISecurityDAL
    {
        readonly ConsultorioDbContext DbContext;

        public SecurityDAL(ConsultorioDbContext pDbContext)
        {
            DbContext = pDbContext;
        }

        #region SEGURIDAD
        public string EncriptarSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public bool ValidateLogin(Users pUser)
        {
            bool result = false;
            var loginUsuarioExiste = DbContext.Users.FirstOrDefault(s => s.Login == pUser.Login && s.UserId != pUser.UserId);
            if (loginUsuarioExiste != null && loginUsuarioExiste.UserId > 0 && loginUsuarioExiste.Login == pUser.Login)
                result = true;
            return result;
        }

        public Users Login(string Login, string Password)
        {
            try
            {              
                Users pUsers = new Users();
                //var users= DbContext.Users.ToList();
                pUsers = DbContext.Users.Include(s => s.Rol).AsQueryable().FirstOrDefault(s => s.Login == Login && s.Password == Password && s.Status == (byte)Users_Status.ACTIVE);
                if (pUsers is null)
                    throw new ArgumentException("El usuario no Existe");
                else
                    return pUsers;

            }
            catch (Exception e)
            {
                Users user = new Users();
                return user;
            }
        }

        public Users ChangePassword(Users users, string PasswordAnt)
        {
            try
            {
                int result = 0;
                var passwordAnt = EncriptarSHA256(PasswordAnt);

                Users pUsers = DbContext.Users.FirstOrDefault(s => s.UserId == users.UserId);

                if (passwordAnt != pUsers.Password.Trim())
                    throw new ArgumentException("El password actual es incorrecto");

                pUsers.Password = EncriptarSHA256(users.Password);
                DbContext.Users.Update(pUsers);
                result = DbContext.SaveChanges();

                return pUsers;
            }
            catch (Exception e)
            {
                return users;
            }
        }
        #endregion
    }
}
