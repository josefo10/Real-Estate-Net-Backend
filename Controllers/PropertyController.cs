using Microsoft.AspNetCore.Mvc;
using proyectoef.Models;

[Route("api/[controller]")]

public class PropertyController: ControllerBase
{
    IPropertyService propertyService;

    public PropertyController(IPropertyService service)
    {
        propertyService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(propertyService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Property property)
    {
        propertyService.Save(property);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Property property)
    {
        propertyService.Update(id, property);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        propertyService.Delete(id);
        return Ok();
    }
}