using WebApi.Dto;

/// <summary>
/// Интерфейс сервиса для управления связями между артистом и жанром музыки
/// </summary>
public interface IServiceParticipationArtistGenre
{
    /// <summary>
    /// Получение списка всех связей
    /// </summary>
    /// <returns></returns>
    public IEnumerable<DtoParticipationDetails> GetEnum();
    /// <summary>
    /// Получение данных о связи
    /// </summary>
    /// <param name="idGenre"></param>
    /// <param name="idArtist"></param>
    /// <returns></returns>
    public DtoParticipationDetails? Get(int idGenre, int idArtist);
    /// <summary>
    /// Добавление связи в список
    /// </summary>
    /// <param name="dtoPparticipation"></param>
    /// <returns></returns>
    public bool Post(DtoParticipationDetails dtoPparticipation);
    /// <summary>
    /// Изменение данных связи
    /// </summary>
    /// <param name="idGenre"></param>
    /// <param name="idArtist"></param>
    /// <param name="dtoParticipation"></param>
    /// <returns></returns>
    public bool Put(int idGenre, int idArtist, DtoParticipationDetails dtoParticipation);
    /// <summary>
    /// Удаление связи
    /// </summary>
    /// <param name="idGenre"></param>
    /// <param name="idArtist"></param>
    /// <returns></returns>
    public bool Delete(int idGenre, int idArtist);
}