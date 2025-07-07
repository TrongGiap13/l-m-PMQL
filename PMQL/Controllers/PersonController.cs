using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMQL.Data;
using PMQL.Models;

namespace PMQL.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Person
        public async Task<IActionResult> Index()
        {
            return View(await _context.Person.ToListAsync());
        }

        // GET: /Person/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: /Person/Edit/id
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
                return NotFound();

            var person = await _context.Person.FindAsync(id);
            if (person == null)
                return NotFound();

            return View(person);
        }

        // POST: /Person/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Person person)
        {
            if (id != person.PersonId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.PersonId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: /Person/Delete/id
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
                return NotFound();

            var person = await _context.Person.FirstOrDefaultAsync(p => p.PersonId == id);
            if (person == null)
                return NotFound();

            return View(person);
        }

        // POST: /Person/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var person = await _context.Person.FindAsync(id);
            if (person != null)
            {
                _context.Person.Remove(person);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(string id)
        {
            return _context.Person.Any(e => e.PersonId == id);
        }
    }
}
