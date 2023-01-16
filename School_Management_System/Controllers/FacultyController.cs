using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Management_System.data;
using School_Management_System.Models;

namespace School_Management_System.Controllers
{
    public class FacultyController : Controller

    {
        private readonly schoolDbContext _context;
        public FacultyController(schoolDbContext context)
        {
            _context = context;
        }
        // GET: StudentController
        public async Task<IActionResult> Index()
        {
            var ft = await _context.FacultiesTable.ToListAsync();
            return View(ft);
        }

        // GET: StudentController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null || _context.FacultiesTable == null)
            {
                return NotFound();
            }
            var ft = await _context.FacultiesTable.FirstOrDefaultAsync(fc => fc.Id == id);
            if (ft == null)
            {
                return NotFound();
            }
            return View(ft);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(faculty ft)
        {
            try
            {
                _context.FacultiesTable.Add(ft);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(ft);
            }
            return View(ft);
        }

        // GET: StudentController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.FacultiesTable == null)
            {
                return NotFound();

            }
            var ft = await _context.FacultiesTable.FindAsync(id);
            if (ft == null)
            {
                return NotFound();
            }
            return View(ft);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, faculty ft)
        {
            if (id != ft.Id)
            {
                return NotFound();

            }
            _context.FacultiesTable.Update(ft);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }


        // GET: StudentController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.FacultiesTable == null)
            {
                return NotFound();

            }
            var stu = await _context.FacultiesTable.FirstOrDefaultAsync(ft => ft.Id == id);
            if (stu == null)
            {
                return NotFound();
            }
            return View(stu);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, faculty ft)
        {
            var existing = await _context.FacultiesTable.FirstOrDefaultAsync(fc => fc.Id == id);
            if (existing == null)
            {
                throw new ArgumentException($"Employee Does not exists");
            }
            _context.Entry(existing).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
