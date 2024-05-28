using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_grade_app.Data;
using MVC_grade_app.Entities;

namespace MVC_grade_app.Controllers
{
    public class SubjectEnrolmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubjectEnrolmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubjectEnrolments
        public async Task<IActionResult> Index()
        {
            return View(await _context.SubjectEnrolment.ToListAsync());
        }

        // GET: SubjectEnrolments/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjectEnrolment = await _context.SubjectEnrolment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subjectEnrolment == null)
            {
                return NotFound();
            }

            return View(subjectEnrolment);
        }

        // GET: SubjectEnrolments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubjectEnrolments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SectionId,SubjectId")] SubjectEnrolment subjectEnrolment)
        {
            if (ModelState.IsValid)
            {
                subjectEnrolment.Id = Guid.NewGuid();
                _context.Add(subjectEnrolment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subjectEnrolment);
        }

        // GET: SubjectEnrolments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjectEnrolment = await _context.SubjectEnrolment.FindAsync(id);
            if (subjectEnrolment == null)
            {
                return NotFound();
            }
            return View(subjectEnrolment);
        }

        // POST: SubjectEnrolments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,SectionId,SubjectId")] SubjectEnrolment subjectEnrolment)
        {
            if (id != subjectEnrolment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subjectEnrolment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectEnrolmentExists(subjectEnrolment.Id))
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
            return View(subjectEnrolment);
        }

        // GET: SubjectEnrolments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjectEnrolment = await _context.SubjectEnrolment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subjectEnrolment == null)
            {
                return NotFound();
            }

            return View(subjectEnrolment);
        }

        // POST: SubjectEnrolments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var subjectEnrolment = await _context.SubjectEnrolment.FindAsync(id);
            if (subjectEnrolment != null)
            {
                _context.SubjectEnrolment.Remove(subjectEnrolment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectEnrolmentExists(Guid id)
        {
            return _context.SubjectEnrolment.Any(e => e.Id == id);
        }
    }
}
