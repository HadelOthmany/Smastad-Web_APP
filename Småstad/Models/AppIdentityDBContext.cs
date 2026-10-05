using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Småstad.Models
{
  public class AppIdentityDBContext : IdentityDbContext<IdentityUser, IdentityRole, string>
  {
    public AppIdentityDBContext(DbContextOptions<AppIdentityDBContext> options): base(options){}
  }
}
