using System.Reflection;
using Rez.ThietLap;
using Web.ThietLap;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

builder.AppDb();
services.AddControllersWithViews().AddNewtonsoftJson(x =>
{
    x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    x.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
    x.SerializerSettings.ConstructorHandling = Newtonsoft.Json.ConstructorHandling.Default;
    x.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
    x.SerializerSettings.ObjectCreationHandling = Newtonsoft.Json.ObjectCreationHandling.Reuse;
    x.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;
    x.SerializerSettings.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;
    x.SerializerSettings.MetadataPropertyHandling = Newtonsoft.Json.MetadataPropertyHandling.ReadAhead;
});
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(options =>
{


    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
services.AddHostedService<Rez.Task.DonRac>();
services.CORS();

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

Task task = new(() =>
{

});

task.Start();


app.UseRouting();
app.UseCors();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Admin}/{controller=Users}/{action=Tatca}/{id?}");

app.Run();
