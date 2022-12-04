using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace VCProryv.DataAccess.Postgres.Entities;

public class Volunteer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? MiddleName { get; set; }
    public string Institute { get; set; }
    public IList<Activity> Activities { get; set; }
}

public sealed class VolunteerEntitiyConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.HasKey(x => x.Id);
    }
}