namespace Småstad.Models
{
  public class Picture
  {
    public int PictureId { get; set; }
    public string? PictureName { get; set; }
    public string? AltText { get; set; }
    public int TownEventId { get; set; }
  }
}
