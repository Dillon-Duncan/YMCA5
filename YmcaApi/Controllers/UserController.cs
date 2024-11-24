using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YmcaApi.Data;

namespace YmcaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly YmcaDbContext _ymcaDbContext;

        public UserController(YmcaDbContext ymcaDbContext) => _ymcaDbContext = ymcaDbContext;

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _ymcaDbContext.Users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User?>> GetById(int id)
        {
            return await _ymcaDbContext.Users.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            await _ymcaDbContext.Users.AddAsync(user);
            await _ymcaDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(User user)
        {
            _ymcaDbContext.Users.Update(user);
            await _ymcaDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var userGetByIdResult = await GetById(id);
            if (userGetByIdResult.Value == null)
            {
                return NotFound();
            }
            _ymcaDbContext.Users.Remove(userGetByIdResult.Value);
            await _ymcaDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}