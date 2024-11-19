using WebApi.Dto;

/// <summary>
/// Интерфейс сервиса для управления музыкальными треками
/// </summary>
public interface IServiceTrack
{
    /// <summary>
    /// Получение списка всех треков
    /// </summary>
    /// <returns></returns>
    public IEnumerable<DtoTrackDetails> GetEnum();
    /// <summary>
    /// Получение данных о треке
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public DtoTrackDetails? Get(int id);
    /// <summary>
    /// Добавление трека в список
    /// </summary>
    /// <param name="dtoTrack"></param>
    /// <returns></returns>
    public bool Post(DtoTrackCreateUpdate dtoTrack);
    /// <summary>
    /// Изменение данных о треке
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dtoTrack"></param>
    /// <returns></returns>
    public bool Put(int id, DtoTrackCreateUpdate dtoTrack);
    /// <summary>
    /// Удаление трека
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id);
}