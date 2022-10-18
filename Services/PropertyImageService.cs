using proyectoef;
using proyectoef.Models;

public class PropertyImageService: IPropertyImageService
{
    ModelsContext context;

    public PropertyImageService(ModelsContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<PropertyImage> Get()
    {
        return context.PropertyImages;
    }

    public async Task Save(PropertyImage propertyImage)
    {
        context.Add(propertyImage);
        await context.SaveChangesAsync();
    }

   public async Task Update(Guid id, PropertyImage propertyImage)
    {
        var propertyImageActual = context.PropertyImages.Find();

        if(propertyImageActual != null)
        {
            propertyImageActual.Enabled = propertyImage.Enabled;
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var propertyImageActual = context.PropertyImages.Find();

        if(propertyImageActual != null)
        {
            context.Remove(propertyImageActual);
            await context.SaveChangesAsync();
        }
    }

}

public interface IPropertyImageService
{
    IEnumerable<PropertyImage> Get();
    Task Save(PropertyImage propertyImage);
    Task Update(Guid id, PropertyImage propertyImage);
    Task Delete(Guid id);
}