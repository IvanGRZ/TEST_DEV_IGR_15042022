#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Rest.Data;
using Api_Rest.Models;

namespace Api_Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tb_PersonasFisicasController : ControllerBase
    {
        private readonly Api_RestContext _context;

        public Tb_PersonasFisicasController(Api_RestContext context)
        {
            _context = context;
        }

        // GET: api/Tb_PersonasFisicas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tb_PersonasFisicas>>> GetTb_PersonasFisicas()
        {
            return await _context.Tb_PersonasFisicas.ToListAsync();
        }

        // GET: api/Tb_PersonasFisicas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tb_PersonasFisicas>> GetTb_PersonasFisicas(int id)
        {
            var tb_PersonasFisicas = await _context.Tb_PersonasFisicas.FindAsync(id);

            if (tb_PersonasFisicas == null)
            {
                return NotFound();
            }

            return tb_PersonasFisicas;
        }

        // PUT: api/Tb_PersonasFisicas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTb_PersonasFisicas(int id, Tb_PersonasFisicas tb_PersonasFisicas)
        {
            if (id != tb_PersonasFisicas.IdPersonaFisica)
            {
                return BadRequest();
            }

            _context.Entry(tb_PersonasFisicas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tb_PersonasFisicasExists(id))
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

        // POST: api/Tb_PersonasFisicas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tb_PersonasFisicas>> PostTb_PersonasFisicas(Tb_PersonasFisicas tb_PersonasFisicas)
        {
            _context.Tb_PersonasFisicas.Add(tb_PersonasFisicas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTb_PersonasFisicas", new { id = tb_PersonasFisicas.IdPersonaFisica }, tb_PersonasFisicas);
        }

        // DELETE: api/Tb_PersonasFisicas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTb_PersonasFisicas(int id)
        {
            var tb_PersonasFisicas = await _context.Tb_PersonasFisicas.FindAsync(id);
            if (tb_PersonasFisicas == null)
            {
                return NotFound();
            }

            _context.Tb_PersonasFisicas.Remove(tb_PersonasFisicas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Tb_PersonasFisicasExists(int id)
        {
            return _context.Tb_PersonasFisicas.Any(e => e.IdPersonaFisica == id);
        }
    }
}
