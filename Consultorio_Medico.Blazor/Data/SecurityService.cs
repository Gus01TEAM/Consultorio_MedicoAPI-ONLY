﻿using Consultorio_Medico.BL.DTOs.userDTO;
using Consultorio_Medico.BL.DTOs.DTOGenericResponse;
using System.Net.Http.Json;
using System.Text.Json;

namespace Consultorio_Medico.Blazor.Data
{
    public class SecurityService
    {
        readonly HttpClient _httpClientAPI;
       

        public SecurityService(IHttpClientFactory httpClientFactory)
        {
            _httpClientAPI = httpClientFactory.CreateClient("MEDICOAPI");
            
        }

        public async Task<DTOGenericResponse<securityDTO>> post(LoginDTO login)
        {
            var response = await _httpClientAPI.PostAsJsonAsync("/api/Security/validate", login);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<DTOGenericResponse<securityDTO>>(responseBody);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                return null;
                throw new Exception($"La solicitud POST no fue exitosa. Código de estado: {response.StatusCode}. Mensaje de error: {errorMessage}");
                
            }
        }
    }
}
