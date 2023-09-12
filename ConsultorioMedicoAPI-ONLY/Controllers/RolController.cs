using Consultorio_Medico.BL.DTOs.RolDTO;
using Consultorio_Medico.BL.Interfaces;
using ConsultorioMedicoAPI_ONLY.DTOGenericResponse;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsultorioMedicoAPI_ONLY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolBL _rolBL;
        private readonly ILogger<RolController> _logger;
        DTOGenericResponse<List<RolSearchingOutputDTO>> ListDTOresponse = new DTOGenericResponse<List<RolSearchingOutputDTO>>();
        DTOGenericResponse<RolSearchingOutputDTO> DTOGenResponse = new DTOGenericResponse<RolSearchingOutputDTO>();

        public RolController(IRolBL rolBL, ILogger<RolController> logger)
        {
            _rolBL = rolBL;
            _logger = logger;
        }


        // GET: api/<RolController>
        [HttpGet]
        public async Task<DTOGenericResponse<List<RolSearchingOutputDTO>>> Get()
        {
            _logger.LogInformation("---- INICIO METODO GET ROL CONTROLLER ----");

            RolSearchingInputDTO rol = new RolSearchingInputDTO();
            var Roles = await _rolBL.Search(rol);

            var DTOGenResponse = ListDTOresponse.GetGenericResponse(true, "Obtencion de todos los registros", Roles);
            _logger.LogInformation("---- FIN METODO GET ROL CONTROLLER ----");
            return DTOGenResponse;
        }

        // GET api/<RolController>/5
        [HttpGet("{Id}")]
        public async Task<DTOGenericResponse<RolSearchingOutputDTO>> GetById(int Id)
        {
            _logger.LogInformation("---- INICIO METODO GET BY ID ROL CONTROLLER ----");
            var rol = await _rolBL.GetById(Id);

            var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, "Obteniendo Schedule by Id", rol);
            _logger.LogInformation("---- FIN METODO GET BY ID ROL CONTROLLER ----");
            return pDTOGenResponse;
        }

        // POST api/<RolController>
        [HttpPost]
        public async Task<DTOGenericResponse<RolSearchingOutputDTO>> Post(RolInputDTO pRol)
        {
            try
            {
                _logger.LogInformation("---- INICIO METODO POST ROL ----");

                var rol = await _rolBL.Create(pRol);
                if (rol > 0)
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, "Creacion correcta", new RolSearchingOutputDTO()
                    {
                        RolId = pRol.RolId,
                        Name = pRol.Name,
                        Status = pRol.Status
                    });
                    _logger.LogInformation("---- FIN METODO POST ROL ----");
                    return pDTOGenResponse;
                }
                else
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(false, "Error al crear", new RolSearchingOutputDTO()
                    {
                        RolId = pRol.RolId,
                        Name = pRol.Name,
                        Status = pRol.Status
                    });
                    _logger.LogWarning("---- ERROR EN METODO POST ROL ----");
                    return pDTOGenResponse;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("--- ERROR : " + ex.Message + " ----");
                var DTOGenRes = DTOGenResponse.GetGenericResponse(false, "Error : " + ex.Message, new RolSearchingOutputDTO()
                {
                    RolId = pRol.RolId,
                    Name = pRol.Name,
                    Status = pRol.Status
                });
                return DTOGenRes;
            }
        }


        // PUT api/<RolController>/5
        [HttpPut("{Id}")]
        public async Task<DTOGenericResponse<RolSearchingOutputDTO>> Put(int Id, RolInputDTO pRol)
        {
            try
            {
                _logger.LogInformation("---- INICIO METODO POST ROL ----");

                var rol = await _rolBL.Update(pRol);
                if (rol > 0)
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, "Creacion correcta", new RolSearchingOutputDTO()
                    {
                        RolId = pRol.RolId,
                        Name = pRol.Name,
                        Status = pRol.Status
                    });
                    _logger.LogInformation("---- FIN METODO POST ROL ----");
                    return pDTOGenResponse;
                }
                else
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(false, "Error al crear", new RolSearchingOutputDTO()
                    {
                        RolId = pRol.RolId,
                        Name = pRol.Name,
                        Status = pRol.Status
                    });
                    _logger.LogWarning("---- ERROR EN METODO POST ROL ----");
                    return pDTOGenResponse;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("--- ERROR : " + ex.Message + " ----");
                var DTOGenRes = DTOGenResponse.GetGenericResponse(false, "Error : " + ex.Message, new RolSearchingOutputDTO()
                {
                    RolId = pRol.RolId,
                    Name = pRol.Name,
                    Status = pRol.Status
                });
                return DTOGenRes;
            }
        }

        // DELETE api/<RolController>/5
        [HttpDelete("{Id}")]
        public async Task<DTOGenericResponse<RolSearchingOutputDTO>> Delete(int Id)
        {
            try
            {
                _logger.LogInformation("---- INICIO METODO DELETE ROL ----");

                var rol = await _rolBL.Delete(Id);
                if (rol > 0)
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, "Eliminacion correcta", null);
                    _logger.LogInformation("---- FIN METODO DELETE ROL ----");
                    return pDTOGenResponse;
                }
                else
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(false, "Error al crear", null);
                    _logger.LogWarning("---- ERROR EN METODO DELETE ROL ----");
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
