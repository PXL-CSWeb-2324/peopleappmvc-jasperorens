using PeopleApp.ClassLib.Models;
using PeopleApp.Mvc.Helpers;

namespace PeopleApp.Mvc.Services
{
    public interface ILocationRepository
    {
        Task<ApiResult<Location>> GetAsync();
        ApiResult<Location> GetById(long id);
        Task<ApiResult<Location>> AddAsync(Location location);
    }
}
