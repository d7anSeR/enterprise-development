using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using MediaLibrary.Classes;
using AutoMapper;

namespace WebApi.Controllers;

/// <summary>
/// Контроллер для работы с музыкальными жанрами
/// </summary>
/// <param name="_genreService"></param>
/// <param name="_mapper"></param>
[Route("api/[controller]")]
[ApiController]
public class ControllerGenre(IServiceGenre _genreService, IMapper _mapper) : ControllerBase
{
    /// <summary>
    /// Получения списка всех жанров
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<DtoGenreDetails>> Get()
    {
        var genres = _genreService.GetEnum();
        var genresDtos = _mapper.Map<IEnumerable<DtoGenreDetails>>(genres);
        return Ok(genresDtos);
    }

    /// <summary>
    /// Получение данных о жанре
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<DtoGenreDetails> Get(int id)
    {
        var genre = _genreService.Get(id);
        if (genre == null)
            return NotFound();
        var genreDto = _mapper.Map<DtoGenreDetails>(genre);
        return Ok(genreDto);
    }

    /// <summary>
    /// Добавление жарна в список
    /// </summary>
    /// <param name="genre"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Post([FromBody] DtoGenreCreateUpdate genre)
    {
        if (_genreService.Post(genre))
        {
            return CreatedAtAction(nameof(Get), genre);
        }
        return BadRequest();
    }

    /// <summary>
    /// Изменение жанра
    /// </summary>
    /// <param name="id"></param>
    /// <param name="genre"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] DtoGenreCreateUpdate genre)
    {
        if (_genreService.Put(id, genre))
        {
            var updatedGenreDto = _mapper.Map<DtoGenreDetails>(genre);
            updatedGenreDto.Id = id;
            return CreatedAtAction(nameof(Get), updatedGenreDto);
        }
        return NotFound();
    }

    /// <summary>
    /// Удаление жанра
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return _genreService.Delete(id) ? Ok() : NoContent();
    }
}