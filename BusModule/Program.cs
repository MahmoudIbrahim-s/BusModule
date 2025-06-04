using AutoMapper;
using BusModule.AutoMapper;
using BusModule.Models;
using BusModule.Repositories;
using BusModule.Services;
using BusModule.Services.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net.Security;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// dbContext configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));






// Add authentication and authorization services
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
            )
        };
    });

builder.Services.AddAuthorization();



// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// register AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
// register services
builder.Services.AddScoped<IGenericRepository<BusType>, GenericRepository<BusType>>();
builder.Services.AddScoped<IGenericRepository<BusCategory>, GenericRepository<BusCategory>>();
builder.Services.AddScoped<IGenericRepository<BusRoute>, GenericRepository<BusRoute>>();
builder.Services.AddScoped<IGenericRepository<Bus>, GenericRepository<Bus>>();
builder.Services.AddScoped<IGenericRepository<Student>, GenericRepository<Student>>();
builder.Services.AddScoped<IGenericRepository<BusAssignment>, GenericRepository<BusAssignment>>();
builder.Services.AddScoped<IGenericRepository<Employee>, GenericRepository<Employee>>();
builder.Services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();

builder.Services.AddScoped<IBusTypeService, BusTypeService>();
builder.Services.AddScoped<IBusCategoryService, BusCategoryService>();
builder.Services.AddScoped<IBusService, BusService>();
builder.Services.AddScoped<IBusAssignmentService, BusAssignmentService>();
builder.Services.AddScoped<IBusRouteService, BusRouteService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
