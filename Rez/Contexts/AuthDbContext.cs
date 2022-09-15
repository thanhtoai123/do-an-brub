using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Rez.Contexts;

public class AuthDbContext : IdentityDbContext
{
    public AuthDbContext()
    {
    }
}