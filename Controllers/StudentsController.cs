using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_grade_app.Data;
using MVC_grade_app.Entities;

namespace MVC_grade_app.Controllers
{
    [Authorize]
    public class StudentsController(ApplicationDbContext context) : Controller
    {

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await context.Students.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentNumber,FirstName,LastName,MiddleName,Email")] Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = Guid.NewGuid();
                context.Add(student);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,StudentNumber,FirstName,LastName,MiddleName,Email")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(student);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var student = await context.Students.FindAsync(id);
            if (student != null)
            {
                context.Students.Remove(student);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [Route("upload-students")]
        public async Task<IActionResult> UploadStudents([FromForm] IFormFile file, CancellationToken cancellationToken = default)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No CSV file uploaded");
            }

            if (!Path.GetExtension(file.FileName).Equals(".csv", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Invalid file format. Only CSV files are allowed.");
            }

            try
            {
                // Read the CSV file content
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    // Skip the header row if it exists (optional)
                    await reader.ReadLineAsync();

                    var students = new List<Student>();
                    while (!reader.EndOfStream)
                    {
                        var line = await reader.ReadLineAsync();
                        var entry = line?.Split(',') ?? [];
                        var student = new Student
                        {
                            StudentNumber = entry[2].Split('@')[0],
                            FirstName = entry[0],
                            LastName = entry[1],
                            Email = entry[2].ToLower()
                        };
                       
                       if (student != null)
                       {
                           students.Add(student);
                       }
                    }

                    // Call StudentService to save students to the database
                    await context.AddRangeAsync(students);
                    var saveResult = await context.SaveChangesAsync(cancellationToken);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred: {ex.Message}";
                return RedirectToAction("Index");
            }

            TempData["SuccessMessage"] = "Students uploaded successfully!";
            return RedirectToAction("Index");
        }

        private bool StudentExists(Guid id)
        {
            return context.Students.Any(e => e.Id == id);
        }
    }
}
