using Consultorio_Medico.BL.DTOs.RolDTO;
using Consultorio_Medico.BL.DTOs.DTOGenericResponse;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Consultorio_Medico.Blazor.Data
{
    public class RolService
    {
        readonly HttpClient _httpClientAPI;

        private readonly InformacionSession _InfoSession;
        public RolService(IHttpClientFactory httpClientFactory, InformacionSession infoSession)
        {
            _httpClientAPI = httpClientFactory.CreateClient("MEDICOAPI");
            _InfoSession = infoSession;
        }       
        public async Task<DTOGenericResponse<List<RolSearchingOutputDTO>>>Search()
        {
            await _InfoSession.SetTokenHttp(_httpClientAPI);
            var response = await _httpClientAPI.GetFromJsonAsync<DTOGenericResponse<List<RolSearchingOutputDTO>>>("/api/Rol");

            if (response != null)
            {
                return response;
            }
            else
            {
                throw new Exception("La solicitud GET no fue exitosa.");
            }
        }

        public async Task<DTOGenericResponse<RolSearchingOutputDTO>> GetById(int id)
        {
            await _InfoSession.SetTokenHttp(_httpClientAPI);
            var response = await _httpClientAPI.GetFromJsonAsync<DTOGenericResponse<RolSearchingOutputDTO>>($"/api/Rol/{id}");

            if (response != null)
            {
                return response;
            }
            else
            {
                throw new Exception("La solicitud GET no fue exitosa.");
            }
        }

        public async Task<DTOGenericResponse<RolSearchingOutputDTO>> Create(RolInputDTO createRolDTO)
        {
            await _InfoSession.SetTokenHttp(_httpClientAPI);
            var response = await _httpClientAPI.PostAsJsonAsync("/api/Rol", createRolDTO);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<DTOGenericResponse<RolSearchingOutputDTO>>(responseBody);
            }
            else
            {
                throw new Exception("La solicitud POST no fue exitosa.");
            }
        }

        public async Task<DTOGenericResponse<RolSearchingOutputDTO>> Edit(int id, RolInputDTO rolInput)
        {
            await _InfoSession.SetTokenHttp(_httpClientAPI);
            var response = await _httpClientAPI.PutAsJsonAsync($"/api/Rol/{id}", rolInput);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<DTOGenericResponse<RolSearchingOutputDTO>>(responseBody);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"La solicitud PUT no fue exitosa. Código de estado: {response.StatusCode}. Mensaje de error: {errorMessage}");
            }
        }

        public async Task<DTOGenericResponse<RolSearchingOutputDTO>> Delete(int id)
        {
            await _InfoSession.SetTokenHttp(_httpClientAPI);
            var response = await _httpClientAPI.DeleteAsync($"/api/Rol/{id}");

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<DTOGenericResponse<RolSearchingOutputDTO>>(responseBody);
            }
            else
            {
                throw new Exception("La solicitud DELETE no fue exitosa.");
            }
        }
    }
}
