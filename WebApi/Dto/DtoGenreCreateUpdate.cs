namespace WebApi.Dto;

/// <summary>
/// Объект передачи данных для жанра музыки
/// </summary>
public class DtoGenreCreateUpdate
{
    /// <summary>
    /// Название жанра
    /// </summary>
    public required string Name { get; set; }
}