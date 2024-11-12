using AutoMapper;
using MediaLibrary.Classes;
using MediaLibrary.Classes.IRepositories;
using WebApi.Dto;

public class ServiceAlbum(IRepositoryAlbum repository, IMapper mapper, IServiceArtist serviceArtist) : IServiceAlbum
{
    public IEnumerable<Album> GetEnum()
    {
        return repository.GetEnum();
    }

    public Album? Get(int id)
    {
        return repository.Get(id);
    }

    public bool Post(DtoAlbum dtoAlbum)
    {
        if (!serviceArtist.ArtistExists(dtoAlbum.IdArtist))
            return false;
        var album = mapper.Map<Album>(dtoAlbum);
        return repository.Post(album);
    }

    public bool Put(int id, DtoAlbum dtoAlbum)
    {
        var album = mapper.Map<Album>(dtoAlbum);
        album.Id = id;
        return repository.Put(id, album);
    }

    public bool Delete(int id)
    {
        return repository.Delete(id);
    }

    public bool AlbumExists(int id)
    {
        return repository.Get(id) != null;
    }
}