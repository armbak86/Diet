namespace Diet.WebMVC.Services;

public class PaginationService<T> : IPaginationService<T> where T : BaseEntity
{
    public PaginatedResult<T> GetPaginatedList(IEnumerable<T> source, int pageNumber, int pageSize)
    {
        if (pageNumber < 1) pageNumber = 1;
        if (pageSize < 1) pageSize = 10;

        var count = source.Count();
        var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        var result = new PaginatedResult<T>
        {
            CurrentPage = pageNumber,
            PageSize = pageSize,
            TotalCount = count,
            TotalPages = (int)Math.Ceiling(count / (double)pageSize),
            Items = items
        };

        return result;
    }
}
