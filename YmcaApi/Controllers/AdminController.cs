using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YmcaApi.Data;

namespace YmcaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly YmcaDbContext _ymcaDbContext;

        public AdminController(YmcaDbContext ymcaDbContext) => _ymcaDbContext = ymcaDbContext;

        [HttpGet]
        public ActionResult<IEnumerable<Admin>> Get()
        {
            return _ymcaDbContext.Admins;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Admin?>> GetById(int id)
        {
            return await _ymcaDbContext.Admins.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Admin>> Post(Admin admin)
        {
            await _ymcaDbContext.Admins.AddAsync(admin);
            await _ymcaDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = admin.Id }, admin);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Admin>> Put(Admin admin)
        {
            _ymcaDbContext.Admins.Update(admin);
            await _ymcaDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Admin>> Delete(int id)
        {
            var adminGetByIdResult = await GetById(id);
            if (adminGetByIdResult.Value == null)
            {
                return NotFound();
            }
            _ymcaDbContext.Admins.Remove(adminGetByIdResult.Value);
            await _ymcaDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}