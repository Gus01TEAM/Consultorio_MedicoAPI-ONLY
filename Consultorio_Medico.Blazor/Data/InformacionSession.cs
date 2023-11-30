using Consultorio_Medico.BL.DTOs.userDTO;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace Consultorio_Medico.Blazor.Data
{
    public class InformacionSession
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        public InformacionSession(AuthenticationStateProvider authenticationStateProvider)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }
        public async Task<securityDTO> GetInfoUser() {
           
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            return new securityDTO {
                userName = user.FindFirstValue(ClaimTypes.Name),
                RolName = user.FindFirstValue(ClaimTypes.Role),
                userId = int.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier)),
                Token = user.FindFirstValue("Token")
            };
        }
        public async Task SetTokenHttp(HttpClient httpClient) {
            var inforUser = await GetInfoUser();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", inforUser.Token);
        }
    }
}
