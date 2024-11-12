using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using MediaLibrary.Classes;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ControllerTrack(IServiceTrack _trackService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Track>> Get()
    {
        return Ok(_trackService.GetEnum());
    }

    [HttpGet("{id}")]
    public ActionResult<Track> Get(int id)
    {
        var track = _trackService.Get(id);
        if (track == null)
            return NotFound();
        return Ok(track);
    }

    [HttpPost]
    public IActionResult Post([FromBody] DtoTrack track)
    {
        return _trackService.Post(track) ? Ok() : BadRequest();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] DtoTrack track)
    {
        return _trackService.Put(id, track) ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return _trackService.Delete(id) ? Ok() : NotFound();
    }
}