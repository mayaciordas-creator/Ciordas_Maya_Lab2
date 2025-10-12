using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lese_Ioana_Lab2.Data;
using Lese_Ioana_Lab2.Models;

namespace Lese_Ioana_Lab2.Pages.Authors
{
    public class DeleteModel : PageModel
    {
        private readonly Lese_Ioana_Lab2.Data.Lese_Ioana_Lab2Context _context;

        public DeleteModel(Lese_Ioana_Lab2.Data.Lese_Ioana_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Author Author { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors.FirstOrDefaultAsync(m => m.ID == id);

            if (author is not null)
            {
                Author = author;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                Author = author;
                _context.Authors.Remove(Author);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
