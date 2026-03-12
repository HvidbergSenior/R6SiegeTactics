using ITMartinR6SiegeTactics.Application.Services;
using ITMartinR6SiegeTactics.Domain.Interfaces;
using ITMartinR6SiegeTactics.InfraStructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Tactic services
builder.Services.AddScoped<TacticService>();
builder.Services.AddScoped<IMapRepository, JsonMapRepository>();
builder.Services.AddHttpClient<JsonMapRepository>();

// Optional API endpoints
builder.Services.AddControllers();

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
    app.UseExceptionHandler("/Error");

app.UseStaticFiles();
app.UseRouting();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();