using MediaLibrary.Classes.IRepositories;

namespace MediaLibrary.Classes.Repositories;

public class RepositoryAlbum : IRepositoryAlbum
{
    private readonly List<Album> albums = [];
    private int albumId = 1;
    public IEnumerable<Album> GetEnum() => albums;

    public Album? Get(int id) => albums.Find(a => a.Id == id);

    public bool Delete(int id)
    {
        var album = Get(id);
        if (album != null)
        {
            albums.Remove(album);
            return true;
        }
        return false;
    }

    public bool Post(Album album)
    {
        album.Id = albumId++;
        if(Get(album.Id) == null)
        {
            albums.Add(album);
            return true;
        }
        return false;
    }

    public bool Put(int id, Album album)
    {
        var oldValue = Get(id);
        if (oldValue == null)
            return false;
        oldValue.Id = album.Id;
        oldValue.Release = album.Release;
        oldValue.Title = album.Title;
        oldValue.IdArtist = album.IdArtist;
        return true;
    }
}