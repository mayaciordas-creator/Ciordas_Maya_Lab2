using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Ciordas_Maya_Lab2.Models
{
    public class Author
    {
        
            public int ID { get; set; }

            [Required, Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required, Display(Name = "Last Name")]
            public string LastName { get; set; }

            // Navigation property – un autor are mai multe cărți
            public ICollection<Book>? Books { get; set; }

            // Proprietate de afișare
            public string FullName => $"{FirstName} {LastName}";
        }
    }



