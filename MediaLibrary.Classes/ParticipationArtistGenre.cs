using System.ComponentModel.DataAnnotations.Schema;

namespace MediaLibrary.Classes;

/// <summary>
/// Связь между артистом и исполняемым жанром
/// </summary>
[Table("ParticipationArtistGenre")]
public class ParticipationArtistGenre
{
    /// <summary>
    /// Идентификатор связанного жанра музыки
    /// </summary>
    [ForeignKey("Genre")]
    [Column("IdGenre")]
    public required int IdGenre { get; set; }
    /// <summary>
    /// Идентификатор связанного музыкального исполнителя
    /// </summary>
    [ForeignKey("Artist")]
    [Column("IdArtist")]
    public required int IdArtist { get; set; }
    /// <summary>
    /// Получение экземпляра жанра
    /// </summary>
    public Genre Genre { get; set; } = null!;
}