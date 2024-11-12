using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using MediaLibrary.Classes;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ControllerGenre(IServiceGenre _genreService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Genre>> Get()
    {
        return Ok(_genreService.GetEnum());
    }

    [HttpGet("{id}")]
    public ActionResult<Genre> Get(int id)
    {
        var genre = _genreService.Get(id);
        if (genre == null)
            return NotFound();
        return Ok(genre);
    }

    [HttpPost]
    public IActionResult Post([FromBody] DtoGenre genre)
    {
        return _genreService.Post(genre) ? Ok() : BadRequest();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] DtoGenre genre)
    {
        return _genreService.Put(id, genre) ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return _genreService.Delete(id) ? Ok() : NotFound();
    }
}