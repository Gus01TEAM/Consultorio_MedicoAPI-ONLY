using Consultorio_Medico.BL;
using Consultorio_Medico.BL.DTOs.PatientDTO;
using Consultorio_Medico.BL.DTOs.RolDTO;
using Consultorio_Medico.BL.Interfaces;
using Consultorio_Medico.Entities;
using ConsultorioMedicoAPI_ONLY.DTOGenericResponse;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsultorioMedicoAPI_ONLY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IPatientBL _patientBL;
        DTOGenericResponse<List<patientSearchOutputDTO>> ListDTOresponse = new DTOGenericResponse<List<patientSearchOutputDTO>>();
        DTOGenericResponse<patientSearchOutputDTO> DTOGenResponse = new DTOGenericResponse<patientSearchOutputDTO>();

        public PatientController(IPatientBL patientBL, ILogger<PatientController> logger)
        {
            _patientBL = patientBL;
            _logger = logger;
        }

        // GET: api/<PatientController>
        [HttpGet]
        public async Task<DTOGenericResponse<List<patientSearchOutputDTO>>> Get()
        {
            _logger.LogInformation("---- INICIO METODO GET PATIENT API CONTROLLER ----");
            patientSearchInputDTO patient = new patientSearchInputDTO();
            var Patients = await _patientBL.Search(patient);

            var DTOGenResponse = ListDTOresponse.GetGenericResponse(true, "Obtencion de todos los registros", Patients);
            _logger.LogInformation("---- FIN METODO GET PATIENT API CONTROLLER ----");
            return DTOGenResponse;
        }

        // GET api/<PatientController>/5
        [HttpGet("{Id}")]
        public async Task<DTOGenericResponse<patientSearchOutputDTO>> Get(int Id)
        {
            _logger.LogInformation("---- INICIO METODO GET BY ID PATIENT API CONTROLLER ----");
            var patient = await _patientBL.GetById(Id);

            var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, "Obteniendo Schedule by Id", patient);
            _logger.LogInformation("---- FIN METODO GET BY ID PATIENT API CONTROLLER ----");
            return pDTOGenResponse;
        }

        // POST api/<PatientController>
        [HttpPost]
        public async Task<DTOGenericResponse<patientSearchOutputDTO>> Post(patientAddDTO pPatient)
        {
            try
            {
                _logger.LogInformation("---- INICIO METODO POST PATIENT API CONTROLLER ----");

                var patient = await _patientBL.Create(pPatient);
                if (patient > 0)
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, "Creacion correcta", new patientSearchOutputDTO()
                    {
                        patientId = pPatient.patientId,
                        Name = pPatient.Name,
                        LastName = pPatient.LastName,
                        DUI = pPatient.DUI,
                        Telefono = pPatient.Telefono
                    });
                    _logger.LogInformation("---- FIN METODO POST API CONTROLLER ----");
                    return pDTOGenResponse;
                }
                else
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(false, "Error al crear", new patientSearchOutputDTO()
                    {
                        patientId = pPatient.patientId,
                        Name = pPatient.Name,
                        LastName = pPatient.LastName,
                        DUI = pPatient.DUI,
                        Telefono = pPatient.Telefono
                    });
                    _logger.LogWarning("---- ERROR EN METODO POST API CONTROLLER ----");
                    return pDTOGenResponse;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("--- ERROR : " + ex.Message + " ----");
                var DTOGenRes = DTOGenResponse.GetGenericResponse(false, "Error : " + ex.Message, new patientSearchOutputDTO()
                {
                    patientId = pPatient.patientId,
                    Name = pPatient.Name,
                    LastName = pPatient.LastName,
                    DUI = pPatient.DUI,
                    Telefono = pPatient.Telefono
                });
                return DTOGenRes;
            }
        }

        // PUT api/<PatientController>/5
        [HttpPut("{Id}")]
        public async Task<DTOGenericResponse<patientSearchOutputDTO>> Put(int Id, patientAddDTO pPatient)
        {
            try
            {
                _logger.LogInformation("---- INICIO METODO PUT PATIENT API CONTROLLER ----");

                var patient = await _patientBL.Update(pPatient);
                if (patient > 0)
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, "Modificacion correcta", new patientSearchOutputDTO()
                    {
                        patientId=pPatient.patientId, 
                        Name = pPatient.Name,
                        LastName = pPatient.LastName,
                        DUI = pPatient.DUI,
                        Telefono = pPatient.Telefono
                    });
                    _logger.LogInformation("---- FIN METODO PUT API CONTROLLER ----");
                    return pDTOGenResponse;
                }
                else
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(false, "Error al crear", new patientSearchOutputDTO()
                    {
                       patientId = pPatient .patientId,
                        Name = pPatient.Name,
                        LastName = pPatient.LastName,
                        DUI = pPatient.DUI,
                        Telefono = pPatient.Telefono
                    });
                    _logger.LogWarning("---- ERROR EN METODO PUT API CONTROLLER ----");
                    return pDTOGenResponse;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("--- ERROR : " + ex.Message + " ----");
                var DTOGenRes = DTOGenResponse.GetGenericResponse(false, "Error : " + ex.Message, new patientSearchOutputDTO()
                {
                    patientId = pPatient.patientId,
                    Name = pPatient.Name,
                    LastName = pPatient.LastName,
                    DUI = pPatient.DUI,
                    Telefono = pPatient.Telefono
                });
                return DTOGenRes;
            }
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{Id}")]
        public async Task<DTOGenericResponse<patientSearchOutputDTO>> Delete(int Id)
        {
            try
            {
                _logger.LogInformation("---- INICIO METODO DELETE PATIENT API CONTROLLER ----");

                var patient = await _patientBL.Delete(Id);
                if (patient > 0)
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, "Eliminacion correcta", null);
                    _logger.LogInformation("---- FIN METODO DELETE PATIENT API CONTROLLER ----");
                    return pDTOGenResponse;
                }
                else
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(false, "Error al crear", null);
                    _logger.LogWarning("---- ERROR EN METODO DELETE PATIENT API CONTROLLER ----");
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
