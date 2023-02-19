using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlightDocsSystem.Models;

namespace FlightDocsSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateFlight(Flight request)
        {
            return Ok(request);
        }

        [HttpGet("{id}")]
        public IActionResult GetFlight(int id)
        {
            return Ok(id);
        }

        [HttpPut]
        public IActionResult UpsertFlight(Flight request)
        {
            return Ok(request);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFlight(int id)
        {
            return Ok(id);
        }
    }
}
