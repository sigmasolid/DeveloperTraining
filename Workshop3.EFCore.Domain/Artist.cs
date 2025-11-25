namespace Workshop3.EFCore.Domain;

public class Artist
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public Genre? Genre { get; set; }
    public IEnumerable<Album> Albums { get; set; } = new List<Album>();
}