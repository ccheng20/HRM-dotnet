using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeStatusLookUpRepository, EmployeeStatusLookUpRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeStatusLookUpService, EmployeeStatusLookUpService>();

// builder.Services.AddDbContext<OnboardingDbContext>(
//     options => options.UseSqlServer(builder.Configuration.GetConnectionString("OnboardingDbConnection")));
var dockerConnectionString = Environment.GetEnvironmentVariable("MySQLConnectionString");
builder.Services.AddDbContext<OnboardingDbContext>(
    options => options.UseSqlServer(dockerConnectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(policy =>
{
    policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
});
app.MapControllers();

app.Run();