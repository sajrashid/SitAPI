using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetAPI.Models;
using dotnetAPI.Repository;

namespace dotnetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestResultsController : ControllerBase
    {
        private readonly SitDbContext _context;

        public TestResultsController(SitDbContext context)
        {
            _context = context;
        }

        // GET: api/TestResults
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestResults>>> GetTestResults()
        {
            return await _context.TestResults.ToListAsync();
        }

        // GET: api/TestResults/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestResults>> GetTestResults(int id)
        {
            var testResults = await _context.TestResults.FindAsync(id);

            if (testResults == null)
            {
                return NotFound();
            }

            return testResults;
        }

        // PUT: api/TestResults/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestResults(int id, TestResults testResults)
        {
            if (id != testResults.TestId)
            {
                return BadRequest();
            }

            _context.Entry(testResults).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestResultsExists(id))
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

        // POST: api/TestResults
        [HttpPost]
        public async Task<ActionResult<TestResults>> PostTestResults(TestResults testResults)
        {
            _context.TestResults.Add(testResults);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestResults", new { id = testResults.TestId }, testResults);
        }

        // DELETE: api/TestResults/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TestResults>> DeleteTestResults(int id)
        {
            var testResults = await _context.TestResults.FindAsync(id);
            if (testResults == null)
            {
                return NotFound();
            }

            _context.TestResults.Remove(testResults);
            await _context.SaveChangesAsync();

            return testResults;
        }

        private bool TestResultsExists(int id)
        {
            return _context.TestResults.Any(e => e.TestId == id);
        }
    }
}
