using MediaLibrary.Classes;
using MediaLibrary.Classes.IRepositories;

/// <summary>
/// Имплементация интерфейса сервиса для управления связями между артистом и жанром музыки
/// </summary>
/// <param name="repository"></param>
/// <param name="serviceArtist"></param>
/// <param name="serviceGenre"></param>
public class ServiceParticipationArtistGenre(IRepositoryParticipationArtistGenre repository, IServiceArtist serviceArtist, IServiceGenre serviceGenre) : IServiceParticipationArtistGenre
{
    /// <summary>
    /// Реализация получения списка всех связей
    /// </summary>
    /// <returns></returns>
    public IEnumerable<ParticipationArtistGenre> GetEnum()
    {
        return repository.GetEnum();
    }

    /// <summary>
    /// Реализация получения данных о связи
    /// </summary>
    /// <param name="idGenre"></param>
    /// <param name="idArtist"></param>
    /// <returns></returns>
    public ParticipationArtistGenre? Get(int idGenre, int idArtist)
    {
        return repository.Get(idGenre, idArtist);
    }

    /// <summary>
    /// Реализация добавления связи в список
    /// </summary>
    /// <param name="participation"></param>
    /// <returns></returns>
    public bool Post(ParticipationArtistGenre participation)
    {
        if (!serviceArtist.ArtistExists(participation.IdArtist) || !serviceGenre.GenreExists(participation.IdGenre))
            return false;
        return repository.Post(participation);
    }

    /// <summary>
    /// Реализация изменения данных связи
    /// </summary>
    /// <param name="idGenre"></param>
    /// <param name="idArtist"></param>
    /// <param name="participation"></param>
    /// <returns></returns>
    public bool Put(int idGenre, int idArtist, ParticipationArtistGenre participation)
    {
        return repository.Put(idGenre, idArtist, participation);
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