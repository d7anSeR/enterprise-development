namespace WebApi.Dto;

/// <summary>
/// Объект передачи данных для артиста с его идентификатором 
/// </summary>
public class DtoArtistDetails
{
    /// <summary>
    /// Идентификатор артиста
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Никнейм артиста
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// Краткое описание артиста
    /// </summary>
    public required string Description { get; set; }
}