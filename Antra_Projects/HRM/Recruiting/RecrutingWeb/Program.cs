using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ClassLibrary1.Data;
using ClassLibrary1.Repositories;
using ClassLibrary1.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<ISubmissionService, SubmissionService>();
builder.Services.AddScoped<ISubmissionRepository, SubmissionRepository>();
builder.Services.AddScoped<IJobsRepository, JobRepository>();
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();


//inject our connectionstring into DbContext
builder.Services.AddDbContext<RecruitingDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("RecruitingDbConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();