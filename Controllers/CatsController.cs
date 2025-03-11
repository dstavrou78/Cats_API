using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cats_API.Models;
using Cats_API.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Cats_API.Controllers
{
    [Route("api/cats")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class CatsController : ControllerBase
    {
        private readonly CatsContext _context;
        private readonly IExternalAPI _externalAPI;
        private readonly HttpClient _client;

        public CatsController(CatsContext context, IExternalAPI externalAPI, IHttpClientFactory factory)
        {
            _context = context;
            //_context.Database.EnsureCreated();
            _externalAPI = externalAPI;
            var client = factory.CreateClient("cats");
            _client = client;
        }

        // GET: api/Cats/fetch
        /// <summary>
        /// Fetches 25 random images from https://thecatapi.com and stores them in the database.
        /// </summary>
        [HttpGet]
        [Route("fetch")]
        public async Task Fetch()
        {
            if (_client.BaseAddress == null)
                throw new BadHttpRequestException("Invalid Cats API address");

            try
            {
                await _externalAPI.GetAsync(_client, _context);
            }
            catch (Exception ex){
                throw new BadHttpRequestException(ex.Message);
            }
            

        }


        // GET: api/Cats
        /// <summary>
        /// Gets all cats with optional pagination and filtering by Tag
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cat>>> GetAllCats([FromQuery] CatQueryParameters queryParameters)
        {
            IQueryable<Cat> cats = _context.Cats.Include(x => x.Image).Include(x => x.Tags).Include(x => x.Image.Breeds);

            if (!string.IsNullOrEmpty(queryParameters.Tag))
            {
                // cats = cats.Include(c => c.Tags).Where(c => c.Tags.Any(t => t.Name == queryParameters.Tag));
                cats = cats.Where(c => c.Tags.Any(t => t.Name.ToLower().Trim() == queryParameters.Tag.ToLower().Trim()));
            }

            cats = cats
                .Skip(queryParameters.PageSize * (queryParameters.Page - 1))
                .Take(queryParameters.PageSize);

            return Ok(await cats.ToListAsync());

        }

        // GET: api/Cats/5
        /// <summary>
        /// Gets a specific Cat.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Cat>> GetCat(int id)
        {
            //var cat = await _context.Cats.FindAsync(id);
            var cat = await _context.Cats.Include(x => x.Image).Include(x => x.Tags).Include(x => x.Image.Breeds).Where(x => x.Id == id).FirstOrDefaultAsync<Cat>();

            if (cat == null)
            {
                return NotFound();
            }

            return Ok(cat);
        }

        // PUT: api/Cats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a specific cat.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cat"></param>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCat(int id, Cat cat)
        {
            if (id != cat.Id)
            {
                return BadRequest();
            }

            _context.Entry(cat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatExists(id))
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

        // POST: api/Cats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Inserts a new Cat.
        /// </summary>
        /// <param name="cat"></param>
        /// <returns>The newly inserted cat</returns>
        [HttpPost]
        public async Task<ActionResult<Cat>> PostCat(Cat cat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Cats.Add(cat);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCat), new { id = cat.Id }, cat);
        }

        // DELETE: api/Cats/5
        /// <summary>
        /// Deletes a specific cat.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The deleted item</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cat>> DeleteCat(int id)
        {
            //var cat = await _context.Cats.FindAsync(id);
            var cat = await _context.Cats.Include(x => x.Image).Include(x => x.Tags).Include(x => x.Image.Breeds).Where(x => x.Id == id).FirstOrDefaultAsync<Cat>();
            if (cat == null)
            {
                return NotFound();
            }

            _context.Cats.Remove(cat);
            await _context.SaveChangesAsync();

            //return NoContent();
            return cat;
        }

        private bool CatExists(int id)
        {
            return _context.Cats.Any(e => e.Id == id);
        }
    }
}
