﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultorio_Medico.BL.DTOs.userDTO;
using Consultorio_Medico.BL.Interfaces;
using Consultorio_Medico.Entities;
using Consultorio_Medico.Entities.Interfaces;

namespace Consultorio_Medico.BL
{
    public class SecurityBL: ISecurityBL
    {
        private readonly ISecurityDAL _securityDAL;
        private readonly IUnitOfWork _unitOfWork;

        public SecurityBL (ISecurityDAL securityDAL, IUnitOfWork unitOfWork)
        {
            _securityDAL = securityDAL;
            _unitOfWork = unitOfWork;
        }

        public Users ChangePassword(Users users, string PasswordAnt)
        {
            throw new NotImplementedException();
        }

        public  securityDTO Login(LoginDTO login)
        {
            try
            {              
                login.password = _securityDAL.EncriptarSHA256(login.password);
                
                var User = _securityDAL.Login(login.login,login.password);
                securityDTO secDTO = new securityDTO()
                {
                    userId = User.UserId,
                    userName = User.Name,
                    Login = User.Login,
                    rolId = User.RolId,
                    RolName = User.Rol.Name
                };
                return secDTO;
            }
            catch (Exception)
            {
                securityDTO secDTO = new securityDTO();
                return secDTO;
            }
        }
    }
}
