using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using MediaLibrary.Classes;

namespace WebApi.Controllers;

/// <summary>
/// Контроллер для работы с музыкальными треками
/// </summary>
/// <param name="_trackService"></param>
[Route("api/[controller]")]
[ApiController]
public class ControllerTrack(IServiceTrack _trackService) : ControllerBase
{
    /// <summary>
    /// Получение списка всех музыкальных треков
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<Track>> Get()
    {
        return Ok(_trackService.GetEnum());
    }

    /// <summary>
    /// Получение данных о треке
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<Track> Get(int id)
    {
        var track = _trackService.Get(id);
        if (track == null)
            return NotFound();
        return Ok(track);
    }

    /// <summary>
    /// Добавление трека в список
    /// </summary>
    /// <param name="track"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Post([FromBody] DtoTrack track)
    {
        return _trackService.Post(track) ? Ok() : BadRequest();
    }

    /// <summary>
    /// Изменение данных трека
    /// </summary>
    /// <param name="id"></param>
    /// <param name="track"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] DtoTrack track)
    {
        return _trackService.Put(id, track) ? Ok() : NotFound();
    }

    /// <summary>
    /// Удаление трека
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return _trackService.Delete(id) ? Ok() : NotFound();
    }
}