using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ciordas_Maya_Lab2.Data;
using Ciordas_Maya_Lab2.Models;

namespace Ciordas_Maya_Pages.Authors
{
    public class CreateModel : PageModel
    {
        private readonly Ciordas_Maya_Lab2.Data.Ciordas_Maya_Lab2Context _context;

        public CreateModel(Ciordas_Maya_Lab2.Data.Ciordas_Maya_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Authors Author { get; set; } = default!;

        public CreateModel(Authors author)
        {
            Author = author;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Author.Add(Author);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
