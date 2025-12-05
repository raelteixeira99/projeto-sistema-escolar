using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Data;
using SistemaEscolar.Models;
using System.Threading.Tasks;
using System.Linq;

namespace SistemaEscolar.Controllers
{
    public class AlunosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AlunosController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> Index(string busca)
        {
            var q = _context.Alunos.AsQueryable();
            if (!string.IsNullOrEmpty(busca))
                q = q.Where(a => a.Nome.Contains(busca));
            var list = await q.ToListAsync();
            return View(list);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Aluno aluno)
        {
            if (!ModelState.IsValid) return View(aluno);
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null) return NotFound();
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Aluno aluno)
        {
            if (id != aluno.Id) return BadRequest();
            if (!ModelState.IsValid) return View(aluno);
            _context.Update(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null) return NotFound();
            return View(aluno);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null) return NotFound();
            return View(aluno);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno != null)
            {
                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
