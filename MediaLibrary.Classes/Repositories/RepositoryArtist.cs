using MediaLibrary.Classes.IRepositories;

namespace MediaLibrary.Classes.Repositories;

/// <summary>
/// Имплементация интерфейса артиста
/// </summary>
public class RepositoryArtist : IRepositoryArtist
{
    /// <summary>
    /// Список всех артистов
    /// </summary>
    private readonly List<Artist> artists = [];
    /// <summary>
    /// Идентификатор артиста
    /// </summary>
    private int artistId = 1;
    /// <summary>
    /// Реализация получения списка всех артистов
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Artist> GetEnum() => artists;

    /// <summary>
    /// Реализация получения информации об артисте
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Artist? Get(int id) => artists.Find(a => a.Id == id);

    /// <summary>
    /// Реализация удаления артиста из списка
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Реализация добавления артиста в список
    /// </summary>
    /// <param name="artist"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Реализация изменения данных об артисте
    /// </summary>
    /// <param name="id"></param>
    /// <param name="artist"></param>
    /// <returns></returns>
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