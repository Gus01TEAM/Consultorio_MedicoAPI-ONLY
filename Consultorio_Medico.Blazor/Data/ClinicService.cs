using Consultorio_Medico.BL.DTOs.DTOs;
using Consultorio_Medico.BL.DTOs.DTOGenericResponse;
using System.Text.Json;

namespace Consultorio_Medico.Blazor.Data
{
    public class ClinicService
    {
        readonly HttpClient _httpClientAPI;
        private readonly InformacionSession _InfoSession;
        public ClinicService(IHttpClientFactory httpClientFactory, InformacionSession infoSession)
        {
            _httpClientAPI = httpClientFactory.CreateClient("MEDICOAPI");
            _InfoSession = infoSession; 
        }

        public async Task<DTOGenericResponse<List<SearchOutputDTO>>> Search()
        {
            await _InfoSession.SetTokenHttp(_httpClientAPI);
            var response = await _httpClientAPI.GetFromJsonAsync<DTOGenericResponse<List<SearchOutputDTO>>>("/api/Clinics");

            if (response != null)
            {
                return response;
            }
            else
            {
                throw new Exception("La solicitud GET no fue exitosa.");
            }
        }

        public async Task<DTOGenericResponse<SearchOutputDTO>> Create(ClinicInputDTO clinicInput)
        {
            await _InfoSession.SetTokenHttp(_httpClientAPI);
            var response = await _httpClientAPI.PostAsJsonAsync("/api/Clinics", clinicInput);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<DTOGenericResponse<SearchOutputDTO>>(responseBody);
            }
            else
            {
                throw new Exception("La solicitud POST no fue exitosa.");
            }
        }
    }
}
