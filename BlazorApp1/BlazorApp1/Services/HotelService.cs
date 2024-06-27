using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Services
{
    public class HotelService
    {
        private readonly TripServiceDbContext _context;

        public HotelService(TripServiceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Hotel>> GetAllHotelsAsync()
        {
            return await _context.Hotels.Include(h => h.City).ToListAsync();
        }

        public async Task DeleteHotelAsync(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel != null)
            {
                _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();
            }
        }
    }
}
