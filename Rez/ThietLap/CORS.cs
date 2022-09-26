namespace Rez.ThietLap;

public static class StartUp
{
    public static void Cors(this IServiceCollection services)
    {
        services.AddCors(options => { options.AddPolicy("ToanBo", policy => { policy.WithOrigins("*"); }); });
    }
}