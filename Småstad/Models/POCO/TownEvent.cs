using System.ComponentModel.DataAnnotations;

namespace Småstad.Models
{
  public class TownEvent
  {
    public int TownEventId { get; set; }

    [Required(ErrorMessage = "Du måste ange en rubrik.")]
    public string? EventName { get; set; }

    [Required(ErrorMessage = "Du måste ange en kort beskrivning.")]
    public string? ShortDescription { get; set; }

    [Required(ErrorMessage = "Du måste ange datum och tid.")]
    public DateTime EventDate { get; set; }

    [Required(ErrorMessage = "Du måste ange en plats.")]
    public string? Place { get; set; }

    [Required(ErrorMessage = "Du måste välja en kategori.")]
    public string? Category { get; set; }

    [Required(ErrorMessage = "Du måste ange en beskrivning.")]
    public string? LongDescription { get; set; }

    [Required(ErrorMessage = "Du måste ange en arrangör.")]
    public string? Organizer { get; set; }

    public ICollection<Picture>? Pictures { get; set; }
  }
}