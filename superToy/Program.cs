using Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

string? path = builder.Configuration.GetConnectionString("pgSql");
ArgumentNullException.ThrowIfNull(path);

builder.Services.AddDbContext<Connection>(row => row.UseNpgsql(path));

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.MapRazorPages();
app.Run();