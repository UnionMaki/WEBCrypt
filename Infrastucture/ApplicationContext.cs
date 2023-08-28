using Domain;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ConsoleApp1;
internal class ApplicationContext : DbContext, IUnitOfWork
{
    public DbSet<Field> Data => Set<Field>();
    public ApplicationContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
    {
        optionsBuilder.UseNpgsql("Server=localhost;Database=postgres;Port=5432;User Id=postgres;Password=3535");
        optionsBuilder.LogTo( Console.WriteLine, new[] { RelationalEventId.CommandExecuted } );
    }

    public void Commit()
    {
        SaveChanges();
    }
}
