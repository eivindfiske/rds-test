using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using rds_test.Data;
using System.ComponentModel.DataAnnotations;
using System;
using rds_test.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();


var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
builder.Services.AddDbContext<ApplicationContext>(options =>
            options.UseMySql(builder.Configuration.GetConnectionString("appDb"), serverVersion));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => 
    {
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    })
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
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
