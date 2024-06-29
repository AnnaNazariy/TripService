using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using BlazorApp1.Data;
using BlazorApp1.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();

        builder.Services.AddScoped<HotelService>();
        builder.Services.AddScoped<ReviewService>();
        builder.Services.AddScoped<AccountService>();
        builder.Services.AddScoped<RoomService>();
        builder.Services.AddScoped<TripService>();
        builder.Services.AddScoped<CityService>();
        builder.Services.AddScoped<AccountTripService>();

        builder.Services.AddHttpClient();

        builder.Services.AddDbContext<TripServiceDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.WebHost.UseUrls("http://localhost:7000", "https://localhost:7001");

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();

        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        app.Run();
    }
}
