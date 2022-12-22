namespace lab2.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime DateTaken { get; set; }
        public int Writer { get; set; }
        public int Reader { get; set; }

        public virtual Writer WriterNavigation { get; set; }
        public virtual Reader ReaderNavigation { get; set; }
    }
}
