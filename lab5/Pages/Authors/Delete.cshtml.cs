using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace lab5.Pages.Authors
{
    public class DeleteModel : PageModel
    {
        private readonly LibraryContext _context;
        public Author? author { get; set; }
        public DeleteModel(LibraryContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(int? id)
        {
            var person = await _context.Authors.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            _context.Authors.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");

        }
    }
}
