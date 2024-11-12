namespace MediaLibrary.Classes.IRepositories;

/// <summary>
/// Интерфейс репозитория связи артиста и жанра музыки
/// </summary>
public interface IRepositoryParticipationArtistGenre
{
    /// <summary>
    /// Получение спика всех связей
    /// </summary>
    /// <returns></returns>
    public IEnumerable<ParticipationArtistGenre> GetEnum();
    /// <summary>
    /// Получение данных связи
    /// </summary>
    /// <param name="idGenre"></param>
    /// <param name="idArtist"></param>
    /// <returns></returns>
    public ParticipationArtistGenre? Get(int idGenre, int idArtist);
    /// <summary>
    /// Добавление новой связи
    /// </summary>
    /// <param name="participation"></param>
    /// <returns></returns>
    public bool Post(ParticipationArtistGenre participation);
    /// <summary>
    /// Удаление связи
    /// </summary>
    /// <param name="idGenre"></param>
    /// <param name="idArtist"></param>
    /// <returns></returns>
    public bool Delete(int idGenre, int idArtist);
    /// <summary>
    /// Изменение данных связи
    /// </summary>
    /// <param name="idGenre"></param>
    /// <param name="idArtist"></param>
    /// <param name="track"></param>
    /// <returns></returns>
    public bool Put(int idGenre, int idArtist, ParticipationArtistGenre track);
}