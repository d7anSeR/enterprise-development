namespace MediaLibrary.Classes.IRepositories;

/// <summary>
/// Интерфейс репозитория жанра музыки
/// </summary>
public interface IRepositoryGenre
{
    /// <summary>
    /// Получение списка всех жанров 
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Genre> GetEnum();
    /// <summary>
    /// Получение информации о жанре
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Genre? Get(int id);
    /// <summary>
    /// Добавление нового жанра в список
    /// </summary>
    /// <param name="genre"></param>
    /// <returns></returns>
    public bool Post(Genre genre);
    /// <summary>
    /// Удаление жанра
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id);
    /// <summary>
    /// Изменение жанра
    /// </summary>
    /// <param name="id"></param>
    /// <param name="genre"></param>
    /// <returns></returns>
    public bool Put(int id, Genre genre);
}