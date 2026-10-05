using Microsoft.AspNetCore.Identity;

namespace Småstad.Models
{
  public class IdentityInitializer
  {
    public static async Task EnsurePopulated(IServiceProvider services)
    {
      var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
      var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
      await CreateRoles(roleManager);
      await CreateUser(userManager);
    }
    private static async Task CreateRoles(RoleManager<IdentityRole> rManager)
    {
      if(!await rManager.RoleExistsAsync("Editor"))
      {
        await rManager.CreateAsync(new IdentityRole("Editor"));
      }
    }
    private static async Task CreateUser(UserManager<IdentityUser> uManager)
    {
      await CreateEditor(uManager, "E01", "Pass01?");
      await CreateEditor(uManager, "E02", "Pass02?");
      await CreateEditor(uManager, "E03", "Pass03?");
      await CreateEditor(uManager, "E04", "Pass04?");
      await CreateEditor(uManager, "E05", "Pass05?");
      await CreateEditor(uManager, "E06", "Pass06?");
    }

    private static async Task CreateEditor(
        UserManager<IdentityUser> uManager,
        string userName,
        string password)
    {
      var user = await uManager.FindByNameAsync(userName);

      if (user == null)
      {
        user = new IdentityUser(userName);

        var result = await uManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
          return;
        }
      }

      if (!await uManager.IsInRoleAsync(user, "Editor"))
      {
        await uManager.AddToRoleAsync(user, "Editor");
      }
    }

  }
}
