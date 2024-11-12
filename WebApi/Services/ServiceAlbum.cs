using AutoMapper;
using MediaLibrary.Classes;
using MediaLibrary.Classes.IRepositories;
using WebApi.Dto;

/// <summary>
/// Имплементация интерфейса сервиса для управления альбомами
/// </summary>
/// <param name="repository"></param>
/// <param name="mapper"></param>
/// <param name="serviceArtist"></param>
public class ServiceAlbum(IRepositoryAlbum repository, IMapper mapper, IServiceArtist serviceArtist) : IServiceAlbum
{
    /// <summary>
    /// Реализация получения списка всех альбомов
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Album> GetEnum()
    {
        return repository.GetEnum();
    }

    /// <summary>
    /// Реализация получения данных об альбоме
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Album? Get(int id)
    {
        return repository.Get(id);
    }

    /// <summary>
    /// Реализация добавления альбома в список
    /// </summary>
    /// <param name="dtoAlbum"></param>
    /// <returns></returns>
    public bool Post(DtoAlbum dtoAlbum)
    {
        if (!serviceArtist.ArtistExists(dtoAlbum.IdArtist))
            return false;
        var album = mapper.Map<Album>(dtoAlbum);
        return repository.Post(album);
    }

    /// <summary>
    /// Реализация изменения данных альбома
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dtoAlbum"></param>
    /// <returns></returns>
    public bool Put(int id, DtoAlbum dtoAlbum)
    {
        var album = mapper.Map<Album>(dtoAlbum);
        album.Id = id;
        return repository.Put(id, album);
    }

    /// <summary>
    /// Реализация удаления альбома
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id)
    {
        return repository.Delete(id);
    }

    /// <summary>
    /// Реализация проверки существования альбома 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool AlbumExists(int id)
    {
        return repository.Get(id) != null;
    }
}