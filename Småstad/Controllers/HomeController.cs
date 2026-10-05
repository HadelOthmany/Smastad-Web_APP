using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Småstad.Controllers
{
  public class HomeController : Controller
  {
    public ViewResult Index()
    {
      return View();
    }

  }
}
