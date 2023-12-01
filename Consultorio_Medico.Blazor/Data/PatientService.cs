using Consultorio_Medico.BL.DTOs.PatientDTO;
using Consultorio_Medico.BL.DTOs.RolDTO;
using Consultorio_Medico.BL.DTOs.DTOGenericResponse;
using System.Text.Json;

namespace Consultorio_Medico.Blazor.Data
{
    public class PatientService
    {
        readonly HttpClient _httpClientAPI;
        private readonly InformacionSession _InfoSession;

        public PatientService(IHttpClientFactory httpClientFactory, InformacionSession infoSession)
        {
            _httpClientAPI = httpClientFactory.CreateClient("MEDICOAPI");
            _InfoSession = infoSession;
        }

        public async Task<DTOGenericResponse<List<patientSearchOutputDTO>>> Search()
        {
            await _InfoSession.SetTokenHttp(_httpClientAPI);
            var response = await _httpClientAPI.GetFromJsonAsync<DTOGenericResponse<List<patientSearchOutputDTO>>>("/api/patient");

            if (response != null)
            {
                return response;
            }
            else
            {
                throw new Exception("La solicitud GET no fue exitosa.");
            }


        }

        public async Task<DTOGenericResponse<patientSearchOutputDTO>> GetById(int id)
        {
            await _InfoSession.SetTokenHttp(_httpClientAPI);
            var response = await _httpClientAPI.GetFromJsonAsync<DTOGenericResponse<patientSearchOutputDTO>>($"/api/patient/{id}");

            if (response != null)
            {
                return response;
            }
            else
            {
                throw new Exception("La solicitud GetById no fue exitosa.");
            }
        }

        public async Task<DTOGenericResponse<patientSearchOutputDTO>> Create(patientAddDTO createPatient)
        {
            await _InfoSession.SetTokenHttp(_httpClientAPI);
            var response = await _httpClientAPI.PostAsJsonAsync("/api/Patient", createPatient);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<DTOGenericResponse<patientSearchOutputDTO>>(responseBody);
            }
            else
            {
                throw new Exception("La solicitud POST no fue exitosa.");
            }
        }

        public async Task<DTOGenericResponse<patientSearchOutputDTO>> Edit(int id, patientAddDTO patientInput)
        {
            await _InfoSession.SetTokenHttp(_httpClientAPI);
            var response = await _httpClientAPI.PutAsJsonAsync($"/api/Patient/{id}", patientInput);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<DTOGenericResponse<patientSearchOutputDTO>>(responseBody);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"La solicitud PUT no fue exitosa. Código de estado: {response.StatusCode}. Mensaje de error: {errorMessage}");
            }
        }

        public async Task<DTOGenericResponse<patientSearchOutputDTO>> Delete(int id)
        {
            await _InfoSession.SetTokenHttp(_httpClientAPI);
            var response = await _httpClientAPI.DeleteAsync($"/api/Patient/{id}");

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<DTOGenericResponse<patientSearchOutputDTO>>(responseBody);
            }
            else
            {
                throw new Exception("La solicitud DELETE no fue exitosa.");
            }
        }
    }
}
