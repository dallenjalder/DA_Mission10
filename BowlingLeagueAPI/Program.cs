using BowlingLeagueAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Allow the React frontend (Vite default port 5173) to call the API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "http://localhost:5174", "http://localhost:5175")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Register controllers
builder.Services.AddControllers();

// Connect to the BowlingLeague SQLite database using EF Core
builder.Services.AddDbContext<BowlingContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BowlingLeague")));

var app = builder.Build();

// Apply CORS policy before routing
app.UseCors("AllowReactApp");

app.UseAuthorization();
app.MapControllers();

app.Run();
