using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YmcaApi.Data;

namespace YmcaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly YmcaDbContext _ymcaDbContext;

        public NewsController(YmcaDbContext ymcaDbContext) => _ymcaDbContext = ymcaDbContext;

        [HttpGet]
        public ActionResult<IEnumerable<News>> Get()
        {
            return _ymcaDbContext.News;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<News?>> GetById(int id)
        {
            return await _ymcaDbContext.News.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult<News>> Post(News news)
        {
            await _ymcaDbContext.News.AddAsync(news);
            await _ymcaDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = news.Id }, news);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<News>> Put(News news)
        {
            _ymcaDbContext.News.Update(news);
            await _ymcaDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<News>> Delete(int id)
        {
            var newsGetByIdResult = await GetById(id);
            if (newsGetByIdResult.Value == null)
            {
                return NotFound();
            }
            _ymcaDbContext.News.Remove(newsGetByIdResult.Value);
            await _ymcaDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}