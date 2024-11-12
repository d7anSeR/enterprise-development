using WebApi.Dto;
using MediaLibrary.Classes;

/// <summary>
/// Интерфейс сервиса для управления музыкальными треками
/// </summary>
public interface IServiceTrack
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
    /// Добавление трека в список
    /// </summary>
    /// <param name="dtoTrack"></param>
    /// <returns></returns>
    public bool Post(DtoTrack dtoTrack);
    /// <summary>
    /// Изменение данных трека
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dtoTrack"></param>
    /// <returns></returns>
    public bool Put(int id, DtoTrack dtoTrack);
    /// <summary>
    /// Удаление трека
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id);
}