using System.Reflection;
using Rez.ThietLap;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
var services = builder.Services;

// Thiết lập
builder.AppDb();
services.ThietLapMVCJSON();
services.AddEndpointsApiExplorer();
services.ThietLapSwagger();
services.AddHostedService<Rez.Task.DonRac>();
services.Cors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Admin}/{controller=Users}/{action=Tatca}/{id?}");

app.Run();
