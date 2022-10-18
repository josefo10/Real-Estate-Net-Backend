using System.Text.Json.Serialization;

namespace proyectoef.Models;
public class Property
{
    public Guid IdProperty {get; set;}
    public string Name {get; set;}
    public string Address {get; set;}
    public int Price {get; set;}
    public string CodeInternal {get; set;}
    public string Year {get; set;}
    public Guid IdOwner {get;set;}

    public virtual Owner Owner {get; set;}

    [JsonIgnore]
    public virtual ICollection<PropertyImage> PropertyImages {get; set;}

    [JsonIgnore]
    public virtual ICollection<PropertyTrace> PropertyTraces {get; set;}

}