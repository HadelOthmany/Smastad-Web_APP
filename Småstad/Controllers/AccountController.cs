using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Småstad.Models.POCO;

namespace Småstad.Controllers
{
  // Endast användare med rollen Editor får komma åt denna controller,
  // förutom de actions som har [AllowAnonymous].
  [Authorize(Roles = "Editor")]
  public class AccountController : Controller
  {
    // Hanterar användare och inloggning med ASP.NET Core Identity.
    private UserManager<IdentityUser> userManager;  
    private SignInManager<IdentityUser> signInManager;

    // Identity-tjänsterna skickas in genom dependency injection.
    public AccountController(UserManager<IdentityUser> userMgr, 
      SignInManager<IdentityUser> signInMgr)
    {
      userManager = userMgr;
      signInManager = signInMgr;
    }
    [AllowAnonymous]
    public ViewResult Login(string returnUrl)
    {
      return View(new LoginModel
      { 
        ReturnUrl = returnUrl 
      });

    // Tar emot och kontrollerar användarens inloggningsuppgifter.
    }
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginModel loginModel)
    {
      if (ModelState.IsValid)
      {
        IdentityUser? user = await userManager.FindByNameAsync(loginModel.UserName);
        if (user != null)
        {
          await signInManager.SignOutAsync();
          if ((await signInManager.PasswordSignInAsync
            (user, loginModel.Password, false, false)).Succeeded)
          {
            if(await userManager.IsInRoleAsync(user, "Editor"))
            {
              return Redirect("/Editor/StartEditor");
            }
          }
        }
      }
      ModelState.AddModelError("", "Felaktigt användarnamn eller lösenord");
      return View(loginModel);
    }
    // Loggar ut användaren och skickar tillbaka användaren till angiven sida.
    public async Task<RedirectResult> Logout(string returnUrl = "/")
    {
      await signInManager.SignOutAsync();
      return Redirect(returnUrl);
    }
    // Visar en vy som informerar användaren om att denne inte har behörighet att komma åt sidan.
    public ViewResult AccessDenied()
    {
      return View();
    }
  }
}
