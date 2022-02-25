using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Models;
using webapi.Servico;

namespace webapi.Controllers
{
    [ApiController]
    [Route("fornecedores/api")]
    public class FornecedoresController : Controller
    {
        private readonly DbContexto _context;

        public FornecedoresController(DbContexto context)
        {
            _context = context;
        }

        // GET: Fornecedores
        [HttpGet("listar-fornecedores")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.Fornecedores.ToListAsync());
        }

        // GET: Fornecedores/Details/5
        [HttpGet("detalhes-fornecedor/{id:int?}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return Ok(fornecedor);
        }

        // POST: Fornecedores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("cadastrar-fornecedor")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Matricula,Notas")] Fornecedor fornecedor)
        {
            _context.Add(fornecedor);
            await _context.SaveChangesAsync();
            return Ok(fornecedor);
        }

        // POST: Fornecedores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut("atualizar-fornecedor/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Matricula,Notas")] Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(fornecedor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FornecedorExists(fornecedor.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            return Ok(fornecedor);
        }

        // POST: Fornecedores/Delete/5
        [HttpDelete("remover-fornecedor/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            
            if(fornecedor == null)
                return NotFound("fornecedor não encontrado");

            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool FornecedorExists(int id)
        {
            return _context.Fornecedores.Any(e => e.Id == id);
        }
    }
}
