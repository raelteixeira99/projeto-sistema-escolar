using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Data;
using SistemaEscolar.Models;
using System.Threading.Tasks;

namespace SistemaEscolar.Controllers
{
    public class ProfessoresController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProfessoresController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> Index() => View(await _context.Professores.ToListAsync());

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Professor professor)
        {
            if (!ModelState.IsValid) return View(professor);
            _context.Professores.Add(professor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var p = await _context.Professores.FindAsync(id);
            if (p == null) return NotFound();
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Professor professor)
        {
            if (id != professor.Id) return BadRequest();
            if (!ModelState.IsValid) return View(professor);
            _context.Update(professor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var p = await _context.Professores.FindAsync(id);
            if (p == null) return NotFound();
            return View(p);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var p = await _context.Professores.FindAsync(id);
            if (p == null) return NotFound();
            return View(p);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var p = await _context.Professores.FindAsync(id);
            if (p != null)
            {
                _context.Professores.Remove(p);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
