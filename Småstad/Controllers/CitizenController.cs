using Småstad.Models;
using Microsoft.AspNetCore.Mvc;

namespace Småstad.Controllers
{
  public class CitizenController : Controller
  {
    private readonly ISmåstadRepository repository;
    public CitizenController(ISmåstadRepository repo)
    {
      repository = repo;
    }
    public ViewResult About()
    {
      return View();
    }
    public ViewResult Contact()
    {
      return View();
    }
    public ViewResult EventList()
    {
      var events = repository.TownEvents.ToList();

      return View(events);
    }
    public ViewResult EventDetail(int id)
    {
      var townEvent = repository.GetTownEvent(id);

      if (townEvent == null)
      {
        return View("EventNotFound");
      }

      return View(townEvent);
    }


  }
}
