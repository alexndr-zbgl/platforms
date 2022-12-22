namespace lab2.Models
{
    public partial class Reader
    {
        public Reader()
        {
            Books = new List<Book>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ReaderTicket { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
