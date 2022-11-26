using Microsoft.EntityFrameworkCore;
using VCProryv.DataAccess.Postgres.Entities;

namespace VCProryv.DataAccess.Postgres;

public class VCProryvDbContext : DbContext
{
    public VCProryvDbContext(DbContextOptions<VCProryvDbContext> options) : base(options) //Передать строки подключение и всё необходимое
    {

    }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Volunteer> Volunteers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        //modelBuilder.ApplyConfiguration(new ActivityEntitiyConfiguration());
        //modelBuilder.ApplyConfiguration(new VolunteerEntitiyConfiguration());
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VCProryvDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}


