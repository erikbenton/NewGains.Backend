using Microsoft.EntityFrameworkCore;
using NewGains.DataAccess.Contexts;
using NewGains.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NewGainsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("NewGainsDbContext"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); // disconnected
});

builder.Services.AddScoped<IExerciseRepository, ExerciseSqlRepository>();
builder.Services.AddScoped<ITemplatesRepository, TemplatesSqlRepository>();

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
