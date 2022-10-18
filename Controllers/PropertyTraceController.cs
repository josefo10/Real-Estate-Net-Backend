using Microsoft.AspNetCore.Mvc;
using proyectoef.Models;

[Route("api/[controller]")]

public class PropertyTraceController: ControllerBase
{
    IPropertyTraceService propertyTraceService;

    public PropertyTraceController(IPropertyTraceService service)
    {
        propertyTraceService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(propertyTraceService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] PropertyTrace propertyTrace)
    {
        propertyTraceService.Save(propertyTrace);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] PropertyTrace propertyTrace)
    {
        propertyTraceService.Update(id, propertyTrace);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        propertyTraceService.Delete(id);
        return Ok();
    }
}