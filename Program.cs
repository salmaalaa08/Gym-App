using GymApp.BLL;
using GymApp.DAL.Repositories;
using GymApp.DAL.Context;
using DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<PlansService>();
// builder.Services.AddScoped<PlansRepository>();
// builder.Services.AddScoped<PlansMockRepository>();
// builder.Services.AddScoped<GymDbContext>();
// builder.Services.AddScoped<IPlansRepository, PlansMockRepository>();
builder.Services.AddScoped<IPlansRepository, PlansRepository>();
builder.Services.AddScoped<IPlansService, PlansService>();
builder.Services.AddScoped<GymDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
