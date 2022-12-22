namespace lab2.Models
{
    public partial class Writer
    {
        public Writer()
        {
            Books = new List<Book>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
