namespace proyectoef.Models;
public class PropertyImage
{
    public Guid IdPropertyImage {get; set;}
    public Guid IdProperty {get; set;}
    public Boolean Enabled {get; set;}
    public virtual Property Property {get; set;}
}