﻿namespace ProyectAdmin.Core.DTOs
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public IDictionary<string, string[]>? ValidationErrors { get; set; } 
    }
}
