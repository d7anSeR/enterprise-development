using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using MediaLibrary.Classes;
using AutoMapper;

namespace WebApi.Controllers;

/// <summary>
/// Контроллер для работы со связями артиста и музыкального жанра
/// </summary>
/// <param name="_participationService"></param>
/// <param name="_mapper"></param>
[Route("api/[controller]")]
[ApiController]
public class ControllerParticipationArtistGenre(IServiceParticipationArtistGenre _participationService, IMapper _mapper) : ControllerBase
{
    /// <summary>
    /// Получения списка всех связей
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<ParticipationArtistGenre>> Get()
    {
        var participations = _participationService.GetEnum();
        var participationsDtos = _mapper.Map<IEnumerable<DtoParticipationDetails>>(participations);
        return Ok(participationsDtos);
    }

    /// <summary>
    /// Получение данных о связи
    /// </summary>
    /// <param name="idGenre"></param>
    /// <param name="idArtist"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<ParticipationArtistGenre> Get(int idGenre, int idArtist)
    {
        var participation = _participationService.Get(idGenre, idArtist);
        if (participation == null)
            return NotFound();
        var participationDto = _mapper.Map<DtoParticipationDetails>(participation);
        return Ok(participationDto);
    }

    /// <summary>
    /// Добавление связи в список
    /// </summary>
    /// <param name="participation"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Post([FromBody] DtoParticipationDetails participation)
    {
        if (_participationService.Post(participation))
        {
            return CreatedAtAction(nameof(Get), participation);
        }
        return BadRequest();
    }

    /// <summary>
    /// Изменение связи
    /// </summary>
    /// <param name="idGenre"></param>
    /// <param name="idArtist"></param>
    /// <param name="participation"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int idGenre, int idArtist, [FromBody] DtoParticipationDetails participation)
    {
        if (_participationService.Put(idGenre, idArtist, participation))
        {
            participation.IdArtist = idArtist;
            participation.IdGenre = idGenre;
            return CreatedAtAction(nameof(Get), participation);
        }
        return NotFound();
    }

    /// <summary>
    /// Удаление связи
    /// </summary>
    /// <param name="idGenre"></param>
    /// <param name="idArtist"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int idGenre, int idArtist)
    {
        return _participationService.Delete(idGenre, idArtist) ? Ok() : NotFound();
    }
}