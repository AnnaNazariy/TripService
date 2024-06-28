using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorApp1.Models;
using System.Collections.Generic;

namespace BlazorApp1.Services
{
    public class HotelService
    {
        private readonly HttpClient _httpClient;

        public HotelService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Hotel>> GetAllHotelsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Hotel>>("api/hotels");
        }

        public async Task<Hotel> GetHotelByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Hotel>($"api/hotels/{id}");
        }

        public async Task AddHotelAsync(Hotel hotel)
        {
            await _httpClient.PostAsJsonAsync("api/hotels", hotel);
        }

        public async Task UpdateHotelAsync(Hotel hotel)
        {
            await _httpClient.PutAsJsonAsync($"api/hotels/{hotel.Id}", hotel);
        }

        public async Task DeleteHotelAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/hotels/{id}");
        }
    }
}
