using MediaLibrary.Classes;

/// <summary>
/// Интерфейс сервиса для управления связями между артистом и жанром музыки
/// </summary>
public interface IServiceParticipationArtistGenre
{
    /// <summary>
    /// Получение списка всех связей
    /// </summary>
    /// <returns></returns>
    public IEnumerable<ParticipationArtistGenre> GetEnum();
    /// <summary>
    /// Получение данных о связи
    /// </summary>
    /// <param name="idGenre"></param>
    /// <param name="idArtist"></param>
    /// <returns></returns>
    public ParticipationArtistGenre? Get(int idGenre, int idArtist);
    /// <summary>
    /// Добавление связи в список
    /// </summary>
    /// <param name="participation"></param>
    /// <returns></returns>
    public bool Post(ParticipationArtistGenre participation);
    /// <summary>
    /// Изменение данных связи
    /// </summary>
    /// <param name="idGenre"></param>
    /// <param name="idArtist"></param>
    /// <param name="participation"></param>
    /// <returns></returns>
    public bool Put(int idGenre, int idArtist, ParticipationArtistGenre participation);
    /// <summary>
    /// Удаление связи
    /// </summary>
    /// <param name="idGenre"></param>
    /// <param name="idArtist"></param>
    /// <returns></returns>
    public bool Delete(int idGenre, int idArtist);
}