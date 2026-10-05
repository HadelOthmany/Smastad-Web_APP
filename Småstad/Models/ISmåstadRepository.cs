namespace Småstad.Models
{
  public interface ISmåstadRepository
  {
    IQueryable<TownEvent> TownEvents { get; }
    IQueryable<Picture> Pictures { get; }
    IQueryable<Category> Categories { get; }
    IQueryable<Editor> Editors { get; }
    void SaveTownEvent(TownEvent townEvent);
    TownEvent? GetTownEvent(int id);
    Task<List<Category>> GetCategoriesAsync();

  }
}
