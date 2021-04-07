using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using litsey.Models;

namespace litsey.Controllers
{
    public class GroupSubjectsController : Controller
    {
        private readonly litseydbContext _context;

        public GroupSubjectsController(litseydbContext context)
        {
            _context = context;
        }

        // GET: GroupSubjects
        public async Task<IActionResult> Index()
        {
            var litseydbContext = _context.GroupSubjects.Include(g => g.Group).Include(g => g.Subject);
            return View(await litseydbContext.ToListAsync());
        }

        // GET: GroupSubjects/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupSubject = await _context.GroupSubjects
                .Include(g => g.Group)
                .Include(g => g.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupSubject == null)
            {
                return NotFound();
            }

            return View(groupSubject);
        }

        // GET: GroupSubjects/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Nomi");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Nomi");
            return View();
        }

        // POST: GroupSubjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GroupId,SubjectId")] GroupSubject groupSubject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupSubject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Nomi", groupSubject.GroupId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Nomi", groupSubject.SubjectId);
            return View(groupSubject);
        }

        // GET: GroupSubjects/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupSubject = await _context.GroupSubjects.FindAsync(id);
            if (groupSubject == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Nomi", groupSubject.GroupId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Nomi", groupSubject.SubjectId);
            return View(groupSubject);
        }

        // POST: GroupSubjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,GroupId,SubjectId")] GroupSubject groupSubject)
        {
            if (id != groupSubject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupSubject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupSubjectExists(groupSubject.Id))
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
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Nomi", groupSubject.GroupId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Nomi", groupSubject.SubjectId);
            return View(groupSubject);
        }

        // GET: GroupSubjects/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupSubject = await _context.GroupSubjects
                .Include(g => g.Group)
                .Include(g => g.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupSubject == null)
            {
                return NotFound();
            }

            return View(groupSubject);
        }

        // POST: GroupSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var groupSubject = await _context.GroupSubjects.FindAsync(id);
            _context.GroupSubjects.Remove(groupSubject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupSubjectExists(long id)
        {
            return _context.GroupSubjects.Any(e => e.Id == id);
        }
    }
}
