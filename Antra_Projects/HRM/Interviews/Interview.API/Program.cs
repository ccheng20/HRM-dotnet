using System.Text;
using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Service;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IInterviewTypeLookUpsRepository, InterviewTypeLookUpsRepository>();
builder.Services.AddScoped<IInterviewTypeLookUpService, InterviewTypeLookUpService>();
builder.Services.AddScoped<IInterviewsRepository, InterviewsRepository>();
builder.Services.AddScoped<IInterviewsService, InterviewsService>();
builder.Services.AddScoped<IInterviewersRepository, InterviewersRepository>();
builder.Services.AddScoped<IInterviewersService, InterviewersService>();


// builder.Services.AddDbContext<InterviewDbContext>(
//     options => options.UseSqlServer(builder.Configuration.GetConnectionString("InterviewDbConnection")));
var dockerConnectionString = Environment.GetEnvironmentVariable("MySQLConnectionString");
builder.Services.AddDbContext<InterviewDbContext>(
    options => options.UseSqlServer(dockerConnectionString));

// Microsoft.AspNetCore.Authentication.JwtBearer and Microsoft.IdentityModel.Tokens
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "HRM",
            ValidAudience = "HRM Users",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SecretKey"] ?? string.Empty))
        };
    });
    
var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(policy =>
{
    policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
});
app.MapControllers();

app.Run();