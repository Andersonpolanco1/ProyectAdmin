namespace ProyectAdmin.Core.DTOs.Filters
{
    public class UserFilter :BaseFilter
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
