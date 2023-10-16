using FirstProgramUI.ApiServices.Interfaces;
using Model.Entities;

namespace FirstProgramUI.ApiServices
{
    public class UserApiService : IUserApiService
    {
        private HttpClient _httpClient;
        public UserApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<User>> GetListAsync()
        {
            var response = await _httpClient.GetAsync("Users/GetList");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var responseSuccess=await response.Content.ReadFromJsonAsync<IEnumerable<User>>();
            return responseSuccess.ToList();
        }
    }
}
