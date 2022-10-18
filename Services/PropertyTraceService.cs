using proyectoef;
using proyectoef.Models;

public class PropertyTraceService: IPropertyTraceService
{
    ModelsContext context;

    public PropertyTraceService(ModelsContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<PropertyTrace> Get()
    {
        return context.PropertyTraces;
    }

    public async Task Save(PropertyTrace propertyTrace)
    {
        context.Add(propertyTrace);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, PropertyTrace propertyTrace)
    {
        var propertyTraceActual = context.PropertyTraces.Find();

        if(propertyTraceActual != null)
        {
            propertyTraceActual.DateSale = propertyTrace.DateSale;
            propertyTraceActual.Name = propertyTrace.Name;
            propertyTraceActual.Value = propertyTrace.Value;
            propertyTrace.Tax = propertyTrace.Tax;
            await context.SaveChangesAsync();
        }

    }

    public async Task Delete(Guid id)
    {
        var propertyTraceActual = context.PropertyTraces.Find();
        if(propertyTraceActual != null)
        {
            context.Remove(propertyTraceActual);
            await context.SaveChangesAsync();
        }
        
        
    }
}

public interface IPropertyTraceService
{
    IEnumerable<PropertyTrace> Get();
    Task Save(PropertyTrace propertyTrace);
    Task Update(Guid id, PropertyTrace propertyTrace);
    Task Delete(Guid id);
}