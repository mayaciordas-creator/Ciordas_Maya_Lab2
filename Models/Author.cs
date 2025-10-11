using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Ciordas_Maya_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

 
        public ICollection<Book>? Books { get; set; }
    }
}
