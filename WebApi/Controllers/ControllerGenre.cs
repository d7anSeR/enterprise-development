using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using MediaLibrary.Classes;

namespace WebApi.Controllers;

/// <summary>
/// Контроллер для работы с жанрами музыки
/// </summary>
/// <param name="_genreService"></param>
[Route("api/[controller]")]
[ApiController]
public class ControllerGenre(IServiceGenre _genreService) : ControllerBase
{
    /// <summary>
    /// Получение списка всех жанров
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<Genre>> Get()
    {
        return Ok(_genreService.GetEnum());
    }

    /// <summary>
    /// Получение данных о жанре музыки 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<Genre> Get(int id)
    {
        var genre = _genreService.Get(id);
        if (genre == null)
            return NotFound();
        return Ok(genre);
    }

    /// <summary>
    /// Добавление жанра в список
    /// </summary>
    /// <param name="genre"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Post([FromBody] DtoGenre genre)
    {
        return _genreService.Post(genre) ? Ok() : BadRequest();
    }

    /// <summary>
    /// Изменение жанра музыки
    /// </summary>
    /// <param name="id"></param>
    /// <param name="genre"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] DtoGenre genre)
    {
        return _genreService.Put(id, genre) ? Ok() : NotFound();
    }

    /// <summary>
    /// Удаление жанра музыки
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return _genreService.Delete(id) ? Ok() : NotFound();
    }
}