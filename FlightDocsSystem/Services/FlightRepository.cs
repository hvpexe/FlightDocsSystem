using FlightDocsSystem.Models;

namespace FlightDocsSystem.Services
{
    public class FlightRepository : IFlightRepository
    {
        private readonly DataContext _context;

        public FlightRepository(DataContext context)
        {
            _context = context;
        }

        public Task<FlightVM> AddGroupAsync(FlightModel flight)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGroupAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FlightVM> GetFlightByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<FlightVM>> GetFlightsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateGroupAsync(FlightVM flight)
        {
            throw new NotImplementedException();
        }
    }
}
