using AutoMapper;
using MediaLibrary.Classes;
using MediaLibrary.Classes.IRepositories;
using WebApi.Dto;

/// <summary>
/// Имплементация интерфейса сервиса для управления артистами
/// </summary>
public class ServiceArtist(IRepositoryArtist repository, IMapper mapper) : IServiceArtist
{
    /// <summary>
    /// Реализация получения списка всех артистов
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Artist> GetEnum()
    {
        return repository.GetEnum();
    }

    /// <summary>
    /// Реализация получения данных об артисте
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Artist? Get(int id)
    {
        return repository.Get(id);
    }

    /// <summary>
    /// Реализация добавления артиста в список
    /// </summary>
    /// <param name="dtoArtist"></param>
    /// <returns></returns>
    public bool Post(DtoArtist dtoArtist)
    {
        var artist = mapper.Map<Artist>(dtoArtist);
        return repository.Post(artist);
    }

    /// <summary>
    /// Реализация изменения данных об артисте
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dtoArtist"></param>
    /// <returns></returns>
    public bool Put(int id, DtoArtist dtoArtist)
    {
        var artist = mapper.Map<Artist>(dtoArtist);
        artist.Id = id;
        return repository.Put(id, artist);
    }

    /// <summary>
    /// Реализация удаления артиста
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id)
    {
        return repository.Delete(id);
    }

    /// <summary>
    /// Реализация проверки существования артиста
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool ArtistExists(int id)
    {
        return repository.Get(id) != null;
    }
}