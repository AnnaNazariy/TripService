using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            return await _context.AccountsTrips.ToListAsync();
        }

        public async Task AddAccountTripAsync(AccountTrip accountTrip)
        {
            _context.AccountsTrips.Add(accountTrip);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccountTripAsync(int accountId, int tripId)
        {
            var accountTrip = await _context.AccountsTrips
                .FirstOrDefaultAsync(at => at.AccountId == accountId && at.TripId == tripId);

            if (accountTrip != null)
            {
                _context.AccountsTrips.Remove(accountTrip);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<AccountTrip>> GetAccountTripsAsync()
        {
            return await _context.AccountsTrips.ToListAsync();
        }

        public async Task<List<Trip>> GetTripsByAccountIdAsync(int accountId)
        {
            return await _context.AccountsTrips
                .Where(at => at.AccountId == accountId)
                .Select(at => at.Trip)
                .ToListAsync();
        }
    }
}
