using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaLibrary.Classes;

/// <summary>
/// Музыкальный альбом
/// </summary>
[Table("Album")]
public class Album
{
    /// <summary>
    /// Идентификатор альбома
    /// </summary>
    [Key]
    [Column("Id")]
    public required int Id { get; set; }
    /// <summary>
    /// Название альбома
    /// </summary>
    [Column("Title")]
    public required string Title { get; set; }
    /// <summary>
    /// Дата релиза
    /// </summary>
    [Column("Release")]
    public required DateTime Release { get; set; }
    /// <summary>
    /// Идентификатор музыкального исполнителя,
    /// которому принадлежит этот альбом
    /// </summary>
    [ForeignKey("Artist")]
    [Column("IdArtist")]
    public required int IdArtist { get; set; }
    /// <summary>
    /// Коллекция артистов
    /// </summary>
    public required ICollection<Artist> Artists { get; set; } = new List<Artist>();
}