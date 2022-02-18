using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Models;
using webapi.Servico;

namespace webapi.Controllers
{
    [ApiController]
    [Route("professores/api")]
    public class ProfessoresController : ControllerBase
    {
        private readonly DbContexto _context;

        public ProfessoresController(DbContexto context)
        {
            _context = context;
        }

        // GET: Professores
        [HttpGet("listar-professores")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.Professores.ToListAsync());
        }

        // GET: Professores/Details/5
        [HttpGet("detalhes-professor")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professor == null)
            {
                return NotFound();
            }

            return Ok(professor);
        }

        // POST: Professores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("cadastrar-professor")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Salario")] Professor professor)
        {
            if (ModelState.IsValid)
            { 

                _context.Add(professor);
                await _context.SaveChangesAsync();
                return Ok(professor);
            }

            var messages = ModelState
                   .SelectMany(x => x.Value.Errors)
                   .Select(e => e.ErrorMessage)
                   .ToList();

            return BadRequest(messages);
        }

        // POST: Professores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut("atualizar-professor/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Salario")] Professor professor)
        {
            if (id != professor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorExists(professor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            
            var messages = ModelState
                   .SelectMany(x => x.Value.Errors)
                   .Select(e => e.ErrorMessage)
                   .ToList();
                   
            return BadRequest(messages);
        }

        // POST: Professores/Delete/5
        [ValidateAntiForgeryToken]
        [HttpDelete("remover-professor/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var professor = await _context.Professores.FindAsync(id);
            
            if(professor == null) 
                return NotFound();

            _context.Professores.Remove(professor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfessorExists(int id)
        {
            return _context.Professores.Any(e => e.Id == id);
        }
    }
}
