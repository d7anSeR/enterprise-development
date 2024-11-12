namespace MediaLibrary.Classes.IRepositories;

/// <summary>
/// Интерфейс репозитория музыкального трека
/// </summary>
public interface IRepositoryTrack
{
    /// <summary>
    /// Получение списка всех треков
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Track> GetEnum();
    /// <summary>
    /// Получение данных о треке
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Track? Get(int id);
    /// <summary>
    /// Добавление нового трека в список
    /// </summary>
    /// <param name="track"></param>
    /// <returns></returns>
    public bool Post(Track track);
    /// <summary>
    /// Удаление трека
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id);
    /// <summary>
    /// Изменение трека
    /// </summary>
    /// <param name="id"></param>
    /// <param name="track"></param>
    /// <returns></returns>
    public bool Put(int id, Track track);
}