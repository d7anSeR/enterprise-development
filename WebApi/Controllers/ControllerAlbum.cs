using AutoMapper;
using MediaLibrary.Classes;
using MediaLibrary.Classes.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;


namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ControllerAlbum(IRepositoryAlbum repository, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Album>> Get()
    {
        return Ok(repository.GetEnum());
    }

    [HttpGet("{id}")]
    public ActionResult<Album> Get(int id)
    {
        var album = repository.Get(id);
        if (album == null)
            return NotFound();
        return Ok(album);
    }

    [HttpPost]
    public IActionResult Post([FromBody] DtoAlbum album)
    {
        var _album = mapper.Map<Album>(album);
        return repository.Post(_album) ? Ok() : BadRequest();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] DtoAlbum album)
    {
        var _album = mapper.Map<Album>(album);
        _album.Id = id;
        return repository.Put(id, _album) ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return repository.Delete(id) ? Ok() : NotFound();
    }
}
