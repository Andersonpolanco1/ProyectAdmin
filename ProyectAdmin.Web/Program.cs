using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectAdmin.Core.ActionFilters;
using ProyectAdmin.Core.Interfaces;
using ProyectAdmin.Core.Models;
using ProyectAdmin.Infrastructure;
using ProyectAdmin.Infrastructure.Repositories;
using ProyectAdmin.Services.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepository<User>,UsersRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services
    .Configure<ApiBehaviorOptions>(x => x.InvalidModelStateResponseFactory = ctx => new ValidationProblemDetailsResult());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHostFiltering();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


