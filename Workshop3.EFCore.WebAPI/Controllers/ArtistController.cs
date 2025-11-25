using Microsoft.AspNetCore.Mvc;
using Workshop3.EFCore.Data.EFCore;
using Workshop3.EFCore.Domain;

namespace Workshop3.EFCore.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtistController : ControllerBase
{
    private readonly MusicWikiContext _context;

    public ArtistController(MusicWikiContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }

    [HttpGet]
    public IActionResult Get()
    {
        //UpdateDemo();

        return Ok(_context.Artists.ToList());
    }

    private void UpdateDemo()
    {
        var album = new Album() { Id = 1, Title = "Master of puppets", ReleaseDate = new DateTime(1986, 3, 3) };
        _context.Albums.Update(album);
        _context.SaveChanges();
    }
}