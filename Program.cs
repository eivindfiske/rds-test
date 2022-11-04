using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using rds_test.Data;
using System.ComponentModel.DataAnnotations;
using System;
using rds_test.Models;
using Microsoft.AspNetCore.Identity;
using rds_test.Areas.Identity.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

ConfigureServices(
    builder.Services,
    builder.Configuration
    );

//var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
//builder.Services.AddDbContext<AppDbContext>(options =>
//        options.UseMySql(builder.Configuration.GetConnectionString("appDb"), serverVersion));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationContext>();


var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

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
    services.AddDbContext<ApplicationContext>(
        opts =>
        {
            opts.UseMySql(configManager.GetConnectionString("appDb"), new MySqlServerVersion(new Version()));
        }, ServiceLifetime.Transient);
}