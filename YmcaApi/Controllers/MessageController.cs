using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YmcaApi.Data;

namespace YmcaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly YmcaDbContext _ymcaDbContext;

        public MessageController(YmcaDbContext ymcaDbContext) => _ymcaDbContext = ymcaDbContext;

        [HttpGet]
        public ActionResult<IEnumerable<Message>> Get()
        {
            return _ymcaDbContext.Messages;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Message?>> GetById(int id)
        {
            return await _ymcaDbContext.Messages.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Message>> Post(Message message)
        {
            await _ymcaDbContext.Messages.AddAsync(message);
            await _ymcaDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = message.Id }, message);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Message>> Put(Message message)
        {
            _ymcaDbContext.Messages.Update(message);
            await _ymcaDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Message>> Delete(int id)
        {
            var messageGetByIdResult = await GetById(id);
            if (messageGetByIdResult.Value == null)
            {
                return NotFound();
            }
            _ymcaDbContext.Messages.Remove(messageGetByIdResult.Value);
            await _ymcaDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}