using FlightDocsSystem.Data;
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

        public async Task<List<Flight>> GetAllFlightsAsync()
        {
            var flights = await _context.Flights.ToListAsync();
            return flights;
        }

        public async Task<Flight?> GetFlightByIdAsync(int id)
        {
            var flight = await _context.Flights.SingleOrDefaultAsync(x => x.Id == id);
            if (flight != null)
            {
                return flight;
            }
            return null;
        }

        public async Task<Flight> CreateFlightAsync(Flight flight)
        {
            await _context.Flights.AddAsync(flight);
            await _context.SaveChangesAsync();

            return flight;
        }

        public async Task UpdateFlightAsync(Flight flight)
        {
            var newFlight = await _context.Flights.SingleOrDefaultAsync(x => x.Id == flight.Id);
            if (newFlight != null)
            {
                newFlight.FlightNo = flight.FlightNo;
                newFlight.Route = flight.Route;
                newFlight.DepartureDate = flight.DepartureDate;
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFlightAsync(int id)
        {
            var flight = await _context.Flights.SingleOrDefaultAsync(x => x.Id == id);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
                await _context.SaveChangesAsync();
            }
        }


    }
}
