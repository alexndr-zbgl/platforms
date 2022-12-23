using lab4.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace lab4.Controllers
{
    public class PersonController : Controller
    {
        LibraryContext _context;
        public PersonController(LibraryContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Author> persons = _context.Authors;
            return View(persons);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Author person)
        {

            if (ModelState.IsValid)
            {
                await _context.Authors.AddAsync(person);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Authors.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Author person)
        {
            if (ModelState.IsValid)
            {
                _context.Authors.Update(person);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Authors.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteP(int? id)
        {
            var person = await _context.Authors.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
