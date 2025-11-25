namespace Workshop3.EFCore.Domain;

public class Genre
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public IEnumerable<Artist> Bands { get; set; } = new List<Artist>();
}