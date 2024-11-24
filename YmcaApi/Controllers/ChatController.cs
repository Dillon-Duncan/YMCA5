using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YmcaApi.Data;

namespace YmcaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly YmcaDbContext _ymcaDbContext;

        public ChatController(YmcaDbContext ymcaDbContext) => _ymcaDbContext = ymcaDbContext;

        [HttpGet]
        public ActionResult<IEnumerable<Chat>> Get()
        {
            return _ymcaDbContext.Chats;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chat?>> GetById(int id)
        {
            return await _ymcaDbContext.Chats.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Chat>> Post(Chat chat)
        {
            await _ymcaDbContext.Chats.AddAsync(chat);
            await _ymcaDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = chat.Id }, chat);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Chat>> Put(Chat chat)
        {
            _ymcaDbContext.Chats.Update(chat);
            await _ymcaDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Chat>> Delete(int id)
        {
            var chatGetByIdResult = await GetById(id);
            if (chatGetByIdResult.Value == null)
            {
                return NotFound();
            }
            _ymcaDbContext.Chats.Remove(chatGetByIdResult.Value);
            await _ymcaDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}