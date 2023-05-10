using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//inject our connectionstring into DbContext
builder.Services.AddDbContext<RecruitingDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("RecruitingDbConnection")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();