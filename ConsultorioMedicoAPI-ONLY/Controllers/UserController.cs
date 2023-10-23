
using Consultorio_Medico.BL;
using Consultorio_Medico.BL.DTOs.RolDTO;
using Consultorio_Medico.BL.DTOs.userDTO;
using Consultorio_Medico.BL.Interfaces;
using Consultorio_Medico.Entities;
using ConsultorioMedicoAPI_ONLY.DTOGenericResponse;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Consultorio_Medico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL _userBL;
        private readonly ILogger<UserController> _logger;
        DTOGenericResponse<List<userSearchOutputDTO>> ListDTOresponse = new DTOGenericResponse<List<userSearchOutputDTO>>();
        DTOGenericResponse<userSearchOutputDTO> DTOGenResponse = new DTOGenericResponse<userSearchOutputDTO>();

        public UserController(IUserBL userBL, ILogger<UserController> logger)
        {
            _userBL = userBL;
            _logger = logger;
        }



        // GET: api/<UserController>
        [HttpGet]
        public async Task<DTOGenericResponse<List<userSearchOutputDTO>>> Get()
        {
            _logger.LogInformation("---- INICIO METODO GET USER CONTROLLER ----");

            userSearchInputDTO user = new userSearchInputDTO();
            var users = await _userBL.Search(user);

            var DTOGenResponse = ListDTOresponse.GetGenericResponse(true, "Obtencion de todos los registros", users);
            _logger.LogInformation("---- FIN METODO GET USER CONTROLLER ----");
            return DTOGenResponse;
        }

        // GET api/<UserController>/5
        [HttpGet("{Id}")]
        public async Task<DTOGenericResponse<userSearchOutputDTO>> Get(int Id)
        {
            _logger.LogInformation("---- INICIO METODO GET USER CONTROLLER ----");

            var user = await _userBL.GetById(Id);

            var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, $"Obtencion del registro con Id {Id} registros", user);
            _logger.LogInformation("---- FIN METODO GET USER CONTROLLER ----");
            return pDTOGenResponse;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<DTOGenericResponse<userSearchOutputDTO>> Post(UserAddDTO pUser)
        {
            try
            {
                _logger.LogInformation("---- INICIO METODO POST USER API CONTROLLER ----");

                var user = await _userBL.Create(pUser);
                if (user > 0)
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, "Creacion correcta", new userSearchOutputDTO()
                    {

                        RolId = pUser.RolId,
                        WorkplaceId = pUser.WorkplaceId,
                        Name = pUser.Name,
                        LastName = pUser.LastName,
                        PhoneNumber = pUser.PhoneNumber,
                        Dui = pUser.Dui,
                        Email = pUser.Email,
                        Login = pUser.Login,
                        Status = pUser.Status,
                        FechaRegistro = pUser.FechaRegistro
                    });
                    _logger.LogInformation("---- FIN METODO POST USER API CONTROLLER ----");
                    return pDTOGenResponse;
                }
                else
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(false, "Error al crear", new userSearchOutputDTO()
                    {
                        RolId = pUser.RolId,
                        WorkplaceId = pUser.WorkplaceId,
                        Name = pUser.Name,
                        LastName = pUser.LastName,
                        PhoneNumber = pUser.PhoneNumber,
                        Dui = pUser.Dui,
                        Email = pUser.Email,
                        Login = pUser.Login,
                        Status = pUser.Status,
                        FechaRegistro = pUser.FechaRegistro
                    });
                    _logger.LogWarning("---- ERROR EN METODO POST USER API CONTROLLER ----");
                    return pDTOGenResponse;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("--- ERROR : " + ex.Message + " ----");
                var DTOGenRes = DTOGenResponse.GetGenericResponse(false, "Error : " + ex.Message, new userSearchOutputDTO()
                {
                    RolId = pUser.RolId,
                    WorkplaceId = pUser.WorkplaceId,
                    Name = pUser.Name,
                    LastName = pUser.LastName,
                    PhoneNumber = pUser.PhoneNumber,
                    Dui = pUser.Dui,
                    Email = pUser.Email,
                    Login = pUser.Login,
                    Status = pUser.Status,
                    FechaRegistro = pUser.FechaRegistro
                });
                return DTOGenRes;
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{Id}")]
        public async Task<DTOGenericResponse<userSearchOutputDTO>> Put(int Id, userUpdateDTO pUser)
        {
            try
            {
                _logger.LogInformation("---- INICIO METODO POST USER API CONTROLLER ----");

                var user = await _userBL.Update(pUser);
                if (user > 0)
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, "Creacion correcta", new userSearchOutputDTO()
                    {

                        RolId = pUser.RolId,
                        WorkplaceId = pUser.WorkplaceId,
                        Name = pUser.Name,
                        LastName = pUser.LastName,
                        PhoneNumber = pUser.PhoneNumber,
                        Dui = pUser.Dui,
                        Email = pUser.Email,
                        Login = pUser.Login,
                        Status = pUser.Status
                    });
                    _logger.LogInformation("---- FIN METODO POST USER API CONTROLLER ----");
                    return pDTOGenResponse;
                }
                else
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(false, "Error al crear", new userSearchOutputDTO()
                    {
                        RolId = pUser.RolId,
                        WorkplaceId = pUser.WorkplaceId,
                        Name = pUser.Name,
                        LastName = pUser.LastName,
                        PhoneNumber = pUser.PhoneNumber,
                        Dui = pUser.Dui,
                        Email = pUser.Email,
                        Login = pUser.Login,
                        Status = pUser.Status
                    });
                    _logger.LogWarning("---- ERROR EN METODO POST USER API CONTROLLER ----");
                    return pDTOGenResponse;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("--- ERROR : " + ex.Message + " ----");
                var DTOGenRes = DTOGenResponse.GetGenericResponse(false, "Error : " + ex.Message, new userSearchOutputDTO()
                {
                    RolId = pUser.RolId,
                    WorkplaceId = pUser.WorkplaceId,
                    Name = pUser.Name,
                    LastName = pUser.LastName,
                    PhoneNumber = pUser.PhoneNumber,
                    Dui = pUser.Dui,
                    Email = pUser.Email,
                    Login = pUser.Login,
                    Status = pUser.Status
                });
                return DTOGenRes;
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{Id}")]
        public async Task<DTOGenericResponse<userSearchOutputDTO>> Delete(int Id)
        {
            try
            {
                _logger.LogInformation("---- INICIO METODO DELETE USER API CONTROLLER ----");

                var user = await _userBL.Delete(Id);
                if (user > 0)
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, "Eliminacion correcta", null);
                    _logger.LogInformation("---- FIN METODO DELETE USER API CONTROLLER ----");
                    return pDTOGenResponse;
                }
                else
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(false, "Error al eliminar", null);
                    _logger.LogWarning("---- ERROR EN METODO DELETE USER API CONTROLLER ----");
                    return pDTOGenResponse;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("--- ERROR : " + ex.Message + " ----");
                var DTOGenRes = DTOGenResponse.GetGenericResponse(false, "Error : " + ex.Message, null);
                return DTOGenRes;
            }
        }
    }
}
