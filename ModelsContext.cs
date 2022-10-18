using Microsoft.EntityFrameworkCore;
using proyectoef.Models;

namespace proyectoef;

public class ModelsContext : DbContext
{
    public DbSet<Owner> Owners {get; set;}
    public DbSet<Property> Properties {get; set;}
    public DbSet<PropertyImage> PropertyImages {get; set;}
    public DbSet<PropertyTrace> PropertyTraces {get; set;}

    public ModelsContext(DbContextOptions<ModelsContext> options) : base(options) {} 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Owner>(owner =>
        {
            owner.ToTable("Owner");

            owner.HasKey(p => p.IdOwner);
            owner.Property(p => p.Name);
            owner.Property(p => p.Adress);
        });

        modelBuilder.Entity<Property>(property =>
        {
            property.ToTable("Property");
            property.HasKey(p => p.IdProperty);
            property.HasOne(p => p.Owner).WithMany(p => p.Propeties).HasForeignKey(p => p.IdOwner); //.WithMany(p => p.Properties).HasForeignKey(p => p.IdOwner);
            property.Property(p => p.Name);
            property.Property(p => p.Address);
            property.Property(p => p.Price);
            property.Property(p => p.CodeInternal);
            property.Property(p => p.Year);
           
        });

        modelBuilder.Entity<PropertyImage>(propertyImage =>{
            propertyImage.ToTable("PropertyImage");
            propertyImage.HasKey(p => p.IdPropertyImage);
            propertyImage.HasOne(p => p.Property).WithMany(p => p.PropertyImages).HasForeignKey(p => p.IdProperty);
            propertyImage.Property(p => p.Enabled);
        });

        modelBuilder.Entity<PropertyTrace>(propertyTrace =>
        {
            propertyTrace.ToTable("PropertyTrace");
            propertyTrace.HasKey(p => p.IdPropertyTrace);
            propertyTrace.Property(p => p.DateSale);
            propertyTrace.Property(p => p.Name);
            propertyTrace.Property(p => p.Value);
            propertyTrace.Property(p => p.Tax);
            propertyTrace.HasOne(p => p.Property).WithMany(p => p.PropertyTraces).HasForeignKey(p => p.IdProperty);
        });
    }
}