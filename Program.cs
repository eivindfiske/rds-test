using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using rds_test.Data;
using System.ComponentModel.DataAnnotations;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

ConfigureServices(
    builder.Services,
    builder.Configuration
    ) ;

var app = builder.Build();


app.MapGet("/Users", async (AppDbContext db) =>
    await db.users.ToListAsync())
    .Produces<List<Users>>(StatusCodes.Status200OK);

app.MapGet("/Users/{id:int}", async (AppDbContext db, int id) =>
    await db.users.FindAsync(id))
    .Produces<List<Users>>(StatusCodes.Status200OK);


app.MapPost("/Users", async (AppDbContext db, Users users) =>
{
     await db.users.AddAsync(users);
     await db.SaveChangesAsync();

    return Results.Created($"/Users/{users.Id}", users);
}).Produces(StatusCodes.Status201Created); //ehedbu

app.MapGet("/Suggestions", async (AppDbContext db) =>
    await db.suggestions.ToListAsync())
    .Produces<List<Suggestions>>(StatusCodes.Status200OK);

app.MapGet("/Suggestions/{id:int}", async (AppDbContext db, int id) =>
    await db.suggestions.FindAsync(id))
    .Produces<List<Suggestions>>(StatusCodes.Status200OK);


app.MapPost("/Suggestions", async (AppDbContext db, Suggestions suggestions) =>
{
    await db.suggestions.AddAsync(suggestions);
    await db.SaveChangesAsync();

    return Results.Created($"/Suggestions/{suggestions.id}", suggestions);
}).Produces(StatusCodes.Status201Created);


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapRazorPages();

    app.Run();

void ConfigureServices(IServiceCollection services, ConfigurationManager configManager)
{
    services.AddDbContext<AppDbContext>(
        opts =>
        {
            opts.UseMySql(configManager.GetConnectionString("appDb"), new MySqlServerVersion(new Version()));
        }, ServiceLifetime.Transient);
}