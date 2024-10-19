using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Patko_Stefania_Lab2_.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Patko_Stefania_Lab2_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Patko_Stefania_Lab2_Context") ?? throw new InvalidOperationException("Connection string 'Patko_Stefania_Lab2_Context' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
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
