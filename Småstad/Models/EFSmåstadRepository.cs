using Microsoft.EntityFrameworkCore;

namespace Småstad.Models
{
  public class EFSmåstadRepository: ISmåstadRepository
  {
    private SmåStadDbContext context;
    public EFSmåstadRepository(SmåStadDbContext ctx)
    {
      context = ctx;
    }
    public IQueryable<TownEvent> TownEvents =>context.TownEvents.Include
      (e => e.Pictures).OrderBy(e => e.EventDate);
    public IQueryable<Picture> Pictures => context.Pictures;
    public IQueryable<Category> Categories => context.Categories;
    public IQueryable<Editor> Editors => context.Editors;
    public TownEvent? GetTownEvent(int id)
    {
      return TownEvents.FirstOrDefault(e => e.TownEventId == id);
    }
    public void SaveTownEvent(TownEvent townEvent)
    {
      context.TownEvents.Add(townEvent);
      context.SaveChanges();
    }
    public async Task<List<Category>> GetCategoriesAsync()
    {
      return await context.Categories.OrderBy(c => c.CategoryName).ToListAsync();
    }

  }
}
