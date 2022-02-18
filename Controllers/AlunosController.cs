using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Models;
using webapi.Servico;

namespace webapi.Controllers
{
    [ApiController]
    [Route("alunos/api")]
    public class AlunosController : Controller
    {
        private readonly DbContexto _context;

        public AlunosController(DbContexto context)
        {
            _context = context;
        }

        // GET: Alunos
        [HttpGet("listar-alunos")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.Alunos.ToListAsync());
        }

        // GET: Alunos/Details/5
        [HttpGet("detalhes-aluno/{id:int?}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("cadastrar-aluno")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Matricula,Notas")] Aluno aluno)
        {
            _context.Add(aluno);
            await _context.SaveChangesAsync();
            return Ok(aluno);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut("atualizar-aluno/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Matricula,Notas")] Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(aluno);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(aluno.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            return Ok(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpDelete("remover-aluno/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            
            if(aluno == null)
                return NotFound("aluno não encontrado");

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool AlunoExists(int id)
        {
            return _context.Alunos.Any(e => e.Id == id);
        }
    }
}
