namespace MediaLibrary.Classes.IRepositories;

public interface IRepositoryArtist
{
    public IEnumerable<Artist> GetEnum();
    public Artist? Get(int id);
    public bool Post(Artist artist);
    public bool Delete(int id);
    public bool Put(int id, Artist artist);
}