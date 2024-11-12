using WebApi.Dto;
using MediaLibrary.Classes;

/// <summary>
/// Интерфейс сервиса для управления музыкальными альбомами
/// </summary>
public interface IServiceAlbum
{
    /// <summary>
    /// Получение списка всех альбомов
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Album> GetEnum();
    /// <summary>
    /// Получение данных об альбоме
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Album? Get(int id);
    /// <summary>
    /// Добавление альбома в список
    /// </summary>
    /// <param name="dtoAlbum"></param>
    /// <returns></returns>
    public bool Post(DtoAlbum dtoAlbum);
    /// <summary>
    /// Изменение данных об альбоме
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dtoAlbum"></param>
    /// <returns></returns>
    public bool Put(int id, DtoAlbum dtoAlbum);
    /// <summary>
    /// Удаление альбома
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id);
    /// <summary>
    /// Проверка существования альбома
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool AlbumExists(int id);
}