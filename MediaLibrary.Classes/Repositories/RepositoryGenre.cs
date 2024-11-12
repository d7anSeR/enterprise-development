using MediaLibrary.Classes.IRepositories;

namespace MediaLibrary.Classes.Repositories;

public class RepositoryGenre : IRepositoryGenre
{
    private readonly List<Genre> genres = [];
    private int genreId = 1;
    public IEnumerable<Genre> GetEnum() => genres;

    public Genre? Get(int id) => genres.Find(g => g.Id == id);

    public bool Delete(int id)
    {
        var genre = Get(id);
        if (genre != null)
        {
            genres.Remove(genre);
            return true;
        }
        return false;
    }

    public bool Post(Genre genre)
    {
        genre.Id = genreId++;
        if (Get(genre.Id) == null)
        {
            genres.Add(genre);
            return true;
        }
        return false;
    }

    public bool Put(int id, Genre genre)
    {
        var oldValue = Get(id);
        if (oldValue == null)
            return false;
        oldValue.Id = genre.Id;
        oldValue.Name = genre.Name;
        return true;
    }
}