namespace proyectoef.Models;
public class PropertyTrace
{
    public Guid IdPropertyTrace {get; set;}
    public DateTime DateSale {get; set;}
    public string Name {get; set;}
    public int Value {get; set;}
    public int Tax {get; set;}
    public Guid IdProperty {get; set;}
    public virtual Property Property {get; set;}
}