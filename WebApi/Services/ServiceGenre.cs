using AutoMapper;
using MediaLibrary.Classes;
using MediaLibrary.Classes.IRepositories;
using WebApi.Dto;

/// <summary>
/// Имплементация интерфейса сервиса для управления музыкальными жанрами
/// </summary>
/// <param name="repository"></param>
/// <param name="mapper"></param>
public class ServiceGenre(IRepositoryGenre repository, IMapper mapper) : IServiceGenre
{
    /// <summary>
    /// Реализация получения списка всех жанров музыки
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Genre> GetEnum()
    {
        return repository.GetEnum();
    }

    /// <summary>
    /// Реализация получения данных о жанре
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Genre? Get(int id)
    {
        return repository.Get(id);
    }

    /// <summary>
    /// Реализация добавления жанра в список
    /// </summary>
    /// <param name="dtoGenre"></param>
    /// <returns></returns>
    public bool Post(DtoGenre dtoGenre)
    {
        var genre = mapper.Map<Genre>(dtoGenre);
        return repository.Post(genre);
    }

    /// <summary>
    /// Реализация изменения данных жанра
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dtoGenre"></param>
    /// <returns></returns>
    public bool Put(int id, DtoGenre dtoGenre)
    {
        var genre = mapper.Map<Genre>(dtoGenre);
        genre.Id = id;
        return repository.Put(id, genre);
    }

    /// <summary>
    /// Реализация удаления жанра
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id)
    {
        return repository.Delete(id);
    }

    /// <summary>
    /// Реализация проверки существования жанра
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool GenreExists(int id)
    {
        return repository.Get(id) != null;
    }
}