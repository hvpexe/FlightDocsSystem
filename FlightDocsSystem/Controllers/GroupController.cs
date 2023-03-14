using AutoMapper;
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
        private readonly IMapper _mapper;

        public GroupController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGroups()
        {
            try
            {
                var data = await _groupRepository.GetAllGroupAsync();
                var dataVM = data.Select(x => _mapper.Map<GroupVM>(x));
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
                    var dataVM = _mapper.Map<GroupVM>(data);
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
        public async Task<IActionResult> CreateGroup(GroupModel group)
        {
            try
            {
                await _groupRepository.CreateGroupAsync(group);
                return Ok("Create success");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateGroup(int id, GroupVM group)
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
        public async Task<ActionResult> DeleteGroup(int id)
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
