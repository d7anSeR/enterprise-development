using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using MediaLibrary.Classes;

namespace WebApi.Controllers;

/// <summary>
/// Контроллер для работы с музыкальными альбомами
/// </summary>
/// <param name="_albumService"></param>
[Route("api/[controller]")]
[ApiController]
public class ControllerAlbum(IServiceAlbum _albumService) : ControllerBase
{
    /// <summary>
    /// Получения списка всех альбомов
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<Album>> Get()
    {
        return Ok(_albumService.GetEnum());
    }

    /// <summary>
    /// Получение данных об альбоме
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<Album> Get(int id)
    {
        var album = _albumService.Get(id);
        if (album == null)
            return NotFound();
        return Ok(album);
    }

    /// <summary>
    /// Добавление альбома в список
    /// </summary>
    /// <param name="album"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Post([FromBody] DtoAlbum album)
    {
        return _albumService.Post(album) ? Ok() : BadRequest();
    }

    /// <summary>
    /// Изменение альбома
    /// </summary>
    /// <param name="id"></param>
    /// <param name="album"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] DtoAlbum album)
    {
        return _albumService.Put(id, album) ? Ok() : NotFound();
    }

    /// <summary>
    /// Удаление альбома
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return _albumService.Delete(id) ? Ok() : NotFound();
    }
}