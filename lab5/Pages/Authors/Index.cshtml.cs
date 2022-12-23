using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace lab5.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly LibraryContext _context;

        public IndexModel(LibraryContext context)
        {
            _context = context;
        }
        public List<Author> Authors { get; set; } = null!;
        public void OnGet()
        {
            Authors = _context.Authors.ToList();
        }
    }
}
