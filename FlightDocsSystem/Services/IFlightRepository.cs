using FlightDocsSystem.Models;

namespace FlightDocsSystem.Services
{
    public interface IFlightRepository
    {
        Task<List<FlightVM>> GetFlightsAsync();
        Task<FlightVM> GetFlightByIdAsync(int id);
        Task<FlightVM> AddGroupAsync(FlightModel flight);
        Task UpdateGroupAsync(FlightVM flight);
        Task DeleteGroupAsync(int id);
    }
}
