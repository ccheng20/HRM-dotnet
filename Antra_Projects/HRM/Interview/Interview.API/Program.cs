using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Service;
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

builder.Services.AddScoped<IInterviewTypeLookUpsRepository, InterviewTypeLookUpsRepository>();
builder.Services.AddScoped<IInterviewTypeLookUpService, InterviewTypeLookUpService>();
builder.Services.AddScoped<IInterviewsRepository, InterviewsRepository>();
builder.Services.AddScoped<IInterviewsService, InterviewsService>();
builder.Services.AddScoped<IInterviewersRepository, InterviewersRepository>();
builder.Services.AddScoped<IInterviewersService, InterviewersService>();


builder.Services.AddDbContext<InterviewDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("InterviewDbConnection")));

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