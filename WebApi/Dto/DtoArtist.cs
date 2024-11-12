namespace WebApi.Dto;

/// <summary>
/// Объект передачи данных для артиста
/// </summary>
public class DtoArtist
{
    /// <summary>
    /// Никнейм артиста
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// Краткое описание артиста
    /// </summary>
    public required string Description { get; set; }
}
