using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using MediaLibrary.Classes;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ControllerAlbum(IServiceAlbum _albumService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Album>> Get()
    {
        return Ok(_albumService.GetEnum());
    }

    [HttpGet("{id}")]
    public ActionResult<Album> Get(int id)
    {
        var album = _albumService.Get(id);
        if (album == null)
            return NotFound();
        return Ok(album);
    }

    [HttpPost]
    public IActionResult Post([FromBody] DtoAlbum album)
    {
        return _albumService.Post(album) ? Ok() : BadRequest();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] DtoAlbum album)
    {
        return _albumService.Put(id, album) ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return _albumService.Delete(id) ? Ok() : NotFound();
    }
}