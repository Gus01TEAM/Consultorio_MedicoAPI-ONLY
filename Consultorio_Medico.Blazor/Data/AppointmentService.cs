using Consultorio_Medico.BL.DTOs.AppointmentDTO;
using Consultorio_Medico.BL.DTOs.DTOGenericResponse;
using System.Text.Json;

namespace Consultorio_Medico.Blazor.Data
{
    public class AppointmentService
    {
        readonly HttpClient _httpClientAPI;
        private readonly InformacionSession _InfoSession;
        public AppointmentService(IHttpClientFactory httpClientFactory, InformacionSession infoSession)
        {
            _httpClientAPI = httpClientFactory.CreateClient("MEDICOAPI");
            _InfoSession = infoSession;
        }

        public async Task<DTOGenericResponse<List<AppointmentSearchOutputDTO>>> Search()
        {
            await _InfoSession.SetTokenHttp(_httpClientAPI);
            var response = await _httpClientAPI.GetFromJsonAsync<DTOGenericResponse<List<AppointmentSearchOutputDTO>>>("/api/Appointment");

            if (response != null)
            {
                return response;
            }
            else
            {
                throw new Exception("La solicitud GET no fue exitosa.");
            }
        }

        public async Task<DTOGenericResponse<AppointmentSearchOutputDTO>> GetById(int id)
        {
            await _InfoSession.SetTokenHttp(_httpClientAPI);
            var response = await _httpClientAPI.GetFromJsonAsync<DTOGenericResponse<AppointmentSearchOutputDTO>>($"/api/Appointment/{id}");

            if (response != null)
            {
                return response;
            }
            else
            {
                throw new Exception("La solicitud GetById no fue exitosa.");
            }
        }

        public async Task<DTOGenericResponse<AppointmentSearchOutputDTO>> Create(AppointmentInputDTO createAppointment)
        {
            await _InfoSession.SetTokenHttp(_httpClientAPI);
            var response = await _httpClientAPI.PostAsJsonAsync("/api/Appointment", createAppointment);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<DTOGenericResponse<AppointmentSearchOutputDTO>>(responseBody);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"La solicitud POST no fue exitosa. Código de estado: {response.StatusCode}. Mensaje de error: {errorMessage}");
            }
        }

        public async Task<DTOGenericResponse<AppointmentSearchOutputDTO>> Edit(int id, AppointmentInputDTO appointmentInput)
        {
            await _InfoSession.SetTokenHttp(_httpClientAPI);
            var response = await _httpClientAPI.PutAsJsonAsync($"/api/Appointment/{id}", appointmentInput);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<DTOGenericResponse<AppointmentSearchOutputDTO>>(responseBody);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"La solicitud PUT no fue exitosa. Código de estado: {response.StatusCode}. Mensaje de error: {errorMessage}");
            }
        }

        public async Task<DTOGenericResponse<AppointmentSearchOutputDTO>> Delete(int id)
        {
            await _InfoSession.SetTokenHttp(_httpClientAPI);
            var response = await _httpClientAPI.DeleteAsync($"/api/Appointment/{id}");

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<DTOGenericResponse<AppointmentSearchOutputDTO>>(responseBody);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"La solicitud PUT no fue exitosa. Código de estado: {response.StatusCode}. Mensaje de error: {errorMessage}");
            }
        }
    }
}
