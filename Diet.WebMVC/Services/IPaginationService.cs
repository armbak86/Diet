namespace Diet.WebMVC.Services;

public interface IPaginationService<T> where T: BaseEntity
{
    PaginatedResult<T> GetPaginatedList(IEnumerable<T> source, int pageNumber, int pageSize);
}
