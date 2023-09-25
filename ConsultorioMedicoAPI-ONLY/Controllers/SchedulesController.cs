
using Consultorio_Medico.BL;
using Consultorio_Medico.BL.DTOs.ScheduleDTO;
using Consultorio_Medico.BL.DTOs.WorkPlaceDTO;
using Consultorio_Medico.BL.Interfaces;
using Consultorio_Medico.Entities;
using ConsultorioMedicoAPI_ONLY.DTOGenericResponse;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Consultorio_Medico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly IScheduleBL _scheduleBL;
        private readonly ILogger<SchedulesController> _logger;
        DTOGenericResponse<List<ScheduleSearchOutPutDTO>> ListDTOresponse = new DTOGenericResponse<List<ScheduleSearchOutPutDTO>>();
        DTOGenericResponse<ScheduleSearchOutPutDTO> DTOGenResponse = new DTOGenericResponse<ScheduleSearchOutPutDTO>();

        public SchedulesController(IScheduleBL scheduleBL, ILogger<SchedulesController> logger)
        {
            _scheduleBL = scheduleBL;
            _logger = logger;
        }

        // GET: api/<SchedulesController>
        [HttpGet]
        public async Task<DTOGenericResponse<List<ScheduleSearchOutPutDTO>>> Get()
        {
            _logger.LogInformation("---- INICIO METODO GET SCHEDULE CONTROLLER ----");

            ScheduleSearchInputDTO schedule = new ScheduleSearchInputDTO();
            var Schedules = await _scheduleBL.Search(schedule);
            
            var DTOGenResponse = ListDTOresponse.GetGenericResponse(true, "Obtencion de todos los registros", Schedules);
            _logger.LogInformation("---- FIN METODO GET SCHEDULE CONTROLLER ----");
            return DTOGenResponse;
        }

        // GET api/<SchedulesController>/5
        [HttpGet("{Id}")]
        public async Task<DTOGenericResponse<ScheduleSearchOutPutDTO>> GetById(int Id)
        {
            _logger.LogInformation("---- INICIO METODO GET BY ID SCHEDULES ----");
            var schedule = await _scheduleBL.GetById(Id);

            var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, "Obteniendo Schedule by Id", schedule);
            _logger.LogInformation("---- FIN METODO GET BY ID SCHEDULES ----");
            return pDTOGenResponse;
        }

        // POST api/<SchedulesController>
        [HttpPost]
        public async Task<DTOGenericResponse<ScheduleSearchOutPutDTO>> Post(ScheduleInputDTO pSchedule)
        {
            try
            {
                _logger.LogInformation("---- INICIO METODO POST SCHEDULES ----");

                var Schdules = await _scheduleBL.Create(pSchedule);
                if (Schdules > 0)
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, "Creacion correcta", new ScheduleSearchOutPutDTO()
                    {
                        SchedulesId = pSchedule.SchedulesId,
                        DayName = pSchedule.DayName,
                        StartOfShift = pSchedule.StartOfShift,
                        EndOfShift = pSchedule.EndOfShift,
                        NumberOfHours = pSchedule.NumberOfHours,
                    });
                    _logger.LogInformation("---- FIN METODO POST SCHEDULES ----");
                    return pDTOGenResponse;
                }
                else
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(false, "Error al crear", new ScheduleSearchOutPutDTO()
                    {
                        SchedulesId = pSchedule.SchedulesId,
                        DayName = pSchedule.DayName,
                        StartOfShift = pSchedule.StartOfShift,
                        EndOfShift = pSchedule.EndOfShift,
                        NumberOfHours = pSchedule.NumberOfHours,
                    });
                    _logger.LogWarning("---- ERROR EN METODO POST SCHEDULES ----");
                    return pDTOGenResponse;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("--- ERROR : " + ex.Message + " ----");
                var DTOGenRes = DTOGenResponse.GetGenericResponse(false, "Error : " + ex.Message, new ScheduleSearchOutPutDTO()
                {
                    SchedulesId = pSchedule.SchedulesId,
                    DayName = pSchedule.DayName,
                    StartOfShift = pSchedule.StartOfShift,
                    EndOfShift = pSchedule.EndOfShift,
                    NumberOfHours = pSchedule.NumberOfHours,
                });
                return DTOGenRes;
            }
        }

        // PUT api/<SchedulesController>/5
        [HttpPut("{Id}")]
        public async Task<DTOGenericResponse<ScheduleSearchOutPutDTO>> Put(int Id, ScheduleInputDTO pSchedule)
        {
            try
            {
                _logger.LogInformation("---- INICIO METODO PUT SCHEDULES ----");

                var Schdules = await _scheduleBL.Update(pSchedule);
                if (Schdules > 0)
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, "Creacion correcta", new ScheduleSearchOutPutDTO()
                    {
                        SchedulesId = pSchedule.SchedulesId,
                        DayName = pSchedule.DayName,
                        StartOfShift = pSchedule.StartOfShift,
                        EndOfShift = pSchedule.EndOfShift
                    });
                    _logger.LogInformation("---- FIN METODO PUT SCHEDULES ----");
                    return pDTOGenResponse;
                }
                else
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(false, "Error al crear", new ScheduleSearchOutPutDTO()
                    {
                        SchedulesId = pSchedule.SchedulesId,
                        DayName = pSchedule.DayName,
                        StartOfShift = pSchedule.StartOfShift,
                        EndOfShift = pSchedule.EndOfShift
                    });
                    _logger.LogWarning("---- ERROR EN METODO PUT SCHEDULES ----");
                    return pDTOGenResponse;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("--- ERROR : " + ex.Message + " ----");
                var DTOGenRes = DTOGenResponse.GetGenericResponse(false, "Error : " + ex.Message, new ScheduleSearchOutPutDTO()
                {
                    SchedulesId = pSchedule.SchedulesId,
                    DayName = pSchedule.DayName,
                    StartOfShift = pSchedule.StartOfShift,
                    EndOfShift = pSchedule.EndOfShift
                });
                return DTOGenRes;
            }
        }

        // DELETE api/<SchedulesController>/5
        [HttpDelete("{Id}")]
        public async Task<DTOGenericResponse<ScheduleSearchOutPutDTO>> Delete(int Id)
        {
            try
            {
                _logger.LogInformation("---- INICIO METODO DELETE SCHEDULE ----");

                var schedule = await _scheduleBL.Delete(Id);
                if (schedule > 0)
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, "Eliminacion correcta", null);
                    _logger.LogInformation("---- FIN METODO DELETE SCHEDULE ----");
                    return pDTOGenResponse;
                }
                else
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(false, "Error al crear", null);
                    _logger.LogWarning("---- ERROR EN METODO DELETE SCHEDULE ----");
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
