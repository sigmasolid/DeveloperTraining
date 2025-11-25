namespace Workshop3.EFCore.Domain;

public class Album
{
    public required int Id { get; init; }
    public required string Title { get; init; }
    public DateTime ReleaseDate { get; set; }
    public Artist Artist { get; set; } = null!;
    public int ArtistId { get; set; }
}