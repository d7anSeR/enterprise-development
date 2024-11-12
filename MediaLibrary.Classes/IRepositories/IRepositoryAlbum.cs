namespace MediaLibrary.Classes.IRepositories;

/// <summary>
/// Интерфейс репозитория музыкального альбома
/// </summary>
public interface IRepositoryAlbum
{
    /// <summary>
    /// Получение списка всех музыкальных альбомов
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Album> GetEnum();
    /// <summary>
    /// Получение данных музыкального альбома
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Album? Get(int id);
    /// <summary>
    /// Добавление нового музыкального альбома в список
    /// </summary>
    /// <param name="album"></param>
    /// <returns></returns>
    public bool Post(Album album);
    /// <summary>
    /// Удаление музыкального альбома
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id);
    /// <summary>
    /// Изменение музыкального альбома
    /// </summary>
    /// <param name="id"></param>
    /// <param name="album"></param>
    /// <returns></returns>
    public bool Put(int id, Album album);
}