namespace ProyectAdmin.Core.DTOs.Filters
{
    public abstract class BaseFilter
    {
        private const int DEFAULT_PAGE_SIZE = 15;
        private const int DEFAULT_PAGE_INDEX = 1;

        public int PageIndex { get; set; } 
        public int PageSize { get; set; } 
        public string? OrderBy { get; set; }
        public SortOrder? SortOrder { get; set; } 

        protected BaseFilter()
        {
            PageIndex = DEFAULT_PAGE_INDEX;
            PageSize = DEFAULT_PAGE_SIZE;
            SortOrder = Filters.SortOrder.Asc;
        }
    }

    public enum SortOrder
    {
        Asc, 
        Desc 
    }


}
