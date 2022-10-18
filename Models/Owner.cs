using System.Text.Json.Serialization;
namespace proyectoef.Models;
public class Owner
{
    public Guid IdOwner {get; set;}
    public string Name {get; set;}
    public string Adress {get; set;}

    [JsonIgnore]
    public virtual ICollection<Property> Propeties {get; set;}
}