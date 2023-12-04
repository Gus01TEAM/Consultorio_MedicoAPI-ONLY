using Consultorio_Medico.BL;
using Consultorio_Medico.BL.DTOs.DTOGenericResponse;
using Consultorio_Medico.BL.DTOs.DTOs;
using Consultorio_Medico.BL.DTOs.RolDTO;
using Consultorio_Medico.BL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioMedicoAPI_ONLY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClinicsController : ControllerBase
    {
        private readonly IClinicBL _clinicBL;
        private readonly ILogger<ClinicsController> _logger;
        DTOGenericResponse<List<SearchOutputDTO>> ListDTOresponse = new DTOGenericResponse<List<SearchOutputDTO>>();
        DTOGenericResponse<SearchOutputDTO> DTOGenResponse = new DTOGenericResponse<SearchOutputDTO>();

        public ClinicsController(IClinicBL clinicBL, ILogger<ClinicsController> logger)
        {
            _clinicBL = clinicBL;
            _logger = logger;
        }

        // GET: api/<RolController>
        [HttpGet]
        public async Task<DTOGenericResponse<List<SearchOutputDTO>>> Get()
        {
            _logger.LogInformation("---- INICIO METODO GET ROL CONTROLLER ----");

            SearchinputDTO clinics = new SearchinputDTO();
            var Clinics = await _clinicBL.Search(clinics);

            var DTOGenResponse = ListDTOresponse.GetGenericResponse(true, "Obtencion de todos los registros", Clinics);
            _logger.LogInformation("---- FIN METODO GET ROL CONTROLLER ----");
            return DTOGenResponse;
        }

        // POST api/<RolController>
        [HttpPost]
        public async Task<DTOGenericResponse<SearchOutputDTO>> Post(ClinicInputDTO Clinics)
        {
            try
            {
                _logger.LogInformation("---- INICIO METODO POST ROL ----");

                var clinic = await _clinicBL.Create(Clinics);
                if (clinic > 0)
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, "Creacion correcta", new SearchOutputDTO()
                    {
                        ClinicsId = Clinics.ClinicsId,
                        OfficeName = Clinics.OfficeName,
                        OfficeAddres = Clinics.OfficeAddres,
                        OfficeEmail = Clinics.OfficeEmail,
                        OfficePhone = Clinics.OfficePhone,  
                    });
                    _logger.LogInformation("---- FIN METODO POST ROL ----");
                    return pDTOGenResponse;
                }
                else
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(false, "Error al crear", new SearchOutputDTO()
                    {
                        ClinicsId = Clinics.ClinicsId,
                        OfficeName = Clinics.OfficeName,
                        OfficeAddres = Clinics.OfficeAddres,
                        OfficeEmail = Clinics.OfficeEmail,
                        OfficePhone = Clinics.OfficePhone,
                    });
                    _logger.LogWarning("---- ERROR EN METODO POST ROL ----");
                    return pDTOGenResponse;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("--- ERROR : " + ex.Message + " ----");
                var DTOGenRes = DTOGenResponse.GetGenericResponse(false, "Error : " + ex.Message, new SearchOutputDTO()
                {
                    ClinicsId = Clinics.ClinicsId,
                    OfficeName = Clinics.OfficeName,
                    OfficeAddres = Clinics.OfficeAddres,
                    OfficeEmail = Clinics.OfficeEmail,
                    OfficePhone = Clinics.OfficePhone
                });
                return DTOGenRes;
            }
        }
    }
    

}
