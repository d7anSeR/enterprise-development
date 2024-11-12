using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using MediaLibrary.Classes;

namespace WebApi.Controllers;

/// <summary>
/// Контроллер для работы с артистами
/// </summary>
/// <param name="_artistService"></param>
[Route("api/[controller]")]
[ApiController]
public class ControllerArtist(IServiceArtist _artistService) : ControllerBase
{
    /// <summary>
    /// Получение списка артистов
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<Artist>> Get()
    {
        return Ok(_artistService.GetEnum());
    }

    /// <summary>
    /// Получение данных об артисте
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<Artist> Get(int id)
    {
        var artist = _artistService.Get(id);
        if (artist == null)
            return NotFound();
        return Ok(artist);
    }

    /// <summary>
    /// Добавление артиста в список
    /// </summary>
    /// <param name="artist"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Post([FromBody] DtoArtist artist)
    {
        return _artistService.Post(artist) ? Ok() : BadRequest();
    }

    /// <summary>
    /// Изменение данных об артисте
    /// </summary>
    /// <param name="id"></param>
    /// <param name="artist"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] DtoArtist artist)
    {
        return _artistService.Put(id, artist) ? Ok() : NotFound();
    }

    /// <summary>
    /// Удаление артиста из списка
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return _artistService.Delete(id) ? Ok() : NotFound();
    }
}