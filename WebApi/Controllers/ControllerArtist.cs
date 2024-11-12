using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using MediaLibrary.Classes;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ControllerArtist(IServiceArtist _artistService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Artist>> Get()
    {
        return Ok(_artistService.GetEnum());
    }

    [HttpGet("{id}")]
    public ActionResult<Artist> Get(int id)
    {
        var artist = _artistService.Get(id);
        if (artist == null)
            return NotFound();
        return Ok(artist);
    }

    [HttpPost]
    public IActionResult Post([FromBody] DtoArtist artist)
    {
        return _artistService.Post(artist) ? Ok() : BadRequest();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] DtoArtist artist)
    {
        return _artistService.Put(id, artist) ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return _artistService.Delete(id) ? Ok() : NotFound();
    }
}