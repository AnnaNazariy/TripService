using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data.Repositories
{
    public class TripRepository
    {
        private readonly TripServiceDbContext _context;

        public TripRepository(TripServiceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Trip>> GetAllTripsAsync()
        {
            return await _context.Trips.Include(t => t.Room).ToListAsync();
        }

        public async Task<Trip?> GetTripByIdAsync(int id) // Changed to return nullable Trip
        {
            return await _context.Trips.Include(t => t.Room).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<int> CreateTripAsync(Trip trip)
        {
            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();
            return trip.Id;
        }

        public async Task UpdateTripAsync(Trip trip)
        {
            _context.Entry(trip).State = EntityState.Modified;
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
