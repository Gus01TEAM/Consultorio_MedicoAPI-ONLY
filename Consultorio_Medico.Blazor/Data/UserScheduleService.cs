using Consultorio_Medico.BL.DTOs.RolDTO;
using Consultorio_Medico.BL.DTOs.UserSchedule;
using ConsultorioMedicoAPI_ONLY.DTOGenericResponse;
using System.Text.Json;

namespace Consultorio_Medico.Blazor.Data
{
    public class UserScheduleService
    {
        readonly HttpClient _httpClientAPI;

        public UserScheduleService(IHttpClientFactory httpClientFactory)
        {
            _httpClientAPI = httpClientFactory.CreateClient("MEDICOAPI");
        }
        public async Task<DTOGenericResponse<List<UserScheduleSearchOutputDTO>>> Search()
        {
            var response = await _httpClientAPI.GetFromJsonAsync<DTOGenericResponse<List<UserScheduleSearchOutputDTO>>>("/api/UserSchedule");

            if (response != null)
            {
                return response;
            }
            else
            {
                throw new Exception("La solicitud GET no fue exitosa.");
            }
        }

        public async Task<DTOGenericResponse<UserScheduleSearchOutputDTO>> GetById(int id)
        {
            var response = await _httpClientAPI.GetFromJsonAsync<DTOGenericResponse<UserScheduleSearchOutputDTO>>($"/api/UserSchedule/{id}");

            if (response != null)
            {
                return response;
            }
            else
            {
                throw new Exception("La solicitud GET no fue exitosa.");
            }
        }
        public async Task<DTOGenericResponse<UserScheduleSearchOutputDTO>> Create(UserScheduleSearchInpuntDTO createUserSchedule)
        {
            var response = await _httpClientAPI.PostAsJsonAsync("/api/UserSchedule", createUserSchedule);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<DTOGenericResponse<UserScheduleSearchOutputDTO>>(responseBody);
            }
            else
            {
                throw new Exception("La solicitud POST no fue exitosa.");
            }
        }
    }
}
