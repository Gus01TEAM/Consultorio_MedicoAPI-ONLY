using Consultorio_Medico.BL.DTOs.DoctorSpecialtiesDTO;
using Consultorio_Medico.BL.DTOs.DTOs;
using Consultorio_Medico.BL.DTOs.userDTO;
using Consultorio_Medico.BL.Interfaces;
using Consultorio_Medico.Entities;
using Consultorio_Medico.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Consultorio_Medico.BL
{
    public class UserBL : IUserBL
    {
        private readonly IUserDAL _userDAL;
        private readonly IDoctorSpecialtiesBL _doctorSpecialties;
        private readonly ISecurityDAL _securityDAL;
        private readonly IUnitOfWork _unitOfWork;

        public UserBL(IUserDAL userDAL, IUnitOfWork unitOfWork, ISecurityDAL security, IDoctorSpecialtiesBL doctorSpecialties)
        {

            _securityDAL = security;
            _userDAL = userDAL;
            _doctorSpecialties = doctorSpecialties;
            _unitOfWork = unitOfWork;   
        }

        public async Task<int> Create(UserAddDTO pUser)
        {
            try
            {
                #region Crear objeto de Users
                Users user = new Users()
                {

                    RolId = pUser.RolId,
                    WorkplaceId = pUser.WorkplaceId,
                    Name = pUser.Name,
                    LastName = pUser.LastName,
                    PhoneNumber = pUser.PhoneNumber,
                    Dui = pUser.Dui,
                    Email = pUser.Email,
                    Login = pUser.Login,
                    Password = pUser.Password,
                    Status = pUser.Status,
                    FechaRegistro = pUser.FechaRegistro,

                };
                #endregion

                #region VALIDAR LOGIN Y ENCRIPTAR PASSWORD
                bool ExisteLogin = _securityDAL.ValidateLogin(user);
                if (ExisteLogin)
                    throw new ArgumentException("El Login ya existe, Intente uno diferente");
                string pass = user.Password;
                user.Password = _securityDAL.EncriptarSHA256(pass); 
                #endregion

                _userDAL.Create(user);
                var result = await _unitOfWork.SaveChangesAsync();

                #region DoctorSpecialtie
                //foreach (var item in pUser.DoctorSpecialtie)
                //{
                //    item.UserId = user.UserId;
                //}
                //var response = await _doctorSpecialties.CreateList(pUser.DoctorSpecialtie); 
                #endregion

                if (result > 0 /*&& response > 0*/)
                    return result;
                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public async Task<int> Delete(int Id)
        {
            Users UserEn = await _userDAL.GetById(Id);
            if (UserEn.UserId == Id)
            {
                _userDAL.Delete(UserEn);
                return await _unitOfWork.SaveChangesAsync();
            }
            else
                return 0;

        }

        public async Task<userSearchOutputDTO> GetById(int Id)
        {
            Users UserEn = await _userDAL.GetById(Id);
            return new userSearchOutputDTO()
            {
                UserId = UserEn.UserId,
                RolId = UserEn.RolId,
                WorkplaceId = UserEn.WorkplaceId,
                Name= UserEn.Name,
                LastName= UserEn.LastName,
                PhoneNumber = UserEn.PhoneNumber,
                Dui = UserEn.Dui,
                Email = UserEn.Email,
                Login = UserEn.Login,
                Status = UserEn.Status,
                FechaRegistro = UserEn.FechaRegistro    

            };

        }

        public async Task<List<userSearchOutputDTO>> Search(userSearchInputDTO pUser)
        {
            List<Users> users = await _userDAL.Search(new Users { Name = pUser.NameLike, PhoneNumber = pUser.PhonNumberLike });
            List<userSearchOutputDTO> list = new List<userSearchOutputDTO>();
            users.ForEach(s => list.Add(new userSearchOutputDTO
            {
                UserId = s.UserId,
                RolId = s.RolId,
                WorkplaceId = s.WorkplaceId,
                Name = s.Name,
                LastName = s.LastName,
                PhoneNumber = s.PhoneNumber,
                Dui = s.Dui,
                Email = s.Email,
                Status = s.Status,
                Login = s.Login,
                RolName =s.Rol.Name,
                WorkPlaceName=s.WorkPlace.WorkPlaces,
            })) ;
            return list;
            }

        public async Task<int> Update(userUpdateDTO pUser)
        {
            try
            {
                Users UserEn = await _userDAL.GetById(pUser.UserId);
                if (UserEn.UserId == pUser.UserId)
                {
                    UserEn.UserId = pUser.UserId;
                    UserEn.RolId = pUser.RolId ;
                    UserEn.WorkplaceId = pUser.WorkplaceId;
                    UserEn.Name = pUser.Name;
                    UserEn.LastName = pUser.LastName;
                    UserEn.PhoneNumber = pUser.PhoneNumber;
                    UserEn.Dui = pUser.Dui;
                    UserEn.Email = pUser.Email;
                    UserEn.Login = pUser.Login;
                    UserEn.Status = pUser.Status;

                    bool ExistLogin = _securityDAL.ValidateLogin(UserEn);
                    if (ExistLogin)
                        throw new ArgumentException("El Login ya existe");

                    _userDAL.Update(UserEn);
                    return await _unitOfWork.SaveChangesAsync();

                }
                else return 0;
            }
            catch (Exception e)
            {

                throw;
            }

         }
        }


}

