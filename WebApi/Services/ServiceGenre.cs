using AutoMapper;
using MediaLibrary.Classes;
using MediaLibrary.Classes.IRepositories;
using WebApi.Dto;

public class ServiceGenre(IRepositoryGenre repository, IMapper mapper) : IServiceGenre
{
    /// <summary>
    /// Получение списка всех жанров
    /// </summary>
    public IEnumerable<DtoGenreDetails> GetEnum()
    {
        var genres = repository.GetEnum();
        return mapper.Map<IEnumerable<DtoGenreDetails>>(genres);
    }

    /// <summary>
    /// Получение данных о жанре
    /// </summary>
    public DtoGenreDetails? Get(int id)
    {
        var genre = repository.Get(id);
        return genre == null ? null : mapper.Map<DtoGenreDetails>(genre);
    }

    /// <summary>
    /// Добавление жанра в список
    /// </summary>
    public bool Post(DtoGenreCreateUpdate dtoGenre)
    {
        var genre = mapper.Map<Genre>(dtoGenre);
        return repository.Post(genre);
    }

    /// <summary>
    /// Изменение данных жанра
    /// </summary>
    public bool Put(int id, DtoGenreCreateUpdate dtoGenre)
    {
        var genre = mapper.Map<Genre>(dtoGenre);
        genre.Id = id;
        return repository.Put(id, genre);
    }

    /// <summary>
    /// Удаление жанра
    /// </summary>
    public bool Delete(int id)
    {
        return repository.Delete(id);
    }

    /// <summary>
    /// Проверка существования жанра
    /// </summary>
    public bool GenreExists(int id)
    {
        return repository.Get(id) != null;
    }
}