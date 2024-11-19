namespace WebApi.Dto;

/// <summary>
/// Объект передачи данных для жанра музыки с его идентификатором 
/// </summary>
public class DtoGenreDetails
{
    /// <summary>
    /// Идентификатор жанра музыки
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название жанра
    /// </summary>
    public required string Name { get; set; }
}