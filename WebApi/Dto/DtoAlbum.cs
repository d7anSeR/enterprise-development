namespace WebApi.Dto;

public class DtoAlbum
{
    /// <summary>
    /// Название альбома
    /// </summary>
    public required string Title { get; set; }
    /// <summary>
    /// Дата релиза
    /// </summary>
    public required DateTime Release { get; set; }
    /// <summary>
    /// Идентификатор музыкального исполнителя,
    /// которому принадлежит этот альбом
    /// </summary>
    public required int IdArtist { get; set; }
}
