using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Management_System.data;
using School_Management_System.Models;

namespace School_Management_System.Controllers
{
    public class StudentController : Controller

    {
        private readonly schoolDbContext _context;
        public StudentController(schoolDbContext context)
        {
            _context = context;
        }
        // GET: StudentController
        public async  Task<IActionResult> Index()
        {
            var st = await _context.StudentTable.ToListAsync();
            return View(st);
        }

        // GET: StudentController/Details/5
        public async Task <ActionResult> Details(int id)
        {
            if(id==null || _context.StudentTable == null)
            {
                return NotFound();
            }
            var stu = await _context.StudentTable.FirstOrDefaultAsync(st => st.Id == id);
            if( stu == null)
            {
                return NotFound();
            }
            return View(stu);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(student stu)
        {
            try
            {
                _context.StudentTable.Add(stu);
                 await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(stu);
            }
            return View(stu);
        }

        // GET: StudentController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if ( id == null || _context.StudentTable == null)
            {
                return NotFound();

            }
            var stu = await _context.StudentTable.FindAsync(id);
            if (stu == null)
            {
                return NotFound();
            }
            return View(stu);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(int id,student stu)
        {
            if(id != stu.Id)
            {
                return NotFound();

            }
              _context.StudentTable.Update(stu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            
            }


    // GET: StudentController/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        if (id == null || _context.StudentTable == null)
        {
            return NotFound();

        }
        var stu = await _context.StudentTable.FirstOrDefaultAsync(st => st.Id == id);
        if (stu == null)
        {
            return NotFound();
        }
        return View(stu);
    }

    // POST: StudentController/Delete/5
    [HttpPost]
        [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id, student stu)
    {
        var existing = await _context.StudentTable.FirstOrDefaultAsync(st => st.Id == id);
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
