using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Costea_Miriam_Lab2.Data;
using Costea_Miriam_Lab2.Models;

namespace Costea_Miriam_Lab2.Pages.Authors
{
    public class CreateModel : PageModel
    {
        private readonly Costea_Miriam_Lab2.Data.Costea_Miriam_Lab2Context _context;

        public CreateModel(Costea_Miriam_Lab2.Data.Costea_Miriam_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Author Author { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
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
