using Microsoft.AspNetCore.Mvc;
using Småstad.Models;

namespace Småstad.Controllers
{
  public class EditorController : Controller
  {
    private readonly ISmåstadRepository repository;
    private readonly IWebHostEnvironment environment;

    public EditorController(ISmåstadRepository repo,IWebHostEnvironment env)
    {
      repository = repo;
      environment = env;
    }


    [HttpGet]
    public ViewResult BookEvent()
    {
      return View();
    }


    [HttpPost]
    public async Task<IActionResult> BookEvent(
      TownEvent townEvent,
      IFormFile? loadImage,
      string? altText)
    {
      if (loadImage == null || loadImage.Length == 0)
      {
        ModelState.AddModelError(
          "loadImage",
          "Du måste välja en bild.");
      }

      if (!ModelState.IsValid)
      {
        return View(townEvent);
      }

      Picture picture = await SavePicture(
        loadImage!,
        altText,
        townEvent.EventName);

      townEvent.Pictures = new List<Picture>
    {
      picture
    };

      repository.SaveTownEvent(townEvent);

      TempData["SuccessMessage"] =
        "Evenemanget sparades korrekt!";

      return RedirectToAction("StartEditor");
    }


    public ViewResult StartEditor()
    {
      return View();
    }


    // Sparar bilden i Pictures-mappen och skapar Picture-objektet
    private async Task<Picture> SavePicture(
      IFormFile loadImage,
      string? altText,
      string? eventName)
    {
      // Den temporära sökvägen
      var tempPath = Path.GetTempFileName();

      if (loadImage.Length > 0)
      {
        using (var stream =
          new FileStream(tempPath, FileMode.Create))
        {
          await loadImage.CopyToAsync(stream);
        }
      }

      // Skapar ett unikt namn för bilden
      string uniqueFileName =
        Guid.NewGuid().ToString()
        + "_"
        + loadImage.FileName;

      // Den nya sökvägen
      var path = Path.Combine(
        environment.WebRootPath,
        "Pictures",
        uniqueFileName);

      // Flyttar bilden till rätt mapp
      System.IO.File.Move(tempPath, path);

      // Standardtext om alt-text saknas
      if (string.IsNullOrWhiteSpace(altText))
      {
        altText =
          "Bild till evenemanget " + eventName;
      }

      return new Picture
      {
        PictureName = uniqueFileName,
        AltText = altText
      };
    }
  }
}