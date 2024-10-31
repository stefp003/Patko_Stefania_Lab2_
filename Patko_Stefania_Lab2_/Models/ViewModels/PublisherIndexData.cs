using Patko_Stefania_Lab2_.Models;


namespace Patko_Stefania_Lab2_.Models.ViewModels
{
    public class PublisherIndexData
    {
        public IEnumerable<Publisher> Publishers { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
