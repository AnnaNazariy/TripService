using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Services
{
    public class AccountService
    {
        private readonly TripServiceDbContext _context;

        public AccountService(TripServiceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Account>> GetAccountsAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<List<City>> GetCitiesAsync()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task CreateAccountAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task<Account> GetAccountAsync(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }
    }

}
