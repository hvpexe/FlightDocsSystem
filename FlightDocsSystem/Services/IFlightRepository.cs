using FlightDocsSystem.Models;

namespace FlightDocsSystem.Services
{
    public interface IFlightRepository
    {
        Task<List<Flight>> GetAllFlightsAsync();
        Task<Flight?> GetFlightByIdAsync(int id);
        Task<Flight> CreateFlightAsync(Flight flight);
        Task UpdateFlightAsync(Flight flight);
        Task DeleteFlightAsync(int id);
    }
}
