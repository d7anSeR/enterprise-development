using WebApi.Dto;

/// <summary>
/// Интерфейс сервиса для управления музыкальными жанрами
/// </summary>
public interface IServiceGenre
{
    /// <summary>
    /// Получение списка всех жанров
    /// </summary>
    /// <returns></returns>
    public IEnumerable<DtoGenreDetails> GetEnum();
    /// <summary>
    /// Получение данных о жанре
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public DtoGenreDetails? Get(int id);
    /// <summary>
    /// Добавление жанра в список
    /// </summary>
    /// <param name="dtoGenre"></param>
    /// <returns></returns>
    public bool Post(DtoGenreCreateUpdate dtoGenre);
    /// <summary>
    /// Изменение данных о жанре
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dtoGenre"></param>
    /// <returns></returns>
    public bool Put(int id, DtoGenreCreateUpdate dtoGenre);
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