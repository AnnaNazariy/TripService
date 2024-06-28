using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Services
{
    public class TripService
    {
        private readonly TripServiceDbContext _context;

        public TripService(TripServiceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Trip>> GetAllTripsAsync()
        {
            return await _context.Trips.Include(t => t.Room).ToListAsync();
        }

        public async Task AddTripAsync(Trip trip)
        {
            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTripAsync(int id)
        {
            var trip = await _context.Trips.FindAsync(id);
            if (trip != null)
            {
                _context.Trips.Remove(trip);
                await _context.SaveChangesAsync();
            }
        }
    }
}
