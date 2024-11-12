namespace MediaLibrary.Classes.IRepositories;

public interface IRepositoryGenre
{
    public IEnumerable<Genre> GetEnum();
    public Genre? Get(int id);
    public bool Post(Genre genre);
    public bool Delete(int id);
    public bool Put(int id, Genre genre);
}