using Consultorio_Medico.BL;
using Consultorio_Medico.BL.DTOs.userDTO;
using Consultorio_Medico.BL.DTOs.UserSchedule;
using Consultorio_Medico.BL.Interfaces;
using Consultorio_Medico.Entities;
using ConsultorioMedicoAPI_ONLY.DTOGenericResponse;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Consultorio_Medico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserScheduleController : ControllerBase
    {
        private readonly IUserSchedulesBL _userScheduleBL;
        private readonly ILogger<UserScheduleController> _logger;
        DTOGenericResponse<List<UserScheduleSearchOutputDTO>> ListDTOresponse = new DTOGenericResponse<List<UserScheduleSearchOutputDTO>>();
        DTOGenericResponse<UserScheduleSearchOutputDTO> DTOGenResponse = new DTOGenericResponse<UserScheduleSearchOutputDTO>();

        public UserScheduleController(IUserSchedulesBL userScheduleBL, ILogger<UserScheduleController> logger)
        {
            _userScheduleBL = userScheduleBL;
            _logger = logger;
        }



        // GET: api/<UserScheduleController>
        [HttpGet]
        public async Task<DTOGenericResponse<List<UserScheduleSearchOutputDTO>>> Get()
        {
            _logger.LogInformation("---- INICIO METODO GET USERSCHEDULE CONTROLLER ----");

            UserScheduleSearchInpuntDTO userSchedule = new UserScheduleSearchInpuntDTO();
            var usersSched = await _userScheduleBL.Search(userSchedule);
            
            var DTOGenResponse = ListDTOresponse.GetGenericResponse(true, "Obtencion de todos los registros", usersSched);
            _logger.LogInformation("---- FIN METODO GET USERSCHEDULE CONTROLLER ----");
            return DTOGenResponse;
        }

        // GET api/<UserScheduleController>/5
        [HttpGet("{Id}")]
        public async Task<DTOGenericResponse<UserScheduleSearchOutputDTO>> Get(int Id)
        {
            _logger.LogInformation("---- INICIO METODO GET USERSCHEDULE CONTROLLER ----");

            var userSchedule = await _userScheduleBL.GetById(Id);

            var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, $"Obtencion del Registro con Id {Id} registros", userSchedule);
            _logger.LogInformation("---- FIN METODO GET USERSCHEDULE CONTROLLER ----");
            return pDTOGenResponse;
        }

        // POST api/<UserScheduleController>
        [HttpPost]
        public async Task<DTOGenericResponse<UserScheduleSearchOutputDTO>> Post(UserScheduleInputDTO pUserSchedule)
        {
            try
            {
                _logger.LogInformation("---- INICIO METODO POST USERSCHEDULE API CONTROLLER ----");

                var userSchedule = await _userScheduleBL.Create(pUserSchedule);
                if (userSchedule > 0)
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, "Creacion correcta", new UserScheduleSearchOutputDTO()
                    {
                        UserSchedulesId = pUserSchedule.SchedulesId,
                        UserId = pUserSchedule.UserId,
                        SchedulesId = pUserSchedule.SchedulesId
                        
                    });
                    _logger.LogInformation("---- FIN METODO POST USERSCHEDULE API CONTROLLER ----");
                    return pDTOGenResponse;
                }
                else
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(false, "Error al crear", new UserScheduleSearchOutputDTO()
                    {
                        UserSchedulesId = pUserSchedule.SchedulesId,
                        UserId = pUserSchedule.UserId,
                        SchedulesId = pUserSchedule.SchedulesId,
                        SpecialtieId = pUserSchedule.SpecialtieId,

                    });
                    _logger.LogWarning("---- ERROR EN METODO POST USERSCHEDULE API CONTROLLER ----");
                    return pDTOGenResponse;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("--- ERROR : " + ex.Message + " ----");
                var DTOGenRes = DTOGenResponse.GetGenericResponse(false, "Error : " + ex.Message, new UserScheduleSearchOutputDTO()
                {
                    UserSchedulesId = pUserSchedule.SchedulesId,
                    UserId = pUserSchedule.UserId,
                    SchedulesId = pUserSchedule.SchedulesId,
                    SpecialtieId = pUserSchedule.SpecialtieId,
                });
                return DTOGenRes;
            }
        }

        // PUT api/<UserScheduleController>/5
        [HttpPut("{Id}")]
        public async Task<DTOGenericResponse<UserScheduleSearchOutputDTO>> Put(int Id, UserScheduleInputDTO pUserSchedule)
        {
            try
            {
                _logger.LogInformation("---- INICIO METODO POST USERSCHEDULE API CONTROLLER ----");

                var userSchedule = await _userScheduleBL.Update(pUserSchedule);
                if (userSchedule > 0)
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, "modificacion correcta", new UserScheduleSearchOutputDTO()
                    {
                        UserSchedulesId = pUserSchedule.SchedulesId,
                        UserId = pUserSchedule.UserId,
                        SchedulesId = pUserSchedule.SchedulesId
                    });
                    _logger.LogInformation("---- FIN METODO POST USERSCHEDULE API CONTROLLER ----");
                    return pDTOGenResponse;
                }
                else
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(false, "Error al crear", new UserScheduleSearchOutputDTO()
                    {
                        UserSchedulesId = pUserSchedule.SchedulesId,
                        UserId = pUserSchedule.UserId,
                        SchedulesId = pUserSchedule.SchedulesId
                    });
                    _logger.LogWarning("---- ERROR EN METODO POST USERSCHEDULE API CONTROLLER ----");
                    return pDTOGenResponse;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("--- ERROR : " + ex.Message + " ----");
                var DTOGenRes = DTOGenResponse.GetGenericResponse(false, "Error : " + ex.Message, new UserScheduleSearchOutputDTO()
                {
                    UserSchedulesId = pUserSchedule.SchedulesId,
                    UserId = pUserSchedule.UserId,
                    SchedulesId = pUserSchedule.SchedulesId
                });
                return DTOGenRes;
            }
        }

        // DELETE api/<UserScheduleController>/5
        [HttpDelete("{Id}")]
        public async Task<DTOGenericResponse<UserScheduleSearchOutputDTO>> Delete(int Id)
        {
            try
            {
                _logger.LogInformation("---- INICIO METODO DELETE USERSCHEDULE API CONTROLLER ----");

                var userSchedule = await _userScheduleBL.Delete(Id);
                if (userSchedule > 0)
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, "Eliminacion correcta", null);
                    _logger.LogInformation("---- FIN METODO DELETE USERSCHEDULE API CONTROLLER ----");
                    return pDTOGenResponse;
                }
                else
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(false, "Error al crear", null);
                    _logger.LogWarning("---- ERROR EN METODO DELETE USERSCHEDULE API CONTROLLER ----");
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