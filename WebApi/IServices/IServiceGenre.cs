using WebApi.Dto;
using MediaLibrary.Classes;

/// <summary>
/// Интерфейс сервиса для управления музыкальными жанрами
/// </summary>
public interface IServiceGenre
{
    /// <summary>
    /// Получение списка всех музыкальных жанров
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Genre> GetEnum();
    /// <summary>
    /// Получение данных о жанре
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Genre? Get(int id);
    /// <summary>
    /// Добавление жанра в список
    /// </summary>
    /// <param name="dtoGenre"></param>
    /// <returns></returns>
    public bool Post(DtoGenre dtoGenre);
    /// <summary>
    /// Изменение жанра
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dtoGenre"></param>
    /// <returns></returns>
    public bool Put(int id, DtoGenre dtoGenre);
    /// <summary>
    /// Удаление жанра
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id);
    /// <summary>
    /// Проверка существования жанра
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool GenreExists(int id);
}