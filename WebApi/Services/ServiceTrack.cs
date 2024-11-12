using AutoMapper;
using MediaLibrary.Classes;
using MediaLibrary.Classes.IRepositories;
using WebApi.Dto;

public class ServiceTrack(IRepositoryTrack repository, IMapper mapper, IServiceAlbum serviceAlbum) : IServiceTrack
{
    public IEnumerable<Track> GetEnum()
    {
        return repository.GetEnum();
    }

    public Track? Get(int id)
    {
        return repository.Get(id);
    }

    public bool Post(DtoTrack dtoTrack)
    {
        if (!serviceAlbum.AlbumExists(dtoTrack.IdAlbum))
            return false;
        var track = mapper.Map<Track>(dtoTrack);
        return repository.Post(track);
    }

    public bool Put(int id, DtoTrack dtoTrack)
    {
        var track = mapper.Map<Track>(dtoTrack);
        track.Id = id;
        return repository.Put(id, track);
    }

    public bool Delete(int id)
    {
        return repository.Delete(id);
    }
}