using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore; 

public interface ICityRepository
{
    Task<List<City>> GetAllCitiesAsync();
    Task<City> GetCityByIdAsync(int id);
    Task AddCityAsync(City city);
    Task UpdateCityAsync(City city);
    Task DeleteCityAsync(int id);
}

public class CityRepository : ICityRepository
{
    private readonly TripServiceDbContext _context;

    public CityRepository(TripServiceDbContext context)
    {
        _context = context;
    }

    public async Task<List<City>> GetAllCitiesAsync()
    {
        return await _context.Cities.ToListAsync();
    }

    public async Task<City> GetCityByIdAsync(int id)
    {
        return await _context.Cities.FindAsync(id);
    }

    public async Task AddCityAsync(City city)
    {
        _context.Cities.Add(city);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCityAsync(City city)
    {
        _context.Cities.Update(city);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCityAsync(int id)
    {
        var city = await _context.Cities.FindAsync(id);
        if (city != null)
        {
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
        }
    }
}
