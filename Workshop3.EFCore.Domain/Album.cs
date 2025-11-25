namespace Workshop3.EFCore.Domain;

public class Album
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime ReleaseDate { get; set; }
    public Artist Artist { get; set; }
    public int ArtistId { get; set; }
}