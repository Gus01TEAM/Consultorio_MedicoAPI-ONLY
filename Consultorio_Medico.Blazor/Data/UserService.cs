using ConsultorioMedicoAPI_ONLY.DTOGenericResponse;
using Consultorio_Medico.BL.DTOs.userDTO;


namespace Consultorio_Medico.Blazor.Data
{
    public class UserService
    {
        readonly HttpClient _httpClientAPI;

        public UserService(IHttpClientFactory httpClientFactory)
        {
            _httpClientAPI = httpClientFactory.CreateClient("MEDICOAPI");
        }

        public async Task<DTOGenericResponse<List<userSearchOutputDTO>>> Search()
        {
            var response = await _httpClientAPI.GetFromJsonAsync<DTOGenericResponse<List<userSearchOutputDTO>>>("/api/patient");

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
