namespace MediaLibrary.Classes.IRepositories;

/// <summary>
/// Интерфейс репозитория артиста
/// </summary>
public interface IRepositoryArtist
{
    /// <summary>
    /// Получение списка всех артистов
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Artist> GetEnum();
    /// <summary>
    /// Получение данных артиста
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Artist? Get(int id);
    /// <summary>
    /// Добавление нового артиста в список
    /// </summary>
    /// <param name="artist"></param>
    /// <returns></returns>
    public bool Post(Artist artist);
    /// <summary>
    /// Удаление артиста из списка
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id);
    /// <summary>
    /// Изменение данных артиста
    /// </summary>
    /// <param name="id"></param>
    /// <param name="artist"></param>
    /// <returns></returns>
    public bool Put(int id, Artist artist);
}