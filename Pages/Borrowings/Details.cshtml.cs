using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Costea_Miriam_Lab2.Data;
using Costea_Miriam_Lab2.Models;

namespace Costea_Miriam_Lab2.Pages.Borrowings
{
    public class DetailsModel : PageModel
    {
        private readonly Costea_Miriam_Lab2.Data.Costea_Miriam_Lab2Context _context;

        public DetailsModel(Costea_Miriam_Lab2.Data.Costea_Miriam_Lab2Context context)
        {
            _context = context;
        }

        public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowing
                .Include(b => b.Member)
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (borrowing == null)
            {
                return NotFound();
            }
            else
            {
                Borrowing = borrowing;
            }
            return Page();
        }
    }
}
