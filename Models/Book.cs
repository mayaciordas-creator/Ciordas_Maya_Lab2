using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ciordas_Maya_Lab2.Models
{
    public class Book
    {
        internal int Id;

        public int ID { get; set; }
        [Display(Name = "Book Title")]
        public string? Title { get; set; }
        [Display(Name = "Author")]
        public int AuthorID { get; set; }
        public Author? Author { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }
        public int PublisherID { get; set; }
        public Publisher? Publisher { get; set; }
        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}
