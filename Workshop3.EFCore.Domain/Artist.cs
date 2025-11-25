namespace Workshop3.EFCore.Domain;

public class Artist
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Genre? Genre { get; set; }
    public IEnumerable<Album> Albums { get; set; }
}