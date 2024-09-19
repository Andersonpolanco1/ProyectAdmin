using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProyectAdmin.Core.DTOs.Filters
{
    public abstract class BaseFilter
    {
        private const int DEFAULT_PAGE_SIZE = 15;
        private const int DEFAULT_PAGE_INDEX = 1;

        [Range(1, int.MaxValue, ErrorMessage = "PageIndex debe ser un entero positivo mayor que 0.")]
        public int PageIndex { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "PageSize debe ser un entero positivo mayor que 0.")]
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
        [Description("Ascendente")]
        Asc,
        [Description("Descendente")]
        Desc
    }


}
