using PeopleApp.ClassLib.Models;
using PeopleApp.Mvc.Helpers;

namespace PeopleApp.Mvc.Services
{
    public interface IDepartmentRepository
    {
        Task<ApiResult<Department>> GetAsync();
        ApiResult<Department> GetById(long id);
        Task<ApiResult<Department>> AddAsync(Department department);
    }
}
