using Microsoft.AspNetCore.Mvc;
using proyectoef.Models;

[Route("api/[controller]")]

public class PropertyImageController: ControllerBase
{
    IPropertyImageService propertyImageService;

    public PropertyImageController(IPropertyImageService service)
    {
        propertyImageService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
       return Ok(propertyImageService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] PropertyImage propertyImage)
    {
        propertyImageService.Save(propertyImage);
        return Ok();    
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] PropertyImage propertyImage)
    {
        propertyImageService.Update(id, propertyImage);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        propertyImageService.Delete(id);
        return Ok();
    }
}