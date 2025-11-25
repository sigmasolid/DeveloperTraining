using Microsoft.AspNetCore.Mvc;
using Workshop3.EFCore.Data.EFCore;
using Workshop3.EFCore.Domain;

namespace Workshop3.EFCore.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ResetDataController : ControllerBase
{
    private readonly MusicWikiContext _context;

    public ResetDataController(MusicWikiContext context)
    {
        _context = context;
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }

    [HttpGet]
    public IActionResult Get()
    {
        foreach (var artist in GetArtists())
        {
            _context.Artists.Add(artist);
        }
        _context.SaveChanges();

        foreach (var album in GetAlbums("Metallica"))
        {
            _context.Albums.Add(album);
        }
        
        _context.SaveChanges();
        return Ok(_context.Artists.ToList());
    }

    private IEnumerable<Album> GetAlbums(string artistName)
    {
        var artist = _context.Artists.Single(x => x.Name==artistName);

        return new[]
        {
            new Album()
            {
                Title = "Master of Puppets",
                ReleaseDate = new DateTime(1986, 3, 3),
                Artist = artist
            },
            new Album()
            {
                Title = "Ride the Lightning",
                ReleaseDate = new DateTime(1984, 7, 27),
                Artist = artist
            },
            new Album()
            {
                Title = "Kill 'Em All",
                ReleaseDate = new DateTime(1983, 7, 25),
                Artist = artist
            }
        };
    }

    private IEnumerable<Artist> GetArtists()
    {
        return new[]
        {
            new Artist() { Name = "Metallica" },
            new Artist() { Name = "Megadeth" },
            new Artist() { Name = "Slayer" },
            new Artist() { Name = "Anthrax" }
        };
    }

    // private IEnumerable<Genre> GetGenres()
    // {
    //     return new[]
    //     {
    //         new Genre()
    //         {
    //             Name = "Trash Metal", Bands = new[]
    //             {
    //                 new Artist() { Name = "Metallica" },
    //                 new Artist() { Name = "Megadeth" },
    //                 new Artist() { Name = "Slayer" },
    //                 new Artist() { Name = "Anthrax" },
    //             }
    //         },
    //         new Genre()
    //         {
    //             Name = "Heavy Metal", Bands = new[]
    //             {
    //                 new Artist() { Name = "Iron Maiden" },
    //                 new Artist() { Name = "Judas Priest" },
    //                 new Artist() { Name = "Black Sabbath" },
    //                 new Artist() { Name = "Accept" },
    //             }
    //         },
    //         new Genre()
    //         {
    //             Name = "Death Metal", Bands = new[]
    //             {
    //                 new Artist() { Name = "Death" },
    //                 new Artist() { Name = "Cannibal Corpse" },
    //                 new Artist() { Name = "Morbid Angel" },
    //                 new Artist() { Name = "Obituary" },
    //             }
    //         },
    //         new Genre()
    //         {
    //             Name = "Black Metal", Bands = new[]
    //             {
    //                 new Artist() { Name = "Mayhem" },
    //                 new Artist() { Name = "Darkthrone" },
    //                 new Artist() { Name = "Emperor" },
    //                 new Artist() { Name = "Burzum" },
    //             }
    //         },
    //         new Genre()
    //         {
    //             Name = "Power Metal", Bands = new[]
    //             {
    //                 new Artist() { Name = "Helloween" },
    //                 new Artist() { Name = "Blind Guardian" },
    //                 new Artist() { Name = "Stratovarius" },
    //                 new Artist() { Name = "Gamma Ray" },
    //             }
    //         },
    //         new Genre()
    //         {
    //             Name = "Progressive Metal", Bands = new[]
    //             {
    //                 new Artist() { Name = "Dream Theater" },
    //                 new Artist() { Name = "Symphony X" },
    //                 new Artist() { Name = "Fates Warning" },
    //                 new Artist() { Name = "Queensrÿche" },
    //             }
    //         },
    //     };
    // }

    // private IEnumerable<Artist> GetArtists()
    // {
    //     // var thrash = _context.Genres.Single(x => x.Name == "Trash Metal");
    //     return new[]
    //     {
    //         new Artist()
    //         {
    //             Name = "Metallica"
    //         }
    //     };
    // }
}
