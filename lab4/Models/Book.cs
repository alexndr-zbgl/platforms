using System.Reflection.PortableExecutable;

namespace lab4.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int AuthorID { get; set; }
        public int ReaderID { get; set; }

        public virtual Author Author { get; set; }
        public virtual Reader Reader { get; set; }
    }
}
