using PeopleApp.ClassLib.Models;
using PeopleApp.Mvc.Helpers;
using System.Net.Http;

namespace PeopleApp.Mvc.Services
{
    public class LocationRepository : ILocationRepository
    {
        private readonly IHttpClientFactory _httpClient;
        public LocationRepository(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ApiResult<Location>> AddAsync(Location location)
        {
            var result = new ApiResult<Location>();
            var client = _httpClient.CreateClient(ApiHelper.ClientName);
            HttpResponseMessage response = client.PostAsJsonAsync("Location", location).Result;
            if (response.IsSuccessStatusCode)
            {
                result.Succeeded = true;
            }
            else
            {
                result.Failed("Error saving Location!");
            }
            return result;
        }

        public async Task<ApiResult<Location>> GetAsync()
        {
            var result = new ApiResult<Location>();
            var client = _httpClient.CreateClient(ApiHelper.ClientName);
            HttpResponseMessage response = client.GetAsync("Location").Result;
            if (response.IsSuccessStatusCode)
            {
                result.Entities = await response.Content.ReadAsAsync<IEnumerable<Location>>();
                result.Succeeded = true;
            }
            return result;
        }

        public ApiResult<Location> GetById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
