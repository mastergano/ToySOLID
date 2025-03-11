using AuthDomain;
using AuthDomain.Queries;
using AuthDomain.Queries.Object;
using Data;
using Microsoft.EntityFrameworkCore;
using Service;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

string? path = builder.Configuration.GetConnectionString("pgSql");
ArgumentNullException.ThrowIfNull(path);

//Db
builder.Services.AddDbContext<Connection>(row => row.UseNpgsql(path));
//Autorization
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IQueryService<EntryDTO, Users?>, AutorizationQueryService>();
builder.Services.AddScoped<IQueryService<RegistrationDTO, Users?>, RegistrationUserQueryService>();
//Claims
builder.Services.AddScoped<IQueryService<Users, ClaimsPrincipal>, CreatePrincipalQueryService>();

//Policy in Claims
builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("Autorization", police =>
    {
        police.RequireClaim("role", "User");
    });
});

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.MapRazorPages();
app.Run();