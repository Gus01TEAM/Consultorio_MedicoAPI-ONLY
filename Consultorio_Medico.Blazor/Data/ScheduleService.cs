using Consultorio_Medico.BL.DTOs.RolDTO;
using Consultorio_Medico.BL.DTOs.ScheduleDTO;
using ConsultorioMedicoAPI_ONLY.DTOGenericResponse;
using System.Text.Json;

namespace Consultorio_Medico.Blazor.Data
{
    public class ScheduleService
    {
        readonly HttpClient _httpClientAPI;
        public ScheduleService(IHttpClientFactory httpClientFactory)
        {
            _httpClientAPI = httpClientFactory.CreateClient("MEDICOAPI");
        }

        public async Task<DTOGenericResponse<List<ScheduleSearchOutPutDTO>>> Search()
        {
            var response = await _httpClientAPI.GetFromJsonAsync<DTOGenericResponse<List<ScheduleSearchOutPutDTO>>>("/api/Schedules");

            if (response != null)
            {
                return response;
            }
            else
            {
                throw new Exception("La solicitud GET no fue exitosa.");
            }
        }
        public async Task<DTOGenericResponse<ScheduleSearchOutPutDTO>> GetById(int id)
        {
            var response = await _httpClientAPI.GetFromJsonAsync<DTOGenericResponse<ScheduleSearchOutPutDTO>>($"/api/Schedules/{id}");

            if (response != null)
            {
                return response;
            }
            else
            {
                throw new Exception("La solicitud GET no fue exitosa.");
            }
        }
        public async Task<DTOGenericResponse<ScheduleSearchOutPutDTO>> Create(ScheduleInputDTO createSchedule)
        {
            var response = await _httpClientAPI.PostAsJsonAsync("/api/Schedules", createSchedule);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<DTOGenericResponse<ScheduleSearchOutPutDTO>>(responseBody);
            }
            else
            {
                throw new Exception("La solicitud POST no fue exitosa.");
            }
        }
        public async Task<DTOGenericResponse<ScheduleSearchOutPutDTO>> Edit(int id, ScheduleInputDTO createSchedule)
        {
            var response = await _httpClientAPI.PutAsJsonAsync($"/api/Schedules/{id}", createSchedule);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<DTOGenericResponse<ScheduleSearchOutPutDTO>>(responseBody);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"La solicitud PUT no fue exitosa. Código de estado: {response.StatusCode}. Mensaje de error: {errorMessage}");
            }
        }

        public async Task<DTOGenericResponse<ScheduleSearchOutPutDTO>> Delete(int id)
        {
            var response = await _httpClientAPI.DeleteAsync($"/api/Schedules/{id}");

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<DTOGenericResponse<ScheduleSearchOutPutDTO>>(responseBody);
            }
            else
            {
                throw new Exception("La solicitud DELETE no fue exitosa.");
            }
        }

    }
}
