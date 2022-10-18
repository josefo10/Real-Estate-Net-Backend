using Microsoft.AspNetCore.Mvc;
using proyectoef.Models;

[Route("api/[controller]")]

public class OwnerController: ControllerBase
{
    IOwnerService ownerService;

    public OwnerController(IOwnerService service)
    {
        ownerService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(ownerService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Owner owner)
    {
        ownerService.Save(owner);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Owner owner)
    {
        ownerService.Update(id, owner);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        ownerService.Delete(id);
        return Ok();
    }
}