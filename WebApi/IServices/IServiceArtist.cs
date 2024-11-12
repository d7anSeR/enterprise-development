using WebApi.Dto;
using MediaLibrary.Classes;

/// <summary>
/// Интерфейс сервиса для управления артистами
/// </summary>
public interface IServiceArtist
{
    /// <summary>
    /// Получение списка всех артистов
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Artist> GetEnum();
    /// <summary>
    /// Получение данных об артисте
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Artist? Get(int id);
    /// <summary>
    /// Добавление артиста в список
    /// </summary>
    /// <param name="dtoArtist"></param>
    /// <returns></returns>
    public bool Post(DtoArtist dtoArtist);
    /// <summary>
    /// Изменение данных об артисте
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dtoArtist"></param>
    /// <returns></returns>
    public bool Put(int id, DtoArtist dtoArtist);
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