using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetAPI.Models;
using Microsoft.Extensions.Logging;

namespace dotnetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApisController : ControllerBase
    {
        private readonly SitDbContext _context;
        readonly ILogger<ApisController> _log;
        public ApisController(SitDbContext context, ILogger<ApisController> log)
        {
            _context = context;
            _log = log;
        }

      
        // GET: api/Apis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Api>>> GetAPI()
        {
            _log.LogInformation("Getting API List from DB");
            // return await _context.API.Include.(x => x.Verbs).ToList();
            return await _context.API
                .Include(b => b.Verbs)
                .ToListAsync();


        }

        // GET: api/Apis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Api>> GetApi(int id)
        {
            var api = await _context.API.FindAsync(id);

            if (api == null)
            {
                return NotFound();
            }

            return api;
        }

        // PUT: api/Apis/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApi(int id, Api api)
        {
            if (id != api.APIId)
            {
                return BadRequest();
            }

            _context.Entry(api).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApiExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Apis
        [HttpPost]
        public async Task<ActionResult<Api>> PostApi( Api api)
        {
            _context.API.Add(api);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApi", new { id = api.APIId }, api);
        }

        // DELETE: api/Apis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Api>> DeleteApi(int id)
        {
            var api = await _context.API.FindAsync(id);
            if (api == null)
            {
                return NotFound();
            }

            _context.API.Remove(api);
            await _context.SaveChangesAsync();

            return api;
        }

        private bool ApiExists(int id)
        {
            return _context.API.Any(e => e.APIId == id);
        }
    }
}
