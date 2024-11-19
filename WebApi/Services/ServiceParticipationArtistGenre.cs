using AutoMapper;
using MediaLibrary.Classes;
using MediaLibrary.Classes.IRepositories;
using WebApi.Dto;

/// <summary>
/// Имплементация интерфейса сервиса для управления связями между артистом и жанром музыки
/// </summary>
/// <param name="repository"></param>
/// <param name="serviceArtist"></param>
/// <param name="serviceGenre"></param>
/// <param name="mapper"></param>
public class ServiceParticipationArtistGenre(IRepositoryParticipationArtistGenre repository, IServiceArtist serviceArtist, IServiceGenre serviceGenre, IMapper mapper) : IServiceParticipationArtistGenre
{
    /// <summary>
    /// Реализация получения списка всех связей
    /// </summary>
    /// <returns></returns>
    public IEnumerable<DtoParticipationDetails> GetEnum()
    {
        var participations = repository.GetEnum();
        return mapper.Map<IEnumerable<DtoParticipationDetails>>(participations);
    }

    /// <summary>
    /// Реализация получения данных о связи
    /// </summary>
    /// <param name="idGenre"></param>
    /// <param name="idArtist"></param>
    /// <returns></returns>
    public DtoParticipationDetails? Get(int idGenre, int idArtist)
    {
        var participation = repository.Get(idGenre, idArtist);
        return participation == null ? null : mapper.Map<DtoParticipationDetails>(participation);
    }

    /// <summary>
    /// Реализация добавления связи в список
    /// </summary>
    /// <param name="participation"></param>
    /// <returns></returns>
    public bool Post(DtoParticipationDetails participation)
    {
        if (!serviceArtist.ArtistExists(participation.IdArtist) || !serviceGenre.GenreExists(participation.IdGenre))
            return false;
        var part = mapper.Map<ParticipationArtistGenre>(participation);
        return repository.Post(part);
    }

    /// <summary>
    /// Реализация изменения данных связи
    /// </summary>
    /// <param name="idGenre"></param>
    /// <param name="idArtist"></param>
    /// <param name="participation"></param>
    /// <returns></returns>
    public bool Put(int idGenre, int idArtist, DtoParticipationDetails participation)
    {
        var participationOrig = mapper.Map<ParticipationArtistGenre>(participation);
        return repository.Put(idGenre, idArtist, participationOrig);
    }

    /// <summary>
    /// Реализация удаления связи
    /// </summary>
    /// <param name="idGenre"></param>
    /// <param name="idArtist"></param>
    /// <returns></returns>
    public bool Delete(int idGenre, int idArtist)
    {
        return repository.Delete(idGenre, idArtist);
    }
}