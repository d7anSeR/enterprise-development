using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using MediaLibrary.Classes;
using AutoMapper;

namespace WebApi.Controllers;

/// <summary>
/// Контроллер для работы с музыкальными треками
/// </summary>
/// <param name="_trackService"></param>
/// <param name="_mapper"></param>
[Route("api/[controller]")]
[ApiController]
public class ControllerTrack(IServiceTrack _trackService, IMapper _mapper) : ControllerBase
{
    /// <summary>
    /// Получения списка всех треков
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<DtoTrackDetails>> Get()
    {
        var tracks = _trackService.GetEnum();
        var tracksDtos = _mapper.Map<IEnumerable<DtoTrackDetails>>(tracks);
        return Ok(tracksDtos);
    }

    /// <summary>
    /// Получение данных о треке
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<DtoTrackDetails> Get(int id)
    {
        var track = _trackService.Get(id);
        if (track == null)
            return NotFound();
        var trackDto = _mapper.Map<DtoTrackDetails>(track);
        return Ok(trackDto);
    }

    /// <summary>
    /// Добавление трека в список
    /// </summary>
    /// <param name="track"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Post([FromBody] DtoTrackCreateUpdate track)
    {
        if (_trackService.Post(track))
        {
            return CreatedAtAction(nameof(Get), track);
        }
        return BadRequest();
    }

    /// <summary>
    /// Изменение трека
    /// </summary>
    /// <param name="id"></param>
    /// <param name="track"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] DtoTrackCreateUpdate track)
    {
        if (_trackService.Put(id, track))
        {
            var updatedTrackDto = _mapper.Map<DtoTrackDetails>(track);
            updatedTrackDto.Id = id;
            return CreatedAtAction(nameof(Get), updatedTrackDto);
        }
        return NotFound();
    }

    /// <summary>
    /// Удаление трека
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return _trackService.Delete(id) ? Ok() : NoContent();
    }
}