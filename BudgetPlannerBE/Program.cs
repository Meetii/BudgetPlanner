using BudgetPlannerBE.Application.Implementation;
using BudgetPlannerBE.Application.Interface;
using BudgetPlannerBE.Infrastructure;
using BudgetPlannerBE.Infrastructure.Implementation;
using BudgetPlannerBE.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("budgetPlannerDb")));

builder.Services.AddCors();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IBudgetService, BudgetService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors(options => options
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
);

app.UseAuthorization();

app.MapControllers();

app.Run();
