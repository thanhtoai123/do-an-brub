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
    public static void AppDb(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("AppDb_Sqlserver"));
        });
    }
}