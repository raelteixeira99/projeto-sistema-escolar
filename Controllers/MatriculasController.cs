using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Data;
using SistemaEscolar.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaEscolar.Controllers
{
    public class MatriculasController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MatriculasController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> Index() => View(await _context.Matriculas.Include(m=>m.Aluno).Include(m=>m.Turma).ToListAsync());

        public async Task<IActionResult> Create()
        {
            ViewData["Alunos"] = new SelectList(await _context.Alunos.ToListAsync(), "Id", "Nome");
            ViewData["Turmas"] = new SelectList(await _context.Turmas.ToListAsync(), "Id", "Codigo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Matricula matricula)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Alunos"] = new SelectList(await _context.Alunos.ToListAsync(), "Id", "Nome", matricula.AlunoId);
                ViewData["Turmas"] = new SelectList(await _context.Turmas.ToListAsync(), "Id", "Codigo", matricula.TurmaId);
                return View(matricula);
            }
            _context.Matriculas.Add(matricula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var m = await _context.Matriculas.Include(m=>m.Aluno).Include(m=>m.Turma).FirstOrDefaultAsync(x=>x.Id==id);
            if (m == null) return NotFound();
            return View(m);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var m = await _context.Matriculas.FindAsync(id);
            if (m != null)
            {
                _context.Matriculas.Remove(m);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var m = await _context.Matriculas.Include(m=>m.Aluno).Include(m=>m.Turma).FirstOrDefaultAsync(x=>x.Id==id);
            if (m == null) return NotFound();
            return View(m);
        }
    }
}
