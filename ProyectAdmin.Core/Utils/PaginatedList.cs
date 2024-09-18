using Microsoft.EntityFrameworkCore;

namespace ProyectAdmin.Core.Utils
{
    public class PaginatedList<T>
    {
        private const int MaxPageSize = 500; // parametrizar en la configuracion
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
        public int TotalRows { get; set; }
        public int TotalPages { get; private set; }
        public List<T> Data { get; set; } = [];

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            TotalRows = count;
            PageIndex = pageIndex;
            PageSize = pageSize > MaxPageSize ? MaxPageSize : pageSize;
            TotalPages = (int)Math.Ceiling(TotalRows / (double)PageSize);
            this.Data.AddRange(items);
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            pageSize = pageSize > MaxPageSize ? MaxPageSize : pageSize;
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
