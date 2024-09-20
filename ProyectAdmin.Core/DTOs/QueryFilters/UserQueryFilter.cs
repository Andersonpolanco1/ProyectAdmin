namespace ProyectAdmin.Core.DTOs.QueryFilters
{
    public class UserQueryFilter :BaseQueryFilter
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
