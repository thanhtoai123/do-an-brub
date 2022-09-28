using Microsoft.EntityFrameworkCore;
using Rez.Contexts;

namespace Rez.ThietLap;

/// <summary>
/// </summary>
public static partial class ThietLap
{
    /// <summary>
    /// </summary>
    /// <param name="builder"></param>
    public static void ThietLapMVCJSON(this IServiceCollection services)
    {
        services.AddControllersWithViews().AddNewtonsoftJson(x =>
        {
            x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            x.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
            x.SerializerSettings.ConstructorHandling = Newtonsoft.Json.ConstructorHandling.Default;
            x.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            x.SerializerSettings.ObjectCreationHandling = Newtonsoft.Json.ObjectCreationHandling.Reuse;
        });
    }
}