using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TranslationApi.Models;

namespace TranslationApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TranslationItemsController : ControllerBase
    {
        private readonly TranslationContext _context;

        public TranslationItemsController(TranslationContext context)
        {
            _context = context;
        }

        // GET: api/TranslationItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TranslationItem>>> GetTranslationItems()
        {
            return await _context.TranslationItems.ToListAsync();
        }

        // GET: api/TranslationItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TranslationItem>> GetTranslationItem(long id)
        {
            var translationItem = await _context.TranslationItems.FindAsync(id);

            if (translationItem == null)
            {
                return NotFound();
            }

            return translationItem;
        }

        // PUT: api/TranslationItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTranslationItem(string id, TranslationItem translationItem)
        {
            if (id != translationItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(translationItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TranslationItemExists(id))
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

        // POST: api/TranslationItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TranslationItem>> PostTranslationItem(TranslationItem translationItem)
        {
            _context.TranslationItems.Add(translationItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTranslationItem", new { id = translationItem.Id }, translationItem);
            return CreatedAtAction(nameof(GetTranslationItem), new { id = translationItem.Id }, translationItem);
        }

        // DELETE: api/TranslationItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TranslationItem>> DeleteTranslationItem(long id)
        {
            var translationItem = await _context.TranslationItems.FindAsync(id);
            if (translationItem == null)
            {
                return NotFound();
            }

            _context.TranslationItems.Remove(translationItem);
            await _context.SaveChangesAsync();

            return translationItem;
        }

        private bool TranslationItemExists(string id)
        {
            return _context.TranslationItems.Any(e => e.Id == id);
        }
    }
}
