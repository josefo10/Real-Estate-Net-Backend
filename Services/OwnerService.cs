using proyectoef;
using proyectoef.Models;

public class OwnerService : IOwnerService
{
    ModelsContext context;

    public OwnerService(ModelsContext dbcontext){
        context = dbcontext;
    }

    public IEnumerable<Owner> Get()
    {
        return context.Owners;
    }

    public async Task Save(Owner owner)
    {
        context.Add(owner);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Owner owner)
    {
        var ownerActual = context.Owners.Find(id);

        if(ownerActual != null)
        {
            ownerActual.Name = owner.Name;
            ownerActual.Adress = owner.Adress;
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var ownerActual = context.Owners.Find(id);

        if(ownerActual != null)
        {
            context.Remove(ownerActual);
            await context.SaveChangesAsync();
        }
    }
}

public interface IOwnerService
{
    IEnumerable<Owner> Get();
    Task Save(Owner owner);
    Task Update(Guid id, Owner owner);
    Task Delete(Guid id);

}