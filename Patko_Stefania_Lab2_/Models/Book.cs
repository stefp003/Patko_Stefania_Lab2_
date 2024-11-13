using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Patko_Stefania_Lab2_.Models
{
    public class Book
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Titlul este obligatoriu.")]
        [Display(Name = "Book Title")]
        [StringLength(150,MinimumLength =(3), ErrorMessage="Titlul trebuie sa aiba intre 3 si 150 de caractere")]
        public string Title { get; set; }
        

        public int AuthorID { get; set; }
        [DataType(DataType.Date)]

        public Author? Author { get; set; }
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        public int? PublisherID { get; set; }
        public Publisher? Publisher { get; set; }
        public ICollection<Borrowing>? Borrowings { get; set; }
        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}
