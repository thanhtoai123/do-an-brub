using System.Reflection;
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
    public static void ThietLapSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
    }
}