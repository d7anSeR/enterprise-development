using AutoMapper;
using MediaLibrary.Classes;
using MediaLibrary.Classes.IRepositories;
using WebApi.Dto;

public class ServiceArtist(IRepositoryArtist repository, IMapper mapper) : IServiceArtist
{
    public IEnumerable<Artist> GetEnum()
    {
        return repository.GetEnum();
    }

    public Artist? Get(int id)
    {
        return repository.Get(id);
    }

    public bool Post(DtoArtist dtoArtist)
    {
        var artist = mapper.Map<Artist>(dtoArtist);
        return repository.Post(artist);
    }

    public bool Put(int id, DtoArtist dtoArtist)
    {
        var artist = mapper.Map<Artist>(dtoArtist);
        artist.Id = id;
        return repository.Put(id, artist);
    }

    public bool Delete(int id)
    {
        return repository.Delete(id);
    }

    public bool ArtistExists(int id)
    {
        return repository.Get(id) != null;
    }
}