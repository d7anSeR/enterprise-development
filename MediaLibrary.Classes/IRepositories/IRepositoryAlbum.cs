namespace MediaLibrary.Classes.Repositories;
public interface IRepositoryAlbum
{
    public IEnumerable<Album> GetEnum();
    public Album? Get(int id);
    public bool Post(Album album);
    public bool Delete(int id);
    public bool Update(int id, Album album);
    public bool Put(int id, Album album);
}