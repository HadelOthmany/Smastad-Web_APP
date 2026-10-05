using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.RegularExpressions;

namespace Småstad.Models
{
  public class DBinitializer
  {
    public static void EnsurePopulated(IServiceProvider services)
    {
      var context = services.GetRequiredService<SmåStadDbContext>();

      if (!context.Categories.Any())
      {
        context.Categories.AddRange(
        new Category { CategoryId = "C01", CategoryName = "Musik" },
        new Category { CategoryId = "C02", CategoryName = "Teater" },
        new Category { CategoryId = "C03", CategoryName = "Dans" },
        new Category { CategoryId = "C04", CategoryName = "Litteratur" },
        new Category { CategoryId = "C05", CategoryName = "Marknad" },
        new Category { CategoryId = "C06", CategoryName = "Barn" },
        new Category { CategoryId = "C07", CategoryName = "Sport" },
        new Category { CategoryId = "C08", CategoryName = "Övrigt" }
        );
        context.SaveChanges();
      }
      //Koll om tabellen Editors är tom och i så fall fyll på med data
      if (!context.Editors.Any())
      {
        context.Editors.AddRange(
        new Editor
        {
          EditorId = "E01",
          EditorName = "Anna Börjesson",
          Company = "Biblioteket"
        },
        new Editor
        {
          EditorId = "E02",
          EditorName = "Carl Davidsson",
          Company
        = "Korpen"
        },
        new Editor
        {
          EditorId = "E03",
          EditorName = "Elsa Falk",
          Company =
        "Dansskolan"
        },
        new Editor
        {
          EditorId = "E04",
          EditorName = "Göran Haglund",
          Company =
        "Gemensam marknad"
        },
        new Editor
        {
          EditorId = "E05",
          EditorName = "Ingela Järlestad",
          Company = "Konserthuset"
        },
        new Editor
        {
          EditorId = "E06",
          EditorName = "Kalle Mårtensson",
          Company = "Kommunen"
        }
        );
        context.SaveChanges();
      }
      //Koll om tabellen TownEvents är tom och i så fall fyll på med data
      if (!context.TownEvents.Any())
      {
        context.TownEvents.AddRange(
        new TownEvent
        {
          EventName = "Lär dig odla",
          ShortDescription = "Odlingskurs för nybörjare. Vi tittar på rotfrukter och grönsaker",
          Category = "Övrigt",
          EventDate = new DateTime(2026, 09, 23, 17, 30, 00),
          Place = "Växthuset",
          LongDescription = "Odlingskurs för nybörjare. Vi tittar på olika rotfrukter och grönsaker du kan odla enkelt hemma.Inga förkunskaper krävs.Material tillhandahålls för inköp",
          Organizer = "Växthuset"
        },
        new TownEvent
        {
          EventName = "Match korpenbollen",
          ShortDescription = "Fotbollsmatch där lagen inom korpen spelar",
          Category = "Sport",
          EventDate = new DateTime(2026, 10, 25, 13, 00, 00),
          Place = "Idrottsplatsen",
          LongDescription = "De fyra korpenlagen - Little Towners, Kontorsslavarna, Miljökämparna, Lag utan slag - möts i en alla - mot - alla match.Kom och njut av spelet,varm korven och hejaropen",
          Organizer = "Korpen"
        },
        new TownEvent
        {
          EventName = "Litteraturafton",
          ShortDescription = "Vår lokala författare Stina Jämtlund berättar om sin senaste bok",
          Category = "Litteratur",
          EventDate = new DateTime(2026, 11, 12, 15, 00, 00),
          Place = "Bibliotekets foajé",
          LongDescription = "Vår lokala författare Stina Jämtlund berättar om sin senaste bok.Efter samtalet som börjar kl. 15.00 får man chans att köpa boken signerad.",
          Organizer = "Biblioteket"
        }
        );
        context.SaveChanges();
      }
      //Koll om tabellen Pictures är tom och i så fall fyll på med data
      if (!context.Pictures.Any())
      {
        context.Pictures.AddRange(
        new Picture
        {
          PictureName = "Odling_rawpixel.webp",
          AltText ="Blandade grönsaker",
          TownEventId = 1
        },
        new Picture
        {
          PictureName = "Sport_rawpixel.webp",
          AltText = "Fotboll som skjuts mot mål", TownEventId = 2 },
        new Picture
        {
          PictureName = "Litteratur_rawpixel.webp",
          AltText = "Öppen bok med ett höstlöv på",
          TownEventId = 3
        }
        );
        context.SaveChanges();
      }
    }
  }
}
