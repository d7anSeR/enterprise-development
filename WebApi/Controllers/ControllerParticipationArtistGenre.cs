using Microsoft.AspNetCore.Mvc;
using MediaLibrary.Classes;

namespace WebApi.Controllers;

/// <summary>
/// Контроллер для работы со связями между артистом и жанром музыки
/// </summary>
/// <param name="_participationService"></param>
[Route("api/[controller]")]
[ApiController]
public class ControllerParticipationArtistGenre(IServiceParticipationArtistGenre _participationService) : ControllerBase
{
    /// <summary>
    /// Получение списка всех связей
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<ParticipationArtistGenre>> Get()
    {
        return Ok(_participationService.GetEnum());
    }

    /// <summary>
    /// Получение данных о связи
    /// </summary>
    /// <param name="idGenre"></param>
    /// <param name="idArtist"></param>
    /// <returns></returns>
    [HttpGet("{idGenre}/{idArtist}")]
    public ActionResult<ParticipationArtistGenre> Get(int idGenre, int idArtist)
    {
        var participation = _participationService.Get(idGenre, idArtist);
        if (participation == null)
            return NotFound();
        return Ok(participation);
    }

    /// <summary>
    /// Добавление связи в список
    /// </summary>
    /// <param name="participation"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Post([FromBody] ParticipationArtistGenre participation)
    {
        return _participationService.Post(participation) ? Ok() : BadRequest();
    }

    /// <summary>
    /// Изменение данных связи
    /// </summary>
    /// <param name="idGenre"></param>
    /// <param name="idArtist"></param>
    /// <param name="participation"></param>
    /// <returns></returns>
    [HttpPut("{idGenre}/{idArtist}")]
    public IActionResult Put(int idGenre, int idArtist, [FromBody] ParticipationArtistGenre participation)
    {
        return _participationService.Put(idGenre, idArtist, participation) ? Ok() : NotFound();
    }

    /// <summary>
    /// Удаление связи
    /// </summary>
    /// <param name="idGenre"></param>
    /// <param name="idArtist"></param>
    /// <returns></returns>
    [HttpDelete("{idGenre}/{idArtist}")]
    public IActionResult Delete(int idGenre, int idArtist)
    {
        return _participationService.Delete(idGenre, idArtist) ? Ok() : NotFound();
    }
}