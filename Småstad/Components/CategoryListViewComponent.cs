using Microsoft.AspNetCore.Mvc;
using Småstad.Models;

namespace Småstad.Components
{
  public class CategoryListViewComponent : ViewComponent
  {
    private readonly ISmåstadRepository repository;

    public CategoryListViewComponent(ISmåstadRepository repo)
    {
      repository = repo;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
      var categories = await repository.GetCategoriesAsync();

      return View(categories);
    }
  }
}