using Microsoft.EntityFrameworkCore;
using Workshop3.EFCore.Domain;

namespace Workshop3.EFCore.Data.EFCore;

public class MusicWikiContext : DbContext
{
    private readonly string _connectionString;

    public MusicWikiContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DbSet<Artist> Artists { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Album> Albums { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Artist>().HasData(new[]
        {
            new Artist() { Id=1,Name = "Metallica"},
            new Artist() { Id=2,Name = "Megadeth" },
            new Artist() { Id=3,Name = "Slayer" },
            new Artist() { Id=4,Name = "Anthrax" }
        });
        modelBuilder.Entity<Album>().HasData(new[]
        {
            new Album()
            {
                Id=3,
                Title = "Master of Puppets",
                ReleaseDate = new DateTime(1986, 3, 3),
                ArtistId = 1
            },
            new Album()
            {
                Id=2,
                Title = "Ride the Lightning",
                ReleaseDate = new DateTime(1984, 7, 27),
                ArtistId = 1
            },
            new Album()
            {
                Id=1,
                Title = "Kill 'Em All",
                ReleaseDate = new DateTime(1983, 7, 25),
                ArtistId = 1
            }
        });
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
}