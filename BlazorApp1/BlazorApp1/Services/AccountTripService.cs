using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Services
{
    public class AccountTripService
    {
        private readonly TripServiceDbContext _context;

        public AccountTripService(TripServiceDbContext context)
        {
            _context = context;
        }

        public async Task<List<AccountTrip>> GetAllAccountTripsAsync()
        {
            return await _context.AccountsTrips.Include(at => at.Account).Include(at => at.Trip).ToListAsync();
        }

        public async Task AddAccountTripAsync(AccountTrip accountTrip)
        {
            _context.AccountsTrips.Add(accountTrip);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccountTripAsync(int accountId, int tripId)
        {
            var accountTrip = await _context.AccountsTrips.FindAsync(accountId, tripId);
            if (accountTrip != null)
            {
                _context.AccountsTrips.Remove(accountTrip);
                await _context.SaveChangesAsync();
            }
        }
    }
}
