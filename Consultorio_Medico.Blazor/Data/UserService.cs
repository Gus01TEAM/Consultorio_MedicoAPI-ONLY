﻿using Consultorio_Medico.BL.DTOs.DTOGenericResponse;
using Consultorio_Medico.BL.DTOs.userDTO;
using System.Text.Json;


namespace Consultorio_Medico.Blazor.Data
{
    public class UserService
    {
        readonly HttpClient _httpClientAPI;
        private readonly InformacionSession _InfoSession;
        public UserService(IHttpClientFactory httpClientFactory, InformacionSession infoSession)
        {
            _httpClientAPI = httpClientFactory.CreateClient("MEDICOAPI");
            _InfoSession = infoSession;
        }

        public async Task<DTOGenericResponse<List<userSearchOutputDTO>>> Search()
        {
            await _InfoSession.SetTokenHttp(_httpClientAPI);
            var response = await _httpClientAPI.GetFromJsonAsync<DTOGenericResponse<List<userSearchOutputDTO>>>("/api/User");

            if (response != null)
            {
                return response;
            }
            else
            {
                throw new Exception("La solicitud GET no fue exitosa.");
            }
        }

        public async Task<DTOGenericResponse<userSearchOutputDTO>> GetById(int id)
        {
            await _InfoSession.SetTokenHttp(_httpClientAPI);
            var response = await _httpClientAPI.GetFromJsonAsync<DTOGenericResponse<userSearchOutputDTO>>($"/api/User/{id}");

            if (response != null)
            {
                return response;
            }
            else
            {
                throw new Exception("La solicitud GetById no fue exitosa.");
            }
        }

        public async Task<DTOGenericResponse<userSearchOutputDTO>> Create(UserAddDTO createUser)
        {
            await _InfoSession.SetTokenHttp(_httpClientAPI);
            var response = await _httpClientAPI.PostAsJsonAsync("/api/User", createUser);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<DTOGenericResponse<userSearchOutputDTO>>(responseBody);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"La solicitud POST no fue exitosa. Código de estado: {response.StatusCode}. Mensaje de error: {errorMessage}");
            }
        }

        public async Task<DTOGenericResponse<userSearchOutputDTO>> Edit(int id, userUpdateDTO userInput)
        {
            await _InfoSession.SetTokenHttp(_httpClientAPI);
            var response = await _httpClientAPI.PutAsJsonAsync($"/api/User/{id}", userInput);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<DTOGenericResponse<userSearchOutputDTO>>(responseBody);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"La solicitud PUT no fue exitosa. Código de estado: {response.StatusCode}. Mensaje de error: {errorMessage}");
            }
        }

        public async Task<DTOGenericResponse<userSearchOutputDTO>> Delete(int id)
        {
            await _InfoSession.SetTokenHttp(_httpClientAPI);
            var response = await _httpClientAPI.DeleteAsync($"/api/User/{id}");

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<DTOGenericResponse<userSearchOutputDTO>>(responseBody);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"La solicitud PUT no fue exitosa. Código de estado: {response.StatusCode}. Mensaje de error: {errorMessage}");
            }
        }
    }
}
