using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YmcaApi.Data;

namespace YmcaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BulletinController : ControllerBase
    {
        private readonly YmcaDbContext _ymcaDbContext;

        public BulletinController(YmcaDbContext ymcaDbContext) => _ymcaDbContext = ymcaDbContext;

        [HttpGet]
        public ActionResult<IEnumerable<Bulletin>> Get()
        {
            return _ymcaDbContext.Bulletins;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bulletin?>> GetById(int id)
        {
            return await _ymcaDbContext.Bulletins.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Bulletin>> Post(Bulletin bulletin)
        {
            await _ymcaDbContext.Bulletins.AddAsync(bulletin);
            await _ymcaDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = bulletin.Id }, bulletin);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Bulletin>> Put(Bulletin bulletin)
        {
            _ymcaDbContext.Bulletins.Update(bulletin);
            await _ymcaDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Bulletin>> Delete(int id)
        {
            var bulletinGetByIdResult = await GetById(id);
            if (bulletinGetByIdResult.Value == null)
            {
                return NotFound();
            }
            _ymcaDbContext.Bulletins.Remove(bulletinGetByIdResult.Value);
            await _ymcaDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}