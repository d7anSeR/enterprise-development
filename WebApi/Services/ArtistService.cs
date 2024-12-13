using AutoMapper;
using MediaLibrary.Classes;
using MediaLibrary.Classes.IRepositories;
using WebApi.Dto;

/// <summary>
/// Сервис для работы с музыкальными артистами
/// </summary>
/// <param name="repository"></param>
/// <param name="mapper"></param>
public class ArtistService(IRepositoryArtist repository, IMapper mapper) : IServiceArtist
{
    /// <summary>
    /// Получение списка всех альбомов
    /// </summary>
    public IEnumerable<DtoArtistDetails> GetEnum()
    {
        var artists = repository.GetEnum();
        return mapper.Map<IEnumerable<DtoArtistDetails>>(artists);
    }

    /// <summary>
    /// Получение данных об альбоме по ID
    /// </summary>
    public DtoArtistDetails? Get(int id)
    {
        var artist = repository.Get(id);
        return artist == null ? null : mapper.Map<DtoArtistDetails>(artist);
    }

    /// <summary>
    /// Добавление альбома в список
    /// </summary>
    public bool Post(DtoArtistCreateUpdate dtoArtist)
    {
        var artist = mapper.Map<Artist>(dtoArtist);
        return repository.Post(artist);
    }

    /// <summary>
    /// Изменение данных альбома
    /// </summary>
    public bool Put(int id, DtoArtistCreateUpdate dtoArtist)
    {
        var artist = mapper.Map<Artist>(dtoArtist);
        artist.Id = id;
        return repository.Put(id, artist);
    }

    /// <summary>
    /// Удаление альбома по ID
    /// </summary>
    public bool Delete(int id)
    {
        return repository.Delete(id);
    }

    /// <summary>
    /// Проверка существования артиста
    /// </summary>
    public bool ArtistExists(int id)
    {
        return repository.Get(id) != null;
    }
}