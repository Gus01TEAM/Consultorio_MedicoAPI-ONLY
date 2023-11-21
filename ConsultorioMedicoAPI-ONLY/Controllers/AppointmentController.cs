
using Consultorio_Medico.BL;
using Consultorio_Medico.BL.DTOs.AppointmentDTO;
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
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentBL _appointmentBL;
        private readonly ILogger<AppointmentController> _logger;
        DTOGenericResponse<List<AppointmentSearchOutputDTO>> ListDTOresponse = new DTOGenericResponse<List<AppointmentSearchOutputDTO>>();
        DTOGenericResponse<AppointmentSearchOutputDTO> DTOGenResponse = new DTOGenericResponse<AppointmentSearchOutputDTO>();

        public AppointmentController(IAppointmentBL appointmentBL, ILogger<AppointmentController> logger)
        {
            _appointmentBL = appointmentBL;
            _logger = logger;
        }


        // GET: api/<AppointmentController>
        [HttpGet]
        public async Task<DTOGenericResponse<List<AppointmentSearchOutputDTO>>> Get()
        {
            _logger.LogInformation("---- INICIO METODO GET APPOINTMENT API CONTROLLER ----");

            AppointmentSearchInputDTO appointment = new AppointmentSearchInputDTO();
            var appointments = await _appointmentBL.Search(appointment);

            var DTOGenResponse = ListDTOresponse.GetGenericResponse(true, "Obtencion de todos los registros", appointments);
            _logger.LogInformation("---- FIN METODO GET APPOINTMENT API CONTROLLER ----");
            return DTOGenResponse;
        }

        // GET api/<AppointmentController>/5
        [HttpGet("{Id}")]
        public async Task<DTOGenericResponse<AppointmentSearchOutputDTO>> Get(int Id)
        {
            _logger.LogInformation("---- INICIO METODO GET APPOINTMENT CONTROLLER ----");

            var appointment = await _appointmentBL.GetById(Id);

            var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, $"Obtencion del Registro con Id {Id} registros", appointment);
            _logger.LogInformation("---- FIN METODO GET APPOINTMENT CONTROLLER ----");
            return pDTOGenResponse;
        }

        //POST api/<AppointmentController>
        [HttpPost]
        public async Task<DTOGenericResponse<AppointmentSearchOutputDTO>> Post(AppointmentInputDTO pAppointment)
        {
            try
            {
                _logger.LogInformation("---- INICIO METODO POST APPOINTMENT API CONTROLLER ----");

                var appointment = await _appointmentBL.Create(pAppointment);
                if (appointment > 0)
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, "Creacion correcta", new AppointmentSearchOutputDTO()
                    {
                        AppointmentId = pAppointment.AppointmentId,
   
                        PatientId = pAppointment.PatientId,
                        Reason = pAppointment.Reason,
                        Appointment_date = pAppointment.Appointment_date,
                        Appointment_Hour = pAppointment.Appointment_Hour,
                        Shift = pAppointment.Shift,
                        Status = pAppointment.Status,

                    });
                    _logger.LogInformation("---- FIN METODO POST APPOINTMENT API CONTROLLER ----");
                    return pDTOGenResponse;
                }
                else
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(false, "Error al crear", new AppointmentSearchOutputDTO()
                    {
                        AppointmentId = pAppointment.AppointmentId,
                        PatientId = pAppointment.PatientId,
                        Reason = pAppointment.Reason,
                        Appointment_date = pAppointment.Appointment_date,
                        Appointment_Hour = pAppointment.Appointment_Hour,
                        Shift = pAppointment.Shift,
                        Status = pAppointment.Status,
                    });
                    _logger.LogWarning("---- ERROR EN METODO POST APPOINTMENT API CONTROLLER ----");
                    return pDTOGenResponse;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("--- ERROR : " + ex.Message + " ----");
                var DTOGenRes = DTOGenResponse.GetGenericResponse(false, "Error : " + ex.Message, new AppointmentSearchOutputDTO()
                {
                    AppointmentId = pAppointment.AppointmentId,
                    PatientId = pAppointment.PatientId,
                    Reason = pAppointment.Reason,
                    Appointment_date = pAppointment.Appointment_date,
                    Appointment_Hour = pAppointment.Appointment_Hour,
                    Shift = pAppointment.Shift,
                    Status = pAppointment.Status,
                });
                return DTOGenRes;
            }
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{Id}")]
        public async Task<DTOGenericResponse<AppointmentSearchOutputDTO>> Put(int Id, AppointmentInputDTO pAppointment)
        {
            try
            {
                _logger.LogInformation("---- INICIO METODO PUT APPOINTMENT API CONTROLLER ----");

                var appointment = await _appointmentBL.Update(pAppointment);
                if (appointment > 0)
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, "Modificacion correcta", new AppointmentSearchOutputDTO()
                    {
                        AppointmentId = pAppointment.AppointmentId,
                        PatientId = pAppointment.PatientId,
                        Reason = pAppointment.Reason,
                        Appointment_date = pAppointment.Appointment_date,
                        Appointment_Hour = pAppointment.Appointment_Hour,
                        Shift = pAppointment.Shift,
                        Status = pAppointment.Status,

                    });
                    _logger.LogInformation("---- FIN METODO PUT APPOINTMENT API CONTROLLER ----");
                    return pDTOGenResponse;
                }
                else
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(false, "Error al Modificacion", new AppointmentSearchOutputDTO()
                    {
                        AppointmentId = pAppointment.AppointmentId,
                        PatientId = pAppointment.PatientId,
                        Reason = pAppointment.Reason,
                        Appointment_date = pAppointment.Appointment_date,
                        Appointment_Hour = pAppointment.Appointment_Hour,
                        Shift = pAppointment.Shift,
                        Status = pAppointment.Status,
                    });
                    _logger.LogWarning("---- ERROR EN METODO PUT APPOINTMENT API CONTROLLER ----");
                    return pDTOGenResponse;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("--- ERROR : " + ex.Message + " ----");
                var DTOGenRes = DTOGenResponse.GetGenericResponse(false, "Error : " + ex.Message, new AppointmentSearchOutputDTO()
                {
                    AppointmentId = pAppointment.AppointmentId,
                    PatientId = pAppointment.PatientId,
                    Reason = pAppointment.Reason,
                    Appointment_date = pAppointment.Appointment_date,
                    Appointment_Hour = pAppointment.Appointment_Hour,
                    Shift = pAppointment.Shift,
                    Status = pAppointment.Status,
                });
                return DTOGenRes;
            }
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{Id}")]
        public async Task<DTOGenericResponse<AppointmentSearchOutputDTO>> Delete(int Id)
        {
            try
            {
                _logger.LogInformation("---- INICIO METODO DELETE APPOINTMENT API CONTROLLER ----");

                var appointment = await _appointmentBL.Delete(Id);
                if (appointment > 0)
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, "Eliminacion correcta", null);
                    _logger.LogInformation("---- FIN METODO DELETE APPOINTMENT API CONTROLLER ----");
                    return pDTOGenResponse;
                }
                else
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(false, "Error al crear", null);
                    _logger.LogWarning("---- ERROR EN METODO DELETE APPOINTMENT API CONTROLLER ----");
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
