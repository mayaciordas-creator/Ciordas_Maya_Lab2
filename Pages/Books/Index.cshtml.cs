using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ciordas_Maya_Lab2.Data;
using Ciordas_Maya_Lab2.Models;

namespace Ciordas_Maya_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Ciordas_Maya_Lab2.Data.Ciordas_Maya_Lab2Context _context;

        public IndexModel(Ciordas_Maya_Lab2.Data.Ciordas_Maya_Lab2Context context)
        {
            _context = context;
        }

        public BookData BookD { get; set; }
        public int BookID { get; set; }
        public int CategoryID { get; set; }
        public string CurrentFilter { get; set; }
        public string TitleSort { get; set; }
        public string AuthorSort { get; set; }

        public class BookData
        {
            public IEnumerable<Book> Books { get; set; }
            public IEnumerable<Category> Categories { get; set; }
            public IEnumerable<BookCategory> BookCategories { get; set; }
        }

        public async Task OnGetAsync(int? id, int? categoryID, string searchString)
        {
            BookD = new BookData();
            CurrentFilter = searchString;

            BookD.Books = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .AsNoTracking()
                .OrderBy(b => b.Title)
                .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                BookD.Books = BookD.Books.Where(s =>
                    (s.Title != null && s.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase)) ||
                    (s.Author?.FirstName != null && s.Author.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase)) ||
                    (s.Author?.LastName != null && s.Author.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                );
            }

            if (id != null)
            {
                BookID = id.Value;
                Book book = BookD.Books
                    .Where(i => i.ID == id.Value).Single();

                BookD.Categories = book.BookCategories.Select(s => s.Category);
            }
        }
    }
}