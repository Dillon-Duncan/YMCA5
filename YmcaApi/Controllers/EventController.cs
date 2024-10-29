using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YmcaApi.Data;

namespace YmcaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly YmcaDbContext _ymcaDbContext;

        public EventController(YmcaDbContext ymcaDbContext) => _ymcaDbContext = ymcaDbContext;

        [HttpGet]
        public ActionResult<IEnumerable<Event>> Get()
        {
            return _ymcaDbContext.Events;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event?>> GetById(int id)
        {
            return await _ymcaDbContext.Events.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Event>> Post(Event @event)
        {
            await _ymcaDbContext.Events.AddAsync(@event);
            await _ymcaDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = @event.Id }, @event);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Event>> Put(Event @event)
        {
            _ymcaDbContext.Events.Update(@event);
            await _ymcaDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Event>> Delete(int id)
        {
            var eventGetByIdResult = await GetById(id);
            if (eventGetByIdResult.Value == null)
            {
                return NotFound();
            }
            _ymcaDbContext.Events.Remove(eventGetByIdResult.Value);
            await _ymcaDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}