using AutoMapper;
using MediaLibrary.Classes;
using MediaLibrary.Classes.IRepositories;
using WebApi.Dto;

public class ServiceGenre(IRepositoryGenre repository, IMapper mapper) : IServiceGenre
{
    public IEnumerable<Genre> GetEnum()
    {
        return repository.GetEnum();
    }

    public Genre? Get(int id)
    {
        return repository.Get(id);
    }

    public bool Post(DtoGenre dtoGenre)
    {
        var genre = mapper.Map<Genre>(dtoGenre);
        return repository.Post(genre);
    }

    public bool Put(int id, DtoGenre dtoGenre)
    {
        var genre = mapper.Map<Genre>(dtoGenre);
        genre.Id = id;
        return repository.Put(id, genre);
    }

    public bool Delete(int id)
    {
        return repository.Delete(id);
    }

    public bool GenreExists(int id)
    {
        return repository.Get(id) != null;
    }
}