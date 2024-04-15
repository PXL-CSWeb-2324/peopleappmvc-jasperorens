namespace PeopleApp.Mvc.Helpers
{
    public class ApiResult<T> : BaseResult
    {
        public IEnumerable<T>? Entities { get; set; }
        public T? Entitiy { get; set; }
    }
}
