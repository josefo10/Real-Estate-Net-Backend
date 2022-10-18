using proyectoef;
using proyectoef.Models;

public class PropertyService: IPropertyService
{
    ModelsContext context;

    public PropertyService(ModelsContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Property> Get()
    {
        return context.Properties;
    }

    public async Task Save(Property property)
    {
        context.Add(property);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Property property)
    {
        var propertyActual = context.Properties.Find();

        if(propertyActual != null)
        {
            propertyActual.Name = property.Name;
            propertyActual.Address = property.Address;
            propertyActual.Price = property.Price;
            propertyActual.CodeInternal = property.CodeInternal;
            propertyActual.Year = property.Year;
            await context.SaveChangesAsync();

        }
    }

    public async Task Delete(Guid id)
    {
        var propertyActual = context.Properties.Find();

        if(propertyActual != null)
        {
            context.Remove(propertyActual);
            await context.SaveChangesAsync();
        }
    }
}

public interface IPropertyService
{
    IEnumerable<Property> Get();
    Task Save(Property property);
    Task Update(Guid id, Property property);
    Task Delete(Guid id);

}
