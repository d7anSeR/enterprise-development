﻿namespace WebApi.Dto;

/// <summary>
/// Объект передачи данных для связей между музыкальным жанром и артистом
/// </summary>
public class DtoParticipationDetails
{
    /// <summary>
    /// Идентификатор жанра
    /// </summary>
    public int IdGenre { get; set; }
    /// <summary>
    /// Идентификатор артиста
    /// </summary>
    public int IdArtist { get; set; }
}