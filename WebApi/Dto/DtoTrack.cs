namespace WebApi.Dto;

public class DtoTrack
{
    /// <summary>
    /// Номер трека в альбоме
    /// </summary>
    public required int TrackNum { get; set; }
    /// <summary>
    /// Название трека
    /// </summary>
    public required string Title { get; set; }
    /// <summary>
    /// Длительность трека 
    /// </summary>
    public required TimeSpan Duration { get; set; }
    /// <summary>
    /// Идентификатор альбома, в котором находится трек
    /// </summary>
    public required int IdAlbum { get; set; }
}
