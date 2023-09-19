using Consultorio_Medico.BL.DTOs.userDTO;
using Consultorio_Medico.BL.Interfaces;
using ConsultorioMedicoAPI_ONLY.DTOGenericResponse;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsultorioMedicoAPI_ONLY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityBL _securityBL;
        private readonly ILogger<SecurityController> _logger;

        DTOGenericResponse<securityDTO> DTOGenResponse = new DTOGenericResponse<securityDTO>();

        public SecurityController(ISecurityBL securityBL, ILogger<SecurityController> logger)
        {
            _securityBL = securityBL;
            _logger = logger;
        }

        // POST api/<SecurityController>
        [HttpPost]
        public DTOGenericResponse<securityDTO> Post(string Login, string Password)
        {
            try
            {
                _logger.LogInformation("---- INICIO METODO POST LOGIN POST API CONTROLLER ----");

                var security = _securityBL.Login(Login, Password);
                if (security.userId > 0)
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, "Logeo correcto", security);
                    _logger.LogInformation("---- FIN METODO POST LOGIN POST API CONTROLLER ----");
                    return pDTOGenResponse;
                }
                else
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(false, "Error al Logeo, credenciales incorrectas", null);
                    _logger.LogWarning("---- ERROR EN METODO POST SPECIALTIE API CONTROLLER ----");
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
