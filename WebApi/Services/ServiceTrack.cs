using AutoMapper;
using MediaLibrary.Classes;
using MediaLibrary.Classes.IRepositories;
using WebApi.Dto;

/// <summary>
/// Имплементация интерфейса сервиса для управления музыкальными треками
/// </summary>
/// <param name="repository"></param>
/// <param name="mapper"></param>
/// <param name="serviceAlbum"></param>
public class ServiceTrack(IRepositoryTrack repository, IMapper mapper, IServiceAlbum serviceAlbum) : IServiceTrack
{
    /// <summary>
    /// Реализация получения списка всех треков
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Track> GetEnum()
    {
        return repository.GetEnum();
    }

    /// <summary>
    /// Реализация получения данных о треке
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Track? Get(int id)
    {
        return repository.Get(id);
    }

    /// <summary>
    /// Реализация добавления трека в список
    /// </summary>
    /// <param name="dtoTrack"></param>
    /// <returns></returns>
    public bool Post(DtoTrack dtoTrack)
    {
        if (!serviceAlbum.AlbumExists(dtoTrack.IdAlbum))
            return false;
        var track = mapper.Map<Track>(dtoTrack);
        return repository.Post(track);
    }

    /// <summary>
    /// Реализация изменения данных трека
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dtoTrack"></param>
    /// <returns></returns>
    public bool Put(int id, DtoTrack dtoTrack)
    {
        var track = mapper.Map<Track>(dtoTrack);
        track.Id = id;
        return repository.Put(id, track);
    }

    /// <summary>
    /// Реализация удаления трека
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id)
    {
        return repository.Delete(id);
    }
}