using AutoMapper;
using MediaLibrary.Classes;
using MediaLibrary.Classes.IRepositories;
using WebApi.Dto;

public class ServiceTrack(IRepositoryTrack repository, IMapper mapper) : IServiceTrack
{
    /// <summary>
    /// Получение списка всех треков
    /// </summary>
    public IEnumerable<DtoTrackDetails> GetEnum()
    {
        var tracks = repository.GetEnum();
        return mapper.Map<IEnumerable<DtoTrackDetails>>(tracks);
    }

    /// <summary>
    /// Получение данных о треке
    /// </summary>
    public DtoTrackDetails? Get(int id)
    {
        var track = repository.Get(id);
        return track == null ? null : mapper.Map<DtoTrackDetails>(track);
    }

    /// <summary>
    /// Добавление трека в список
    /// </summary>
    public bool Post(DtoTrackCreateUpdate dtotrack)
    {
        var track = mapper.Map<Track>(dtotrack);
        return repository.Post(track);
    }

    /// <summary>
    /// Изменение данных трека
    /// </summary>
    public bool Put(int id, DtoTrackCreateUpdate dtoTrack)
    {
        var track = mapper.Map<Track>(dtoTrack);
        track.Id = id;
        return repository.Put(id, track);
    }

    /// <summary>
    /// Удаление трека
    /// </summary>
    public bool Delete(int id)
    {
        return repository.Delete(id);
    }
}