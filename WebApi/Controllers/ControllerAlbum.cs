using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using MediaLibrary.Classes;
using AutoMapper;

namespace WebApi.Controllers;

/// <summary>
/// Контроллер для работы с музыкальными альбомами
/// </summary>
/// <param name="_albumService"></param>
/// <param name="_mapper"></param>
[Route("api/[controller]")]
[ApiController]
public class ControllerAlbum(IServiceAlbum _albumService, IMapper _mapper) : ControllerBase
{
    /// <summary>
    /// Получения списка всех альбомов
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<DtoAlbumDetails>> Get()
    {
        var albums = _albumService.GetEnum();
        var albumsDtos = _mapper.Map<IEnumerable<DtoAlbumDetails>>(albums);
        return Ok(albumsDtos);
    }

    /// <summary>
    /// Получение данных об альбоме
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<DtoAlbumDetails> Get(int id)
    {
        var album = _albumService.Get(id);
        if (album == null)
            return NotFound();
        var albumDto = _mapper.Map<DtoAlbumDetails>(album);
        return Ok(albumDto);
    }

    /// <summary>
    /// Добавление альбома в список
    /// </summary>
    /// <param name="album"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Post([FromBody] DtoAlbumCreateUpdate album)
    {
        if (_albumService.Post(album))
        {
            return CreatedAtAction(nameof(Get), album);
        }
        return BadRequest();
    }

    /// <summary>
    /// Изменение альбома
    /// </summary>
    /// <param name="id"></param>
    /// <param name="album"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] DtoAlbumCreateUpdate album)
    {
        if (_albumService.Put(id, album))
        {
            var updatedAlbumDto = _mapper.Map<DtoAlbumDetails>(album);
            updatedAlbumDto.Id = id;
            return CreatedAtAction(nameof(Get), updatedAlbumDto);
        }
        return NotFound();
    }

    /// <summary>
    /// Удаление альбома
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return _albumService.Delete(id) ? Ok() : NoContent();
    }
}