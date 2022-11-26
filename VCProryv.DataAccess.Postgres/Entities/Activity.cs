using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace VCProryv.DataAccess.Postgres.Entities;

public class Activity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Degree { get; set; }
    public DateTime Date { get; set; }
    public IList<Volunteer> Volunteers { get; set; }
}

public sealed class ActivityEntitiyConfiguration : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder.HasKey(x => x.Id);
    }
}