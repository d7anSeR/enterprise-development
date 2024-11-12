using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using MediaLibrary.Classes;
using WebApi.IServices;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ControllerParticipationArtistGenre(IServiceParticipationArtistGenre _participationService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<ParticipationArtistGenre>> Get()
    {
        return Ok(_participationService.GetEnum());
    }

    [HttpGet("{id}")]
    public ActionResult<ParticipationArtistGenre> Get(int idGenre, int idArtist)
    {
        var participation = _participationService.Get(idGenre, idArtist);
        if (participation == null)
            return NotFound();
        return Ok(participation);
    }

    [HttpPost]
    public IActionResult Post([FromBody] DtoParticipationArtistGenre participation)
    {
        return _participationService.Post(participation) ? Ok() : BadRequest();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int idGenre, int idArtist, [FromBody] DtoTrack track)
    {
        return _participationService.Put(idGenre, idArtist, track) ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int idGenre, int idArtist)
    {
        return _participationService.Delete(idGenre, idArtist) ? Ok() : NotFound();
    }
}