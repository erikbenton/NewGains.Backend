using Microsoft.EntityFrameworkCore;
using NewGains.DataAccess.Contexts;
using NewGains.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Db Contexts
builder.Services.AddDbContext<NewGainsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("NewGainsDbContext"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); // disconnected
});

// Repositories
builder.Services.AddScoped<IExerciseRepository, ExerciseSqlRepository>();
builder.Services.AddScoped<ITemplatesRepository, TemplatesSqlRepository>();

// Middleware policies
builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", builder => 
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}

app.UseHttpsRedirection();

// Blazor middleware
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseAuthorization();

//app.UseCors("Open");

app.MapControllers();

// Client blazor app
app.MapFallbackToFile("index.html");

app.Run();
