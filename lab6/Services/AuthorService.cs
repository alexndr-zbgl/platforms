using lab6.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace lab6.Services
{
    public class AuthorService
    {
        private readonly LibraryContext _context;
        public AuthorService(LibraryContext context)
        {
            _context = context;
        }
        public List<Author> authors { get; set; } = new List<Author>();

        public async Task GetAuthors()
        {
            authors = await _context.Authors.ToListAsync();
        }

        public async Task<Author> GetAuthor(int id)
        {

            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                throw new Exception("Can't find the author with id: " + id);
            }
            return author;
        }

        public async Task Create(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Author author)
        {

            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {

            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                throw new Exception("Can't find the author with id: " + id);
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }
    }
}
