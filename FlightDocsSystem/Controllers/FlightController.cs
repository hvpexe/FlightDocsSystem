using AutoMapper;
using FlightDocsSystem.Data;
using FlightDocsSystem.Helpers;
using FlightDocsSystem.Models;
using FlightDocsSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FlightDocsSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public FlightController(IFlightRepository flightRepository, IUserRepository userRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet] 
        public async Task<IActionResult> GetAllFlights()
        {
            var flights = await _flightRepository.GetAllFlightsAsync();
            if (flights == null) return NotFound();
            var flightVMs = flights.Select(x => _mapper.Map<FlightVM>(x));
            return Ok(flightVMs);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFlight(FlightModel request)
        {
            if (request.FlightNo.IsNullOrEmpty())
            {
                return BadRequest("Flight No must not be empty");
            }

            if (request.Loading.IsNullOrEmpty())
            {
                return BadRequest("Point of Loading must not be empty");
            }

            if (request.Unloading.IsNullOrEmpty())
            {
                return BadRequest("Point of Unloading must not be empty");
            }

            User? creator;
            try
            {
                creator = await _userRepository.GetUserByIdAsync(request.UserId);
            } catch (Exception ex)
            {
                return BadRequest("Creator not exist");
            }

            var flight = new Flight
            {
                FlightNo = request.FlightNo,
                Route = Utils.TwoPointToRoute(request.Loading, request.Unloading),
                DepartureDate = request.DepartureDate,
                UserId = request.UserId
            };
            try
            {
                await _flightRepository.CreateFlightAsync(flight);
                return Ok(request);
            } catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlight(int id)
        {
            var flight = await _flightRepository.GetFlightByIdAsync(id);
            if (flight == null) return NotFound();
            var flightVM = _mapper.Map<FlightVM>(flight);
            return Ok(flightVM);  
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlight(int id, FlightEM request)
        {
            if (request.FlightNo.IsNullOrEmpty())
            {
                return BadRequest("Flight No must not be empty");
            }

            if (request.Loading.IsNullOrEmpty())
            {
                return BadRequest("Point of Loading must not be empty");
            }

            if (request.Unloading.IsNullOrEmpty())
            {
                return BadRequest("Point of Unloading must not be empty");
            }

            var flight = await _flightRepository.GetFlightByIdAsync(id);
            if (flight == null)
            {
                return BadRequest("ID of flight not exist");
            }

            var newFlight = new Flight
            {
                Id = id,
                FlightNo = request.FlightNo,
                Route = Utils.TwoPointToRoute(request.Loading, request.Unloading),
                DepartureDate = request.DepartureDate
            };

            try
            {
                await _flightRepository.UpdateFlightAsync(newFlight);
            } 
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(request);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            await _flightRepository.DeleteFlightAsync(id);
            return Ok();
        }
    }
}
