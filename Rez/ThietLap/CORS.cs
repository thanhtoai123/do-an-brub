using Microsoft.AspNetCore.ResponseCompression;

namespace Web.ThietLap;

public static partial class StartUp
{
    public static void CORS(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("ToanBo", policy =>
            {
                policy.WithOrigins("*");
            });
        });
    }
}