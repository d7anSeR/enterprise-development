using MediaLibrary.Classes.IRepositories;

namespace MediaLibrary.Classes.Repositories;

public class RepositoryArtist : IRepositoryArtist
{
    private readonly List<Artist> artists = [];
    private int artistId = 1;
    public IEnumerable<Artist> GetEnum() => artists;

    public Artist? Get(int id) => artists.Find(a => a.Id == id);

    public bool Delete(int id)
    {
        var artist = Get(id);
        if (artist != null)
        {
            artists.Remove(artist);
            return true;
        }
        return false;
    }

    public bool Post(Artist artist)
    {
        artist.Id = artistId++;
        if (Get(artist.Id) == null)
        {
            artists.Add(artist);
            return true;
        }
        return false;
    }

    public bool Put(int id, Artist artist)
    {
        var oldValue = Get(id);
        if (oldValue == null)
            return false;
        oldValue.Id = artist.Id;
        oldValue.Name = artist.Name;
        oldValue.Description = artist.Description;
        return true;
    }
}