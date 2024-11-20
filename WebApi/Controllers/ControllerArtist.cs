using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using MediaLibrary.Classes;
using AutoMapper;

namespace WebApi.Controllers;

/// <summary>
/// Контроллер для работы с музыкальными артистами
/// </summary>
/// <param name="_artistService"></param>
/// <param name="_mapper"></param>
[Route("api/[controller]")]
[ApiController]
public class ControllerArtist(IServiceArtist _artistService, IMapper _mapper) : ControllerBase
{
    /// <summary>
    /// Получения списка всех артистов
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<DtoArtistDetails>> Get()
    {
        var artists = _artistService.GetEnum();
        var artistsDtos = _mapper.Map<IEnumerable<DtoArtistDetails>>(artists);
        return Ok(artistsDtos);
    }

    /// <summary>
    /// Получение данных об артисте
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<DtoArtistDetails> Get(int id)
    {
        var artist = _artistService.Get(id);
        if (artist == null)
            return NotFound();
        var artistDto = _mapper.Map<DtoArtistDetails>(artist);
        return Ok(artistDto);
    }

    /// <summary>
    /// Добавление артиста в список
    /// </summary>
    /// <param name="artist"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Post([FromBody] DtoArtistCreateUpdate artist)
    {
        if (_artistService.Post(artist))
        {
            return CreatedAtAction(nameof(Get), artist);
        }
        return BadRequest();
    }

    /// <summary>
    /// Изменение данных об артисте
    /// </summary>
    /// <param name="id"></param>
    /// <param name="artist"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] DtoArtistCreateUpdate artist)
    {
        if (_artistService.Put(id, artist))
        {
            var updatedArtistDto = _mapper.Map<DtoArtistDetails>(artist);
            updatedArtistDto.Id = id;
            return CreatedAtAction(nameof(Get), updatedArtistDto);
        }
        return NotFound();
    }

    /// <summary>
    /// Удаление артиста
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return _artistService.Delete(id) ? Ok() : NoContent();
    }
}