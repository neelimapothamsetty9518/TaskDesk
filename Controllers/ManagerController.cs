using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelDeskWebapi.IRepoManager;
using TravelDeskWebapi.Model;

namespace TravelDeskWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    { 
     private readonly ManagerInterface _repository;

            public ManagerController(ManagerInterface repository)
            {
                _repository = repository;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Manager>>> GetAllTravelRequests()
            {
                var travelRequests = await _repository.GetAllAsync();
                return Ok(travelRequests);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Manager>> GetTravelRequest(int id)
            {
                var travelRequest = await _repository.GetByIdAsync(id);

                if (travelRequest == null)
                {
                    return NotFound();
                }

                return travelRequest;
            }

            [HttpPost]
            public async Task<ActionResult<Manager>> CreateTravelRequest(Manager travelRequest)
            {
                await _repository.AddAsync(travelRequest);
                return CreatedAtAction(nameof(GetTravelRequest), new { id = travelRequest.Id }, travelRequest);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateTravelRequest(int id, Manager travelRequest)
            {
                if (id != travelRequest.Id)
                {
                    return BadRequest();
                }

                if (!await _repository.ExistsAsync(id))
                {
                    return NotFound();
                }

                // Ensure comments are not left blank
                if (string.IsNullOrEmpty(travelRequest.Comments))
                {
                    return BadRequest("Comments cannot be left blank.");
                }

                // Update the status and comments
                var existingRequest = await _repository.GetByIdAsync(id);
                existingRequest.Status = travelRequest.Status;
                existingRequest.Comments = travelRequest.Comments;
                existingRequest.UpdateAt = DateTime.UtcNow;

                await _repository.UpdateAsync(existingRequest);

                // Notify HR Travel Admin and Employee based on the status
                NotifyHrTravelAdmin(existingRequest);
                NotifyEmployee(existingRequest);

                return NoContent();
            }

            private void NotifyHrTravelAdmin(Manager travelRequest)
            {
                // Implement notification logic to HR Travel Admin
            }

            private void NotifyEmployee(Manager travelRequest)
            {
                // Implement notification logic to Employee
            }
        }

    }

