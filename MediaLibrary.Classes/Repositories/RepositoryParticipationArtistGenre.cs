using MediaLibrary.Classes.IRepositories;

namespace MediaLibrary.Classes.Repositories;

/// <summary>
/// Имплементация интерфейса связи артиста и жанра музыки
/// </summary>
public class RepositoryParticipationArtistGenre : IRepositoryParticipationArtistGenre
{
    /// <summary>
    /// Список связей
    /// </summary>
    private readonly List<ParticipationArtistGenre> participations = [];
    /// <summary>
    /// Реализация получения списка всех связей
    /// </summary>
    /// <returns></returns>
    public IEnumerable<ParticipationArtistGenre> GetEnum() => participations;

    /// <summary>
    /// Реализация получения данных связи
    /// </summary>
    /// <param name="idGenre"></param>
    /// <param name="idArtist"></param>
    /// <returns></returns>
    public ParticipationArtistGenre? Get(int idGenre, int idArtist) => participations.Find(t => t.IdGenre == idGenre && t.IdArtist == idArtist);

    /// <summary>
    /// Реализация удаления связи
    /// </summary>
    /// <param name="idGenre"></param>
    /// <param name="idArtist"></param>
    /// <returns></returns>
    public bool Delete(int idGenre, int idArtist)
    {
        var participation = Get(idGenre, idArtist);
        if (participation != null)
        {
            participations.Remove(participation);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Реализация добавления связи
    /// </summary>
    /// <param name="participation"></param>
    /// <returns></returns>
    public bool Post(ParticipationArtistGenre participation)
    {
        if (Get(participation.IdGenre, participation.IdArtist) == null)
        {
            participations.Add(participation);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Реализация изменения связи
    /// </summary>
    /// <param name="IdGenre"></param>
    /// <param name="IdArtist"></param>
    /// <param name="participation"></param>
    /// <returns></returns>
    public bool Put(int IdGenre, int IdArtist, ParticipationArtistGenre participation)
    {
        var oldValue = Get(IdGenre, IdArtist);
        if (oldValue == null)
            return false;
        oldValue.IdGenre = participation.IdGenre;
        oldValue.IdArtist = participation.IdArtist;
        return true;
    }
}