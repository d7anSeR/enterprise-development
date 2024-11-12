using MediaLibrary.Classes.IRepositories;

namespace MediaLibrary.Classes.Repositories;

/// <summary>
/// Имплементация интерфейса жанра музыки
/// </summary>
public class RepositoryGenre : IRepositoryGenre
{
    /// <summary>
    /// Список жанров музыки
    /// </summary>
    private readonly List<Genre> genres = [];
    /// <summary>
    /// Идентификатор жанра музыки
    /// </summary>
    private int genreId = 1;
    /// <summary>
    /// Реализация получения списка всех жанров 
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Genre> GetEnum() => genres;

    /// <summary>
    /// Реализация получения данных о жанре 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Genre? Get(int id) => genres.Find(g => g.Id == id);

    /// <summary>
    /// Реализация удаления жанра из списка
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Реализация добавления жанра в список
    /// </summary>
    /// <param name="genre"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Реализация изменения данных жанра
    /// </summary>
    /// <param name="id"></param>
    /// <param name="genre"></param>
    /// <returns></returns>
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