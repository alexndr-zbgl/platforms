using lab2.Models;
using Microsoft.EntityFrameworkCore;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

string connectionString = config.GetConnectionString("Library");
var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
var options = optionsBuilder
    .UseSqlServer(connectionString)
    .Options;
var db = new LibraryContext(options);

var library = from books in db.Books
               join readers in db.Readers on books.Reader equals readers.Id
               join writers in db.Writers on books.Writer equals writers.Id
               select new
               {
                   Name = books.Name,
                   Price = books.Price,
                   Taken = books.DateTaken,
                   ReaderFirstName = readers.FirstName,
                   ReaderLastName = readers.LastName,
                   WriterFirstName = writers.FirstName,
                   WriterLastName = writers.LastName
               };
foreach (var book in library)
{
    Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}",
        book.Name, book.Price, book.Taken, book.ReaderFirstName,  book.ReaderLastName, book.WriterFirstName, book.WriterLastName
     );
}
Console.ReadLine();
