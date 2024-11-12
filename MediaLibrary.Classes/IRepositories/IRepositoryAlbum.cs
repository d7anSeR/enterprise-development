namespace MediaLibrary.Classes.IRepositories;

public interface IRepositoryAlbum
{
    public IEnumerable<Album> GetEnum();
    public Album? Get(int id);
    public bool Post(Album album);
    public bool Delete(int id);
    public bool Put(int id, Album album);
}