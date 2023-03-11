using FlightDocsSystem.Models;
using FlightDocsSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocsSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository _groupRepository;

        public GroupController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGroup()
        {
            try
            {
                var data = await _groupRepository.GetAllGroupAsync();
                return Ok(data);
            } catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetGroupById(int id)
        {
            try
            {
                var data = await _groupRepository.GetGroupByIdAsync(id);
                if (data != null)
                {
                    return Ok(data);
                } else
                {
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(GroupModel group)
        {
            try
            {
                var data = await _groupRepository.AddGroupAsync(group);
                return Ok(data);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("id")]
        public async Task<IActionResult> Update(int id, GroupVM group)
        {
            if (id != group.Id)
            {
                return BadRequest();
            }

            try
            {
                await _groupRepository.UpdateGroupAsync(group);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("id")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _groupRepository.DeleteGroupAsync(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
