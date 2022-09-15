using Microsoft.AspNetCore.Identity;

namespace Rez.ThietLap;

public static partial class ThietLap
{
    public static void Auth(this IServiceCollection servies)
    {
        servies.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<Contexts.AuthDbContext>();
    }
}