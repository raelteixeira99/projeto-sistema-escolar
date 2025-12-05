using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Data;
using SistemaEscolar.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaEscolar.Controllers
{
    public class TurmasController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TurmasController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> Index() => View(await _context.Turmas.Include(t=>t.Curso).Include(t=>t.Professor).ToListAsync());

        public async Task<IActionResult> Create()
        {
            ViewData["Cursos"] = new SelectList(await _context.Cursos.ToListAsync(), "Id", "Nome");
            ViewData["Professores"] = new SelectList(await _context.Professores.ToListAsync(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Turma turma)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Cursos"] = new SelectList(await _context.Cursos.ToListAsync(), "Id", "Nome", turma.CursoId);
                ViewData["Professores"] = new SelectList(await _context.Professores.ToListAsync(), "Id", "Nome", turma.ProfessorId);
                return View(turma);
            }
            _context.Turmas.Add(turma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var turma = await _context.Turmas.FindAsync(id);
            if (turma == null) return NotFound();
            ViewData["Cursos"] = new SelectList(await _context.Cursos.ToListAsync(), "Id", "Nome", turma.CursoId);
            ViewData["Professores"] = new SelectList(await _context.Professores.ToListAsync(), "Id", "Nome", turma.ProfessorId);
            return View(turma);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Turma turma)
        {
            if (id != turma.Id) return BadRequest();
            if (!ModelState.IsValid)
            {
                ViewData["Cursos"] = new SelectList(await _context.Cursos.ToListAsync(), "Id", "Nome", turma.CursoId);
                ViewData["Professores"] = new SelectList(await _context.Professores.ToListAsync(), "Id", "Nome", turma.ProfessorId);
                return View(turma);
            }
            _context.Update(turma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var turma = await _context.Turmas.Include(t=>t.Curso).Include(t=>t.Professor).FirstOrDefaultAsync(t=>t.Id==id);
            if (turma == null) return NotFound();
            return View(turma);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var turma = await _context.Turmas.FindAsync(id);
            if (turma == null) return NotFound();
            return View(turma);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turma = await _context.Turmas.FindAsync(id);
            if (turma != null)
            {
                _context.Turmas.Remove(turma);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
