using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
namespace Småstad.Models
{
  public class SmåStadDbContext : DbContext
  {
    public SmåStadDbContext(DbContextOptions<SmåStadDbContext> options) : base(options) {}
    public DbSet<TownEvent> TownEvents{ get; set; }
    public DbSet<Picture> Pictures { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Editor> Editors{ get; set; }

  }
}
