using WebApi.Dto;

/// <summary>
/// Интерфейс сервиса для управления музыкальными артистами
/// </summary>
public interface IServiceArtist
{
    /// <summary>
    /// Получение списка всех артистов
    /// </summary>
    /// <returns></returns>
    public IEnumerable<DtoArtistDetails> GetEnum();
    /// <summary>
    /// Получение данных об артисте
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public DtoArtistDetails? Get(int id);
    /// <summary>
    /// Добавление артиста в список
    /// </summary>
    /// <param name="dtoArtist"></param>
    /// <returns></returns>
    public bool Post(DtoArtistCreateUpdate dtoArtist);
    /// <summary>
    /// Изменение данных об артисте
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dtoArtist"></param>
    /// <returns></returns>
    public bool Put(int id, DtoArtistCreateUpdate dtoArtist);
    /// <summary>
    /// Удаление артиста
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id);
    /// <summary>
    /// Проверка существования артиста
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool ArtistExists(int id);
}