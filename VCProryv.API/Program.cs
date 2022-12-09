using Microsoft.EntityFrameworkCore;
using VCProryv.Core.Services; //  interface IActivityService
using VCProryv.BusinessLogic; //  ActivityService
using VCProryv.Core.Repositories; //  interface IActivityRepository
using VCProryv.DataAccess.Postgres.Repositories; //  ActivitiesRepository
using VCProryv.DataAccess.Postgres; //  context DB

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IVolunteersService, VolunteersService>();
builder.Services.AddScoped<IVolunteersRepository, VolunteersRepository>();

builder.Services.AddScoped<IActivitiesService, ActivitiesService>();
builder.Services.AddScoped<IActivitiesRepository, ActivitiesRepository>();

builder.Services.AddDbContext<VCProryvDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(VCProryvDbContext))); //Берётся строка из appsetings.json
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
