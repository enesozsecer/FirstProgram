using FirstProgramUI.ApiServices.Interfaces;
using Model.Dtos.UserLoginDto;
using Model.Entities;
using Newtonsoft.Json;

namespace FirstProgramUI.ApiServices
{
    public class AuthApiService : IAuthApiService
    {
        private HttpClient _httpClient;
        public AuthApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<User> LoginAsync(LoginDto loginDto)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("Auths/Login", loginDto);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var data =await httpResponseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<User>(data);
                return await Task.FromResult(result);
            }
            return null;
        }
    }
}
