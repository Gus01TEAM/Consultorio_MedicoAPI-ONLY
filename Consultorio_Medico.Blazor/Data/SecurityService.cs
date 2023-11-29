using Consultorio_Medico.BL.DTOs.userDTO;
using Consultorio_Medico.BL.DTOs.DTOGenericResponse;
using System.Net.Http.Json;
using System.Text.Json;
using System.Net.Http.Headers;

namespace Consultorio_Medico.Blazor.Data
{
    public class SecurityService
    {
        readonly HttpClient _httpClientAPI;
       

        public SecurityService(IHttpClientFactory httpClientFactory)
        {
            _httpClientAPI = httpClientFactory.CreateClient("MEDICOAPI");
            
        }

        public async Task<LoginDTOBlazor> post(LoginDTO login)
        {
            var response = await _httpClientAPI.PostAsJsonAsync("/api/Security/validate", login);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<LoginDTOBlazor>(responseBody);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                return null;
                throw new Exception($"La solicitud POST no fue exitosa. Código de estado: {response.StatusCode}. Mensaje de error: {errorMessage}");
                
            }
        }

        public async Task<DTOGenericResponse<securityDTO>> GetUserInfo(string jwtToken)
        {
            try
            {
                _httpClientAPI.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

                var response = await _httpClientAPI.GetAsync("/api/Security/");
                return new DTOGenericResponse<securityDTO>
                {
                    Success = true,
                    Data = new securityDTO()
                };
                /* if (response != null && response.Success)
                 {
                     var user = response.Data;

                     var securityDTO = new securityDTO
                     {
                         userId = user.userId,
                         userName = user.userName,
                         RolName = user.RolName
                     };

                     return new DTOGenericResponse<securityDTO>
                     {
                         Success = true,
                         Data = securityDTO
                     };
                 }
                 else
                 {
                     throw new Exception("La solicitud GET no fue exitosa.");
                 }*/
            }
            catch (Exception ex)
            {
                return new DTOGenericResponse<securityDTO>
                {
                    Success = false,
                };
            }
        }
    }
}
