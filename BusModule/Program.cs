using AutoMapper;
using BusModule.AutoMapper;
using BusModule.Repositories;
using BusModule.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// dbContext configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// register AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
// register services
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
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

app.UseAuthorization();

app.MapControllers();

app.Run();
