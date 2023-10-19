using Consultorio_Medico.BL.DTOs.PatientDTO;
using ConsultorioMedicoAPI_ONLY.DTOGenericResponse;

namespace Consultorio_Medico.Blazor.Data
{
    public class PatientService
    {
        readonly HttpClient _httpClientAPI;

        public PatientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientAPI = httpClientFactory.CreateClient("MEDICOAPI");
        }

        public async Task<DTOGenericResponse<List<patientSearchOutputDTO>>> Search()
        {
            var response = await _httpClientAPI.GetFromJsonAsync<DTOGenericResponse<List<patientSearchOutputDTO>>>("/api/Rol");

            if (response != null)
            {
                return response;
            }
            else
            {
                throw new Exception("La solicitud GET no fue exitosa.");
            }
        }
    }
}
